﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Cassandra.Mapping.Attributes;

namespace ConectaTEC.Models
{
    [Table("users")]
    public class UsersModel
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}