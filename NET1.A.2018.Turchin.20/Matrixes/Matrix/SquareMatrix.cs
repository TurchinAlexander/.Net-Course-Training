using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrixes.Matrix
{
    public class SquareMatrix<T> : BaseMatrix<T>
    {
        public SquareMatrix() : base()
        {
        }

        public SquareMatrix(int size) : base(size)
        {
        }

        public override void SetValue(T value, int i, int j)
        {
            array[i, j] = value;
        }

        public static SquareMatrix<T> operator +(SquareMatrix<T> squareA, SquareMatrix<T> squareB)
        {
            CheckSize(squareA, squareB);

            return NewMatrix(squareA, squareB);
        }

        public static SquareMatrix<T> operator +(SquareMatrix<T> square, SymmetricMatrix<T> symmetric)
        {
            CheckSize(square, symmetric);

            return NewMatrix(square, symmetric);
        }

        private static SquareMatrix<T> NewMatrix(BaseMatrix<T> matrixA, BaseMatrix<T> matrixB)
        {
            SquareMatrix<T> result = new SquareMatrix<T>(matrixA.Size);

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
