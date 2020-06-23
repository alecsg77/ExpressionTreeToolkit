﻿// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Diagnostics.CodeAnalysis;

#if JETBRAINS_ANNOTATIONS
using AllowNullAttribute = JetBrains.Annotations.CanBeNullAttribute;
using DisallowNullAttribute = JetBrains.Annotations.NotNullAttribute;
using AllowItemNullAttribute = JetBrains.Annotations.ItemCanBeNullAttribute;
#endif

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<IndexExpression>
    {
        /// <summary>Determines whether the children of the two IndexExpression are equal.</summary>
        /// <param name="x">The first IndexExpression to compare.</param>
        /// <param name="y">The second IndexExpression to compare.</param>
        /// <param name="context"></param>
        /// <returns>true if the specified IndexExpression are equal; otherwise, false.</returns>
        protected virtual bool EqualsIndex([DisallowNull] IndexExpression x, [DisallowNull] IndexExpression y, [DisallowNull] ComparisonContext context)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            return x.Type == y.Type
                   && Equals(x.Object, y.Object, context)
                   && Equals(x.Indexer, y.Indexer)
                   && Equals(x.Arguments, y.Arguments, context);
        }

        /// <summary>Gets the hash code for the specified IndexExpression.</summary>
        /// <param name="node">The IndexExpression for which to get a hash code.</param>
        /// <returns>A hash code for the specified IndexExpression.</returns>
        protected virtual int GetHashCodeIndex([DisallowNull] IndexExpression node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));
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
        bool IEqualityComparer<IndexExpression>.Equals([AllowNull] IndexExpression? x, [AllowNull] IndexExpression? y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsIndex(x, y, BeginScope());
        }

        /// <summary>Returns a hash code for the specified IndexExpression.</summary>
        /// <param name="obj">The <see cref="IndexExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified IndexExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<IndexExpression>.GetHashCode([DisallowNull] IndexExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeIndex(obj);
        }
    }
}