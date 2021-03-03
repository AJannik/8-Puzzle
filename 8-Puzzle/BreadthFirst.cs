using System;
using System.Collections.Generic;
using System.Text;

namespace _8_Puzzle
{
    internal class BreadthFirst
    {
        public Vertex RunBreadthFirst(Vertex[] vertices, int[,] target)
        {
            List<Vertex> childVertices = new List<Vertex>();
            foreach (Vertex vertex in vertices)
            {
                if (vertex.EqualsTarget(target))
                {
                    return vertex;
                }
                childVertices.AddRange(vertex.GetChilds());
            }
            if (childVertices.Count != 0)
            {
                return RunBreadthFirst(childVertices.ToArray(), target);
            }            
            return null;
        }
    }
}
