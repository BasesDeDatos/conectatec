CREATE TABLE users (
    username text,
    name text,
    description text,
    password text,
    email text,
    PRIMARY KEY ((username), name)
) WITH CLUSTERING ORDER BY (name DESC);

CREATE TABLE tweets (
    tweet_id uuid,
    username text,
    body text,
    time timestamp,
    PRIMARY KEY ((tweet_id), time)
) WITH CLUSTERING ORDER BY (time DESC);

CREATE TABLE friends (
    username text,
    friend text,
    since timestamp,
    PRIMARY KEY (username, friend)
);

CREATE TABLE followers (
    username text,
    follower text,
    since timestamp,
    PRIMARY KEY (username, follower)
);

CREATE TABLE userline (
    username text,
    time timeuuid,
    tweet_id uuid,
    PRIMARY KEY (username, time)
) WITH CLUSTERING ORDER BY (time DESC);

CREATE TABLE timeline (
    username text,
    time timeuuid,
    tweet_id uuid,
    PRIMARY KEY (username, time)
) WITH CLUSTERING ORDER BY (time DESC);
