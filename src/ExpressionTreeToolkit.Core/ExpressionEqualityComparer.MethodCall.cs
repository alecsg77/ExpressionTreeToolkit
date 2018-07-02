// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<MethodCallExpression>
    {
        private bool EqualsMethodCall(MethodCallExpression x, MethodCallExpression y)
        {
            return Equals(x.Method, y.Method)
                   && Equals(x.Object, y.Object)
                   && EqualsExpressionList(x.Arguments, y.Arguments);
        }

        private IEnumerable<int> GetHashElementsMethodCall(MethodCallExpression node)
        {
            return GetHashElements(
                node.Method,
                node.Object,
                node.Arguments);
        }

        public bool Equals(MethodCallExpression x, MethodCallExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y)
                   && EqualsMethodCall(x, y);
        }

        public int GetHashCode(MethodCallExpression obj)
        {
            if (obj == null) return 0;

            return GetHashCodeExpression(
                obj,
                GetHashElementsMethodCall(obj));
        }
    }
}