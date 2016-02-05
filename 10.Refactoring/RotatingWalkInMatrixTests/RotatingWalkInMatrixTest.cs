namespace RotatingWalkInMatrixTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using _01.CleanTheSmellyCode;

    [TestClass]
    public class RotatingWalkInMatrixTest
    {
        [TestMethod]
        public void TestGenerateMatrix_SizeOne_ExpectedOne()
        {
            int[,] ExpectedMatrix = { { 1 } };

            int[,] matrix = RotatingWalkInMatrix.GenerateMatrix(1);

            CollectionAssert.AreEqual(ExpectedMatrix, matrix, "Matrix should have had only one element which is a 1.");
        }

        [TestMethod]
        public void TestGenerateMatrix_SizeSix_ExpectedCorrectMatric()
        {
            int[,] ExpectedMatrix = 
            {
                { 1, 16, 17, 18, 19, 20 },
                { 15,  2, 27, 28, 29, 21 },
                { 14, 31, 3, 26, 30, 22 },
                { 13, 36, 32,  4, 25, 23 },
                { 12, 35, 34, 33, 5, 24 },
                { 11, 10, 9, 8, 7, 6 }
            };

            int[,] matrix = RotatingWalkInMatrix.GenerateMatrix(6);

            CollectionAssert.AreEqual(ExpectedMatrix, matrix, "Matrx didn't match elements.");
        }
    }
}
