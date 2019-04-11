using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace ShortestPath
{
    public class Dijkstra : ReadFile
    {
        public Dijkstra()
        {

        }
        public Dijkstra(double [,]graph)
        {
            graph = weight;
        }
        static int V = 3366;
        int minDistance(int[] dist,
                bool[] sptSet)
        {
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < V; v++)
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }

            return min_index;
        }

        void printSolution(int[] dist, int n)
        {
            Console.Write("Vertex     Distance "
                          + "from Source\n");
            for (int i = 0; i < V; i++)
                Console.Write(i + " \t\t " + dist[i] + "\n");
            Console.ReadKey();
        }

        public void dijkstra(double[,] graph, int src)
        {
            Double[] dist = new double[V]; 
            bool[] sptSet = new bool[V];

            for (int i = 0; i < V; i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }
            dist[src] = 0;

            // Find shortest path for all vertices 
            for (int count = 0; count < V - 1; count++)
            {
                int u = minDistance(Convert.ToInt32(dist), sptSet);

                sptSet[u] = true;

                for (int v = 0; v < V; v++)

                    if (!sptSet[v] && graph[u, v] != 0 &&
                         dist[u] != double.MaxValue && dist[u] + graph[u, v] < dist[v])
                        dist[v] = Convert.ToInt32(dist[u] + graph[u, v]);
            }

            // print the constructed distance array 
            printSolution(dist, V);
        }

       
    }
}