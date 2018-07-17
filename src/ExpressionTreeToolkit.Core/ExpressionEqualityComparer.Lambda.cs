// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JetBrains.Annotations;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<LambdaExpression>
    {
        /// <summary>Determines whether the children of the two LambdaExpression are equal.</summary>
        /// <param name="x">The first LambdaExpression to compare.</param>
        /// <param name="y">The second LambdaExpression to compare.</param>
        /// <returns>true if the specified LambdaExpression are equal; otherwise, false.</returns>
        protected virtual bool EqualsLambda([NotNull] LambdaExpression x, LambdaExpression y)
        {
            return x.Type == y.Type
                && Equals(x.Parameters, y.Parameters, EqualsParameter)
                && new ExpressionEqualityComparer(x.Parameters, y.Parameters).Equals(x.Body, y.Body);
        }

        /// <summary>Gets the hash code for the specified LambdaExpression.</summary>
        /// <param name="node">The LambdaExpression for which to get a hash code.</param>
        /// <returns>A hash code for the specified LambdaExpression.</returns>
        protected virtual int GetHashCodeLambda([NotNull] LambdaExpression node)
        {
            return GetHashCode(
                GetDefaultHashCode(node.Type),
                GetHashCode(node.Parameters, GetHashCodeParameter),
                GetHashCode(node.Body));
        }

        /// <summary>Determines whether the specified LambdaExpressions are equal.</summary>
        /// <param name="x">The first LambdaExpression to compare.</param>
        /// <param name="y">The second LambdaExpression to compare.</param>
        /// <returns>true if the specified LambdaExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<LambdaExpression>.Equals(LambdaExpression x, LambdaExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsLambda(x, y);
        }

        /// <summary>Returns a hash code for the specified LambdaExpression.</summary>
        /// <param name="obj">The <see cref="LambdaExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified LambdaExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<LambdaExpression>.GetHashCode(LambdaExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeLambda(obj);
        }
    }
}