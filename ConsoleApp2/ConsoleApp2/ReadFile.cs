using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;


namespace ShortestPath
{
    public class Neighbor
    {
        public int node;
        public int next;
        public int weight;
        public Neighbor(int _node, int _next, int _weight)
        {
            this.node = _node;
            this.next = _next;
            this.weight = _weight;
        }
    }
    public class Vertex
    {
        public int node;
        public int distance;
        Neighbor neighbor;
        public Vertex(int _node, Neighbor _neighbor)
        {
            this.node = _node;
            this.neighbor = _neighbor;
        }
    }
    class ReadFile
    {
        private readonly string delimiter = " ";
        private readonly string delimiter1 = ".";
        public string FileName1 = @"vertices.txt";
        public string FileName2 = @"edges.txt";
        LinkedList<Vertex> V = new LinkedList<Vertex>();
        // public int[] id = new int[10000];

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
        public LinkedList<Vertex> ReadEdges()
        {
            TextFieldParser par = new TextFieldParser(FileName2, Encoding.GetEncoding("iso-8859-1"));
            par.TextFieldType = FieldType.Delimited;
            par.SetDelimiters(delimiter, delimiter1);
            while (!par.EndOfData)
            {
                string[] fields = par.ReadFields();
                int v1 = Convert.ToInt32(fields[0]);
                int v2 = Convert.ToInt32(fields[1]);
                int weight = Convert.ToInt32(fields[2]);

                Neighbor n = new Neighbor(v1, v2, weight);
                Vertex temp = new Vertex(v1, n);
                V.AddLast(temp);

                n = new Neighbor(v2, v1, weight);
                temp = new Vertex(v2, n);
                V.AddLast(temp);

            }
            return V;
        }
    }
}