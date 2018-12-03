using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrixes.Matrix
{
    public class SquareMatrix<T> : BaseMatrix<T>
    {
        /// <summary>
        /// Constructor without parameters.
        /// </summary>
        public SquareMatrix() : base()
        {
        }

        /// <summary>
        /// Create a matrix of concrete size.
        /// </summary>
        /// <param name="size">The size of matrix.</param>
        /// <exception cref="ArgumentException">if size is zero or less.</exception>
        public SquareMatrix(int size) : base(size)
        {
        }

        /// <summary>
        /// Create a matrix with values from array.
        /// </summary>
        /// <param name="array"></param>
        /// <exception cref="InvalidCastException">if array is not square.</exception>
        public SquareMatrix(T[,] array)
        {
            int root = (int)Math.Sqrt(array.Length);

            if (array.Length - root * root > 0.01)
            {
                throw new ArgumentException(nameof(array));
            }

            this.Size = root;
            this.matrixArray = array;
        }

        /// <summary>
        /// Sum between one <see cref="SquareMatrix{T}"/> with another <see cref="SquareMatrix{T}"/>.
        /// </summary>
        /// <param name="squareA">First <see cref="SquareMatrix{T}"/>.</param>
        /// <param name="squareB">Second <see cref="SquareMatrix{T}"/>.</param>
        /// <returns>New <see cref="SquareMatrix{T}"/>.</returns>
        public static SquareMatrix<T> operator +(SquareMatrix<T> squareA, SquareMatrix<T> squareB)
        {
            CheckSize(squareA, squareB);

            return NewMatrix(squareA, squareB);
        }

        /// <summary>
        /// Sum between one <see cref="SquareMatrix{T}"/> with another <see cref="SymmetricMatrix{T}"/>.
        /// </summary>
        /// <param name="square"><see cref="SquareMatrix{T}"/>.</param>
        /// <param name="symmetric"><see cref="SymmetricMatrix{T}"/>.</param>
        /// <returns>New <see cref="SquareMatrix{T}"/>.</returns>
        public static SquareMatrix<T> operator +(SquareMatrix<T> square, SymmetricMatrix<T> symmetric)
        {
            CheckSize(square, symmetric);

            return NewMatrix(square, symmetric);
        }

        /// <summary>
        /// Sum between one <see cref="SquareMatrix{T}"/> with another <see cref="DiagonalMatrix{T}"/>.
        /// </summary>
        /// <param name="square"><see cref="SquareMatrix{T}"/>.</param>
        /// <param name="diagonal"><see cref="DiagonalMatrix{T}"/>.</param>
        /// <returns>New <see cref="SquareMatrix{T}"/>.</returns>
        public static SquareMatrix<T> operator +(SquareMatrix<T> square, DiagonalMatrix<T> diagonal)
        {
            CheckSize(square, diagonal);

            return NewMatrix(square, diagonal);
        }

        /// <summary>
        /// Method to set value to the matrix
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="i">The number of the string.</param>
        /// <param name="j">The number of the row.</param>
        protected override void SetValue(T value, int i, int j)
        {
            matrixArray[i, j] = value;
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
