CREATE KEYSPACE test01 WITH replication = {
  'class': 'SimpleStrategy',
  'replication_factor': '1'
};

USE test01;
