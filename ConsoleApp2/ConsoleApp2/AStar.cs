using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    class AStar
    {
        public AStar(Vertex[] graph, int source, int dest, int verticesCount)
        {            //Yen(graph, source, dest, verticesCount);
            DijkstraAlgo(graph, source, dest, verticesCount);
        }
        private int MinimumDistance(Vertex[] graph, int verticesCount, int dest)
        {
            double min = double.MaxValue;
            int minIndex = 0;
            int[] prioQueue = new int[verticesCount];
            for (int v = 0; v < verticesCount; ++v)
            {
                if (!graph[v].shortestPathTreeSet && graph[v].distance != int.MaxValue)
                {
                    double eucDist = Math.Round(Math.Sqrt(
                            Math.Pow(graph[v].x - graph[dest].x, 2) +
                            Math.Pow(graph[v].y - graph[dest].y, 2)));

                    if (eucDist < min)
                    {
                        min = eucDist;
                        minIndex = v;
                    }
                }
            }
            return minIndex;
        }

        //public int[] SortSP(int[] pathway, int verticesCount, int desti, int s)
        //{
        //    int[] sPathArray = new int[verticesCount+1];
        //    int d = desti;
        //    int m = 0;
        //    while (s != desti)
        //    {
        //        if(pathway[desti] != int.MaxValue)
        //            sPathArray[m] = pathway[desti]; // indekset lå udenfor matrixens grænser
        //            m++;
        //            desti = pathway[desti];
        //    }
        //    int[] PathArray = new int[m+1];
        //    int reverse = m;
        //    for (int i = 0; i < m; i++)
        //    {
        //        PathArray[reverse] = sPathArray[i];
        //        reverse = reverse - 1;

        //    }
        //    return PathArray;
        //}

        public void DijkstraAlgo(Vertex[] graph, int source, int dest, int verticesCount)
        {
            int[] pathWay = new int[verticesCount];
            int[] shortestPathArray = new int[verticesCount];

            for (int i = 0; i < verticesCount; ++i)
            {
                graph[i].distance = int.MaxValue;
                graph[i].shortestPathTreeSet = false;
            }

            graph[source].distance = 0;

            for (int count = 0; count < verticesCount - 1; count++)
            {
                int u = MinimumDistance(graph, verticesCount, dest);
                graph[u].shortestPathTreeSet = true;
                foreach (Neighbor neighbor in graph[u].neighbor)
                {
                    int temp = graph[u].distance;
                    if (!graph[neighbor.node].shortestPathTreeSet &&
                        graph[u].distance != int.MaxValue && 
                        temp + neighbor.weight < graph[neighbor.node].distance)
                    {
                        graph[neighbor.node].distance = graph[u].distance + neighbor.weight;
                        pathWay[neighbor.node] = u;
                    }
                }
                if (dest == u)
                {
                    break;
                }
            }
           // Console.WriteLine("Shortest path from {0} to {1} is dist: {2}", source, dest, graph[dest].distance);

            //shortestPathArray = SortSP(pathWay, verticesCount, dest, source);
            // return shortestPathArray;

        }
    }
}
