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

        public int SortSP(int[] pathway, int[] sPathArray, int verticesCount, int desti, int k, int s)
        {
            Console.WriteLine("from: " + desti + "to: " + pathway[desti]); //fghhgffhghfg
            sPathArray[k] = pathway[desti];
            k++;
            desti = pathway[desti];
            if (desti == s)
            {
                desti = -1;
            }
            Console.ReadKey();
            return desti;

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

        private void DijkstraAlgo(int[,] graph, int source, int dest, int verticesCount)
        {
            int pH;
            int k = 0;
            int[] distance = new int[verticesCount];
            bool[] shortestPathTreeSet = new bool[verticesCount];
            int[] pathWay = new int[verticesCount];
            int[] shortestPathArray = new int[verticesCount];

            for (int i = 0; i < verticesCount; ++i)
            {
                distance[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }

            distance[source] = 0;

            for (int count = 0; count < verticesCount - 1; ++count)
            {
                pH = 0;
                int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
                shortestPathTreeSet[u] = true;

                for (int v = 0; v < verticesCount; ++v)
                    if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) &&
                        distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                    {
                        distance[v] = distance[u] + graph[u, v];
                        pH++;
                    }
            }
            Print(distance, dest, source, verticesCount);
            SortSP(pathWay, shortestPathArray, verticesCount, dest, k, distance[source]);
            Yen(graph, source, dest, verticesCount, distance);
        }

        public static void Yen(int[,] graph, int source, int dest, int verticesCount, int[] distance)
        {
            int lowerBoundInput = distance[dest];
            List<int> CandidatePaths = new List<int>();
            CandidatePaths.Add(lowerBoundInput);
            bool emptyList = !CandidatePaths.Any();

            if (emptyList == false)
            {
                for (int i = 1; i < 2; i++)
                {
                    Console.WriteLine(CandidatePaths[0]);
                    Console.ReadKey();
                }
            }

        }
    }
}