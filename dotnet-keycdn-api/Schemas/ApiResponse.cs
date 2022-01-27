using System;
using System.Collections.Generic;

namespace Com.KeyCDN.Api.Schemas
{
    public class Data
    {
        public List<Zone> zones { get; set; }
        public List<Zonealias> zonealiases { get; set; }
        public List<Zonereferrer> zonereferrers { get; set; }
        public List<Stat> stats { get; set; }
    }

    public class ApiResponse
    {
        public string status { get; set; }
        public string description { get; set; }
        public Data data { get; set; }
    }
}

