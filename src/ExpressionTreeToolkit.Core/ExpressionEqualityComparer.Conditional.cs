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
    partial class ExpressionEqualityComparer : IEqualityComparer<ConditionalExpression>
    {
        /// <summary>Determines whether the children of the two <see cref="ConditionalExpression"/> are equal.</summary>
        /// <param name="x">The first <see cref="ConditionalExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="ConditionalExpression"/> to compare.</param>
        /// <param name="context"></param>
        /// <returns>true if the specified <see cref="ConditionalExpression"/> are equal; otherwise, false.</returns>
        protected virtual bool EqualsConditional([DisallowNull] ConditionalExpression x, [DisallowNull] ConditionalExpression y, [DisallowNull] ComparisonContext context)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            return x.Type == y.Type
                   && Equals(x.Test, y.Test, context)
                   && Equals(x.IfTrue, y.IfTrue, context)
                   && Equals(x.IfFalse, y.IfFalse, context);
        }

        /// <summary>Gets the hash code for the specified <see cref="ConditionalExpression"/>.</summary>
        /// <param name="node">The <see cref="ConditionalExpression"/> for which to get a hash code.</param>
        /// <returns>A hash code for the specified <see cref="ConditionalExpression"/>.</returns>
        protected virtual int GetHashCodeConditional([DisallowNull] ConditionalExpression node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));
            return GetHashCode(
                GetDefaultHashCode(node.Type),
                GetHashCode(node.Test),
                GetHashCode(node.IfTrue),
                GetHashCode(node.IfFalse));
        }

        /// <summary>Determines whether the specified <see cref="ConditionalExpression"/>s are equal.</summary>
        /// <param name="x">The first <see cref="ConditionalExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="ConditionalExpression"/> to compare.</param>
        /// <returns>true if the specified <see cref="ConditionalExpression"/>s are equal; otherwise, false.</returns>
        bool IEqualityComparer<ConditionalExpression>.Equals([AllowNull] ConditionalExpression? x, [AllowNull] ConditionalExpression? y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsConditional(x, y, BeginScope());
        }

        /// <summary>Returns a hash code for the specified <see cref="ConditionalExpression"/>.</summary>
        /// <param name="obj">The <see cref="ConditionalExpression"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified <see cref="ConditionalExpression"/>.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<ConditionalExpression>.GetHashCode([DisallowNull] ConditionalExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeConditional(obj);
        }
    }
}