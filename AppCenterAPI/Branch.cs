namespace AppCenterAPI
{
    public class Branch
    {
        public string name { get; set; }
        public Commit commit { get; set; }
        public bool @protected { get; set; }
        public Protection protection { get; set; }
        public string protection_url { get; set; }
    }

    public class Commit
    {
        public string sha { get; set; }
        public string url { get; set; }
    }

    public class LastBuild
    {
        public int id { get; set; }
        public string buildNumber { get; set; }
        public DateTime queueTime { get; set; }
        public DateTime startTime { get; set; }
        public DateTime finishTime { get; set; }
        public DateTime lastChangedDate { get; set; }
        public string status { get; set; }
        public string result { get; set; }
        public string reason { get; set; }
        public string sourceBranch { get; set; }
        public string sourceVersion { get; set; }
        public List<string> tags { get; set; }
        public Properties properties { get; set; }
    }

    public class Properties
    {
    }

    public class Protection
    {
        public bool enabled { get; set; }
        public RequiredStatusChecks required_status_checks { get; set; }
    }

    public class RequiredStatusChecks
    {
        public string enforcement_level { get; set; }
        public List<object> contexts { get; set; }
        public List<object> checks { get; set; }
    }

    public class Root
    {
        public Branch branch { get; set; }
        public bool configured { get; set; }
        public LastBuild lastBuild { get; set; }
        public string trigger { get; set; }
    }
}