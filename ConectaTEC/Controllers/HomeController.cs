using Cassandra;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConectaTEC.Controllers
{
    public class HomeController : Controller
    {
        private static Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
        private static ISession session = cluster.Connect("test01");

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Perfil()
        {
            Row user =  session.Execute("select * from users where username = 'jeffreya12'").First();
            ViewData["username"] = user["username"].ToString();
            ViewData["name"] = user["name"].ToString();
            ViewData["description"] = user["description"].ToString();
            return View();
        }
    }
}