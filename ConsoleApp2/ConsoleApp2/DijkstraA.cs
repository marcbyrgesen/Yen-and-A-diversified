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
            int m = 0;
            while (s != desti)
            {
                if(pathway[desti] != int.MaxValue)
                    sPathArray[m] = pathway[desti]; // indekset lå udenfor matrixens grænser
                    m++;
                    desti = pathway[desti];
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

        public int[] DijkstraAlgo(int[,] graph, int source, int dest, int verticesCount, int[] distance)
        {
            bool[] shortestPathTreeSet = new bool[verticesCount];
            int[] pathWay = new int[verticesCount];
            int[] shortestPathArray = new int[verticesCount];

            for (int i = 0; i < verticesCount; ++i)
            {
                distance[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }

            distance[source] = 0;

            for (int count = 0; count < verticesCount - 1; count++)
            {
                int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
                shortestPathTreeSet[u] = true;

                for (int v = 0; v < verticesCount; v++)
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

        // tilføj distance
        public void Yen(int[,] graph, int source, int dest, int verticesCount)
        {
            int[] distance = new int[verticesCount];
            int[] dijkPath = DijkstraAlgo(graph, source, dest, verticesCount, distance);
            for (int i = 0; i < dijkPath.Length - 2; i++)
                Console.WriteLine(dijkPath[i]);

            int spurNode;
            int[] rootPath = new int[dijkPath.Length];
            List<int> CandidatePaths = new List<int>();
            for (int k = 1; k < 5; k++)
            {
                for (int i = 0; i < dijkPath.Length - 2; i++)
                {
                    int[,] tempGraph = graph;
                    spurNode = dijkPath[i+1];
                    Console.WriteLine(spurNode);

                    for (int j = 0; j <= i; j++)
                    {
                            rootPath[j] = dijkPath[j+1];
                    }

                    // hele dette loop overflødigt?
                    for(int p = 0; p < i; p++)                        // bedre condition?
                    {
                        //if(p<=i)
                        Console.WriteLine("p: " + rootPath[p] + " " + rootPath[p+1]);
                        Console.WriteLine(spurNode);
                        // muligt if statement her
                        tempGraph[rootPath[p], rootPath[p+1]] = 0;
                        tempGraph[rootPath[p+1], rootPath[p]] = 0;
                    }

                    //for(int r = 0; r < verticesCount; r++)
                    //{
                    //    for(int n = 0; n < i; n++)
                    //    if(r == rootPath[i] || n == rootPath[i])
                    //    {
                    //        tempGraph[n, r] = 0;
                    //        tempGraph[r, n] = 0;
                    //    }
                    //}
                    string[] totalpath = new string[7];
                    int[] spurDijkPath = DijkstraAlgo(tempGraph, spurNode, dest, verticesCount, distance);
                    string[] totalPath = Array.ConvertAll(rootPath, ele => ele.ToString());
                    totalPath = Array.ConvertAll(spurDijkPath, ele => ele.ToString());
                    Console.WriteLine(string.Join(", ", totalPath));
                    totalPath = Array.ConvertAll(rootPath, ele => ele.ToString());
                    Console.WriteLine(string.Join(", ", totalPath));
                    Console.ReadLine();
                    //for (int a = 0; true; a++)
                    //{

                    //    //if (a < rootPath.Length)
                    //    //    totalpath[a] = IntArrayToString(rootPath[a]);

                    //    //totalpath = spurPath;
                    //}
                }

            }

        }
        public string IntArrayToString(int[] ints)
        {
            return string.Join(",", ints.Select(x => x.ToString()).ToArray());
        }
    }

}
