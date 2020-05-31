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
    partial class ExpressionEqualityComparer : IEqualityComparer<BlockExpression>
    {
        /// <summary>Determines whether the children of the two BlockExpression are equal.</summary>
        /// <param name="x">The first BlockExpression to compare.</param>
        /// <param name="y">The second BlockExpression to compare.</param>
        /// <returns>true if the specified BlockExpression are equal; otherwise, false.</returns>
        protected virtual bool EqualsBlock([DisallowNull] BlockExpression x, [DisallowNull] BlockExpression y)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            return x.Type == y.Type
                   && Equals(x.Expressions, y.Expressions)
                   && Equals(x.Variables, y.Variables, EqualsParameter)
                   && Equals(x.Result, y.Result);
        }

        /// <summary>Gets the hash code for the specified BlockExpression.</summary>
        /// <param name="node">The BlockExpression for which to get a hash code.</param>
        /// <returns>A hash code for the specified BlockExpression.</returns>
        protected virtual int GetHashCodeBlock([DisallowNull] BlockExpression node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));
            return GetHashCode(
                GetDefaultHashCode(node.Type),
                GetHashCode(node.Expressions),
                GetHashCode(node.Variables, GetHashCodeParameter),
                GetHashCode(node.Result));
        }

        /// <summary>Determines whether the specified BlockExpression are equal.</summary>
        /// <param name="x">The first BlockExpression to compare.</param>
        /// <param name="y">The second BlockExpression to compare.</param>
        /// <returns>true if the specified BlockExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<BlockExpression>.Equals([AllowNull] BlockExpression? x, [AllowNull] BlockExpression? y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsBlock(x, y);
        }

        /// <summary>Returns a hash code for the specified BlockExpression.</summary>
        /// <param name="obj">The <see cref="BlockExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified BlockExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<BlockExpression>.GetHashCode([DisallowNull] BlockExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeBlock(obj);
        }
    }
}