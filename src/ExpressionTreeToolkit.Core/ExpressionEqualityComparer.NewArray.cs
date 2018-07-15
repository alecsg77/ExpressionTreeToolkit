// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<NewArrayExpression>
    {
        private bool EqualsNewArray(NewArrayExpression x, NewArrayExpression y)
        {
            return x.Type == y.Type
                   && EqualsExpressionList(x.Expressions, y.Expressions);
        }

        private int GetHashCodeNewArray(NewArrayExpression node)
        {
            return GetHashCode(
                GetHashCodeSafe(node.Type),
                GetHashCodeList(node.Expressions));
        }

        /// <summary>Determines whether the specified NewArrayExpressions are equal.</summary>
        /// <param name="x">The first NewArrayExpression to compare.</param>
        /// <param name="y">The second NewArrayExpression to compare.</param>
        /// <returns>true if the specified NewArrayExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<NewArrayExpression>.Equals(NewArrayExpression x, NewArrayExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsNewArray(x, y);
        }

        /// <summary>Returns a hash code for the specified NewArrayExpression.</summary>
        /// <param name="obj">The <see cref="NewArrayExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified NewArrayExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<NewArrayExpression>.GetHashCode(NewArrayExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeNewArray(obj);
        }
    }
}