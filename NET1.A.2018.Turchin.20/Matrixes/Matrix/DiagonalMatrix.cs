using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrixes.Matrix
{
    public class DiagonalMatrix<T> : BaseMatrix<T>
    {
        private T[] matrixArray;

        /// <summary>
        /// Constructor without parameters.
        /// </summary>
        public DiagonalMatrix() : base()
        {
            matrixArray = new T[defaultSize];
        }

        /// <summary>
        /// Create a matrix of concrete size.
        /// </summary>
        /// <param name="size">The size of matrix.</param>
        public DiagonalMatrix(int size) : base(size)
        {
            matrixArray = new T[size];
        }

        /// <summary>
        /// Create a matrix with values from array.
        /// </summary>
        /// <param name="array"></param>
        /// <exception cref="InvalidCastException">if array is not diagonal.</exception>
        public DiagonalMatrix(T[,] array)
        {
            CheckArray(array);

            this.Size = array.GetLength(0);
            this.matrixArray = TakeValues(array);
        }

        /// <summary>
        /// Method to set value to the matrix
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="i">The number of the string.</param>
        /// <param name="j">The number of the row.</param>
        protected override void SetValue(T value, int i, int j)
        {
            dynamic temp = value;

            if (i == j)
            {
                matrixArray[i] = value;
            }
            else if (!temp.Equals(default(T)))
            {
                throw new InvalidOperationException($"Cannot change not diagonal values.");
            }
        }

        /// <summary>
        /// Method to get value from the matrix.
        /// </summary>
        /// <param name="i">Index of the row.</param>
        /// <param name="j">Index of the column.</param>
        /// <returns>The value of <see cref="T"/>.</returns>
        protected override T GetValue(int i, int j)
        {
            if (i == j)
            {
                return matrixArray[i];
            }
            else
            {
                return default(T);
            }
        }

        private void CheckArray(T[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    if ((i != j) && !array[i, j].Equals(default(T)))
                    {
                        throw new ArgumentException(nameof(array));
                    }
                }
        }

        private T[] TakeValues(T[,] array)
        {
            T[] result = new T[array.GetLength(0)];

            for (int i = 0; i < array.Length; i++)
            {
                result[i] = array[i, i];
            }

            return result;
        }

        
    }
}
