using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrixes.Matrix
{
    public class DiagonalMatrix<T> : BaseMatrix<T>
    {
        /// <summary>
        /// Constructor without parameters.
        /// </summary>
        public DiagonalMatrix() : base()
        {
        }

        /// <summary>
        /// Create a matrix of concrete size.
        /// </summary>
        /// <param name="size">The size of matrix.</param>
        public DiagonalMatrix(int size) : base(size)
        {
        }

        /// <summary>
        /// Create a matrix with values from array.
        /// </summary>
        /// <param name="array"></param>
        /// <exception cref="InvalidCastException">if array is not symmetric.</exception>
        public DiagonalMatrix(T[,] array)
        {
            int root = (int)Math.Sqrt(array.Length);

            if (array.Length - root * root > 0.01)
            {
                throw new ArgumentException(nameof(array));
            }

            CheckArray(array, root);

            this.Size = root;
            this.matrixArray = array;
        }

        /// <summary>
        /// Sum between one <see cref="DiagonalMatrix{T}"/> with another <see cref="DiagonalMatrix{T}"/>.
        /// </summary>
        /// <param name="diagonalA">First <see cref="DiagonalMatrix{T}"/>.</param>
        /// <param name="diagonalB">Second <see cref="DiagonalMatrix{T}"/>.</param>
        /// <returns>New <see cref="SymmetricMatrix{T}"/>.</returns>
        public static DiagonalMatrix<T> operator +(DiagonalMatrix<T> diagonalA, DiagonalMatrix<T> diagonalB)
        {
            CheckSize(diagonalA, diagonalB);

            return NewMatrix(diagonalA, diagonalB);
        }

        /// <summary>
        /// Method to set value to the matrix
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="i">The number of the string.</param>
        /// <param name="j">The number of the row.</param>
        protected override void SetValue(T value, int i, int j)
        {
            if (i != j)
            {
                throw new InvalidOperationException($"Cannot change not diagonal values.");
            }

            matrixArray[i, j] = value;
        }

        private static DiagonalMatrix<T> NewMatrix(BaseMatrix<T> matrixA, BaseMatrix<T> matrixB)
        {
            DiagonalMatrix<T> result = new DiagonalMatrix<T>(matrixA.Size);

            for (int i = 0; i < matrixA.Size; i++)
            {
                    result[i, i] = (dynamic)matrixA[i, i] + (dynamic)matrixB[i, i];
            }

            return result;
        }

        private void CheckArray(T[,] array, int length)
        {
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if ((i != j) && !array[i, j].Equals(default(T)))
                    {
                        throw new ArgumentException(nameof(array));
                    }
                }
            }
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
