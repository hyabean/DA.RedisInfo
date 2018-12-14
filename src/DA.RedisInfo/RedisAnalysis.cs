namespace DA.RedisInfo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="RedisAnalysis" />
    /// </summary>
    public static class RedisAnalysis
    {
        /// <summary>
        /// The GetQPS
        /// </summary>
        /// <param name="redisInfos">The redisInfos<see cref="IEnumerable{IDictionary{string, string}}"/></param>
        /// <returns>The <see cref="List{QpsModel}"/></returns>
        public static List<QpsModel> GetQPS(IEnumerable<IDictionary<string, string>> redisInfos)
        {
            var list = new List<QpsModel>();

            var filtedList = redisInfos.Where(dic => dic.ContainsKey("uptime_in_seconds")).OrderBy(dic => int.Parse(dic["uptime_in_seconds"])).ToList();

            if (filtedList.Count < 2)
            {
                return new List<QpsModel>();
            }

            for (var i = 0; i < filtedList.Count - 1; i++)
            {
                var time1 = long.Parse(filtedList[i]["uptime_in_seconds"]);
                var processCount1 = long.Parse(filtedList[i]["total_commands_processed"]);
                var inputbyteKbps1 = long.Parse(filtedList[i]["total_net_input_bytes"]);
                var onputbyteKbps1 = long.Parse(filtedList[i]["total_net_output_bytes"]);

                var time2 = long.Parse(filtedList[i + 1]["uptime_in_seconds"]);
                var processCount2 = long.Parse(filtedList[i + 1]["total_commands_processed"]);
                var inputbyteKbps2 = long.Parse(filtedList[i + 1]["total_net_input_bytes"]);
                var onputbyteKbps2 = long.Parse(filtedList[i + 1]["total_net_output_bytes"]);

                if (time2 != time1)
                {
                    var qps = (processCount2 - processCount1) / (time2 - time1);
                    var inputbyteKbps = (inputbyteKbps2 - inputbyteKbps1) / (time2 - time1);
                    var onputbyteKbps = (onputbyteKbps2 - onputbyteKbps1) / (time2 - time1);

                    list.Add(new QpsModel(DateTime.Parse(filtedList[i + 1]["Current_Time"]), qps, inputbyteKbps,
                        onputbyteKbps,
                        double.Parse(filtedList[i]["instantaneous_input_kbps"]),
                        double.Parse(filtedList[i]["instantaneous_output_kbps"])));
                }
            }

            return list;
        }
    }

    /// <summary>
    /// Defines the <see cref="QpsModel" />
    /// </summary>
    public class QpsModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QpsModel"/> class.
        /// </summary>
        /// <param name="endTime">The endTime<see cref="DateTime"/></param>
        /// <param name="qPS">The qPS<see cref="long"/></param>
        /// <param name="inputBps">The inputBps<see cref="long"/></param>
        /// <param name="onputBps">The onputBps<see cref="long"/></param>
        /// <param name="instantaneousInputKbps">The instantaneousInputKbps<see cref="double"/></param>
        /// <param name="instantaneousOnputKbps">The instantaneousOnputKbps<see cref="double"/></param>
        public QpsModel(DateTime endTime, long qPS, long inputBps, long onputBps,
            double instantaneousInputKbps, double instantaneousOnputKbps)
        {
            EndTime = endTime;
            QPS = qPS;
            InputBps = inputBps;
            OnputBps = onputBps;
            InstantaneousInputKbps = instantaneousInputKbps;
            InstantaneousOnputKbps = instantaneousOnputKbps;
        }

        /// <summary>
        /// Gets or sets the EndTime
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Gets or sets the QPS
        /// </summary>
        public long QPS { get; set; }

        /// <summary>
        /// Gets or sets the InputBps
        /// </summary>
        public long InputBps { get; set; }

        /// <summary>
        /// Gets or sets the OnputBps
        /// </summary>
        public long OnputBps { get; set; }

        /// <summary>
        /// Gets or sets the InstantaneousInputKbps
        /// </summary>
        public double InstantaneousInputKbps { get; set; }

        /// <summary>
        /// Gets or sets the InstantaneousOnputKbps
        /// </summary>
        public double InstantaneousOnputKbps { get; set; }
    }
}
