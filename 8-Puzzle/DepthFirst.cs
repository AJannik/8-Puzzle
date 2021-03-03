using System;
using System.Collections.Generic;
using System.Text;

namespace _8_Puzzle
{
    internal class DepthFirst
    {
        public Vertex RunDepthFirstSearch(Vertex vertex, int[,] target)
        {
            if (vertex.EqualsTarget(target))
            {
                return vertex;
            }
            List<Vertex> childVertices = new List<Vertex>();
            childVertices.AddRange(vertex.GetChilds());
            while (childVertices.Count > 0)
            {
                Vertex result = RunDepthFirstSearch(childVertices[0], target);
                if (result.EqualsTarget(target))
                {
                    return result;
                }
                childVertices.RemoveAt(0);
            }
            return null;
        }
    }
}
