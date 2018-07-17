// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JetBrains.Annotations;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<IndexExpression>
    {
        /// <summary>Determines whether the children of the two IndexExpression are equal.</summary>
        /// <param name="x">The first IndexExpression to compare.</param>
        /// <param name="y">The second IndexExpression to compare.</param>
        /// <returns>true if the specified IndexExpression are equal; otherwise, false.</returns>
        protected virtual bool EqualsIndex([NotNull] IndexExpression x, [NotNull] IndexExpression y)
        {
            return x.Type == y.Type
                   && Equals(x.Object, y.Object)
                   && Equals(x.Indexer, y.Indexer)
                   && Equals(x.Arguments, y.Arguments);
        }

        /// <summary>Gets the hash code for the specified IndexExpression.</summary>
        /// <param name="node">The IndexExpression for which to get a hash code.</param>
        /// <returns>A hash code for the specified IndexExpression.</returns>
        protected virtual int GetHashCodeIndex([NotNull] IndexExpression node)
        {
            return GetHashCode(
                GetDefaultHashCode(node.Type),
                GetHashCode(node.Object),
                GetDefaultHashCode(node.Indexer),
                GetHashCode(node.Arguments));
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