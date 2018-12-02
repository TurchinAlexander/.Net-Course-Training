using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrixes.Matrix
{
    public class SymmetricMatrix<T> : BaseMatrix<T>
    {
        /// <summary>
        /// Constructor without parameters.
        /// </summary>
        public SymmetricMatrix() : base()
        {
        }

        /// <summary>
        /// Create a matrix of concrete size.
        /// </summary>
        /// <param name="size">The size of matrix.</param>
        public SymmetricMatrix(int size) : base(size)
        {
        }

        /// <summary>
        /// Create a matrix with values from array.
        /// </summary>
        /// <param name="array"></param>
        /// <exception cref="InvalidCastException">if array is not symmetric.</exception>
        public SymmetricMatrix(T[,] array)
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
        /// Sum between one <see cref="SymmetricMatrix{T}"/> with another <see cref="SymmetricMatrix{T}"/>.
        /// </summary>
        /// <param name="symmetricA">First <see cref="SymmetricMatrix{T}"/>.</param>
        /// <param name="symmetricB">Second <see cref="DiaSymmetricMatrixgonalMatrix{T}"/>.</param>
        /// <returns>New <see cref="SymmetricMatrix{T}"/>.</returns>
        public static SymmetricMatrix<T> operator +(SymmetricMatrix<T> symmetricA, SymmetricMatrix<T> symmetricB)
        {
            CheckSize(symmetricA, symmetricB);

            return NewMatrix(symmetricA, symmetricB);
        }

        /// <summary>
        /// Sum between one <see cref="SymmetricMatrix{T}"/> with another <see cref="SymmetricMatrix{T}"/>.
        /// </summary>
        /// <param name="square"><see cref="SymmetricMatrix{T}"/>.</param>
        /// <param name="diagonal"><see cref="DiagonalMatrix{T}"/>.</param>
        /// <returns>New <see cref="SymmetricMatrix{T}"/>.</returns>
        public static SymmetricMatrix<T> operator +(SymmetricMatrix<T> symmetric, DiagonalMatrix<T> diagonal)
        {
            CheckSize(symmetric, diagonal);

            return NewMatrix(symmetric, diagonal);
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
            matrixArray[j, i] = value;
        }

        private static SymmetricMatrix<T> NewMatrix(BaseMatrix<T> matrixA, BaseMatrix<T> matrixB)
        {
            SymmetricMatrix<T> result = new SymmetricMatrix<T>(matrixA.Size);

            for (int i = 0; i < matrixA.Size; i++)
            {
                for (int j = 0; j < matrixA.Size; j++)
                {
                    result[i, j] = (dynamic)matrixA[i, j] + (dynamic)matrixB[i, j];
                }
            }

            return result;
        }

        private void CheckArray(T[,] array, int length)
        {
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    dynamic temp1 = array[i, j];
                    dynamic temp2 = array[j, i];
                    if (!temp1.Equals(temp2))
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
