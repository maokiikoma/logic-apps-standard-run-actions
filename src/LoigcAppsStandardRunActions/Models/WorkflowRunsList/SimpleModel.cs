namespace LoigcAppsStandardRunActions.Models.WorkflowRunsList
{
    public class SimpleModel
    {
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ExecutionTime 
        { 
            get
            {
                var interval = StartTime - EndTime;
                return interval.ToString("hh:mm:ss:fff");
            }
        }

        public SimpleModel(string name, DateTime startTime, DateTime endTime)
        {
            Name = name;
            StartTime = startTime;
            EndTime = endTime;
        }

        public void Print()
        {
            throw new NotImplementedException();
        }
    }
}
