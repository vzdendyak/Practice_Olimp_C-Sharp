using System;
using System.IO;
using System.Text.RegularExpressions;

namespace CourseraAlgorithms
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string text = "";
            using (StreamReader sr = new StreamReader(@"D:\projects\Practice_Olimp_C-Sharp\CourseraAlgorithms\Logs.txt"))
            {
                text = sr.ReadToEnd();
            }
            Regex regex = new Regex(@"(\d{2}.\d{2}.\d{4})\s*(\d)\s*(\d)");
            var matches = regex.Matches(text);
            Log[] logs = new Log[matches.Count];
            int i = 0;
            foreach (Match m in matches)
            {
                var log = new Log { Date = DateTime.Parse(m.Groups[1].Value), FirstId = int.Parse(m.Groups[2].Value), SecondId = int.Parse(m.Groups[3].Value) };
                logs[i] = log;
                i++;
            }
            TaskFirst f = new TaskFirst(10);
        }
    }
}