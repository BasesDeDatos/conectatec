using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Cassandra.Mapping.Attributes;

namespace ConectaTEC.Models
{
    [Table("followers")]
    public class FollowersModel
    {
        public string username { get; set; }
        public string follower { get; set; }
        public string since { get; set; }
    }
}