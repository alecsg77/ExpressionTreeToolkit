// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JetBrains.Annotations;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<BinaryExpression>
    {
        /// <summary>Determines whether the children of the two BinaryExpression are equal.</summary>
        /// <param name="x">The first BinaryExpression to compare.</param>
        /// <param name="y">The second BinaryExpression to compare.</param>
        /// <returns>true if the specified BinaryExpression are equal; otherwise, false.</returns>
        protected virtual bool EqualsBinary([NotNull] BinaryExpression x, [NotNull] BinaryExpression y)
        {
            return x.Type == y.Type
                && Equals(x.Method, y.Method)
                && Equals(x.Left, y.Left)
                && Equals(x.Right, y.Right)
                && Equals(x.Conversion, y.Conversion);
        }

        /// <summary>Gets the hash code for the specified BinaryExpression.</summary>
        /// <param name="node">The BinaryExpression for which to get a hash code.</param>
        /// <returns>A hash code for the specified BinaryExpression.</returns>
        protected virtual int GetHashCodeBinary([NotNull] BinaryExpression node)
        {
            return GetHashCode(
                GetDefaultHashCode(node.Type),
                GetDefaultHashCode(node.Method),
                GetHashCode(node.Left),
                GetHashCode(node.Right),
                GetHashCode(node.Conversion));
        }

        /// <summary>Determines whether the specified BinaryExpressions are equal.</summary>
        /// <param name="x">The first BinaryExpression to compare.</param>
        /// <param name="y">The second BinaryExpression to compare.</param>
        /// <returns>true if the specified BinaryExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<BinaryExpression>.Equals(BinaryExpression x, BinaryExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsBinary(x, y);
        }

        /// <summary>Returns a hash code for the specified BinaryExpression.</summary>
        /// <param name="obj">The <see cref="BinaryExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified BinaryExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<BinaryExpression>.GetHashCode(BinaryExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeBinary(obj);
        }
    }
}