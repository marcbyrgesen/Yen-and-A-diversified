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
        public int weight;
        public Neighbor(int _node, int _weight)
        {
            this.node = _node;
            this.weight = _weight;
        }
    }
    public class Vertex
    {
        public int node;
        public int distance;
        public double x;
        public double y;
        public List<Neighbor> neighbor = new List<Neighbor>();
        public bool shortestPathTreeSet;

        public Vertex()
        {

        }

        public Vertex(int _node, double _x, double _y)
        {
            node = _node;
            x = _x;
            y = _y;
        }
    }
    class ReadFile
    {
        private readonly string delimiter = " ";
        private readonly string delimiter1 = ".";
        public string FileName1 = @"vertices.txt";
        public string FileName2 = @"edges.txt";

        public ReadFile()
        {

        }

        public Vertex[] ReadVertices(Vertex[] V)
        {
            TextFieldParser par = new TextFieldParser(FileName1, Encoding.GetEncoding("iso-8859-1"));
            par.TextFieldType = FieldType.Delimited;
            par.SetDelimiters(delimiter);
            while (!par.EndOfData)
            {
                string[] fields = par.ReadFields();

                int id = Convert.ToInt32(fields[0]);
                double x = Convert.ToDouble(fields[1]);
                double y = Convert.ToDouble(fields[2]);
                Vertex temp = new Vertex(id, x, y);
                V[id] = temp;
                
            }
            Console.ReadKey();
            return V;
        }
        public Vertex[] ReadEdges(Vertex[] V)
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

                Neighbor n = new Neighbor(v2, weight);

                V[v1].neighbor.Add(n);
                n = new Neighbor(v1, weight);
                V[v2].neighbor.Add(n);


            }
            return V;
        }
    }
}