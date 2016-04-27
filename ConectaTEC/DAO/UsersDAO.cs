using ConectaTEC.Models;
using Cassandra;
using Cassandra.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ConectaTEC.DAO
{
    public interface IUsersDAO
    {
        Task<IEnumerable<UsersModel>> getUsers();
        void insertUser(string pUsername, string pPassword);
    }

    public class UsersDAO : IUsersDAO
    {
        protected ISession session;
        protected IMapper mapper;

        public UsersDAO()
        {
            ICassandraDAO cassandraDAO = new CassandraDAO();
            session = cassandraDAO.GetSession();
            mapper = new Mapper(session);
        }

        public async Task<IEnumerable<UsersModel>> getUsers()
        {
            return await mapper.FetchAsync<UsersModel>();
        }

        public void insertUser(string pUsername, string pPassword)
        {
            var newUser = new UsersModel {
                                            username = pUsername,
                                            password = pPassword
                                         };
            mapper.InsertAsync(newUser);
        }
    }
}