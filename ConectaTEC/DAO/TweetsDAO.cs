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
    public interface ITweetsDAO
    {
        Task<IEnumerable<TweetsModel>> getTweets();
    }

    public class TweetsDAO : ITweetsDAO
    {
        protected readonly ISession session;
        protected readonly IMapper mapper;

        public TweetsDAO()
        {
            ICassandraDAO cassandraDAO = new CassandraDAO();
            session = cassandraDAO.GetSession();
            mapper = new Mapper(session);
        }

        public async Task<IEnumerable<TweetsModel>> getTweets()
        {
            return await mapper.FetchAsync<TweetsModel>();
        }
    }
}