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
        private static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            ProcessCompetitions().Wait();
        }
        private static async Task ProcessCompetitions()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3.raw"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var stringTask = client.GetStringAsync("https://api.github.com/repos/footballcsv/england/contents/2010s/2019-20/eng.1.csv");

            var msg = await stringTask;
            Console.Write(msg);

            //TextReader reader = new StreamReader(msg);
            //var csvReader = new CsvReader(reader);
            //var fixtures = csvReader.GetRecords<Fixtures>();
            //foreach (var fixture in fixtures)
            //{
            //    Console.WriteLine(fixture);
            //}
        }
    }

    class Fixtures
    {
        public Fixtures()
        {

        }

        public string Round { get; set; }
        public string Date { get; set; }
        public string Team1 { get; set; }
        public string FT { get; set; }
        public string HT { get; set; }
        public string Team2 { get; set; }
    }
}
