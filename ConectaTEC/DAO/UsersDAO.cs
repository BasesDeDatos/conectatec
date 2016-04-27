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
    }

    public class UsersDAO : IUsersDAO
    {
        protected readonly ISession session;
        protected readonly IMapper mapper;

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
    }
}