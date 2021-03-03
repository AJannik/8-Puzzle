using System;
using System.Collections.Generic;
using System.Text;

namespace _8_Puzzle
{
    internal class Vertex
    {
        public int[,] field = new int[3, 3];
        public Vertex parent;
        public int heuristicValue { get; set; }
        private int emptyX, emptyY;
        private bool useManhattanDistance;

        public Vertex(Vertex parent, bool useManhattanDistance)
        {
            this.parent = parent;
            this.useManhattanDistance = useManhattanDistance;
        }

        public void FillField(int[,] values)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    field[i, j] = values[i, j];
                }
            }            
        }

        public bool EqualsTarget(int[,] target)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if(field[i, j] != target[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public Vertex[] GetChilds()
        {
            List<Vertex> childs = new List<Vertex>();
            FindEmptyValue();
            if(emptyX != 0)
            {
                Vertex v = new Vertex(this, useManhattanDistance);
                v.FillField(field);
                v.SwapTwoValues(emptyX, emptyY, emptyX - 1, emptyY);
                if (!IsCycle(v))
                {
                    childs.Add(v);
                }                
            }
            if (emptyX != 2)
            {
                Vertex v = new Vertex(this, useManhattanDistance);
                v.FillField(field);
                v.SwapTwoValues(emptyX, emptyY, emptyX + 1, emptyY);
                if (!IsCycle(v))
                {
                    childs.Add(v);
                }
            }
            if (emptyY != 0)
            {
                Vertex v = new Vertex(this, useManhattanDistance);
                v.FillField(field);
                v.SwapTwoValues(emptyX, emptyY, emptyX, emptyY - 1);
                if (!IsCycle(v))
                {
                    childs.Add(v);
                }
            }
            if (emptyY != 2)
            {
                Vertex v = new Vertex(this, useManhattanDistance);
                v.FillField(field);
                v.SwapTwoValues(emptyX, emptyY, emptyX, emptyY + 1);
                if (!IsCycle(v))
                {
                    childs.Add(v);
                }
            }
            //Console.WriteLine(childs.Count);
            return childs.ToArray();
        }

        private bool IsCycle(Vertex child)
        {
            Vertex vertex = child.parent;
            while(vertex != null)
            {
                if (child.EqualsTarget(vertex.field))
                {
                    return true;
                }
                vertex = vertex.parent;
            }
            return false;
        }

        private void SwapTwoValues(int xOne, int yOne, int xTwo, int yTwo)
        {
            int tmp = field[yOne, xOne];
            field[yOne, xOne] = field[yTwo, xTwo];
            field[yTwo, xTwo] = tmp;
        }

        private void FindEmptyValue()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (field[i, j] == 0)
                    {
                        emptyX = j;
                        emptyY = i;
                    }
                }
            }
        }

        public void PrintArray(int[,] array)
        {
            for (int i = 0; i < 3; i++)
            {
                string line = "";
                for (int j = 0; j < 3; j++)
                {
                    line += array[i, j];
                }
                Console.WriteLine(line);
            }
        }

        private int DistanceToRoot()
        {
            int i = 0;
            Vertex vertex = this.parent;
            while (vertex != null)
            {
                i++;
                vertex = vertex.parent;
            }
            return i;
        }

        public void HeuristicEvaluation(int[,] target)
        {
            heuristicValue = 0;
            heuristicValue += DistanceToRoot();
            if (!useManhattanDistance)
            {
                Heuristic1(target);
            }
            else
            {
                Heuristic2(target);
            }            
        }

        private void Heuristic1(int[,] target)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (field[i, j] != target[i, j])
                    {
                        heuristicValue++;
                    }
                }
            }
        }

        //Manhattan-Distance
        private void Heuristic2(int[,] target)
        {
            int[] posTarget = new int[2];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (field[j, i] != target[j, i])
                    {
                        posTarget = findPosTarget(field[j, i], target);
                        heuristicValue += Math.Abs(j - posTarget[0]);
                        heuristicValue += Math.Abs(i - posTarget[1]);
                    }                    
                }
            }
        }

        private int[] findPosTarget(int value, int[,] target)
        {
            int[] posTarget = new int[2];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (value == target[j, i])
                    {
                        posTarget[0] = j;
                        posTarget[1] = i;
                        return posTarget;
                    }
                }
            }
            return null;
        }
    }
}
