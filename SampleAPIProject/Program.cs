using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Data;

namespace SampleAPIProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProcessCompetitions().Wait();
            GetCompetitions().Wait();
        }

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

        static HttpClient client = new HttpClient();
        private static async Task<List<Competition>> GetCompetitions()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("X-Auth-Token", Environment.GetEnvironmentVariable("FootballApi"));

            var stringTask = client.GetStringAsync("http://api.football-data.org/v2/competitions");
            var msg = await stringTask;

            var json = msg.Remove(0, 41);
            var jsonArray = json.Remove(json.Length-1);

            List<Competition> competitions = JsonConvert.DeserializeObject<List<Competition>>(jsonArray);

            return competitions;
        }
    }

    //class Fixtures
    //{
    //    public Fixtures()
    //    {

    //    }

    //    public string Round { get; set; }
    //    public string Date { get; set; }
    //    public string Team1 { get; set; }
    //    public string FT { get; set; }
    //    public string HT { get; set; }
    //    public string Team2 { get; set; }
    //}

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
    class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }
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
}
