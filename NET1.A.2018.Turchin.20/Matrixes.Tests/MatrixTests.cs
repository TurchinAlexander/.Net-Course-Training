using System;
using NUnit.Framework;

using Matrixes.DataEvent;
using Matrixes.Matrix;

namespace Matrixes.Tests
{
    [TestFixture]
    public class MatrixTests
    {
        private string data;

        [Test]
        public void CheckSizeTest_WithoutInputSize_StandardSize()
        {
            var matrix = new SquareMatrix<int>();

            Assert.AreEqual(5, matrix.Size);
        }

        [Test]
        public void CheckSizeTest_InputSize_MatrixWithSize()
        {
            const int size = 10;

            var matrix = new SquareMatrix<int>(size);

            Assert.AreEqual(size, matrix.Size);
        }

        [Test]
        public void EventsTest_SubscribeToEvent_GetDefaultMessage()
        {
            const string defaultMessage = "The element[0,0] has been changed.";
            var matrix = new SquareMatrix<int>(2);
            data = null;

            matrix.OnChanged += GetData;
            matrix[0, 0] = 1;

            Assert.AreEqual(defaultMessage, data);
        }

        [Test]
        public void SumTest_SquarePlusSquare_Square()
        {
            var matrix1 = new SquareMatrix<int>(2);
            matrix1[0, 0] = 1;

            var matrix2 = new SquareMatrix<int>(2);
            matrix2[0, 0] = 1;
            matrix2[0, 1] = 2;

            var matrix = matrix1 + matrix2;

            int[] array = { 2, 2, 0, 0 };

            Assert.IsTrue(IsEqual(matrix, array));
        }

        [Test]
        public void SumTest_SquarePlusSymmetric_Square()
        {
            var matrix1 = new SquareMatrix<int>(2);
            matrix1[0, 0] = 1;

            var matrix2 = new SymmetricMatrix<int>(2);
            matrix2[0, 0] = 1;
            matrix2[1, 1] = 2;

            var matrix = matrix1 + matrix2;

            int[] array = { 2, 0, 0, 2 };

            Assert.IsTrue(IsEqual(matrix, array));
        }

        [Test]
        public void SumTest_SquarePlusDiagonal_Square()
        {
            var matrix1 = new SquareMatrix<int>(2);
            matrix1[1, 0] = 2;
            matrix1[1, 1] = 2;

            var matrix2 = new DiagonalMatrix<int>(2);
            matrix2[0, 0] = 1;
            matrix2[1, 1] = 2;

            var matrix = matrix1 + matrix2;

            int[] array = { 1, 0, 2, 4 };

            Assert.IsTrue(IsEqual(matrix, array));
        }

        [Test]
        public void SumTest_DiagonalPlusDiagonal_Diagonal()
        {
            var matrix1 = new DiagonalMatrix<int>(2);
            matrix1[0, 0] = 1;
            matrix1[1, 1] = 2;

            var matrix2 = new DiagonalMatrix<int>(2);
            matrix2[0, 0] = 1;
            matrix2[1, 1] = 2;

            var matrix = matrix1 + matrix2;

            int[] array = { 2, 0, 0, 4 };

            Assert.IsTrue(IsEqual(matrix, array));
        }

        [Test]
        public void SumTest_SymmetricPlusDiagonal_Symmetric()
        {
            var matrix1 = new SymmetricMatrix<int>(new int[,] { { 1, 2 }, { 2, 1 } });

            var matrix2 = new DiagonalMatrix<int>(2);
            matrix2[0, 0] = 1;
            matrix2[1, 1] = 1;

            var matrix = matrix1 + matrix2;

            int[] array = { 2, 2, 2, 2 };

            Assert.IsTrue(IsEqual(matrix, array));
        }

        [Test]
        public void SumTest_SymmetricPlusSymmetric_Symmetric()
        {
            var matrix1 = new SymmetricMatrix<int>(new int[,] { { 1, 2 }, { 2, 1 } });
            var matrix2 = new SymmetricMatrix<int>(new int[,] { { 1, 2 }, { 2, 1 } });

            var matrix = matrix1 + matrix2;

            int[] array = { 2, 4, 4, 2 };

            Assert.IsTrue(IsEqual(matrix, array));
        }

        [Test]
        public void ValidationTest_UncorrectDataFirstIndex_ArgumentException()
        {
            var matrix = new SquareMatrix<int>(2);

            Assert.Throws<IndexOutOfRangeException>(() => matrix[-1, 0] = 5);
        }

        [Test]
        public void ValidationTest_UncorrectDataSecondIndex_ArgumentException()
        {
            var matrix = new SquareMatrix<int>(2);

            Assert.Throws<IndexOutOfRangeException>(() => matrix[0, -1] = 5);
        }

        [Test]
        public void ValidationTest_UncorrectMatrixSize_ArgumentException()
            => Assert.Throws<ArgumentException>(() => new SquareMatrix<int>(0));

        [Test]
        public void ValidationTest_DifferentSizes_InvalidOperationException()
        {
            var matrix1 = new SquareMatrix<int>(2);
            var matrix2 = new SquareMatrix<int>(3);
            SquareMatrix<int> matrix;

            Assert.Throws<InvalidOperationException>(() => matrix = matrix1 + matrix2);
        }

        [Test]
        public void ValidationTest_DiagonalUncorrectValue_InvalidOperationException()
        {
            var matrix = new DiagonalMatrix<int>(3);

            Assert.Throws<InvalidOperationException>(() => matrix[0, 1] = 5);
        }


        private void GetData(object obj, DataEventArgs e)
        {
            data = e.Message;
        }

        private bool IsEqual(BaseMatrix<int> matrix, int[] expectedResult)
        {
            int count = 0;

            for (int i = 0; i < matrix.Size; i++)
            {
                for (int j = 0; j < matrix.Size; j++)
                {
                    if (!(matrix[i, j].Equals(expectedResult[count++])))
                        return false;
                }
            }

            return true;
        }
    }
}
