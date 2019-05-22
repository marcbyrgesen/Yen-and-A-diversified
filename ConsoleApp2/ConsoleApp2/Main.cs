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

            int verticesCount = 3365;
            Vertex[] V = new Vertex[verticesCount+1];
            ReadFile reader = new ReadFile();
            reader.ReadVertices(V);
            reader.ReadEdges(V);
            int[] source = new int[1000];
            int[] dest = new int[1000];
            for (int i = 0; i < 1000; i++)
            {
                Random rnd = new Random();
                source[i] = rnd.Next(0, 3365);
                dest[i] = rnd.Next(0, 3365);
            }
            var s1 = Stopwatch.StartNew();
            for (int j = 0; j < 1000; j++)
            {
                Dijkstra d = new Dijkstra(V, source[j], dest[j], verticesCount);

            }
            s1.Stop();

            Console.WriteLine("Time for Dijkstra: " + s1.Elapsed.TotalMilliseconds);
            var s2 = Stopwatch.StartNew();
            for (int j = 0; j < 1000; j++)
            {
                AStar d = new AStar(V, source[j], dest[j], verticesCount);

            }
            s2.Stop();
            Console.WriteLine("Time for Astar: " + s2.Elapsed.TotalMilliseconds);
            Console.ReadLine();
            Console.ReadKey();
        }

    }


}
