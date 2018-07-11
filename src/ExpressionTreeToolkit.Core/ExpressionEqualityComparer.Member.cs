// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<MemberExpression>
    {
        private bool EqualsMember(MemberExpression x, MemberExpression y)
        {
            return Equals(x.Member, y.Member)
                   && Equals(x.Expression, y.Expression);
        }

        private IEnumerable<int> GetHashElementsMember(MemberExpression node)
        {
            return GetHashElements(
                node.Member,
                node.Expression);
        }

        /// <summary>Determines whether the specified MemberExpressions are equal.</summary>
        /// <param name="x">The first MemberExpression to compare.</param>
        /// <param name="y">The second MemberExpression to compare.</param>
        /// <returns>true if the specified MemberExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<MemberExpression>.Equals(MemberExpression x, MemberExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y)
                   && EqualsMember(x, y);
        }

        /// <summary>Returns a hash code for the specified MemberExpression.</summary>
        /// <param name="obj">The <see cref="MemberExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified MemberExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<MemberExpression>.GetHashCode(MemberExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeExpression(
                obj,
                GetHashElementsMember(obj));
        }
    }
}