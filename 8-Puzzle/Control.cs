using System;
using System.Collections.Generic;
using System.Text;

namespace _8_Puzzle
{
    internal class Control
    {
        private Vertex root;
        Vertex solution;
        private BreadthFirst breadthFirst = new BreadthFirst();
        private DepthFirst depthFirst = new DepthFirst();
        private IterativeDeepening iterativeDeepening = new IterativeDeepening();
        private A_Star a_Star = new A_Star();
        private int algorithm;
        private bool useManhattanDistance;

        public Control(int[,] startValues, int[,] targetValues, int algorithm, bool useManhattanDistance)
        {
            this.algorithm = algorithm;
            this.useManhattanDistance = useManhattanDistance;
            
            root = new Vertex(null, useManhattanDistance);
            root.FillField(startValues);

            Vertex[] rootList = new Vertex[1];
            rootList[0] = root;            
            
            switch (algorithm)
            {
                case 0:
                    solution = breadthFirst.RunBreadthFirst(rootList, targetValues);
                    break;
                case 1:
                    solution = depthFirst.RunDepthFirstSearch(root, targetValues);
                    break;
                case 2:
                    solution = iterativeDeepening.RunIterativeDeepening(root, targetValues);
                    break;
                case 3:
                    solution = a_Star.RunA_Star(root, targetValues);
                    break;
            }

            if ( solution != null)
            {
                Console.WriteLine("Found a solution");
                PrintSolutionPath(solution);
            }
            else
            {
                Console.WriteLine("Found no solution");
            }
        }
        
        private void PrintSolutionPath(Vertex solution)
        {
            while(solution != null)
            {
                solution.PrintArray(solution.field);
                Console.WriteLine();
                solution = solution.parent;
            }
        }
    }
}
