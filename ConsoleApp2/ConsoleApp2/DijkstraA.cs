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
        public int[] DijkP;
        public Dijkstra(int[,] graph, int source, int dest, int verticesCount, int[] distance)
        {
            DijkstraAlgo(graph, source, dest, verticesCount);
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
            int[] PathArray = new int[verticesCount];
            int d = desti;
            bool notSource = true;
            int k = 0;
            while (s != desti)
            {
                if (notSource)
                {
                    sPathArray[k] = pathway[desti];
                    Console.WriteLine("from: " + desti + "to: " + pathway[desti]); //fghhgffhghfg
                    k++;
                    desti = pathway[desti];
                }
            }
            int reverse = k;
            for (int i = 0; i < k; i++)
            {
                PathArray[reverse] = sPathArray[i];
                reverse = reverse - 1;

            }
            for(int i = 1; i <= k; i++)
            {
                Console.WriteLine(PathArray[i]);
            }
            return PathArray;
        }

        private void DijkstraAlgo(int[,] graph, int source, int dest, int verticesCount)
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
            //Yen(graph, source, dest, verticesCount, distance, shortestPathArray);
        }
        //public static void Yen(int[,] graph, int source, int dest, int verticesCount, int[] distance, int[] dijkPath)
        //{
        //    int lowerBoundInput = distance[dest];
        //    List<int> TopCandidatePaths = new List<int>();
        //    List<int> CandidatePaths = new List<int>();

        //    TopCandidatePaths.Add(lowerBoundInput);
        //    bool emptyList = !TopCandidatePaths.Any();
        //    int spurnode;
        //    if (emptyList == false)
        //    {
        //        for (int i = 1; i < verticesCount; i++)
        //        {
        //            for (int j = 0; j < 10; j++)  // for i from 0 to size(A[k − 1]) − 2:
        //            {
        //                Console.WriteLine(CandidatePaths[0]);
        //                Console.ReadKey();

        //                spurnode = PathArray[k - 1].node(i);
        //                rootPath = PathArray[k - 1].nodes(0, i);


        //                foreach (int path in TopCandidatePaths)
        //                {
        //                    if rootpath == path(i, i + 1)
        //                            {
        //                        remove p.edge(i, i + 1) from Graph;
        //                    }
        //                }
        //            }
        //        }
        //    }

       // }
    }

}
