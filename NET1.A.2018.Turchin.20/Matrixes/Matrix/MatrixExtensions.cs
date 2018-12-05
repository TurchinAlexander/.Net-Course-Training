using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp.RuntimeBinder;

namespace Matrixes.Matrix
{
    public static class MatrixExtensions
    {
        /// <summary>
        /// Add two matrixes.
        /// </summary>
        /// <typeparam name="T">Type of values in matrixes.</typeparam>
        /// <param name="firstMatrix"></param>
        /// <param name="secondMatrix"></param>
        /// <exception cref="InvalidOperationException">if cannot add two matrixes.</exception>
        public static void Add<T>(this BaseMatrix<T> firstMatrix, BaseMatrix<T> secondMatrix)
        {
            dynamic resolveMatrix = firstMatrix;
            dynamic resolveOtherMatrix = secondMatrix;

            try
            {
                CheckSize(firstMatrix, secondMatrix);
                Add(resolveMatrix, resolveOtherMatrix);
            }
            catch(RuntimeBinderException)
            {
                throw new InvalidOperationException(nameof(firstMatrix));
            }
        }

        private static void Add<T>(SquareMatrix<T> firstSquare, SquareMatrix<T> secondSquare) => AddLogic(firstSquare, secondSquare);
        private static void Add<T>(SquareMatrix<T> square, SymmetricMatrix<T> symmetric) =>      AddLogic(square, symmetric);
        private static void Add<T>(SquareMatrix<T> square, DiagonalMatrix<T> diagonal) =>        AddLogic(square, diagonal);

        private static void Add<T>(SymmetricMatrix<T> firstSymmetric, SymmetricMatrix<T> secondSymmetric) => AddLogic(firstSymmetric, secondSymmetric);
        private static void Add<T>(SymmetricMatrix<T> symmetric, DiagonalMatrix<T> diagonal) =>              AddLogic(symmetric, diagonal);

        private static void Add<T>(DiagonalMatrix<T> firstDiagonal, DiagonalMatrix<T> secondDiagonal) => AddLogic(firstDiagonal, secondDiagonal);

        private static void AddLogic<T>(BaseMatrix<T> firstMatrix, BaseMatrix<T> secondMatrix)
        {
            for (int i = 0; i < firstMatrix.Size; i++)
            {
                for (int j = 0; j < firstMatrix.Size; j++)
                {
                    try
                    {
                        dynamic value = secondMatrix[i, j];
                        firstMatrix[i, j] += value;
                    }
                    catch (RuntimeBinderException)
                    {
                        throw new InvalidOperationException(nameof(T));
                    }
                }
            }
        }

        private static void AddLogic<T>(SymmetricMatrix<T> firstSymmetric, SymmetricMatrix<T> secondSymmetric)
        {
            for (int i = 0; i < firstSymmetric.Size; i++)
            {
                for (int j = i; j < firstSymmetric.Size; j++)
                {
                    try
                    {
                        dynamic value = secondSymmetric[i, j];
                        firstSymmetric[i, j] += value;
                    }
                    catch (RuntimeBinderException)
                    {
                        throw new InvalidOperationException(nameof(T));
                    }
                }
            }
        }

        private static void CheckSize<T>(BaseMatrix<T> a, BaseMatrix<T> b)
        {
            if (a.Size != b.Size)
            {
                throw new InvalidOperationException($"Matrixes have different sizes");
            }
        }
    }
}
