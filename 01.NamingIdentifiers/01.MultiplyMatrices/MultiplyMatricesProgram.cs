namespace _01.MultiplyMatrices
{
    using System;

    class MultiplyMatricesProgram
    {
        static void Main(string[] args)
        {
            var firstMatrix = new double[,] { { 1, 3 }, { 5, 7 } };
            var secondMatrix = new double[,] { { 4, 2 }, { 1, 5 } };
            var productMatrix = MultiplyTwoMatrices(firstMatrix, secondMatrix);

            for (int row = 0; row < productMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < productMatrix.GetLength(1); col++)
                {
                    Console.Write(productMatrix[row, col] + " ");
                }

                Console.WriteLine();
            }

        }

        static double[,] MultiplyTwoMatrices(double[,] firstMatrix, double[,] secondMatrix)
        {
            if (firstMatrix.GetLength(1) != secondMatrix.GetLength(0))
            {
                throw new InvalidOperationException("Matrices cannot be multiplied!");
            }

            var firstMatrixColumnLength = firstMatrix.GetLength(1);
            var productMatrix = new double[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];

            for (int row = 0; row < productMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < productMatrix.GetLength(1); col++)
                {
                    for (int i = 0; i < firstMatrixColumnLength; i++)
                    {
                        productMatrix[row, col] += firstMatrix[row, i] * secondMatrix[i, col];
                    }  
                }   
            }

            return productMatrix;
        }
    }
}