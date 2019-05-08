using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace ShortestPath
{
    class Program
    {


        static void Main(string[] args)
        {
            int verticesCount = 3365;
            int[,] graph = new int[verticesCount, verticesCount];
            int[] distance = new int[verticesCount];
            ReadFile reader = new ReadFile();

            for (int i = 0; i < 1000; i++)
            {
                graph = reader.ReadEdges();
                Random rnd = new Random();
                int source = rnd.Next(1, 3366);
                int dest = rnd.Next(1, 3366);
                Console.WriteLine(source);
                Console.WriteLine(dest);
                Dijkstra d = new Dijkstra(graph, source, dest, verticesCount, distance);
                Console.ReadKey();
            }

        }

    }


}
