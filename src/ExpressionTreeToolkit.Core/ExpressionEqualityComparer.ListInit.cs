// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

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

        public bool Equals(ListInitExpression x, ListInitExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y) && EqualsListInit(x, y);
        }

        public int GetHashCode(ListInitExpression obj)
        {
            if (obj == null) return 0;
            return GetHashCodeExpression(obj, GetHashElementsListInit(obj));
        }
    }
}