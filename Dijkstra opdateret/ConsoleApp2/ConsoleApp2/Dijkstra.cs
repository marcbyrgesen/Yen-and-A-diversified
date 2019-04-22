using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using System.Collections;

namespace ShortestPath
{
    class Dijkstra : ReadFile
    {
        public Dijkstra(int[,] graph, int source, int dest, int verticesCount, int[] distance)
        {
            DijkstraAlgo(graph, source, dest, verticesCount);
        }

        public Dijkstra()
        { 

        }

        private static int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
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

        public static void Print(int[] distance, int dest, int source, int verticesCount)
        {
            for (int i = 0; i <= 0; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("Source    Destination    Distance from source");
                    Console.WriteLine("{0}\t  {1}\t\t {2}", source, dest, distance[dest]);
                }
            }
            Console.ReadKey();
        }

        private static void DijkstraAlgo(int[,] graph, int source, int dest, int verticesCount)
        {
            int[] distance = new int[verticesCount];
            bool[] shortestPathTreeSet = new bool[verticesCount];

            for (int i = 0; i < verticesCount; ++i)
            {
                distance[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }
            distance[source] = 0;

            for (int count = 0; count < verticesCount; ++count)
            {
                int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
                shortestPathTreeSet[u] = true;

                for (int v = 0; v < verticesCount; ++v)
                    if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) &&
                        distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                    {
                        distance[v] = distance[u] + graph[u, v];
                    }

                /*
                ArrayList cc = new ArrayList();
                cc.Add(v);
                int c = cc.Count;
                Console.WriteLine(c);
                */

            }
            Print(distance, dest, source, verticesCount);
        }

        public static void Yen(int[,] graph, int source, int dest, int verticesCount, int[] distance)
        {

            List<int> CandidatePaths = new List<int>();

            for (int i = 0; i < verticesCount; i++)
            {

            }

        }
    }
}