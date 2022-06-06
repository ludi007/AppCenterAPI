﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCenterAPI
{

    public class Builds
    {
        public int id { get; set; }
        public string buildNumber { get; set; }
        public DateTime queueTime { get; set; }
        public DateTime lastChangedDate { get; set; }
        public string status { get; set; }
        public string reason { get; set; }
        public string sourceBranch { get; set; }
        public string sourceVersion { get; set; }
        public List<object> tags { get; set; }
        public Properties properties { get; set; }
    }
}
