// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<LoopExpression>
    {
        private bool EqualsLoop(LoopExpression x, LoopExpression y)
        {
            return x.Type == y.Type
                   && EqualsExpression(x.Body, y.Body)
                   && EqualsLabelTarget(x.ContinueLabel, y.ContinueLabel)
                   && EqualsLabelTarget(x.BreakLabel, y.BreakLabel);
        }

        private int GetHashCodeLoop(LoopExpression node)
        {
            return GetHashCode(
                GetHashCodeSafe(node.Type),
                GetHashCodeExpression(node.Body),
                GetHashCodeLabelTarget(node.ContinueLabel),
                GetHashCodeLabelTarget(node.BreakLabel));
        }

        /// <summary>Determines whether the specified LoopExpressions are equal.</summary>
        /// <param name="x">The first LoopExpression to compare.</param>
        /// <param name="y">The second LoopExpression to compare.</param>
        /// <returns>true if the specified LoopExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<LoopExpression>.Equals(LoopExpression x, LoopExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsLoop(x, y);
        }

        /// <summary>Returns a hash code for the specified LoopExpression.</summary>
        /// <param name="obj">The <see cref="LoopExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified LoopExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<LoopExpression>.GetHashCode(LoopExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeLoop(obj);
        }
    }
}