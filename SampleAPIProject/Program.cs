using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace SampleAPIProject
{
    class Program
    {
        static void Main(string[] args)
        {
            SetHeaders();

            //CompetitionList competitionList = GetCompetitionList().Result;
            //List<Competition> competitions = competitionList.Competitions;
            //competitions.ForEach(c => Console.WriteLine(c.Name));

            //AreaList areaList = GetAreaList().Result;
            //List<Area> areas = areaList.Areas;
            //areas.ForEach(a => Console.WriteLine(a.Name));

            //TeamsList teamsList = GetTeamsList().Result;
            //List<Team> teams = teamsList.Teams;
            //teams.ForEach(t => Console.WriteLine($"{t.Name}, {t.Id}"));

            //Team team = GetTeam(563).Result;
            //List<Player> players = team.Squad;
            //Console.WriteLine(team.Name);
            //players.ForEach(p => Console.WriteLine($"{p.Name}, {p.Position}"));

            //MatchList matchList = GetMatchList().Result;
            //List<Match> matches = matchList.Matches;
            //matches.ForEach(m => Console.WriteLine($"{m.HomeTeam.Name} vs {m.AwayTeam.Name}"));

            StandingsList standingsList = GetStandingsListForLeague(2021).Result;
            List<Table> tables = standingsList.Standings;
            Table total = tables.Find(t => t.Type.Equals(Type.TOTAL));
            List<Standing> standings = total.table;
            standings.ForEach(s => Console.WriteLine($"{s.Position}, {s.Team.Name}"));
            
        }

        #region GitHubAPI
        //private static readonly HttpClient client = new HttpClient();
        //private static async Task<List<Fixtures>> ProcessCompetitions()
        //{
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3.raw"));
        //    client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

        //    var stringTask = client.GetStringAsync("https://api.github.com/repos/footballcsv/england/contents/2010s/2019-20/eng.1.csv");

        //    var msg = await stringTask;

        //    //Split original CSV string into a string array
        //    string[] msgSplit = msg.Split('\n');
        //    List<Fixtures> fixtures = new List<Fixtures>();
        //    Fixtures fixture = new Fixtures();

        //    //changing the strings into fixture objects
        //    for (int i = 1; i < msgSplit.Length - 1; i++)
        //    {
        //        string[] itemArray = msgSplit[i].Split(',');
        //        fixture.Round = itemArray[0];
        //        fixture.Date = itemArray[1];
        //        fixture.Team1 = itemArray[2];
        //        fixture.FT = itemArray[3];
        //        fixture.HT = itemArray[4];
        //        fixture.Team2 = itemArray[5];

        //        fixtures.Add(fixture);
        //    }

        //    return fixtures;
        //}
        #endregion

        static HttpClient client = new HttpClient();
        static void SetHeaders()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("X-Auth-Token", Environment.GetEnvironmentVariable("FootballApi"));
        }
        static async Task<CompetitionList> GetCompetitionList()
        {
            var msg = await client.GetStringAsync("http://api.football-data.org/v2/competitions");
            CompetitionList competitionList = JsonConvert.DeserializeObject<CompetitionList>(msg);
            return competitionList;
        }

        static async Task<AreaList> GetAreaList()
        {
            var msg = await client.GetStringAsync("https://api.football-data.org/v2/areas");
            AreaList areaList = JsonConvert.DeserializeObject<AreaList>(msg);
            return areaList;
        }
        static async Task<TeamsList> GetTeamsList()
        {
            var msg = await client.GetStringAsync("https://api.football-data.org/v2/teams");
            TeamsList teamsList = JsonConvert.DeserializeObject<TeamsList>(msg);
            return teamsList;
        }
        static async Task<TeamsList> GetTeamsListInLeague(int id)
        {
            var msg = await client.GetStringAsync($"https://api.football-data.org/v2/competitions/{id}/teams");
            TeamsList teamsList = JsonConvert.DeserializeObject<TeamsList>(msg);
            return teamsList;
        }
        static async Task<Team> GetTeam(int id)
        {
            var msg = await client.GetStringAsync($"https://api.football-data.org/v2/teams/{id}");
            Team team = JsonConvert.DeserializeObject<Team>(msg);
            return team;
        }
        static async Task<MatchList> GetMatchList()
        {
            var msg = await client.GetStringAsync("https://api.football-data.org/v2/matches");
            MatchList matchList = JsonConvert.DeserializeObject<MatchList>(msg);
            return matchList;
        }
        static async Task<MatchList> GetMatchesForTeam(int id)
        {
            var msg = await client.GetStringAsync($"http://api.football-data.org/v2/teams/{id}/matches");
            MatchList matchList = JsonConvert.DeserializeObject<MatchList>(msg);
            return matchList;
        }
        static async Task<MatchList> GetMatchesForCompetition(int id)
        {
            var msg = await client.GetStringAsync($"http://api.football-data.org/v2/competitions/{id}/matches");
            MatchList matchList = JsonConvert.DeserializeObject<MatchList>(msg);
            return matchList;
        }
        static async Task<StandingsList> GetStandingsListForLeague(int id)
        {
            var msg = await client.GetStringAsync($"https://api.football-data.org/v2/competitions/{id}/standings");
            StandingsList standingsList = JsonConvert.DeserializeObject<StandingsList>(msg);
            return standingsList;
        }
        static async Task<Player> GetPlayerInfo(int id)
        {
            var msg = await client.GetStringAsync($"https://api.fooball-data.org/v2/players/{id}");
            Player player = JsonConvert.DeserializeObject<Player>(msg);
            return player;
        }
        static async Task<MatchList> GetPlayerMatchList(int id)
        {
            var msg = await client.GetStringAsync($"https://api.football-data.org/v2/players/{id}/matches");
            MatchList matchList = JsonConvert.DeserializeObject<MatchList>(msg);
            return matchList;
        }
    }

    #region GitHubAPIClass
    //class Fixtures
    //{
    //    public string Round { get; set; }
    //    public string Date { get; set; }
    //    public string Team1 { get; set; }
    //    public string FT { get; set; }
    //    public string HT { get; set; }
    //    public string Team2 { get; set; }
    //}
    #endregion
}
