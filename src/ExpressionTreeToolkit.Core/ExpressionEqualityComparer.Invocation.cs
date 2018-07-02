// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<InvocationExpression>
    {
        private bool EqualsInvocation(InvocationExpression x, InvocationExpression y)
        {
            return Equals(x.Expression, y.Expression)
                   && EqualsExpressionList(x.Arguments, y.Arguments);
        }

        private IEnumerable<int> GetHashElementsInvocation(InvocationExpression node)
        {
            return GetHashElements(
                node.Expression,
                node.Arguments);
        }

        public bool Equals(InvocationExpression x, InvocationExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y) && EqualsInvocation(x, y);
        }

        public int GetHashCode(InvocationExpression obj)
        {
            if (obj == null) return 0;

            return GetHashCodeExpression(
                obj,
                GetHashElementsInvocation(obj));
        }
    }
}