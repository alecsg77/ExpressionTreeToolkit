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
            return Equals(x.Test, y.Test)
                   && Equals(x.IfTrue, y.IfTrue)
                   && Equals(x.IfFalse, y.IfFalse);
        }

        private IEnumerable<int> GetHashElementsConditional(ConditionalExpression node)
        {
            return GetHashElements(
                node.Test,
                node.IfTrue,
                node.IfFalse);
        }

        /// <summary>Determines whether the specified ConditionalExpressions are equal.</summary>
        /// <param name="x">The first ConditionalExpression to compare.</param>
        /// <param name="y">The second ConditionalExpression to compare.</param>
        /// <returns>true if the specified ConditionalExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<ConditionalExpression>.Equals(ConditionalExpression x, ConditionalExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y)
                   && EqualsConditional(x, y);
        }

        /// <summary>Returns a hash code for the specified ConditionalExpression.</summary>
        /// <param name="obj">The <see cref="ConditionalExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified ConditionalExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<ConditionalExpression>.GetHashCode(ConditionalExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeExpression(
                obj,
                GetHashElementsConditional(obj));
        }
    }
}