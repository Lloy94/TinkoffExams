using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Case4
{
    class Program
    {
        static void Main(string[] args)

        {
            Console.WriteLine();
            Dictionary<string, int> values = new();

            do
            {
                
                string s = Console.ReadLine();
                var regex1 = new Regex(@"^[a-z]{0,9}=[a-z]{0,9}$");
                var regex2 = new Regex(@"^[a-z]{0,9}=[0-10000]{0,9}$");
                var regex3 = new Regex(@"[0-10000]");
                if (regex1.IsMatch(s) ^ regex2.IsMatch(s))
                {
                    Console.WriteLine(s);
                    string[] text = s.Split('=');
                    if (regex3.IsMatch(text[1])) 
                    {
                        int i = int.Parse(text[1].ToString());
                        if (values.ContainsKey(text[0]))
                        {
                            values.Remove(text[0]);
                            values.Add(text[0], i);
                        }
                        else values.Add(text[0], i);
                    }
                    else
                    {
                        if (values.ContainsKey(text[0]))
                        {
                            values.TryGetValue(text[0], out int k);
                            values.Remove(text[0]);
                            values.Add(text[0], k);
                        }
                        else values.Add(text[0], 0);
                    }
                }


            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            foreach (var person in values)
            {
                Console.WriteLine($"key: {person.Key}  value: {person.Value}");
            }
        }
        
    }
}
