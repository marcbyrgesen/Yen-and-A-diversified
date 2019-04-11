using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace ShortestPath
{
    public class ReadFile
    {
        private readonly string delimiter = " ";
        public string FileName1 = @"vertices.txt";
        public string FileName2 = @"edges.txt";
        public int[] id = new int[10000];
        public double[,] weight = new double[10000,10000];

        public ReadFile()
        {
            //ReadVertices();
            ReadEdges();
        }

        // lav struct for at organisere fuckeren bedre
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
        public void ReadEdges()
        {
            TextFieldParser par = new TextFieldParser(FileName2, Encoding.GetEncoding("iso-8859-1"));
            par.TextFieldType = FieldType.Delimited;
            par.SetDelimiters(delimiter);
            while (!par.EndOfData)
            {
                string[] fields = par.ReadFields();
                weight[Convert.ToInt32(fields[0]), Convert.ToInt32(fields[1])]
                    = Convert.ToDouble(fields[2]);
                weight[Convert.ToInt32(fields[1]), Convert.ToInt32(fields[0])]
                    = Convert.ToDouble(fields[2]);
            }
                if(weight[61,62] != 0)
                {
                    Console.WriteLine(weight[61,62]);

                }
            Console.ReadKey();
        }
    }
}