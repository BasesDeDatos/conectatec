using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Cassandra.Mapping.Attributes;

namespace ConectaTEC.Models
{
    [Table("friends")]
    public class FriendsModel
    {
        public string username { get; set; }
        public string friend { get; set; }
        public string since { get; set; }
    }
}