using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrixes.Matrix
{
    public class SquareMatrix<T> : BaseMatrix<T>
    {
        private T[,] matrixArray;

        /// <summary>
        /// Constructor without parameters.
        /// </summary>
        public SquareMatrix() : base()
        {
            matrixArray = new T[defaultSize, defaultSize];
        }

        /// <summary>
        /// Create a matrix of concrete size.
        /// </summary>
        /// <param name="size">The size of matrix.</param>
        /// <exception cref="ArgumentException">if size is zero or less.</exception>
        public SquareMatrix(int size) : base(size)
        {
            matrixArray = new T[size, size];
        }

        /// <summary>
        /// Create a matrix with values from array.
        /// </summary>
        /// <param name="array"></param>
        /// <exception cref="InvalidCastException">if array is not square.</exception>
        public SquareMatrix(T[,] array)
        {
            this.Size = array.GetLength(0);
            this.matrixArray = array;
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

        /// <summary>
        /// Method to get value from the matrix.
        /// </summary>
        /// <param name="i">Index of the row.</param>
        /// <param name="j">Index of the column.</param>
        /// <returns>The value of <see cref="T"/>.</returns>
        protected override T GetValue(int i, int j)
        {
            return matrixArray[i, j];
        }
    }
}
