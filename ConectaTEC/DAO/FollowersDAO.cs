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
    public interface IFollowersDAO
    {
        Task<IEnumerable<FollowersModel>> getFollowers();
    }

    public class FollowersDAO : IFollowersDAO
    {
        protected readonly ISession session;
        protected readonly IMapper mapper;

        public FollowersDAO()
        {
            ICassandraDAO cassandraDAO = new CassandraDAO();
            session = cassandraDAO.GetSession();
            mapper = new Mapper(session);
        }

        public async Task<IEnumerable<FollowersModel>> getFollowers()
        {
            return await mapper.FetchAsync<FollowersModel>();
        }
    }
}