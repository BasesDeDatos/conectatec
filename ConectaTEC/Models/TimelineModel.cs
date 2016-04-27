using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Cassandra.Mapping.Attributes;

namespace ConectaTEC.Models
{
    [Table("timeline")]
    public class TimelineModel
    {
        public string username { get; set; }
        public string time { get; set; }
        public string tweet_id { get; set; }
    }
}