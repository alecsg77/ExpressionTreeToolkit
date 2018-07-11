// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<ListInitExpression>
    {
        private bool EqualsListInit(ListInitExpression x, ListInitExpression y)
        {
            return Equals(x.NewExpression, y.NewExpression)
                   && EqualsList(x.Initializers, x.Initializers, EqualsElementInit);
        }

        private IEnumerable<int> GetHashElementsListInit(ListInitExpression node)
        {
            return GetHashElements(node.NewExpression,
                node.Initializers.Select(x => GetHashElements(x.AddMethod, x.Arguments)));
        }

        /// <summary>Determines whether the specified ListInitExpressions are equal.</summary>
        /// <param name="x">The first ListInitExpression to compare.</param>
        /// <param name="y">The second ListInitExpression to compare.</param>
        /// <returns>true if the specified ListInitExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<ListInitExpression>.Equals(ListInitExpression x, ListInitExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y) && EqualsListInit(x, y);
        }

        /// <summary>Returns a hash code for the specified ListInitExpression.</summary>
        /// <param name="obj">The <see cref="ListInitExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified ListInitExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<ListInitExpression>.GetHashCode(ListInitExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            return GetHashCodeExpression(obj, GetHashElementsListInit(obj));
        }
    }
}