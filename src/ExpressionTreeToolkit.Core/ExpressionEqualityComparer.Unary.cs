// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<UnaryExpression>
    {
        private bool EqualsUnary(UnaryExpression x, UnaryExpression y)
        {
            return Equals(x.Method, y.Method)
                   && Equals(x.Operand, y.Operand);
        }

        private IEnumerable<int> GetHashElementsUnary(UnaryExpression unary)
        {
            return GetHashElements(
                unary.Method,
                unary.Operand);
        }

        /// <summary>Determines whether the specified UnaryExpressions are equal.</summary>
        /// <param name="x">The first UnaryExpression to compare.</param>
        /// <param name="y">The second UnaryExpression to compare.</param>
        /// <returns>true if the specified UnaryExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<UnaryExpression>.Equals(UnaryExpression x, UnaryExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y)
                   && EqualsUnary(x, y);
        }

        /// <summary>Returns a hash code for the specified UnaryExpression.</summary>
        /// <param name="obj">The <see cref="UnaryExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified UnaryExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<UnaryExpression>.GetHashCode(UnaryExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeExpression(
                obj,
                GetHashElementsUnary(obj));
        }
    }
}