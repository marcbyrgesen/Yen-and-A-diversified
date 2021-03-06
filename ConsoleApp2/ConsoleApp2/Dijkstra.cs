﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace ShortestPath
{
    class Dijkstra
    {
        public Dijkstra(int[,] graph, int source, int dest, int verticesCount, int[] distance)
        {
            DijkstraAlgo(graph, source, dest, verticesCount);
        }
        private int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for (int v = 0; v < verticesCount; ++v)
            {
                if (shortestPathTreeSet[v] == false && distance[v] <= min)
                {
                    min = distance[v];
                    minIndex = v;
                    
                }
            }
            return minIndex;
        }

        public int[] SortSP(int[] pathway, int verticesCount, int desti, int s)
        {
            int[] sPathArray = new int[verticesCount];
            bool notSource = true;
            for (int i = 0; s != desti; i++)
            {
                sPathArray[i] = pathway[s];
                Console.WriteLine("from: " + s + "to: " + pathway[s]); //fghhgffhghfg
                s = pathway[s];

                Console.ReadLine();
            }
            return sPathArray;
        }

        private void DijkstraAlgo(int[,] graph, int source, int dest, int verticesCount)
        {
            int[] distance = new int[verticesCount];
            bool[] shortestPathTreeSet = new bool[verticesCount];
            int[] pathWay = new int[verticesCount];
            int[] shortestPathArray = new int[verticesCount];

            for (int i = 0; i < verticesCount; ++i)
            {
                distance[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }

            distance[source] = 0;

            for (int count = 0; count < verticesCount - 1; ++count)
            {
                int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
                shortestPathTreeSet[u] = true;

                for (int v = 0; v < verticesCount; ++v)
                {
                    if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) &&
                        distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                    {
                        distance[v] = distance[u] + graph[u, v];
                        pathWay[u] = v;
                    }
                }

                        
            }
            Console.WriteLine("Shortest path from {0} to {1} is dist: {2}", source, dest, distance[dest]);
            
            shortestPathArray = SortSP(pathWay, verticesCount, dest, source);
        }
    }
}