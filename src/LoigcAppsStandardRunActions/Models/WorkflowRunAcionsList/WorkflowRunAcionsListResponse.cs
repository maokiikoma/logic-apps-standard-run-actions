using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoigcAppsStandardRunActions.Models.WorkflowRunAcionsList
{
    public class WorkflowRunAcionsListResponse
    {
        public Value[] value { get; set; }
    }

    public class Value
    {
        public Properties properties { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }

    public class Properties
    {
        public Inputslink inputsLink { get; set; }
        public Outputslink outputsLink { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public Correlation correlation { get; set; }
        public string status { get; set; }
        public string code { get; set; }
    }

    public class Inputslink
    {
        public string uri { get; set; }
        public int contentSize { get; set; }
    }

    public class Outputslink
    {
        public string uri { get; set; }
        public int contentSize { get; set; }
    }

    public class Correlation
    {
        public string actionTrackingId { get; set; }
        public string clientTrackingId { get; set; }
    }

}
