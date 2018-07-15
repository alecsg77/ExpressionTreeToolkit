// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<MethodCallExpression>
    {
        private bool EqualsMethodCall(MethodCallExpression x, MethodCallExpression y)
        {
            return x.Type == y.Type
                   && Equals(x.Method, y.Method)
                   && EqualsExpression(x.Object, y.Object)
                   && EqualsExpressionList(x.Arguments, y.Arguments);
        }

        private int GetHashCodeMethodCall(MethodCallExpression node)
        {
            return GetHashCode(
                GetHashCodeSafe(node.Type),
                GetHashCodeSafe(node.Method),
                GetHashCodeExpression(node.Object),
                GetHashCodeExpressionList(node.Arguments));
        }

        /// <summary>Determines whether the specified MethodCallExpressions are equal.</summary>
        /// <param name="x">The first MethodCallExpression to compare.</param>
        /// <param name="y">The second MethodCallExpression to compare.</param>
        /// <returns>true if the specified MethodCallExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<MethodCallExpression>.Equals(MethodCallExpression x, MethodCallExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsMethodCall(x, y);
        }

        /// <summary>Returns a hash code for the specified MethodCallExpression.</summary>
        /// <param name="obj">The <see cref="MethodCallExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified MethodCallExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<MethodCallExpression>.GetHashCode(MethodCallExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeMethodCall(obj);
        }
    }
}