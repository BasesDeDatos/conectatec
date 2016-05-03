using Cassandra;
using ConectaTEC.Models;
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
            List<Row> feed = session.Execute("select * from tweets").ToList();
            var tweets = new List<TweetsModel>();
            foreach (Row tweet in feed)
            {
                TweetsModel tweetData = new TweetsModel();

                tweetData.username = tweet["username"].ToString();
                tweetData.body = tweet["body"].ToString();
                tweetData.tweet_id = tweet["tweet_id"].ToString();

                tweets.Add(tweetData);
            }
            ViewData["tweetList"] = tweets;
            return View();
        }
        
        public ActionResult Perfil(string username)
        {
            try
            {
                //Home/Perfil?username='username'
                Row user = session.Execute("select * from users where username = " + username).First();
                /*List<Row> feed = new List<Row>();
                List<string> tweets = new List<string>();

                try
                {
                    feed = session.Execute("select * from tweets where username = " + username + " allow filtering").ToList();
                }
                catch{ }

                foreach (Row tweet in feed)
                {
                    Debug.WriteLine(tweet["body"].ToString());
                    tweets.Add(tweet["body"].ToString());
                }*/

                List<Row> feed = new List<Row>();
                var tweets = new List<TweetsModel>();

                try
                {
                    feed = session.Execute("select * from tweets where username = " + username + " allow filtering").ToList();
                }
                catch { }
                
                foreach (Row tweet in feed)
                {
                    TweetsModel tweetData = new TweetsModel();

                    tweetData.username = tweet["username"].ToString();
                    tweetData.body = tweet["body"].ToString();
                    tweetData.tweet_id = tweet["tweet_id"].ToString();

                    tweets.Add(tweetData);
                }

                ViewData["username"] = user["username"].ToString();
                ViewData["email"] = user["email"].ToString();
                ViewData["name"] = user["name"].ToString();
                ViewData["description"] = user["description"].ToString();
                ViewData["feed"] = tweets;
                return View();
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
        
        public ActionResult UserList()
        {
            List<Row> userList = session.Execute("select * from users").ToList();
            var data = new List<UsersModel>();
            foreach (Row user in userList)
            {
                UsersModel userData = new UsersModel();

                userData.username = user["username"].ToString();
                userData.password = user["password"].ToString();
                userData.description = user["description"].ToString();
                userData.name = user["name"].ToString();
                userData.email = user["email"].ToString();

                data.Add(userData);
            }
            ViewData["userList"] = data;
            return View();
        }
    }
}