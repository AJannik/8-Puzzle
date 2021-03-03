using System;
using System.Collections.Generic;
using System.Text;

namespace _8_Puzzle
{
    internal class A_Star
    {
        public Vertex RunA_Star(Vertex start, int[,] target)
        {
            List<Vertex> vertices = new List<Vertex>();
            start.HeuristicEvaluation(target);
            vertices.Add(start);
            while (true)
            {
                if(vertices.Count == 0)
                {
                    return null;
                }
                Vertex vertex = vertices[0];
                vertices.RemoveAt(0);
                if (vertex.EqualsTarget(target))
                {
                    return vertex;
                }
                InsertChilds(vertices, vertex.GetChilds(), target);
            }
        }

        private void InsertChilds(List<Vertex> list, Vertex[] childs, int[,] target)
        {
            foreach (Vertex vertex in childs)
            {
                vertex.HeuristicEvaluation(target);
                list.Insert(LinearSearch(list.ToArray(), vertex), vertex);                
            }            
        }

        private int LinearSearch(Vertex[] array, Vertex target)
        {
            if (array.Length == 0)
            {
                return 0;
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].heuristicValue > target.heuristicValue)
                {
                    return i;
                }
            }
            return array.Length;
        }        
    }
}
