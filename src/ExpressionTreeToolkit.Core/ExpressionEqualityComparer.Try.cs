// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<TryExpression>
    {
        private bool EqualsTry(TryExpression x, TryExpression y)
        {
            return x.Type == y.Type
                   && EqualsExpression(x.Body, y.Body)
                   && EqualsExpression(x.Fault, y.Fault)
                   && EqualsExpression(x.Finally, y.Finally)
                   && EqualsList(x.Handlers, y.Handlers, EqualsCatchBlock);
        }

        private bool EqualsCatchBlock(CatchBlock x, CatchBlock y)
        {
            return x.Test == y.Test
                   && EqualsExpression(x.Body, y.Body)
                   && EqualsExpression(x.Filter, y.Filter)
                   && EqualsParameter(x.Variable, y.Variable);
        }

        private int GetHashCodeTry(TryExpression node)
        {
            return GetHashCode(
                GetHashCodeSafe(node.Type),
                GetHashCodeExpression(node.Body),
                GetHashCodeExpression(node.Fault),
                GetHashCodeExpression(node.Finally),
                GetHashCodeList(node.Handlers, GetHashCodeCatchBlock));
        }

        private int GetHashCodeCatchBlock(CatchBlock catchBlock)
        {
            return GetHashCode(
                GetHashCodeSafe(catchBlock.Test),
                GetHashCodeExpression(catchBlock.Body),
                GetHashCodeExpression(catchBlock.Filter),
                GetHashCodeParameter(catchBlock.Variable));
        }

        /// <summary>Determines whether the specified TryExpressions are equal.</summary>
        /// <param name="x">The first TryExpression to compare.</param>
        /// <param name="y">The second TryExpression to compare.</param>
        /// <returns>true if the specified TryExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<TryExpression>.Equals(TryExpression x, TryExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsTry(x, y);
        }

        /// <summary>Returns a hash code for the specified TryExpression.</summary>
        /// <param name="obj">The <see cref="TryExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified TryExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<TryExpression>.GetHashCode(TryExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeTry(obj);
        }
    }
}