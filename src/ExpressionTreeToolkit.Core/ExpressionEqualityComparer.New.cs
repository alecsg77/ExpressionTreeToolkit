// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<NewExpression>
    {
        private bool EqualsNew(NewExpression x, NewExpression y)
        {
            return Equals(x.Constructor, y.Constructor)
                   && EqualsList(x.Members, y.Members)
                   && EqualsExpressionList(x.Arguments, y.Arguments);
        }

        private IEnumerable<int> GetHashElementsNew(NewExpression node)
        {
            return GetHashElements(
                node.Constructor,
                node.Members,
                node.Arguments);
        }

        /// <summary>Determines whether the specified NewExpressions are equal.</summary>
        /// <param name="x">The first NewExpression to compare.</param>
        /// <param name="y">The second NewExpression to compare.</param>
        /// <returns>true if the specified NewExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<NewExpression>.Equals(NewExpression x, NewExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y)
                   && EqualsNew(x, y);
        }

        /// <summary>Returns a hash code for the specified NewExpression.</summary>
        /// <param name="obj">The <see cref="NewExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified NewExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<NewExpression>.GetHashCode(NewExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeExpression(
                obj,
                GetHashElementsNew(obj));
        }
    }
}