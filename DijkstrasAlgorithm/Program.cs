using System;
using System.Collections.Generic;

namespace DijkstrasAlgorithm
{
    public class Program
    {
        private const double Infinity = double.PositiveInfinity;
        private static readonly Dictionary<string, Dictionary<string, double>> Graph = new();
        private static readonly List<string> Processed = new();

        public static void Main(string[] args)
        {
            Graph.Add("start", new Dictionary<string, double>());
            Graph["start"].Add("a", 6.0);
            Graph["start"].Add("b", 2.0);

            Graph.Add("a", new Dictionary<string, double>());
            Graph["a"].Add("fin", 1.0);

            Graph.Add("b", new Dictionary<string, double>());
            Graph["b"].Add("a", 3.0);
            Graph["b"].Add("fin", 5.0);

            Graph.Add("fin", new Dictionary<string, double>());

            var costs = new Dictionary<string, double>
            {
                { "a", 6.0 },
                { "b", 2.0 },
                { "fin", Infinity }
            };

            var parents = new Dictionary<string, string>
            {
                { "a", "start" },
                { "b", "start" },
                { "fin", null }
            };

            var node = FindLowestCostNode(costs);
            while (node != null)
            {
                var cost = costs[node];
                var neighbors = Graph[node];
                foreach (var n in neighbors.Keys)
                {
                    var new_cost = cost + neighbors[n];
                    if (costs[n] > new_cost)
                    {
                        costs[n] = new_cost;
                        parents[n] = node;
                    }
                }
                Processed.Add(node);
                node = FindLowestCostNode(costs);
            }
            Console.WriteLine(string.Join(", ", costs));
        }

        private static string FindLowestCostNode(Dictionary<string, double> costs)
        {
            var lowestCost = double.PositiveInfinity;
            string lowestCostNode = null;
            foreach (var node in costs)
            {
                var cost = node.Value;
                if (cost < lowestCost && !Processed.Contains(node.Key))
                {
                    lowestCost = cost;
                    lowestCostNode = node.Key;
                }
            }
            return lowestCostNode;
        }
    }
}