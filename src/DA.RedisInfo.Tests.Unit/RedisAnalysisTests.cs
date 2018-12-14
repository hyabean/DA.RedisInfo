using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RedisInside;
using ServiceStack.Redis;
using Shouldly;

namespace DA.RedisInfo.Tests.Unit
{
    public class RedisAnalysisTests
    {
        [Test]
        public void StartARedisServer_Normal_Normal()
        {
            using (var redis = new Redis())
            {
                // connect to redis.Endpoint here
                var ip = ((IPEndPoint)redis.Endpoint).Address.ToString();
                var port = ((IPEndPoint)redis.Endpoint).Port;

                ip.ShouldNotBe(string.Empty);
                port.ShouldNotBe(0);

                var redisClient = new RedisClient(ip, port);

                redisClient.Info.ShouldNotBe(null);

                redisClient.Info["total_commands_processed"] = "0";
            }
        }

        [Test]
        public void GetQPS_Normal_Get()
        {
            var redisInfos = new List<Dictionary<string, string>>();

            var info1 = new Dictionary<string, string>();
            info1.Add("uptime_in_seconds", "1");
            info1.Add("total_commands_processed", "100");
            info1.Add("total_net_input_bytes", "100");
            info1.Add("total_net_output_bytes", "100");
            info1.Add("instantaneous_input_kbps", "100");
            info1.Add("instantaneous_output_kbps", "100");
            info1.Add("Current_Time", new DateTime(2018, 11, 20, 13, 0, 0).ToString());
            redisInfos.Add(info1);


            var info2 = new Dictionary<string, string>();
            info2.Add("uptime_in_seconds", "61");
            info2.Add("total_commands_processed", "341");
            info2.Add("total_net_input_bytes", "100");
            info2.Add("total_net_output_bytes", "100");
            info2.Add("instantaneous_input_kbps", "100");
            info2.Add("instantaneous_output_kbps", "100");
            info2.Add("Current_Time", new DateTime(2018, 11, 20, 13, 1, 0).ToString());
            redisInfos.Add(info2);
            
            var info3 = new Dictionary<string, string>();
            info3.Add("uptime_in_seconds", "121");
            info3.Add("total_commands_processed", "641");
            info3.Add("total_net_input_bytes", "100");
            info3.Add("total_net_output_bytes", "100");
            info3.Add("instantaneous_input_kbps", "100");
            info3.Add("instantaneous_output_kbps", "100");
            info3.Add("Current_Time", new DateTime(2018, 11, 20, 13, 2, 0).ToString());
            redisInfos.Add(info3);

            var qps = RedisAnalysis.GetQPS(redisInfos);

            qps.Count.ShouldBe(2);
            qps[0].EndTime.ShouldBe(new DateTime(2018, 11, 20, 13, 1, 0));
            qps[0].QPS.ShouldBe(4);
            
            qps[1].EndTime.ShouldBe(new DateTime(2018, 11, 20, 13, 2, 0));
            qps[1].QPS.ShouldBe(5);
        }
    }
}
