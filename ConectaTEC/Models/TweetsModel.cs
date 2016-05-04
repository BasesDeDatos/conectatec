using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Cassandra.Mapping.Attributes;

namespace ConectaTEC.Models
{
    [Table("tweets")]
    public class TweetsModel
    {
        public string tweet_id { get; set; }
        public string body { get; set; }
        public string username { get; set; }
        public string time { get; set; }
    }
}