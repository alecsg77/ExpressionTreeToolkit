// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Diagnostics.CodeAnalysis;

#if JETBRAINS_ANNOTATIONS
using AllowNullAttribute  = JetBrains.Annotations.CanBeNullAttribute;
using DisallowNullAttribute = JetBrains.Annotations.NotNullAttribute;
using AllowItemNullAttribute = JetBrains.Annotations.ItemCanBeNullAttribute;
#endif

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<DefaultExpression>
    {
        /// <summary>Determines whether the children of the two DefaultExpression are equal.</summary>
        /// <param name="x">The first DefaultExpression to compare.</param>
        /// <param name="y">The second DefaultExpression to compare.</param>
        /// <param name="context"></param>
        /// <returns>true if the specified DefaultExpression are equal; otherwise, false.</returns>
        protected virtual bool EqualsDefault([DisallowNull] DefaultExpression x, [DisallowNull] DefaultExpression y, [DisallowNull] ComparisonContext context)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            return x.Type == y.Type;
        }

        /// <summary>Gets the hash code for the specified DefaultExpression.</summary>
        /// <param name="node">The DefaultExpression for which to get a hash code.</param>
        /// <returns>A hash code for the specified DefaultExpression.</returns>
        protected virtual int GetHashCodeDefault([DisallowNull] DefaultExpression node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));
            return GetDefaultHashCode(node.Type);
        }

        /// <summary>Determines whether the specified DefaultExpressions are equal.</summary>
        /// <param name="x">The first DefaultExpression to compare.</param>
        /// <param name="y">The second DefaultExpression to compare.</param>
        /// <returns>true if the specified DefaultExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<DefaultExpression>.Equals([AllowNull] DefaultExpression? x, [AllowNull] DefaultExpression? y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsDefault(x, y, BeginScope());
        }

        /// <summary>Returns a hash code for the specified DefaultExpression.</summary>
        /// <param name="obj">The <see cref="DefaultExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified DefaultExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<DefaultExpression>.GetHashCode([DisallowNull] DefaultExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeDefault(obj);
        }
    }
}