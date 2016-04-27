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
    public interface IUserlineDAO
    {
        Task<IEnumerable<UserlineModel>> getUserline();
    }

    public class UserlineDAO : IUserlineDAO
    {
        protected readonly ISession session;
        protected readonly IMapper mapper;

        public UserlineDAO()
        {
            ICassandraDAO cassandraDAO = new CassandraDAO();
            session = cassandraDAO.GetSession();
            mapper = new Mapper(session);
        }

        public async Task<IEnumerable<UserlineModel>> getUserline()
        {
            return await mapper.FetchAsync<UserlineModel>();
        }
    }
}