// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<BlockExpression>
    {
        private bool EqualsBlock(BlockExpression x, BlockExpression y)
        {
            return EqualsExpressionList(x.Expressions, y.Expressions)
                   && EqualsExpressionList(x.Variables, y.Variables)
                   && Equals(x.Result, y.Result);
        }

        private IEnumerable<int> GetHashElementsBlock(BlockExpression node)
        {
            return GetHashElements(
                node.Expressions,
                node.Variables,
                node.Result);
        }

        /// <summary>Determines whether the specified BlockExpression are equal.</summary>
        /// <param name="x">The first BlockExpression to compare.</param>
        /// <param name="y">The second BlockExpression to compare.</param>
        /// <returns>true if the specified BlockExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<BlockExpression>.Equals(BlockExpression x, BlockExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y)
                   && EqualsBlock(x, y);
        }

        /// <summary>Returns a hash code for the specified BlockExpression.</summary>
        /// <param name="obj">The <see cref="BlockExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified BlockExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<BlockExpression>.GetHashCode(BlockExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeExpression(
                obj,
                GetHashElementsBlock(obj));
        }
    }
}