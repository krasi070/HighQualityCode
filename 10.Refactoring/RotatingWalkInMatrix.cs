namespace _01.CleanTheSmellyCode
{
    using System;

    public class RotatingWalkInMatrix 
    {
        public static void Main()
        {
            Console.Write("Enter a positive number: ");
            string input = Console.ReadLine();
            int n = 0;

            while (!int.TryParse(input, out n) || n < 0 || n > 100)
            {
                Console.Write("You haven't entered a correct positive number!\nTry again: ");
                input = Console.ReadLine();
            }

            int[,] matrix = GenerateMatrix(n);

            PrintMatrix(matrix);
        }

        public static int[,] GenerateMatrix(int n)
        {
            int[,] matrix = new int[n, n];
            int currNumber = 1;
            int currRow = 0;
            int currCol = 0;
            int directionX = 1;
            int directionY = 1;

            while (CheckIfCellIsEmpty(matrix, currRow, currCol) && currNumber != n *n)
            {
                matrix[currRow, currCol] = currNumber;
                ChangeDirectionIfNeeded(matrix, currRow, currCol, ref directionX, ref directionY);

                currRow += directionX;
                currCol += directionY;
                currNumber++;
            }

            matrix[currRow, currCol] = currNumber;

            FindEmptyCell(matrix, out currRow, out currCol);
            if (currRow != 0 && currCol != 0)
            {
                directionX = 1;
                directionY = 1;
                currNumber++;

                while (CheckIfCellIsEmpty(matrix, currRow, currCol))
                {
                    matrix[currRow, currCol] = currNumber;
                    ChangeDirectionIfNeeded(matrix, currRow, currCol, ref directionX, ref directionY);

                    currRow += directionX;
                    currCol += directionY;
                    currNumber++;
                }

                matrix[currRow, currCol] = currNumber;
            }

            return matrix;
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,4}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static void ChangeDirection(ref int directionX, ref int directionY)
        {
            int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int changeDirection = 0;

            for (int index = 0; index < directionsX.Length; index++)
            {
                if (directionsX[index] == directionX && directionsY[index] == directionY)
                {
                    changeDirection = index;
                    break;
                }
            }

            if (changeDirection == 7)
            {
                directionX = directionsX[0]; 
                directionY = directionsY[0];

                return;
            }

            directionX = directionsX[changeDirection + 1];
            directionY = directionsY[changeDirection + 1];
        }

        private static void ChangeDirectionIfNeeded(int[,] matrix, int currRow, int currCol, ref int directionX, ref int directionY)
        {
            bool isRowOutsideOfBounds = currRow + directionX >= matrix.GetLength(0) || currRow + directionX < 0;
            bool isColOutsideOfBounds = currCol + directionY >= matrix.GetLength(1) || currCol + directionY < 0;

            while (isRowOutsideOfBounds || isColOutsideOfBounds || matrix[currRow + directionX, currCol + directionY] != 0)
            {
                ChangeDirection(ref directionX, ref directionY);

                isRowOutsideOfBounds = currRow + directionX >= matrix.GetLength(0) || currRow + directionX < 0;
                isColOutsideOfBounds = currCol + directionY >= matrix.GetLength(1) || currCol + directionY < 0;
            }
        }

        private static bool CheckIfCellIsEmpty(int[,] matrix, int x, int y)
        {
            int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int index = 0; index < directionsX.Length; index++)
            {
                if (x + directionsX[index] >= matrix.GetLength(0) || x + directionsX[index] < 0)
                {
                    directionsX[index] = 0;
                }

                if (y + directionsY[index] >= matrix.GetLength(0) || y + directionsY[index] < 0)
                {
                    directionsY[index] = 0;
                }
            }

            for (int index = 0; index < directionsX.Length; index++)
            {
                if (matrix[x + directionsX[index], y + directionsY[index]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private static void FindEmptyCell(int[,] matrix, out int x, out int y)
        {
            x = 0;
            y = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 0) 
                    {
                        x = row;
                        y = col;

                        return; 
                    }
                }
            }
        }
    }
}
