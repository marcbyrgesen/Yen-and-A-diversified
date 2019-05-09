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
        public Dijkstra(int[,] graph, int source, int dest, int verticesCount)
        {
            Yen(graph, source, dest, verticesCount);
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

        public int[] SortSP(int[] pathway, int verticesCount, int desti, int s)
        {
            int[] sPathArray = new int[verticesCount];
            int d = desti;
            bool notSource = true;
            int m = 0;
            while (s != desti)
            {
                if (notSource)
                {
                    sPathArray[m] = pathway[desti];
                    m++;
                    desti = pathway[desti];
                }
            }
            int[] PathArray = new int[m+1];
            int reverse = m;
            for (int i = 0; i < m; i++)
            {
                PathArray[reverse] = sPathArray[i];
                reverse = reverse - 1;

            }
            return PathArray;
        }

        public int[] DijkstraAlgo(int[,] graph, int source, int dest, int verticesCount)
        {
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
                int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
                shortestPathTreeSet[u] = true;

                for (int v = 0; v < verticesCount; ++v)
                {
                    if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) &&
                        distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                    {
                        distance[v] = distance[u] + graph[u, v];
                        pathWay[v] = u;
                    }
                }
            }
            Console.WriteLine("Shortest path from {0} to {1} is dist: {2}", source, dest, distance[dest]);

            shortestPathArray = SortSP(pathWay, verticesCount, dest, source);
            return shortestPathArray;

        }

        public void Yen(int[,] graph, int source, int dest, int verticesCount)
        {
            int[] dijkPath = DijkstraAlgo(graph, source, dest, verticesCount);
            int spurNode;
            int[] rootPath = new int[dijkPath.Length+1];
            int[,] g = graph;
            List<int> CandidatePaths = new List<int>();
            for (int k = 1; k < 5; k++)
            {
                for (int i = 0; i < dijkPath.Length - 2; i++)
                {
                    spurNode = dijkPath[k - 1];

                    Console.WriteLine();
                    for (int j = 1; j < i; j++)
                    {
                        rootPath[j - 1] = dijkPath[j];
                        Console.WriteLine(rootPath[j - 1]);
                    }

                    for (int n = 0; n < dijkPath.Length - 1; n++)                        // bedre midte?
                    {
                        if (spurNode != g[rootPath[n], rootPath[n + 1]] || spurNode != g[rootPath[n + 1], rootPath[n]]) { }
                        g[rootPath[n], rootPath[n + 1]] = 0;
                        g[rootPath[n + 1], rootPath[n]] = 0;
                    } // mulig mangel, andet for each loop i pseudo

                    int[] spurPath = DijkstraAlgo(g, spurNode, dest, verticesCount);
                    int[] totalpath = rootPath + spurPath; // check om den cutter den af det rigtige sted
                    List<int> pong = rootPath + spurPath;
                }

            }

        }
    }

}
