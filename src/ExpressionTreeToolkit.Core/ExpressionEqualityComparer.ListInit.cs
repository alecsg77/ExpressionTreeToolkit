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
    partial class ExpressionEqualityComparer : IEqualityComparer<ListInitExpression>
    {
        /// <summary>Determines whether the children of the two <see cref="ListInitExpression"/> are equal.</summary>
        /// <param name="x">The first <see cref="ListInitExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="ListInitExpression"/> to compare.</param>
        /// <param name="context"></param>
        /// <returns>true if the specified <see cref="ListInitExpression"/> are equal; otherwise, false.</returns>
        protected virtual bool EqualsListInit([DisallowNull] ListInitExpression x, [DisallowNull] ListInitExpression y, [DisallowNull] ComparisonContext context)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            return x.Type == y.Type
                   && Equals(x.NewExpression, y.NewExpression, context)
                   && Equals(x.Initializers, y.Initializers, EqualsElementInit, context);
        }

        /// <summary>Gets the hash code for the specified <see cref="ListInitExpression"/>.</summary>
        /// <param name="node">The <see cref="ListInitExpression"/> for which to get a hash code.</param>
        /// <returns>A hash code for the specified <see cref="ListInitExpression"/>.</returns>
        protected virtual int GetHashCodeListInit([DisallowNull] ListInitExpression node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));
            return GetHashCode(
                GetDefaultHashCode(node.Type),
                GetHashCode(node.NewExpression),
                GetHashCode(node.Initializers, GetHashCodeElementInit));
        }

        /// <summary>Determines whether the specified <see cref="ListInitExpression"/>s are equal.</summary>
        /// <param name="x">The first <see cref="ListInitExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="ListInitExpression"/> to compare.</param>
        /// <returns>true if the specified <see cref="ListInitExpression"/>s are equal; otherwise, false.</returns>
        bool IEqualityComparer<ListInitExpression>.Equals([AllowNull] ListInitExpression? x, [AllowNull] ListInitExpression? y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsListInit(x, y, BeginScope());
        }

        /// <summary>Returns a hash code for the specified <see cref="ListInitExpression"/>.</summary>
        /// <param name="obj">The <see cref="ListInitExpression"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified <see cref="ListInitExpression"/>.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<ListInitExpression>.GetHashCode([DisallowNull] ListInitExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeListInit(obj);
        }
    }
}