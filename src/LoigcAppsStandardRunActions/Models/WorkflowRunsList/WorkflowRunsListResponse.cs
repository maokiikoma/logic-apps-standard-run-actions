using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoigcAppsStandardRunActions.Models.WorkflowRunsList
{
    public class WorkflowRunsListResponse
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
        public DateTime waitEndTime { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string status { get; set; }
        public Correlation correlation { get; set; }
        public Workflow workflow { get; set; }
        public Trigger trigger { get; set; }
        public Outputs outputs { get; set; }
    }

    public class Correlation
    {
        public string clientTrackingId { get; set; }
    }

    public class Workflow
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }

    public class Trigger
    {
        public string name { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public DateTime scheduledTime { get; set; }
        public Correlation1 correlation { get; set; }
        public string code { get; set; }
        public string status { get; set; }
    }

    public class Correlation1
    {
        public string clientTrackingId { get; set; }
    }

    public class Outputs
    {
    }

}
