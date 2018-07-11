// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<InvocationExpression>
    {
        private bool EqualsInvocation(InvocationExpression x, InvocationExpression y)
        {
            return Equals(x.Expression, y.Expression)
                   && EqualsExpressionList(x.Arguments, y.Arguments);
        }

        private IEnumerable<int> GetHashElementsInvocation(InvocationExpression node)
        {
            return GetHashElements(
                node.Expression,
                node.Arguments);
        }

        /// <summary>Determines whether the specified InvocationExpressions are equal.</summary>
        /// <param name="x">The first InvocationExpression to compare.</param>
        /// <param name="y">The second InvocationExpression to compare.</param>
        /// <returns>true if the specified InvocationExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<InvocationExpression>.Equals(InvocationExpression x, InvocationExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y) && EqualsInvocation(x, y);
        }

        /// <summary>Returns a hash code for the specified InvocationExpression.</summary>
        /// <param name="obj">The <see cref="InvocationExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified InvocationExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<InvocationExpression>.GetHashCode(InvocationExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeExpression(
                obj,
                GetHashElementsInvocation(obj));
        }
    }
}