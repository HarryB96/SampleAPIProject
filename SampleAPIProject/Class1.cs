using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAPIProject
{
    public enum Status
    {
        SCHEDULED,
        LIVE,
        IN_PLAY,
        PAUSED,
        FINISHED,
        POSTPONED,
        SUSPENDED,
        CANCELED
    }
    public enum Venue
    {
        HOME,
        AWAY
    }
    //public enum Stage
    //{
    //    FIRST_QUALIFYING_ROUND,
    //    SECOND_QUALIFYING_ROUND,
    //    THIRD_QUALIFYING_ROUND,
    //    PLAY_OFF_ROUND,
    //    GROUP_STAGE,
    //    ROUND_OF_16,
    //    QUARTER_FINALS,
    //    SEMI_FINALS,
    //    FINAL
    //}
    class CompetitionList
    {
        public int Count { get; set; }
        public Filters Filters { get; set; }
        public List<Competition> Competitions { get; set; }
    }
    class AreaList
    {
        public int Count { get; set; }
        public Filters Filters { get; set; }
        public List<Area> Areas { get; set; }
    }
    class TeamsList
    {
        public int Count { get; set; }
        public Filters Filters { get; set; }
        public List<Team> Teams { get; set; }
    }
    class MatchList
    {
        public int Count { get; set; }
        public Filters Filters { get; set; }
        public List<Match> Matches { get; set; }
    }
    class Filters
    {
        public int? Id { get; set; }
        public int? Matchday { get; set; }
        public string Season { get; set; }
        public Status? Status { get; set; }
        public Venue? Venue { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string Stage { get; set; }
        public string Plan { get; set; }
        public string Competitions { get; set; }
        public string Group { get; set; }
        public int? Limit { get; set; }
        public string StandingType { get; set; }
    }
    class Competition
    {
        public int Id { get; set; }
        public Area Area { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string EmblemURL { get; set; }
        public string Plan { get; set; }
        public CurrentSeason CurrentSeason { get; set; }
        public int NumberOfAvailableSeasons { get; set; }
        public string LastUpdated { get; set; }

    }
    class CurrentSeason
    {
        public int Id { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int? CurrentMatchday { get; set; }
        public Winner Winner { get; set; }
    }
    class Winner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Tla { get; set; }
        public string CrestURL { get; set; }
    }
    class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string EnsignURL { get; set; }
        public int? ParentAreaId { get; set; }
        public string ParentArea { get; set; }
    }
    class Team
    {
        public int Id { get; set; }
        public Area Area { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Tla { get; set; }
        public string CrestURL { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public int? Founded { get; set; }
        public string ClubColors { get; set; }
        public string Venue { get; set; }
        public string LastUpdated { get; set; }
    }
    class Score
    {
        public int? HomeTeam { get; set; }
        public int? AwayTeam { get; set; }
    }
    class Result
    {
        public string Winner { get; set; }
        public string Duration { get; set; }
        public Score FullTime { get; set; }
        public Score HalfTime { get; set; }
        public Score ExtraTime { get; set; }
        public Score Penalties { get; set; }
    }
    class Referee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
    }
    class Match
    {
        public int Id { get; set; }
        public Competition Competition { get; set; }
        public CurrentSeason Season { get; set; }
        public string UtcDate { get; set; }
        public Status Status { get; set; }
        public int? MatchDay { get; set; }
        public string Stage { get; set; }
        public string Group { get; set; }
        public string LastUpdated { get; set; }
        public Result Result { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public List<Referee> Referees { get; set; }

    }
}
