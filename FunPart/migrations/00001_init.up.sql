CREATE TABLE IF NOT EXISTS Users
(
    Nickname TEXT PRIMARY KEY,
    Password TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS TasksCategories
(
    Nickname TEXT PRIMARY KEY
);

CREATE TABLE IF NOT EXISTS Tasks
(
    Id              SERIAL                 PRIMARY KEY,
    Descriprions    TEXT                   NOT NULL,
    TaskCategory    TEXT                   NOT NULL,

    FOREIGN KEY (TaskCategory) REFERENCES TasksCategories (Nickname) ON DELETE CASCADE
                                                                     ON UPDATE CASCADE
);