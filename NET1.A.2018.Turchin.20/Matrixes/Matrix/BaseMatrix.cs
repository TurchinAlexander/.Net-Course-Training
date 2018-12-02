using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Matrixes.DataEvent;

namespace Matrixes.Matrix
{
    internal abstract class BaseMatrix<T>
    {
        private const int defaultSize = 5;
        protected T[,] array;

        public int Size { get; }
        public event EventHandler<DataEventArgs> OnChanged = delegate { };

        public BaseMatrix() : this(defaultSize)
        {
        }

        public BaseMatrix(int size)
        {
            if (size < 1)
            {
                throw new ArgumentException($"{nameof(size)} cannot be less than 1");
            }

            this.Size = size;
            array = new T[this.Size, this.Size];
        }

        public T this[int i, int j]
        {
            get
            {
                ValidateIndexes(i, j);

                return array[i, j];
            }

            set
            {
                ValidateIndexes(i, j);
                SetValue(value, i, j);
                CallEvent(i, j);
            }
        }

        public abstract void ValidateSet(int i, int j);
        public abstract void SetValue(T value, int i, int j);

        public virtual void CallEvent(int i, int j)
        {
            string message = $"The element A[{i},{j}] has been changed.";

            OnChanged(this, new DataEventArgs(message));
        }

        protected T[,] Add(T[,] a, T[,] b)
        {
            T[,] result = new T[this.Size, this.Size];

            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    result[i, j] = (dynamic)a[i, j] + (dynamic)b[i, j];
                }
            }

            return result;
        }

        private void ValidateIndexes(int i, int j)
        {
            if ((i < 0) && (i > this.Size))
            {
                throw new ArgumentException($"{nameof(i)} is invalid!");
            }

            if ((j < 0) && (j > this.Size))
            {
                throw new ArgumentException($"{nameof(j)} is invalid!");
            }
        }

        private void CheckSizes(BaseMatrix<T> a, BaseMatrix<T> b)
        {
            if (a.Size != b.Size)
            {
                throw new InvalidOperationException($"Matrixes have different sizes");
            }
        }
    }
}
