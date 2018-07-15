// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<MemberInitExpression>
    {
        private bool EqualsMemberInit(MemberInitExpression x, MemberInitExpression y)
        {
            return x.Type == y.Type
                   && EqualsExpression(x.NewExpression, y.NewExpression)
                   && EqualsList(x.Bindings, y.Bindings, EqualsBinding);
        }

        private int GetHashCodeMemberInit(MemberInitExpression node)
        {
            return GetHashCode(
                GetHashCodeSafe(node.Type),
                GetHashCodeExpression(node.NewExpression),
                GetHashCodeList(node.Bindings, GetHashCodeBinding));
        }

        /// <summary>Determines whether the specified MemberInitExpressions are equal.</summary>
        /// <param name="x">The first MemberInitExpression to compare.</param>
        /// <param name="y">The second MemberInitExpression to compare.</param>
        /// <returns>true if the specified MemberInitExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<MemberInitExpression>.Equals(MemberInitExpression x, MemberInitExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsMemberInit(x, y);
        }

        /// <summary>Returns a hash code for the specified MemberInitExpression.</summary>
        /// <param name="obj">The <see cref="MemberInitExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified MemberInitExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<MemberInitExpression>.GetHashCode(MemberInitExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeMemberInit(obj);
        }
    }
}