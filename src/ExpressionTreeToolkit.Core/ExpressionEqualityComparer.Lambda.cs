// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<LambdaExpression>
    {
        private bool EqualsLambda(LambdaExpression x, LambdaExpression y)
        {
            if (!EqualsList(x.Parameters, y.Parameters, EqualsParameter))
            {
                return false;
            }

            var comparer = new ExpressionEqualityComparer(x.Parameters, y.Parameters);
            return comparer.Equals(x.Body, y.Body);
        }

        private IEnumerable<int> GetHashElementsLambda(LambdaExpression node)
        {
            return GetHashElements(node.Parameters, node.Body);
        }

        /// <summary>Determines whether the specified LambdaExpressions are equal.</summary>
        /// <param name="x">The first LambdaExpression to compare.</param>
        /// <param name="y">The second LambdaExpression to compare.</param>
        /// <returns>true if the specified LambdaExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<LambdaExpression>.Equals(LambdaExpression x, LambdaExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y) && EqualsLambda(x, y);
        }

        /// <summary>Returns a hash code for the specified LambdaExpression.</summary>
        /// <param name="obj">The <see cref="LambdaExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified LambdaExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<LambdaExpression>.GetHashCode(LambdaExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            return GetHashCodeExpression(obj, GetHashElementsLambda(obj));
        }
    }
}