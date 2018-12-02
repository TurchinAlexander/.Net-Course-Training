using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrixes.Matrix
{
    public class DiagonalMatrix<T> : BaseMatrix<T>
    {
        public DiagonalMatrix() : base()
        {
        }

        public DiagonalMatrix(int size) : base(size)
        {
        }

        public override void SetValue(T value, int i, int j)
        {
            if (i != j)
            {
                throw new InvalidOperationException($"Cannot change not diagonal values.");
            }

            array[i, j] = value;
        }

        public static DiagonalMatrix<T> operator +(DiagonalMatrix<T> diagonalA, DiagonalMatrix<T> diagonalB)
        {
            CheckSize(diagonalA, diagonalB);

            return NewMatrix(diagonalA, diagonalB);
        }

        private static DiagonalMatrix<T> NewMatrix(BaseMatrix<T> matrixA, BaseMatrix<T> matrixB)
        {
            DiagonalMatrix<T> result = new DiagonalMatrix<T>(matrixA.Size);

            for (int i = 0; i < matrixA.Size; i++)
            {
                for (int j = 0; j < matrixA.Size; j++)
                {
                    result[i, j] = (dynamic)matrixA[i, j] + (dynamic)matrixB[i, j];
                }
            }

            return result;
        }

        private static void CheckSize(BaseMatrix<T> a, BaseMatrix<T> b)
        {
            if (a.Size != b.Size)
            {
                throw new InvalidOperationException($"Matrixes have different sizes");
            }
        }
    }
}
