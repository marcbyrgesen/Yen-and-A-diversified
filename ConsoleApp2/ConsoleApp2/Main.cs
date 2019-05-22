using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;

namespace ShortestPath
{
    class Program
    {

        static void Main(string[] args)
        {
            int VerticesVisited = 0;
            int TotalDistance = 0;
            int verticesCount = 3365;
            Vertex[] V = new Vertex[verticesCount+1];
            ReadFile reader = new ReadFile();
            reader.ReadVertices(V);

            reader.ReadEdges(V);
            int[] random = new int[1000+1];
            for (int i = 1; i < 1000; i++)
            { 
                Random rnd = new Random();
                random[i] = RandomNumber(0, 3365);
            }
            var s1 = Stopwatch.StartNew();

            for (int j = 1; j < 1000; j++)
            {
 
                Dijkstra d = new Dijkstra();
                Tuple<int, int> gg = d.DijkstraAlgo(V, random[j], random[j + 1], verticesCount);
                VerticesVisited += gg.Item1;
                if (gg.Item2 != int.MaxValue)
                    TotalDistance += gg.Item2;
            }
            s1.Stop();
            Console.WriteLine(VerticesVisited);
            Console.WriteLine(TotalDistance);
            Console.WriteLine("Time for Dijkstra: " + s1.Elapsed.TotalMilliseconds);

            VerticesVisited = 0;
            TotalDistance = 0;
            var s2 = Stopwatch.StartNew();

            for (int z = 1; z < 1000; z++)
            {
                AStar d = new AStar(V, random[z], random[z+1], verticesCount);
                Tuple<int, int> gg = d.DijkstraAlgo(V, random[z], random[z + 1], verticesCount);
                VerticesVisited += gg.Item1;
                if(gg.Item2 != int.MaxValue)
                    TotalDistance += gg.Item2;

            }
            s2.Stop();
            Console.WriteLine(VerticesVisited);
            Console.WriteLine(TotalDistance);
            Console.WriteLine("Time for Astar: " + s2.Elapsed.TotalMilliseconds);
            Console.ReadLine();
            Console.ReadKey();
        }
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();

        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }

    }

}

