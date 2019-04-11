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
            Console.ReadKey();
            double[,] graph = new double[3365, 3365];
            ReadFile reader = new ReadFile();
            Dijkstra t = new Dijkstra();
            t.DijkstraAlgo(graph, 0, 3365);
        }
    }
}
