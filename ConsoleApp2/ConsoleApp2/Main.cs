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
            graph = reader.ReadEdges();
            Dijkstra d = new Dijkstra(graph, 10, verticesCount, distance);
        }

    }


}
