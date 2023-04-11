create table if not exists users
(
    id int not null primary key,
    login varchar(64) not null,
    password varchar(64) not null,
    permissions varchar(64) not null
);

create table if not exists countries
(
    id int not null primary key,
    name varchar(64) not null,
    confederation varchar(64) not null
);

create table if not exists teams
(
    id int not null primary key,
    name varchar(64) not null,
    country_id int,
    foreign key (country_id) references countries(id) on delete set null 
);

create table if not exists tournaments
(
    id int not null primary key,
    name varchar(64) not null,
    country_id int,
    foreign key (country_id) references countries(id) on delete set null,
    user_id int not null,
    foreign key (user_id) references users(id) on delete cascade
);

create table if not exists matches
(
    id int not null primary key,
    tournament_id int not null,
    foreign key (tournament_id) references tournaments(id) on delete cascade,
    home_team_id int not null,
    foreign key (home_team_id) references teams(id) on delete cascade,
    guest_team_id int not null,
    foreign key (guest_team_id) references teams(id) on delete cascade,
    home_goals int not null,
    guest_goals int not null
);

create table if not exists team_tournaments
(
    team_id int not null,
    foreign key (team_id) references teams(id) on delete cascade,
    tournament_id int not null,
    foreign key (tournament_id) references tournaments(id) on delete cascade,
    primary key(team_id, tournament_id)
);

create or replace function get_table(id_ integer)
returns table(name varchar(64), matches integer, wins integer, draws integer, loses integer, gs integer, gc integer, points integer)
as $$
begin
	drop table if exists tour_clubs;
	create temp table if not exists tour_clubs(id integer, name varchar(64));
	insert into tour_clubs(id, name)
	select c.id, c.name
	from teams c join team_tournaments tt on c.id = tt.team_id
		join tournaments t on tt.tournament_id = t.id
	where t.id = id_;


	drop table if exists home_results;
	create temp table if not exists home_results(id integer, matches integer, wins integer, draws integer, loses integer, gs integer, gc integer);
	insert into home_results(id, matches, wins, draws, loses, gs, gc)
	select c.id, count(*), sum(case when m.home_goals > m.guest_goals then 1 else 0 end),
		sum(case when m.home_goals = m.guest_goals then 1 else 0 end),
		sum(case when m.home_goals < m.guest_goals then 1 else 0 end),
		sum(m.home_goals), sum(m.guest_goals)

	from tour_clubs c join matches m on c.id = m.home_team_id
	where m.tournament_id = id_
	group by c.id;

	drop table if exists guest_results;
	create temp table if not exists guest_results(id integer, matches integer, wins integer, draws integer, loses integer, gs integer, gc integer);
	insert into guest_results(id, matches, wins, draws, loses, gs, gc)
	select c.id, count(*), 
		sum(case when m.home_goals < m.guest_goals then 1 else 0 end),
		sum(case when m.home_goals = m.guest_goals then 1 else 0 end),
		sum(case when m.home_goals > m.guest_goals then 1 else 0 end),
		sum(m.guest_goals), sum(m.home_goals)

	from tour_clubs c join matches m on c.id = m.guest_team_id
	where m.tournament_id = id_
	group by c.id;

	drop table if exists results;
	create temp table if not exists results(name varchar(64), matches integer, wins integer, draws integer, loses integer, gs integer, gc integer, diff integer, points integer);
	insert into results(name, matches, wins, draws, loses, gs, gc, diff, points)
	select c.name, h.matches + g.matches, h.wins + g.wins, h.draws + g.draws, h.loses + g.loses,
		h.gs + g.gs, h.gc + g.gc, 
		h.gs + g.gs - h.gc - g.gc,
		(h.wins + g.wins) * 3 + h.draws + g.draws
	from tour_clubs c join home_results h on c.id = h.id
		join guest_results g on c.id = g.id;
	return query
	select r.name, r.matches, r.wins, r.draws, r.loses, r.gs, r.gc, r.points
	from results r
	order by r.points desc, r.diff desc, r.wins desc;

end
$$ language PLPGSQL;