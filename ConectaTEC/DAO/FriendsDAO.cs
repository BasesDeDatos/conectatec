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
    public interface IFriendsDAO
    {
        Task<IEnumerable<FriendsModel>> getFriends();
    }

    public class FriendsDAO : IFriendsDAO
    {
        protected readonly ISession session;
        protected readonly IMapper mapper;

        public FriendsDAO()
        {
            ICassandraDAO cassandraDAO = new CassandraDAO();
            session = cassandraDAO.GetSession();
            mapper = new Mapper(session);
        }

        public async Task<IEnumerable<FriendsModel>> getFriends()
        {
            return await mapper.FetchAsync<FriendsModel>();
        }
    }
}