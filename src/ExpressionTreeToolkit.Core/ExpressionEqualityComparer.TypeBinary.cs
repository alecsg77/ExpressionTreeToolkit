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
    partial class ExpressionEqualityComparer : IEqualityComparer<TypeBinaryExpression>
    {
        /// <summary>Determines whether the children of the two <see cref="TypeBinaryExpression"/> are equal.</summary>
        /// <param name="x">The first <see cref="TypeBinaryExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="TypeBinaryExpression"/> to compare.</param>
        /// <param name="context"></param>
        /// <returns>true if the specified <see cref="TypeBinaryExpression"/> are equal; otherwise, false.</returns>
        protected virtual bool EqualsTypeBinary([DisallowNull] TypeBinaryExpression x,
            [DisallowNull] TypeBinaryExpression y, [DisallowNull] ComparisonContext context)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            return x.Type == y.Type
                   && x.TypeOperand == y.TypeOperand
                   && Equals(x.Expression, y.Expression, context);
        }

        /// <summary>Gets the hash code for the specified <see cref="TypeBinaryExpression"/>.</summary>
        /// <param name="node">The <see cref="TypeBinaryExpression"/> for which to get a hash code.</param>
        /// <returns>A hash code for the specified <see cref="TypeBinaryExpression"/>.</returns>
        protected virtual int GetHashCodeTypeBinary([DisallowNull] TypeBinaryExpression node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));
            return GetHashCode(
                GetDefaultHashCode(node.Type),
                GetDefaultHashCode(node.TypeOperand),
                GetHashCode(node.Expression));
        }

        /// <summary>Determines whether the specified <see cref="TypeBinaryExpression"/>s are equal.</summary>
        /// <param name="x">The first <see cref="TypeBinaryExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="TypeBinaryExpression"/> to compare.</param>
        /// <returns>true if the specified <see cref="TypeBinaryExpression"/>s are equal; otherwise, false.</returns>
        bool IEqualityComparer<TypeBinaryExpression>.Equals([AllowNull] TypeBinaryExpression? x, [AllowNull] TypeBinaryExpression? y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsTypeBinary(x, y, BeginScope());
        }

        /// <summary>Returns a hash code for the specified <see cref="TypeBinaryExpression"/>.</summary>
        /// <param name="obj">The <see cref="TypeBinaryExpression"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified <see cref="TypeBinaryExpression"/>.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<TypeBinaryExpression>.GetHashCode([DisallowNull] TypeBinaryExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeTypeBinary(obj);
        }
    }
}