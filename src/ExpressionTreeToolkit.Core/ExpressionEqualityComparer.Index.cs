// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<IndexExpression>
    {
        private bool EqualsIndex(IndexExpression x, IndexExpression y)
        {
            return x.Type == y.Type
                   && EqualsExpression(x.Object, y.Object)
                   && Equals(x.Indexer, y.Indexer)
                   && EqualsExpressionList(x.Arguments, y.Arguments);
        }

        private int GetHashCodeIndex(IndexExpression node)
        {
            return GetHashCode(
                GetHashCodeSafe(node.Type),
                GetHashCodeExpression(node.Object),
                GetHashCodeSafe(node.Indexer),
                GetHashCodeExpressionList(node.Arguments));
        }

        /// <summary>Determines whether the specified IndexExpressions are equal.</summary>
        /// <param name="x">The first IndexExpression to compare.</param>
        /// <param name="y">The second IndexExpression to compare.</param>
        /// <returns>true if the specified IndexExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<IndexExpression>.Equals(IndexExpression x, IndexExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsIndex(x, y);
        }

        /// <summary>Returns a hash code for the specified IndexExpression.</summary>
        /// <param name="obj">The <see cref="IndexExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified IndexExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<IndexExpression>.GetHashCode(IndexExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeIndex(obj);
        }
    }
}