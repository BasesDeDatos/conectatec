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
    public interface ITimelineDAO
    {
        Task<IEnumerable<TimelineModel>> getTimeline();
    }

    public class TimelineDAO : ITimelineDAO
    {
        protected readonly ISession session;
        protected readonly IMapper mapper;

        public TimelineDAO()
        {
            ICassandraDAO cassandraDAO = new CassandraDAO();
            session = cassandraDAO.GetSession();
            mapper = new Mapper(session);
        }

        public async Task<IEnumerable<TimelineModel>> getTimeline()
        {
            return await mapper.FetchAsync<TimelineModel>();
        }
    }
}