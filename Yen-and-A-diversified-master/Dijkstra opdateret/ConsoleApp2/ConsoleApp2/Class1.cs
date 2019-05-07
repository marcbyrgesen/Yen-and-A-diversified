using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Class1
    {

    using namespace std;

    int max_number_of_Kth_path = 5;

    int total_Node;         // Total number of node in the Network
    int** graph;


    bool find_SP_Dijkastra(int** Graph, int source, int destination)
    {
        float* dist = new float[total_Node];    // The output array.  dist[i] will hold the shortest distance from source to i
        bool* sptSet = new bool[total_Node]; // sptSet[i] will true if vertex i is included in shortest path tree or shortest distance from source to i is finalized
        int* parent = new int[total_Node];
        //current_path.tempPath = new int [total_Node];
        //std::fill(current_path.tempPath, current_path.tempPath+total_Node, -1);
        std::fill(parent, parent + total_Node, -1);

        // Initialize all distances as INFINITE and stpSet[] as false
        for (int i = 0; i < total_Node; i++)
            dist[i] = INT_MAX, sptSet[i] = false;

        // Distance of source vertex from itself is always 0
        dist[source] = 0;

        // Find shortest path for all vertices
        for (int c = 0; c < total_Node - 1; c++)
        {
            // find min
            float min = INT_MAX;
            int min_index;

            for (int v = 0; v < total_Node; v++)
                if (sptSet[v] == false && dist[v] <= min)
                    min = dist[v], min_index = v;   // min_index is used to retain in "current node"

            // Mark the picked vertex as processed
            sptSet[min_index] = true;

            if (min_index == destination)
                break;

            // Update dist value of the adjacent vertices of the picked vertex.
            for (int v = 0; v < total_Node; v++)
                // Update dist[v] only if is not in sptSet, there is an edge from
                // min_index to v, and total weight of path from source to  v through min_index is
                // smaller than current value of dist[v]
                if (!sptSet[v] && Graph[min_index][v] && dist[min_index] != INT_MAX && dist[min_index] + Graph[min_index][v] < dist[v])
                {
                    dist[v] = dist[min_index] + Graph[min_index][v];
                    parent[v] = min_index;
                }
        }

        if (parent[destination] == -1)
        {
            delete[] dist;  // deleting temp memory allocation
            delete[] sptSet;
            delete[] parent;
            dist = NULL;      // with NULL
            sptSet = NULL;
            parent = NULL;

            return false;
        }
        current_path.total_Node_in_path = 0;
        current_path.tempPath[current_path.total_Node_in_path] = destination;
        for (current_path.total_Node_in_path = 0; current_path.tempPath[current_path.total_Node_in_path] != source; current_path.total_Node_in_path++)
            current_path.tempPath[current_path.total_Node_in_path + 1] = parent[current_path.tempPath[current_path.total_Node_in_path]];

        // reverse the order
        for (int i = 0; i < ((current_path.total_Node_in_path % 2 + current_path.total_Node_in_path) / 2); i++)
        {
            current_path.tempPath[i] = current_path.tempPath[i] + current_path.tempPath[current_path.total_Node_in_path - i];
            current_path.tempPath[current_path.total_Node_in_path - i] = current_path.tempPath[i] - current_path.tempPath[current_path.total_Node_in_path - i];
            current_path.tempPath[i] = current_path.tempPath[i] - current_path.tempPath[current_path.total_Node_in_path - i];
        }
        current_path.path_total_distance = dist[destination];

        delete[] dist;  // deleting temp memory allocation
        delete[] sptSet;
        delete[] parent;
        dist = NULL;      // with NULL
        sptSet = NULL;
        parent = NULL;

        return true;
    }

    bool compare1DdynamicArray(int* array1, int* array2, int max_size)
    {
        for (int i = 0; i < max_size; i++)
            if (array1[i] != array2[i])
                return false;
        return true;
    }

    bool YkSPfunc(int s, int d, int k)
    {
        if (k == 0)
        {
            ykSP.source = s, ykSP.destination = d;
            ykSP.potential = -1, ykSP.length_of_YkSP_All = -1;

            if (!find_SP_Dijkastra(graph, ykSP.source, ykSP.destination))
                return false;
            else
            {
                // copy path, YkSP_All
                //current_path.shortestPath = new int [total_Node];
                std::copy(current_path.tempPath, current_path.tempPath + total_Node, current_path.shortestPath);
                std::copy(current_path.tempPath, current_path.tempPath + total_Node, ykSP.YkSP_All[0].ykspAllPath);
                // copy cost  or length
                // not required as it does not stored in temp
                ykSP.YkSP_All[0].cost = current_path.path_total_distance;
                // copy total node in path
                ykSP.YkSP_All[0].total_Node_in_path = current_path.total_Node_in_path;
                // set length_of_YkSP_All counter
                ykSP.length_of_YkSP_All++;
                return true;
            }
        }
        else if (ykSP.source != s || ykSP.destination != d)
            perror("check S and D in ykSP before calling YkSPfunc");

        int** tempGraph = new int*[total_Node];
        for (int r = 0; r < total_Node; r++)
            tempGraph[r] = new int[total_Node];

        // here we are not counting k, as we assume k is controlled from where function is called and it incremented by 1
        // The spur node ranges from the first node to the next to last node in the previous k-shortest path.
        for (int i = 0; i < ykSP.YkSP_All[k - 1].total_Node_in_path; i++) // check i final value :)
        {
            std::copy(graph, graph + total_Node * total_Node, tempGraph);

            // Spur node is retrieved from the previous k-shortest path, k − 1.
            int spurNode = ykSP.YkSP_All[k - 1].ykspAllPath[i];
            // The sequence of nodes from the source to the spur node of the previous k-shortest path.
            // std::vector<int> rootPath;
            int* rootPath = new int[i + 1];
            std::copy(ykSP.YkSP_All[k - 1].ykspAllPath, ykSP.YkSP_All[k - 1].ykspAllPath + i + 1, rootPath);

            int rootCost = 0;
            for (int p = 0; p < i; p++)
                rootCost = rootCost + graph[p][p + 1];

            for (int p = 0; p <= ykSP.length_of_YkSP_All; p++)
            {
                if (i <= ykSP.YkSP_All[p].total_Node_in_path)    // check i final value :)
                {
                    int* temp4compare = new int[(i + 1)];
                    std::copy(ykSP.YkSP_All[p].ykspAllPath, ykSP.YkSP_All[p].ykspAllPath + i + 1, temp4compare);

                    if (compare1DdynamicArray(rootPath, temp4compare, (i + 1)))
                    //if(flag)
                    {
                        // Remove the links that are part of the previous shortest paths which share the same root path.
                        tempGraph[ykSP.YkSP_All[p].ykspAllPath[i]][ykSP.YkSP_All[p].ykspAllPath[i + 1]] = 0;    // or INT_MAX
                    }
                    delete[] temp4compare; temp4compare = NULL;
                }
            }

            for (int p = 0; p <= i; p++)
            {
                if (spurNode != rootPath[p])
                {
                    // make all distance from rootPath[p] = 0 or INT_MAX
                    for (int j = 0; j < total_Node; j++)
                    {
                        tempGraph[rootPath[p]][j] = 0;
                        tempGraph[j][rootPath[p]] = 0;
                    }
                }
            }

            if (find_SP_Dijkastra(tempGraph, spurNode, d)) // spurPath = current_path.tempPath
            {                                               // spurCost = current_path.path_total_distance
                bool samePathFlag = false;  // 0

                int* temp4compare = new int[(i + current_path.total_Node_in_path + 1)];
                std::copy(rootPath, rootPath + i, temp4compare);

                std::copy(current_path.tempPath, current_path.tempPath + current_path.total_Node_in_path + 1, temp4compare + i);

                for (int p = 0; p <= ykSP.length_of_YkSP_All; p++)
                    if (compare1DdynamicArray(ykSP.YkSP_All[p].ykspAllPath, temp4compare, max(ykSP.YkSP_All[p].total_Node_in_path, (i + current_path.total_Node_in_path + 1))))
                        samePathFlag = true;

                for (int p = 0; p <= ykSP.potential; p++)
                    if (compare1DdynamicArray(ykSP.heap_B[p].heapPath, temp4compare, max(ykSP.heap_B[p].total_Node_in_path, (i + current_path.total_Node_in_path + 1))))
                        samePathFlag = true;

                if (samePathFlag == false)
                {
                    // B is The heap to store the potential kth shortest path.
                    // Add the potential k-shortest path to the heap.
                    // Entire path is made up of the root path and spur path.
                    ykSP.potential++;
                    std::copy(temp4compare, temp4compare + i + current_path.total_Node_in_path + 1, ykSP.heap_B[ykSP.potential].heapPath);
                    ykSP.heap_B[ykSP.potential].cost = rootCost + current_path.path_total_distance;
                    ykSP.heap_B[ykSP.potential].total_Node_in_path = (i + current_path.total_Node_in_path);
                }
                delete[] temp4compare; temp4compare = NULL;
            }
            delete[] rootPath;  // deleting temp memory allocation
            rootPath = NULL;      // with NULL
        }
        if (ykSP.potential >= 0)
        {
            // heap_YkSP_struct *index = std::min_element(ykSP.heap_B, ykSP.heap_B + ykSP.potential, [](const heap_YkSP_struct &lhs, const heap_YkSP_struct &rhs) { return lhs.cost < rhs.cost; });
            // std::cout << "Value = " << index->cost << '\n';
            // std::cout << "Position = " << (index - ykSP.heap_B) << '\n'; // or std::distance(ykSP.heap_B, index);
            int index; float minimum = INT_MAX; int smallerPathNodes = INT_MAX;
            for (int p = 0; p <= ykSP.potential; p++)
            {
                if (ykSP.heap_B[p].cost < minimum && ykSP.heap_B[p].total_Node_in_path < smallerPathNodes)
                {
                    minimum = ykSP.heap_B[p].cost;
                    smallerPathNodes = ykSP.heap_B[p].total_Node_in_path;
                    index = p;
                }
            }
            ykSP.length_of_YkSP_All++;
            ykSP.YkSP_All[ykSP.length_of_YkSP_All].cost = ykSP.heap_B[index].cost;
            ykSP.YkSP_All[ykSP.length_of_YkSP_All].total_Node_in_path = ykSP.heap_B[index].total_Node_in_path;
            std::copy(ykSP.heap_B[index].heapPath, ykSP.heap_B[index].heapPath + ykSP.heap_B[index].total_Node_in_path + 1, ykSP.YkSP_All[ykSP.length_of_YkSP_All].ykspAllPath);

            current_path.total_Node_in_path = ykSP.YkSP_All[ykSP.length_of_YkSP_All].total_Node_in_path;
            current_path.path_total_distance = ykSP.YkSP_All[ykSP.length_of_YkSP_All].cost;
            std::copy(ykSP.heap_B[index].heapPath, ykSP.heap_B[index].heapPath + ykSP.heap_B[index].total_Node_in_path + 1, current_path.shortestPath);

            for (int p = index; p < ykSP.potential; p++)
            {
                ykSP.heap_B[index].cost = ykSP.heap_B[index + 1].cost;
                ykSP.heap_B[index].total_Node_in_path = ykSP.heap_B[index + 1].total_Node_in_path;
                std::copy(ykSP.heap_B[index + 1].heapPath, ykSP.heap_B[index + 1].heapPath + ykSP.heap_B[index + 1].total_Node_in_path + 1, ykSP.heap_B[index].heapPath);
            }
            ykSP.potential--;

            for (int r = 0; r < total_Node; r++)
            {
                delete[] tempGraph[r]; tempGraph[r] = NULL;
            }
            delete[] tempGraph; tempGraph = NULL;

            return true;
        }
        else
            for (int r = 0; r < total_Node; r++)
            {
                delete[] tempGraph[r]; tempGraph[r] = NULL;
            }
        delete[] tempGraph; tempGraph = NULL;

        return false;
    }

    }
}
