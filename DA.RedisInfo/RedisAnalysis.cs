using System;
using System.Collections.Generic;
using System.Linq;

namespace DA.RedisInfo
{
    public class RedisAnalysis
    {
        public static List<QPSModel> GetQPS(List<Dictionary<string, string>> redisInfos)
        {
            List<QPSModel> list = new List<QPSModel>();

            List<Dictionary<string, string>> filtedList = redisInfos.Where(dic => dic.ContainsKey("uptime_in_seconds")).OrderBy(dic => int.Parse(dic["uptime_in_seconds"])).ToList();

            if (filtedList.Count() < 2)
            { 
                return new List<QPSModel>();
            }

            for (int i = 0;i < filtedList.Count() - 1;i++)
            {
                var time1 = long.Parse(filtedList[i]["uptime_in_seconds"]);
                var processCount1 = long.Parse(filtedList[i]["total_commands_processed"]);
                var inputbyteKbps1 = long.Parse(filtedList[i]["total_net_input_bytes"]);
                var onputbyteKbps1 = long.Parse(filtedList[i]["total_net_output_bytes"]);

                var time2 = long.Parse(filtedList[i + 1]["uptime_in_seconds"]);
                var processCount2 = long.Parse(filtedList[i + 1]["total_commands_processed"]);
                var inputbyteKbps2 = long.Parse(filtedList[i+1]["total_net_input_bytes"]);
                var onputbyteKbps2 = long.Parse(filtedList[i+1]["total_net_output_bytes"]);

                if (time2 != time1)
                {
                    var qps = (processCount2 - processCount1) / (time2 - time1);
                    var inputbyteKbps = (inputbyteKbps2 - inputbyteKbps1) / (time2 - time1);
                    var onputbyteKbps = (onputbyteKbps2 - onputbyteKbps1) / (time2 - time1);

                    list.Add(new QPSModel(DateTime.Parse(filtedList[i + 1]["Current_Time"]), qps, inputbyteKbps, 
                        onputbyteKbps, 
                        double.Parse(filtedList[i]["instantaneous_input_kbps"]),
                        double.Parse(filtedList[i]["instantaneous_output_kbps"])));
                }

                
            }
            
            return list;
        }
    }

    public class QPSModel
    {
        public QPSModel(DateTime endTime, long qPS, long inputBps, long onputBps, 
            double instantaneousInputKbps, double instantaneousOnputKbps)
        {
            EndTime = endTime;
            QPS = qPS;
            InputBps = inputBps;
            OnputBps = onputBps;
            InstantaneousInputKbps = instantaneousInputKbps;
            InstantaneousOnputKbps = instantaneousOnputKbps;
        }

        public DateTime EndTime { get; set; }

        public long QPS { get; set; }

        public long InputBps { get; set; }
        
        public long OnputBps { get; set; }


        public double InstantaneousInputKbps { get; set; }

        public double InstantaneousOnputKbps { get; set; }
    }
}
