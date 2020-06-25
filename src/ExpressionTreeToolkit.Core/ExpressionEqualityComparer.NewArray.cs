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
    partial class ExpressionEqualityComparer : IEqualityComparer<NewArrayExpression>
    {
        /// <summary>Determines whether the children of the two <see cref="NewArrayExpression"/> are equal.</summary>
        /// <param name="x">The first <see cref="NewArrayExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="NewArrayExpression"/> to compare.</param>
        /// <param name="context"></param>
        /// <returns>true if the specified <see cref="NewArrayExpression"/> are equal; otherwise, false.</returns>
        protected virtual bool EqualsNewArray([DisallowNull] NewArrayExpression x, [DisallowNull] NewArrayExpression y, [DisallowNull] ComparisonContext context)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            return x.Type == y.Type
                   && Equals(x.Expressions, y.Expressions, context);
        }

        /// <summary>Gets the hash code for the specified <see cref="NewArrayExpression"/>.</summary>
        /// <param name="node">The <see cref="NewArrayExpression"/> for which to get a hash code.</param>
        /// <returns>A hash code for the specified <see cref="NewArrayExpression"/>.</returns>
        protected virtual int GetHashCodeNewArray([DisallowNull] NewArrayExpression node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));
            return GetHashCode(
                GetDefaultHashCode(node.Type),
                GetHashCode(node.Expressions));
        }

        /// <summary>Determines whether the specified <see cref="NewArrayExpression"/>s are equal.</summary>
        /// <param name="x">The first <see cref="NewArrayExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="NewArrayExpression"/> to compare.</param>
        /// <returns>true if the specified <see cref="NewArrayExpression"/>s are equal; otherwise, false.</returns>
        bool IEqualityComparer<NewArrayExpression>.Equals([AllowNull] NewArrayExpression? x, [AllowNull] NewArrayExpression? y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsNewArray(x, y, BeginScope());
        }

        /// <summary>Returns a hash code for the specified <see cref="NewArrayExpression"/>.</summary>
        /// <param name="obj">The <see cref="NewArrayExpression"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified <see cref="NewArrayExpression"/>.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<NewArrayExpression>.GetHashCode([DisallowNull] NewArrayExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeNewArray(obj);
        }
    }
}