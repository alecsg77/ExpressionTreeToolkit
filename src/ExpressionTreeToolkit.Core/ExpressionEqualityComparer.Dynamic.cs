// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

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

        public bool Equals(DynamicExpression x, DynamicExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y)
                   && EqualsDynamic(x, y);
        }

        public int GetHashCode(DynamicExpression obj)
        {
            if (obj == null) return 0;

            return GetHashCodeExpression(
                obj,
                GetHashElementsDynamic(obj));
        }
    }
}