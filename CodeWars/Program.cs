using System;
using System.Linq;
using System.Text;

namespace CodeWars
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        
        public static string Likes(string[] name)
        {
            int length = name.Length;
            switch (length)
            {
                case 0:
                    return "no one likes this";
                case 1:
                    return $"{name[0]} likes this";
                case 2:
                    return $"{name[0]} and {name[1]} like this";
                case 3:
                    return $"{name[0]}, {name[1]} and {name[2]} like this";
                default:
                    return $"{name[0]}, {name[1]} and {length-2} others like this";
            }
        }
        
        public static string Disemvowel(string str)
        {
            StringBuilder str2 = new StringBuilder();
            var l = str.Where(s => !"aieouAIEOU".Contains(s)).ToList();
            foreach (var c in l)
            {
                str2.Append(c);
            }
            return str2.ToString();
        }
        
        public static string ToJadenCase( string phrase)
        {
         
            return String.Empty;
        }
    }
}