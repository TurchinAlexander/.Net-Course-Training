using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Matrixes.DataEvent;

namespace Matrixes.Matrix
{
    public abstract class BaseMatrix<T>
    {
        private const int defaultSize = 5;
        protected T[,] matrixArray;

        /// <summary>
        /// Size of the matrix
        /// </summary>
        public int Size { get; protected set; }
        /// <summary>
        /// Event when element of the matrix is changed.
        /// </summary>
        public event EventHandler<DataEventArgs> OnChanged = delegate { };

        /// <summary>
        /// Constructor without parameters.
        /// </summary>
        public BaseMatrix() : this(defaultSize)
        {
        }

        /// <summary>
        /// Create a matrix of concrete size.
        /// </summary>
        /// <param name="size">The size of matrix.</param>
        /// <exception cref="ArgumentException">if size is zero or less.</exception>
        public BaseMatrix(int size)
        {
            if (size < 1)
            {
                throw new ArgumentException($"{nameof(size)} cannot be less than 1");
            }

            this.Size = size;
            matrixArray = new T[this.Size, this.Size];
        }

        /// <summary>
        /// Indexer to get value from matrix.
        /// </summary>
        /// <param name="i">The number of the string.</param>
        /// <param name="j">The number of the row.</param>
        /// <returns>Value from the matrix</returns>
        /// <exception cref="IndexOutOfRangeException">if indexes are not valid.</exception>
        public T this[int i, int j]
        {
            get
            {
                ValidateIndexes(i, j);

                return matrixArray[i, j];
            }

            set
            {
                ValidateIndexes(i, j);
                SetValue(value, i, j);
                CallEvent(i, j);
            }
        }

        /// <summary>
        /// Method to call event of setting the value.
        /// </summary>
        /// <param name="i">The number of the string.</param>
        /// <param name="j">The number of the row.</param>
        public virtual void CallEvent(int i, int j)
        {
            string message = $"The element[{i},{j}] has been changed.";

            OnChanged(this, new DataEventArgs(message));
        }

        /// <summary>
        /// Method to set value to the matrix element.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="i">The number of the string.</param>
        /// <param name="j">The number of the row.</param>
        protected abstract void SetValue(T value, int i, int j);

        private void ValidateIndexes(int i, int j)
        {
            if ((i < 0) && (i > this.Size))
            {
                throw new IndexOutOfRangeException($"{nameof(i)} is invalid!");
            }

            if ((j < 0) && (j > this.Size))
            {
                throw new IndexOutOfRangeException($"{nameof(j)} is invalid!");
            }
        }
    }
}
