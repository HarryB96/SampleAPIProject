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
            //CompetitionList competitionList = GetCompetitionList().Result;
            //List<Competition> competitions = competitionList.Competitions;
            //competitions.ForEach(c => Console.WriteLine(c.Name));

            //AreaList areaList = GetAreaList().Result;
            //List<Area> areas = areaList.Areas;
            //areas.ForEach(a => Console.WriteLine(a.Name));

            //TeamsList teamsList = GetTeamsList().Result;
            //List<Team> teams = teamsList.Teams;
            //teams.ForEach(t => Console.WriteLine(t.Name));

            //MatchList matchList = GetMatchList().Result;
            //List<Match> matches = matchList.Matches;
            //matches.ForEach(m => Console.WriteLine(m.Status));
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
            SetHeaders();

            var stringTask = client.GetStringAsync("http://api.football-data.org/v2/competitions");
            var msg = await stringTask;

            CompetitionList competitionList = JsonConvert.DeserializeObject<CompetitionList>(msg);
            return competitionList;
        }

        static async Task<AreaList> GetAreaList()
        {
            SetHeaders();

            var stringTask = client.GetStringAsync("https://api.football-data.org/v2/areas");
            var msg = await stringTask;
            AreaList areaList = JsonConvert.DeserializeObject<AreaList>(msg);

            return areaList;
        }
        static async Task<TeamsList> GetTeamsList()
        {
            SetHeaders();

            var stringTask = client.GetStringAsync("https://api.football-data.org/v2/teams");
            var msg = await stringTask;
            TeamsList teamsList = JsonConvert.DeserializeObject<TeamsList>(msg);
            return teamsList;
        }
        static async Task<MatchList> GetMatchList()
        {
            SetHeaders();
            var stringTask = client.GetStringAsync("https://api.football-data.org/v2/matches");
            var msg = await stringTask;
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
