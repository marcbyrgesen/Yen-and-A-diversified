using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace ShortestPath
{
    class Program : ReadFile
    {

        static void Main(string[] args)
        {
            // Dijkstra
            int verticesCount = 3366;
            Random rnd = new Random();
            int[,] graph = new int[verticesCount, verticesCount];
            int[] distance = new int[verticesCount];
            ReadFile reader = new ReadFile();
            graph = reader.ReadEdges();
            for (int i = 0; i < 50; i++)
            {
                int source = rnd.Next(1, 3366);
                int dest = rnd.Next(1, 3366);
                Dijkstra d = new Dijkstra(graph, source, dest, verticesCount, distance);
            }


        }

    }


}
