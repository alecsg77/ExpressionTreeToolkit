﻿// Copyright (c) 2018 Alessio Gogna
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
    partial class ExpressionEqualityComparer : IEqualityComparer<UnaryExpression>
    {
        /// <summary>Determines whether the children of the two <see cref="UnaryExpression"/> are equal.</summary>
        /// <param name="x">The first <see cref="UnaryExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="UnaryExpression"/> to compare.</param>
        /// <param name="context"></param>
        /// <returns>true if the specified <see cref="UnaryExpression"/> are equal; otherwise, false.</returns>
        protected virtual bool EqualsUnary([DisallowNull] UnaryExpression x, [DisallowNull] UnaryExpression y, [DisallowNull] ComparisonContext context)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            return x.Type == y.Type
                   && Equals(x.Method, y.Method)
                   && Equals(x.Operand, y.Operand, context);
        }

        /// <summary>Gets the hash code for the specified <see cref="UnaryExpression"/>.</summary>
        /// <param name="node">The <see cref="UnaryExpression"/> for which to get a hash code.</param>
        /// <returns>A hash code for the specified <see cref="UnaryExpression"/>.</returns>
        protected virtual int GetHashCodeUnary([DisallowNull] UnaryExpression node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));
            return GetHashCode(
                GetDefaultHashCode(node.Type),
                GetDefaultHashCode(node.Method),
                GetHashCode(node.Operand));
        }

        /// <summary>Determines whether the specified <see cref="UnaryExpression"/>s are equal.</summary>
        /// <param name="x">The first <see cref="UnaryExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="UnaryExpression"/> to compare.</param>
        /// <returns>true if the specified <see cref="UnaryExpression"/>s are equal; otherwise, false.</returns>
        bool IEqualityComparer<UnaryExpression>.Equals([AllowNull] UnaryExpression? x, [AllowNull] UnaryExpression? y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsUnary(x, y, BeginScope());
        }

        /// <summary>Returns a hash code for the specified <see cref="UnaryExpression"/>.</summary>
        /// <param name="obj">The <see cref="UnaryExpression"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified <see cref="UnaryExpression"/>.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<UnaryExpression>.GetHashCode([DisallowNull] UnaryExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeUnary(obj);
        }
    }
}