using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeightedGraphs
{
    class Maze
    {
        public List<int>[] Nodes { get; set; }

        public Maze(int nrOfNodes)
        {
            Nodes = new List<int>[nrOfNodes];
            for (int i = 0; i < Nodes.Length; i++)
            {
                Nodes[i] = new List<int>();
            }
        }
        public void AddNode(int nr, int[] neighbors)
        {
            Nodes[nr].AddRange(neighbors);
        }

        public void AddEdge(int node, int next)
        {
            Nodes[node].Add(next);
            Nodes[next].Add(node);
        }


        public int GetNextNode(int[] distances, bool[] visited)
        {
            int min = Int32.MaxValue;
            int next = -1;

            for (int i = 0; i < Nodes.Length; i++)
            {
                if (!visited[i] && distances[i] < min)
                {
                    min = distances[i];
                    next = i;
                }
            }
            return next;
        }

        public void Dijstra(int start)
        {
            int[] distances = new int[Nodes.Length];
            int[] pre = new int[Nodes.Length];
            bool[] visited = new bool[Nodes.Length];

            //every distance on max, visited is initialised at false
            for (int i = 0; i < Nodes.Length; i++)
            {
                distances[i] = Int32.MaxValue;
                visited[i] = false;
                pre[i] = -1;
            } 

            distances[start] = 0;

            while (true)
            {

                int node = GetNextNode(distances, visited);
                if (node == -1) break;

                visited[node] = true;

                foreach (var item in Nodes[node])
                {
                    int distance = distances[node] + Math.Abs(node - item);
                    if (!visited[item] && distance < distances[item])
                    {
                        pre[item] = node;
                        distances[item] = distance;
                    }
                }
            }

            for (int i = 0; i < distances.Length; i++)
            {
                Console.WriteLine($"node: {i} --> cost: {distances[i]} with predecessor {pre[i]}");
            }

            int end = 0;
            string path = end.ToString();
            while (end != start)
            {
                end = pre[end];
                path = end + " " + path;
            }
            Console.WriteLine("\nShortest path Dijkstra: " + path);
        }

        public override string ToString()
        {
            string s = "PRINT MAZE\n";
            for (int i = 0; i < Nodes.Length; i++)
            {
                s += i + " --> ";
                foreach (var item in Nodes[i])
                {
                    s += item + " ";
                }
                s += "\n";
            }
            return s;
        }
    }
}
