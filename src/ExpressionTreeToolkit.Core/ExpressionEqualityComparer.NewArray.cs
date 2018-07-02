// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<NewArrayExpression>
    {
        private bool EqualsNewArray(NewArrayExpression x, NewArrayExpression y)
        {
            return EqualsExpressionList(x.Expressions, y.Expressions);
        }

        private IEnumerable<int> GetHashElementsNewArray(NewArrayExpression node)
        {
            return GetHashElements(node.Expressions);
        }

        public bool Equals(NewArrayExpression x, NewArrayExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y)
                   && EqualsNewArray(x, y);
        }

        public int GetHashCode(NewArrayExpression obj)
        {
            if (obj == null) return 0;

            return GetHashCodeExpression(
                obj,
                GetHashElementsNewArray(obj));
        }
    }
}