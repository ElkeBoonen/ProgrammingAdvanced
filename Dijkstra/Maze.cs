using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dijkstra
{
    public class Maze
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
