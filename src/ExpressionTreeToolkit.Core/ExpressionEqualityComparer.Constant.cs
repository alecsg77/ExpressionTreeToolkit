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
    partial class ExpressionEqualityComparer : IEqualityComparer<ConstantExpression>
    {
        /// <summary>Determines whether the children of the two <see cref="ConstantExpression"/> are equal.</summary>
        /// <param name="x">The first <see cref="ConstantExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="ConstantExpression"/> to compare.</param>
        /// <param name="context"></param>
        /// <returns>true if the specified <see cref="ConstantExpression"/> are equal; otherwise, false.</returns>
        protected virtual bool EqualsConstant([DisallowNull] ConstantExpression x, [DisallowNull] ConstantExpression y, [DisallowNull] ComparisonContext context)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            return x.Type == y.Type
                   && Equals(x.Value, y.Value);
        }

        /// <summary>Gets the hash code for the specified <see cref="ConstantExpression"/>.</summary>
        /// <param name="node">The <see cref="ConstantExpression"/> for which to get a hash code.</param>
        /// <returns>A hash code for the specified <see cref="ConstantExpression"/>.</returns>
        protected virtual int GetHashCodeConstant([DisallowNull] ConstantExpression node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));
            return GetHashCode(
                GetDefaultHashCode(node.Type),
                GetDefaultHashCode(node.Value));
        }

        /// <summary>Determines whether the specified <see cref="ConstantExpression"/>s are equal.</summary>
        /// <param name="x">The first <see cref="ConstantExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="ConstantExpression"/> to compare.</param>
        /// <returns>true if the specified <see cref="ConstantExpression"/>s are equal; otherwise, false.</returns>
        bool IEqualityComparer<ConstantExpression>.Equals([AllowNull] ConstantExpression? x, [AllowNull] ConstantExpression? y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsConstant(x, y, BeginScope());
        }

        /// <summary>Returns a hash code for the specified <see cref="ConstantExpression"/>.</summary>
        /// <param name="obj">The <see cref="ConstantExpression"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified <see cref="ConstantExpression"/>.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<ConstantExpression>.GetHashCode([DisallowNull] ConstantExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeConstant(obj);
        }
    }
}