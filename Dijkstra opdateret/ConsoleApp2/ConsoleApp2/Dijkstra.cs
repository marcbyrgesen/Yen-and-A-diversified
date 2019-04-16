using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace ShortestPath
{
    class Dijkstra
    {
        Random rnd = new Random();

        public Dijkstra(int[,] graph, int source, int dest, int verticesCount, int[] distance)
        {
            DijkstraAlgo(graph, source, dest, verticesCount);
            Print(distance, dest, source);
        }

        public Dijkstra()
        { 

        }

        private int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for (int v = 0; v < verticesCount; ++v)
            {
                if (shortestPathTreeSet[v] == false && distance[v] <= min)
                {
                    min = distance[v];
                    minIndex = v;
                }
            }
            return minIndex;
        }

        public void Print(int[] distance, int dest, int source)
        {
            Console.WriteLine("Source    Destination    Distance from source");
            //for (int i = 0; i < verticesCount; ++i)
            foreach (var ele in distance)
            {
                if (distance[dest] == distance[dest])
                {
                    Console.WriteLine("{0}\t  {1}\t\t {2}", source, dest, distance[dest]);
                }
                Console.ReadKey();
            }

        }
        
        private void DijkstraAlgo(int[,] graph, int source, int dest, int verticesCount)
        {
            int[] distance = new int[verticesCount];
            bool[] shortestPathTreeSet = new bool[verticesCount];

            for (int i = 0; i < verticesCount; ++i)
            {
                distance[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }
            source = rnd.Next(1, 3366);
            dest = rnd.Next(1, 3366);
            distance[source] = 0;

            for (int count = 0; count < verticesCount - 1; ++count)
            {
                int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
                shortestPathTreeSet[u] = true;

                for (int v = 0; v < verticesCount; ++v)
                    if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) &&
                        distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                    {
                        distance[v] = distance[u] + graph[u, v];
                    }
                        
            }
            Print(distance, dest, source);
        }
    }
}