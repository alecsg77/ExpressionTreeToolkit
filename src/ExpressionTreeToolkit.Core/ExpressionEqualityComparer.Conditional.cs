// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<ConditionalExpression>
    {
        private bool EqualsConditional(ConditionalExpression x, ConditionalExpression y)
        {
            return x.Type == y.Type
                   && EqualsExpression(x.Test, y.Test)
                   && EqualsExpression(x.IfTrue, y.IfTrue)
                   && EqualsExpression(x.IfFalse, y.IfFalse);
        }

        private int GetHashCodeConditional(ConditionalExpression node)
        {
            return GetHashCode(
                GetHashCodeSafe(node.Type),
                GetHashCodeExpression(node.Test),
                GetHashCodeExpression(node.IfTrue),
                GetHashCodeExpression(node.IfFalse));
        }

        /// <summary>Determines whether the specified ConditionalExpressions are equal.</summary>
        /// <param name="x">The first ConditionalExpression to compare.</param>
        /// <param name="y">The second ConditionalExpression to compare.</param>
        /// <returns>true if the specified ConditionalExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<ConditionalExpression>.Equals(ConditionalExpression x, ConditionalExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsConditional(x, y);
        }

        /// <summary>Returns a hash code for the specified ConditionalExpression.</summary>
        /// <param name="obj">The <see cref="ConditionalExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified ConditionalExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<ConditionalExpression>.GetHashCode(ConditionalExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));


            return GetHashCodeConditional(obj);
        }
    }
}