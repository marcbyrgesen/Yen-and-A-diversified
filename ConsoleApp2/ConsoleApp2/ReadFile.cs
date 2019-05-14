using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;


namespace ShortestPath
{
    class ReadFile
    {
        private readonly string delimiter = " ";
        private readonly string delimiter1 = ".";
        public string FileName1 = @"vertices.txt";
        public string FileName2 = @"edges.txt";
        // public int[] id = new int[10000];
        public int[,] graph = new int[3366, 3366];

        public ReadFile()
        {
            //ReadVertices();
        }

        //public void ReadVertices()
        //{
        //    TextFieldParser par = new TextFieldParser(FileName1, Encoding.GetEncoding("iso-8859-1"));
        //    par.TextFieldType = FieldType.Delimited;
        //    par.SetDelimiters(delimiter);
        //    for (int i = 0; !par.EndOfData; i++)
        //    {
        //        string[] fields = par.ReadFields();
        //        id[i] = Convert.ToInt32(fields[0]);
        //        Console.WriteLine(id[i]);
        //    }
        //    Console.ReadKey();
        //}
        public int[,] ReadEdges()
        {
            int x;
            int y;
            TextFieldParser par = new TextFieldParser(FileName2, Encoding.GetEncoding("iso-8859-1"));
            par.TextFieldType = FieldType.Delimited;
            par.SetDelimiters(delimiter, delimiter1);
            while (!par.EndOfData)
            {
                string[] fields = par.ReadFields();
                x = Convert.ToInt32(fields[0]);
                y = Convert.ToInt32(fields[1]);
                graph[y, x] = Convert.ToInt32(fields[2]);
                graph[x, y] = Convert.ToInt32(fields[2]);
            }
            return graph;
        }
    }
}