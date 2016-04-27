using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConectaTEC.DAO
{
    public interface ICassandraDAO
    {
        ISession GetSession();
    }

    public class CassandraDAO : ICassandraDAO
    {
        private static Cluster Cluster;
        private static ISession Session;

        public CassandraDAO()
        {
            SetCluster();
        }

        private void SetCluster()
        {
            if (Cluster == null)
            {
                Cluster = Connect();
            }
        }

        public ISession GetSession()
        {
            if (Cluster == null)
            {
                SetCluster();
                Session = Cluster.Connect("test01");
            }
            else if (Session == null)
            {
                Session = Cluster.Connect("test01");
            }

            return Session;
        }

        private Cluster Connect()
        {
            QueryOptions queryOptions = new QueryOptions()
                .SetConsistencyLevel(ConsistencyLevel.One);

            Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();

            return cluster;
        }

        private string getAppSetting(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }
    }
}