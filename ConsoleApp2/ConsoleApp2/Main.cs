using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace ShortestPath
{
    public class Program : ReadFile
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
            ReadFile reader = new ReadFile();
            double[,] graph = new double[3366, 3366];
            Dijkstra t = new Dijkstra();
            t.dijkstra(graph, 0);
        }
    }
}
