using System;

namespace _8_Puzzle
{
    internal class Start
    {
		private int[] startValues = { 1, 2, 3, 4, 5, 6, 7, 8, 0 };
		private int[] testValues = { 2, 0, 4, 6, 7, 1, 8, 5, 3 };
		private int[] stressValues = { 8, 6, 7, 2, 5, 4, 3, 0, 1 };
		private const int SEED = 0;

		// 0 = only two places switched
		// 1 = test values
		// 2 = stress test
		// 3 = full random
		private const int START_VALUE_SELECTION = 1;

		// Controlls which algorithm to use
		// 0 = BreadthFirst
		// 1 = DepthFirst - though we run into a stack overflow due to non finite search tree
		// 2 = IterativeDeepening
		// 3 = A*
		private int algorithm = 2;

		// false = using h1
		// true = using h2
		private bool useManhattanDistance = true;

		public Start()
		{
			int[,] targetValues = Array1Dto2D(startValues);

			switch (START_VALUE_SELECTION)
			{
				case 0:
					startValues[1] = 0;
					startValues[8] = 2;
					break;
				case 1:
					startValues = testValues;
					break;
				case 2:
					startValues = stressValues;
					break;
				case 3:
					startValues = Shuffle(startValues);
					break;
			}

			int[,] values = Array1Dto2D(startValues);
			Control control = new Control(values, targetValues, algorithm, useManhattanDistance);
		}

		private int[,] Array1Dto2D(int[] array)
        {
			int[,] result = new int[3, 3];
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					result[j, i] = array[(j * 3) + i];
				}
			}
			return result;
		}

		private int[] Shuffle(int[] array)
		{
			Random random = new Random(SEED);
			for (int i = array.Length; i > 1; i--)
			{
				// Pick random element to swap.
				int j = random.Next(i);
				int tmp = array[j];
				array[j] = array[i - 1];
				array[i - 1] = tmp;
			}
			return array;
		}

		static void Main(string[] args)
		{
			Start start = new Start();
		}
	}
}
