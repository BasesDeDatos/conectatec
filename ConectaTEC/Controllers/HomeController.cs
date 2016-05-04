using Cassandra;
using ConectaTEC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
            var usernameSession = Session["active_user"] ?? String.Empty;
            if (!String.IsNullOrEmpty(usernameSession.ToString()))
            {
                List<Row> feed = session.Execute("select * from tweets").ToList();
                var tweets = new List<TweetsModel>();
                foreach (Row tweet in feed)
                {
                    TweetsModel tweetData = new TweetsModel();

                    tweetData.username = tweet["username"].ToString();
                    tweetData.body = tweet["body"].ToString();
                    tweetData.tweet_id = tweet["tweet_id"].ToString();
                    tweetData.time = tweet["time"].ToString();

                    tweets.Add(tweetData);
                }

                tweets.Reverse();

                ViewData["tweetList"] = tweets;
                return View();
            }
            else
            {
                return RedirectToAction("../Account/Login");
            }
        }

        public ActionResult MiPerfil()
        {
            var usernameSession = Session["active_user"] ?? String.Empty;
            if (!String.IsNullOrEmpty(usernameSession.ToString()))
            {
                string username = usernameSession.ToString();
                try
                {
                    //Home/Perfil?username='username'
                    Row user = session.Execute("select * from users where username = '" + username + "'").First();

                    List<Row> feed = new List<Row>();
                    var tweets = new List<TweetsModel>();

                    try
                    {
                        feed = session.Execute("select * from tweets where username = '" + username + "' allow filtering").ToList();
                    }
                    catch { }

                    foreach (Row tweet in feed)
                    {
                        TweetsModel tweetData = new TweetsModel();

                        tweetData.username = tweet["username"].ToString();
                        tweetData.body = tweet["body"].ToString();
                        tweetData.tweet_id = tweet["tweet_id"].ToString();
                        tweetData.time = tweet["time"].ToString();

                        tweets.Add(tweetData);
                    }

                    tweets.Reverse();

                    ViewData["username"] = user["username"].ToString();
                    ViewData["email"] = user["email"].ToString();
                    ViewData["name"] = user["name"].ToString();
                    ViewData["description"] = user["description"].ToString();
                    ViewData["feed"] = tweets;
                    return View("Perfil");
                }
                catch
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("../Account/Login");
            }
        }

        public ActionResult Perfil(string username)
        {
            var usernameSession = Session["active_user"] ?? String.Empty;
            if (!String.IsNullOrEmpty(usernameSession.ToString()))
            {
                try
                {
                    //Home/Perfil?username='username'
                    Row user = session.Execute("select * from users where username = '" + username + "'").First();

                    List<Row> feed = new List<Row>();
                    var tweets = new List<TweetsModel>();

                    try
                    {
                        feed = session.Execute("select * from tweets where username = '" + username + "' allow filtering").ToList();
                    }
                    catch { }

                    foreach (Row tweet in feed)
                    {
                        TweetsModel tweetData = new TweetsModel();

                        tweetData.username = tweet["username"].ToString();
                        tweetData.body = tweet["body"].ToString();
                        tweetData.tweet_id = tweet["tweet_id"].ToString();
                        tweetData.time = tweet["time"].ToString();

                        tweets.Add(tweetData);
                    }

                    tweets.Reverse();

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
            else
            {
                return RedirectToAction("../Account/Login");
            }
        }


        public ActionResult UserList()
        {
            var username = Session["active_user"] ?? String.Empty;
            if (!String.IsNullOrEmpty(username.ToString()))
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
            else
            {
                return RedirectToAction("../Account/Login");
            }
            
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Publicar(TweetsModel model, string returnUrl)
        {
            try
            {
                session.Execute("insert into tweets (tweet_id, time, body, username) values (uuid(), toTimestamp(now()), '" + model.body + "', '" + Session["active_user"] + "' )");
            }
            catch { }
            return RedirectToAction("Index");
        }
    }
}