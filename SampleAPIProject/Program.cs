using CsvHelper;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Collections.Generic;

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
        private static async Task GetCompetitions()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("X-Auth-Token", Environment.GetEnvironmentVariable("FootballApi"));

            var stringTask = client.GetStringAsync("http://api.football-data.org/v2/competitions");
            var msg = await stringTask;

            Console.WriteLine(msg);
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
}
