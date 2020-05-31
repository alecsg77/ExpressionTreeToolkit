// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Diagnostics.CodeAnalysis;

#if JETBRAINS_ANNOTATIONS
using AllowNullAttribute  = JetBrains.Annotations.CanBeNullAttribute;
using DisallowNullAttribute = JetBrains.Annotations.NotNullAttribute;
using AllowItemNullAttribute = JetBrains.Annotations.ItemCanBeNullAttribute;
#endif

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<MethodCallExpression>
    {
        /// <summary>Determines whether the children of the two MethodCallExpression are equal.</summary>
        /// <param name="x">The first MethodCallExpression to compare.</param>
        /// <param name="y">The second MethodCallExpression to compare.</param>
        /// <returns>true if the specified MethodCallExpression are equal; otherwise, false.</returns>
        protected virtual bool EqualsMethodCall([DisallowNull] MethodCallExpression x, [DisallowNull] MethodCallExpression y)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            return x.Type == y.Type
                   && Equals(x.Method, y.Method)
                   && Equals(x.Object, y.Object)
                   && Equals(x.Arguments, y.Arguments);
        }

        /// <summary>Gets the hash code for the specified MethodCallExpression.</summary>
        /// <param name="node">The MethodCallExpression for which to get a hash code.</param>
        /// <returns>A hash code for the specified MethodCallExpression.</returns>
        protected virtual int GetHashCodeMethodCall([DisallowNull] MethodCallExpression node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));
            return GetHashCode(
                GetDefaultHashCode(node.Type),
                GetDefaultHashCode(node.Method),
                GetHashCode(node.Object),
                GetHashCode(node.Arguments));
        }

        /// <summary>Determines whether the specified MethodCallExpressions are equal.</summary>
        /// <param name="x">The first MethodCallExpression to compare.</param>
        /// <param name="y">The second MethodCallExpression to compare.</param>
        /// <returns>true if the specified MethodCallExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<MethodCallExpression>.Equals([AllowNull] MethodCallExpression? x, [AllowNull] MethodCallExpression? y)
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
        int IEqualityComparer<MethodCallExpression>.GetHashCode([DisallowNull] MethodCallExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeMethodCall(obj);
        }
    }
}