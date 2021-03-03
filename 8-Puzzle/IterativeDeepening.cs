using System;
using System.Collections.Generic;
using System.Text;

namespace _8_Puzzle
{
    internal class IterativeDeepening
    {
        public Vertex RunIterativeDeepening(Vertex vertex, int[,] target)
        {
            int maxDepth = 0;
            Vertex result = null;
            do
            {
                result = RunDepthFirst_B(vertex, target, 0, maxDepth);
                maxDepth++;
            } while (result == null);
            return result;
        }

        private Vertex RunDepthFirst_B(Vertex vertex, int[,] target, int depth, int maxDepth)
        {
            if (vertex.EqualsTarget(target))
            {
                return vertex;
            }
            List<Vertex> childVertices = new List<Vertex>();
            childVertices.AddRange(vertex.GetChilds());
            Vertex result;
            while (childVertices.Count != 0 && depth < maxDepth)
            {
                result = RunDepthFirst_B(childVertices[0], target, depth + 1, maxDepth);
                if (result != null && result.EqualsTarget(target))
                {
                    return result;
                }
                childVertices.RemoveAt(0);
            }
            return null;
        }
    }
}
