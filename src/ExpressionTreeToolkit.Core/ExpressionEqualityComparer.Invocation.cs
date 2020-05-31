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
    partial class ExpressionEqualityComparer : IEqualityComparer<InvocationExpression>
    {
        /// <summary>Determines whether the children of the two InvocationExpression are equal.</summary>
        /// <param name="x">The first InvocationExpression to compare.</param>
        /// <param name="y">The second InvocationExpression to compare.</param>
        /// <returns>true if the specified InvocationExpression are equal; otherwise, false.</returns>
        protected virtual bool EqualsInvocation([DisallowNull] InvocationExpression x, [DisallowNull] InvocationExpression y)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            return x.Type == y.Type
                   && Equals(x.Expression, y.Expression)
                   && Equals(x.Arguments, y.Arguments);
        }

        /// <summary>Gets the hash code for the specified InvocationExpression.</summary>
        /// <param name="node">The InvocationExpression for which to get a hash code.</param>
        /// <returns>A hash code for the specified InvocationExpression.</returns>
        protected virtual int GetHashCodeInvocation([DisallowNull] InvocationExpression node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));
            return GetHashCode(
                GetDefaultHashCode(node.Type),
                GetHashCode(node.Expression),
                GetHashCode(node.Arguments));
        }

        /// <summary>Determines whether the specified InvocationExpressions are equal.</summary>
        /// <param name="x">The first InvocationExpression to compare.</param>
        /// <param name="y">The second InvocationExpression to compare.</param>
        /// <returns>true if the specified InvocationExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<InvocationExpression>.Equals([AllowNull] InvocationExpression? x, [AllowNull] InvocationExpression? y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsInvocation(x, y);
        }

        /// <summary>Returns a hash code for the specified InvocationExpression.</summary>
        /// <param name="obj">The <see cref="InvocationExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified InvocationExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<InvocationExpression>.GetHashCode([DisallowNull] InvocationExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeInvocation(obj);
        }
    }
}