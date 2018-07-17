// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JetBrains.Annotations;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<ConstantExpression>
    {
        /// <summary>Determines whether the children of the two ConstantExpression are equal.</summary>
        /// <param name="x">The first ConstantExpression to compare.</param>
        /// <param name="y">The second ConstantExpression to compare.</param>
        /// <returns>true if the specified ConstantExpression are equal; otherwise, false.</returns>
        protected virtual bool EqualsConstant([NotNull] ConstantExpression x, [NotNull] ConstantExpression y)
        {
            return x.Type == y.Type
                   && Equals(x.Value, y.Value);
        }

        /// <summary>Gets the hash code for the specified ConstantExpression.</summary>
        /// <param name="node">The ConstantExpression for which to get a hash code.</param>
        /// <returns>A hash code for the specified ConstantExpression.</returns>
        protected virtual int GetHashCodeConstant([NotNull] ConstantExpression node)
        {
            return GetHashCode(
                GetDefaultHashCode(node.Type),
                GetDefaultHashCode(node.Value));
        }

        /// <summary>Determines whether the specified ConstantExpressions are equal.</summary>
        /// <param name="x">The first ConstantExpression to compare.</param>
        /// <param name="y">The second ConstantExpression to compare.</param>
        /// <returns>true if the specified ConstantExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<ConstantExpression>.Equals(ConstantExpression x, ConstantExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsConstant(x, y);
        }

        /// <summary>Returns a hash code for the specified ConstantExpression.</summary>
        /// <param name="obj">The <see cref="ConstantExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified ConstantExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<ConstantExpression>.GetHashCode(ConstantExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeConstant(obj);
        }
    }
}