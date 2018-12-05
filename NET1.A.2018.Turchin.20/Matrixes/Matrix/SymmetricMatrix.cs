using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrixes.Matrix
{
    public class SymmetricMatrix<T> : BaseMatrix<T>
    {
        private T[][] matrixArray;

        /// <summary>
        /// Constructor without parameters.
        /// </summary>
        public SymmetricMatrix() : base()
        {
            matrixArray = CreateJaggedArray(defaultSize);
        }

        /// <summary>
        /// Create a matrix of concrete size.
        /// </summary>
        /// <param name="size">The size of matrix.</param>
        public SymmetricMatrix(int size) : base(size)
        {
            matrixArray = CreateJaggedArray(size);
        }

        /// <summary>
        /// Create a matrix with values from array.
        /// </summary>
        /// <param name="array"></param>
        /// <exception cref="InvalidCastException">if array is not symmetric.</exception>
        public SymmetricMatrix(T[,] array)
        {
            CheckArray(array);

            this.Size = array.GetLength(0);
            this.matrixArray = TakeSymmetricArray(array);
        }

        /// <summary>
        /// Method to set value to the matrix
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="i">The number of the string.</param>
        /// <param name="j">The number of the row.</param>
        protected override void SetValue(T value, int i, int j)
        {
            if (i > j)
            {
                Swap(ref i, ref j);
            }

            matrixArray[i][j - i] = value;
        }

        protected override T GetValue(int i, int j)
        {
            if (i > j)
            {
                Swap(ref i, ref j);
            }

            return matrixArray[i][j - i];
        }

        private void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        private void CheckArray(T[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
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

        private T[][] CreateJaggedArray(int length)
        {
            T[][] result = new T[length][];

            for (int i = 0; i < length; i++)
            {
                result[i] = new T[length - i];
            }

            return result;
        }

        private T[][] TakeSymmetricArray(T[,] array)
        {
            T[][] result = CreateJaggedArray(array.GetLength(0));

            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result[i].Length; j++)
                {
                    result[i][j] = array[i, i + j];
                }
            }

            return result;
        }
    }
}
