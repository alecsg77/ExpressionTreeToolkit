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
    partial class ExpressionEqualityComparer : IEqualityComparer<BinaryExpression>
    {
        /// <summary>Determines whether the children of the two <see cref="BinaryExpression"/> are equal.</summary>
        /// <param name="x">The first <see cref="BinaryExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="BinaryExpression"/> to compare.</param>
        /// <param name="context"></param>
        /// <returns>true if the specified <see cref="BinaryExpression"/> are equal; otherwise, false.</returns>
        protected virtual bool EqualsBinary([DisallowNull] BinaryExpression x, [DisallowNull] BinaryExpression y, [DisallowNull] ComparisonContext context)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            return x.Type == y.Type
                   && Equals(x.Method, y.Method)
                   && Equals(x.Left, y.Left, context)
                   && Equals(x.Right, y.Right, context)
                   && Equals(x.Conversion, y.Conversion, context);
        }

        /// <summary>Gets the hash code for the specified <see cref="BinaryExpression"/>.</summary>
        /// <param name="node">The <see cref="BinaryExpression"/> for which to get a hash code.</param>
        /// <returns>A hash code for the specified <see cref="BinaryExpression"/>.</returns>
        protected virtual int GetHashCodeBinary([DisallowNull] BinaryExpression node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));
            return GetHashCode(
                GetDefaultHashCode(node.Type),
                GetDefaultHashCode(node.Method),
                GetHashCode(node.Left),
                GetHashCode(node.Right),
                GetHashCode(node.Conversion));
        }

        /// <summary>Determines whether the specified <see cref="BinaryExpression"/>s are equal.</summary>
        /// <param name="x">The first <see cref="BinaryExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="BinaryExpression"/> to compare.</param>
        /// <returns>true if the specified <see cref="BinaryExpression"/>s are equal; otherwise, false.</returns>
        bool IEqualityComparer<BinaryExpression>.Equals([AllowNull] BinaryExpression? x, [AllowNull] BinaryExpression? y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsBinary(x, y, BeginScope());
        }

        /// <summary>Returns a hash code for the specified <see cref="BinaryExpression"/>.</summary>
        /// <param name="obj">The <see cref="BinaryExpression"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified <see cref="BinaryExpression"/>.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<BinaryExpression>.GetHashCode([DisallowNull] BinaryExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeBinary(obj);
        }
    }
}