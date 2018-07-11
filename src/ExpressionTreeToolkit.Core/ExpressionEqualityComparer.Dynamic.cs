// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<DynamicExpression>
    {
        private bool EqualsDynamic(DynamicExpression x, DynamicExpression y)
        {
            return x.DelegateType == y.DelegateType
                   && EqualsExpressionList(x.Arguments, y.Arguments)
                   && Equals(x.Binder, y.Binder);
        }

        private IEnumerable<int> GetHashElementsDynamic(DynamicExpression node)
        {
            return GetHashElements(
                node.DelegateType,
                node.Arguments,
                node.Binder);
        }

        /// <summary>Determines whether the specified DynamicExpressions are equal.</summary>
        /// <param name="x">The first DynamicExpression to compare.</param>
        /// <param name="y">The second DynamicExpression to compare.</param>
        /// <returns>true if the specified DynamicExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<DynamicExpression>.Equals(DynamicExpression x, DynamicExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y)
                   && EqualsDynamic(x, y);
        }

        /// <summary>Returns a hash code for the specified DynamicExpression.</summary>
        /// <param name="obj">The <see cref="DynamicExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified DynamicExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<DynamicExpression>.GetHashCode(DynamicExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeExpression(
                obj,
                GetHashElementsDynamic(obj));
        }
    }
}