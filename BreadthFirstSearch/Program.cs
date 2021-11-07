using System;
using System.Collections.Generic;
using System.Linq;

namespace BreadthFirstSearch
{
    public class Program
    {
        private static readonly Dictionary<string, string[]> Graph = new();

        public static void Main(string[] args)
        {
            Graph.Add("you", new[] { "alice", "bob", "claire" });
            Graph.Add("bob", new[] { "anuj", "peggy" });
            Graph.Add("alice", new[] { "peggy" });
            Graph.Add("claire", new[] { "thom", "jonny" });
            Graph.Add("anuj", Array.Empty<string>());
            Graph.Add("peggy", Array.Empty<string>());
            Graph.Add("thom", Array.Empty<string>());
            Graph.Add("jonny", Array.Empty<string>());
            Search("you");
        }

        private static bool Search(string name)
        {
            var searchQueue = new Queue<string>(Graph[name]);
            var searched = new List<string>();
            while (searchQueue.Any())
            {
                var person = searchQueue.Dequeue();
                if (!searched.Contains(person))
                {
                    if (PersonIsSeller(person))
                    {
                        Console.WriteLine($"{person} is a mango seller");
                        return true;
                    }

                    searchQueue = new Queue<string>(searchQueue.Concat(Graph[person]));
                    searched.Add(person);
                }
            }
            return false;
        }

        private static bool PersonIsSeller(string name)
        {
            return name.EndsWith("m");
        }
    }
}