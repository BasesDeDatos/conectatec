using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using ConectaTEC.Models;
using ConectaTEC.DAO;

namespace ConectaTEC.Controllers
{
    public class UsersController : Controller
    {
        private static IUsersDAO dao;

        public UsersController()
        {
        }

        protected IUsersDAO usersDao
        {
            get
            {
                if (dao == null)
                {
                    dao = new UsersDAO();
                }
                return dao;
            }
        }

        public async Task<ActionResult> UsersList()
        {
            IEnumerable<UsersModel> users = await usersDao.getUsers();
            return View("UsersList", users.ToList());
        }
    }
}