using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;

namespace AoC_Collection
{ 
    public static class DataGatherer
    {
        private string token = JObject.Parse(File.ReadAllText());
        public static List<string> GetDataAsList(int year, int day)
        {
            var rq = (HttpWebRequest)WebRequest.Create($"https://adventofcode.com/{year}/day/{day}/input");
            rq.CookieContainer = new CookieContainer();
            rq.CookieContainer.Add(new Cookie("session", "53616c7465645f5f691a0bcf70314a0e3a44820f96c6ec5e37940716d2f214026f61515d276d20aeac9f3781987cb74b5bae36fa0f1f2e19af25ecf48440b4c6", "/", "adventofcode.com"));
            
            var response = (HttpWebResponse)rq.GetResponse();
            var encoding = Encoding.ASCII;
            var content = new List<string>();
            using var reader = new StreamReader(response.GetResponseStream(), encoding);
            while (true)
            {
                var line = reader.ReadLine();
                if (line == null) break;
                content.Add(line);
            }

            return content;
        }

        public static string GetDataAsString(int year, int day)
        {
            var rq = (HttpWebRequest)WebRequest.Create($"https://adventofcode.com/{year}/day/{day}/input");
            rq.CookieContainer = new CookieContainer();
            rq.CookieContainer.Add(new Cookie("session", "53616c7465645f5f691a0bcf70314a0e3a44820f96c6ec5e37940716d2f214026f61515d276d20aeac9f3781987cb74b5bae36fa0f1f2e19af25ecf48440b4c6", "/", "adventofcode.com"));
            
            var response = (HttpWebResponse)rq.GetResponse();
            var encoding = Encoding.ASCII;
            var content = new List<string>();
            using var reader = new StreamReader(response.GetResponseStream(), encoding);

            return reader.ReadToEnd().Trim();
        }

        public static List<string> GetDataFromFileAsList(string filepath)
        {
            var logFile = File.ReadAllLines(filepath);
            var logList = new List<string>(logFile);
            return logList;
        }
    }
}