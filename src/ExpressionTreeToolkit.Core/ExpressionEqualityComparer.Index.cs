// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<IndexExpression>
    {
        private bool EqualsIndex(IndexExpression x, IndexExpression y)
        {
            return Equals(x.Object, y.Object)
                   && Equals(x.Indexer, y.Indexer)
                   && EqualsExpressionList(x.Arguments, y.Arguments);
        }

        private IEnumerable<int> GetHashElementsIndex(IndexExpression node)
        {
            return GetHashElements(
                node.Object,
                node.Indexer,
                node.Arguments);
        }

        public bool Equals(IndexExpression x, IndexExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y) && EqualsIndex(x, y);
        }

        public int GetHashCode(IndexExpression obj)
        {
            if (obj == null) return 0;

            return GetHashCodeExpression(
                obj,
                GetHashElementsIndex(obj));
        }
    }
}