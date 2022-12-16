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
        private static readonly JObject Settings = JObject.Parse(File.ReadAllText("../../../../AoC_Solutions/settings.json"));
        public static List<string> GetDataAsList(int year, int day)
        {
            var rq = (HttpWebRequest)WebRequest.Create($"https://adventofcode.com/{year}/day/{day}/input");
            rq.CookieContainer = new CookieContainer();
            rq.CookieContainer.Add(new Cookie("session", Settings["sessionID"].ToString(), "/", "adventofcode.com"));
            
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
            rq.CookieContainer.Add(new Cookie("session", Settings["sessionID"].ToString(), "/", "adventofcode.com"));
            
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
        
        public static string GetDataFromFileAsString(string filepath)
        {
            var logFile = File.ReadAllText(filepath);
            var logList = new string(logFile);
            return logList;
        }
    }
}