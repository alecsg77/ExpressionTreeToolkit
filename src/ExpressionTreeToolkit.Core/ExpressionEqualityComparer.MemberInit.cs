// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JetBrains.Annotations;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<MemberInitExpression>
    {
        /// <summary>Determines whether the children of the two MemberInitExpression are equal.</summary>
        /// <param name="x">The first MemberInitExpression to compare.</param>
        /// <param name="y">The second MemberInitExpression to compare.</param>
        /// <returns>true if the specified MemberInitExpression are equal; otherwise, false.</returns>
        protected virtual bool EqualsMemberInit([NotNull] MemberInitExpression x, [NotNull] MemberInitExpression y)
        {
            return x.Type == y.Type
                   && Equals(x.NewExpression, y.NewExpression)
                   && Equals(x.Bindings, y.Bindings, EqualsMemberBinding);
        }

        /// <summary>Gets the hash code for the specified MemberInitExpression.</summary>
        /// <param name="node">The MemberInitExpression for which to get a hash code.</param>
        /// <returns>A hash code for the specified MemberInitExpression.</returns>
        protected virtual int GetHashCodeMemberInit([NotNull] MemberInitExpression node)
        {
            return GetHashCode(
                GetDefaultHashCode(node.Type),
                GetHashCode(node.NewExpression),
                GetHashCode(node.Bindings, GetHashCodeMemberBinding));
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