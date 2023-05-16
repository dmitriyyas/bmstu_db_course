-- роль Администратора

CREATE ROLE admin WITH
    SUPERUSER
    NOCREATEDB
    CREATEROLE
    NOINHERIT
    NOREPLICATION
    NOBYPASSRLS
    CONNECTION LIMIT -1
    LOGIN
    PASSWORD 'admin';

-- права доступа

GRANT ALL PRIVILEGES 
    ON ALL TABLES IN SCHEMA public 
    TO admin;

-- роль Авторизированного пользователя

CREATE ROLE _user WITH
    NOSUPERUSER
    NOCREATEDB
    NOCREATEROLE
    NOINHERIT
    NOREPLICATION
    NOBYPASSRLS
    CONNECTION LIMIT -1
    LOGIN
    PASSWORD 'user';

-- права доступа

GRANT SELECT
    ON ALL TABLES IN SCHEMA public 
    TO _user;

GRANT INSERT
    ON public."teams", 
       public."tournaments", 
       public."team_tournaments",
       public."matches"
    TO _user;

GRANT DELETE
    ON public."tournaments", 
       public."team_tournaments",
       public."matches"
    TO _user;

GRANT UPDATE
    ON public."matches"
    TO _user;

-- роль Гостя

CREATE ROLE guest WITH
    NOSUPERUSER
    NOCREATEDB
    NOCREATEROLE
    NOINHERIT
    NOREPLICATION
    NOBYPASSRLS
    CONNECTION LIMIT -1
    LOGIN
    PASSWORD 'guest';

-- права доступа

GRANT SELECT
    ON ALL TABLES IN SCHEMA public 
    TO guest;

GRANT INSERT
    ON public."users"
    TO guest;

-- Удалить права доступа

-- REVOKE SELECT 
--     ON public."Club" 
--     TO user;

-- Удалить роль

-- DROP ROLE guest;