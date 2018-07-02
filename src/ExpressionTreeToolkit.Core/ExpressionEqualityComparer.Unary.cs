// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<UnaryExpression>
    {
        private bool EqualsUnary(UnaryExpression x, UnaryExpression y)
        {
            return Equals(x.Method, y.Method)
                   && Equals(x.Operand, y.Operand);
        }

        private IEnumerable<int> GetHashElementsUnary(UnaryExpression unary)
        {
            return GetHashElements(
                unary.Method,
                unary.Operand);
        }

        public bool Equals(UnaryExpression x, UnaryExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y)
                   && EqualsUnary(x, y);
        }

        public int GetHashCode(UnaryExpression obj)
        {
            if (obj == null) return 0;

            return GetHashCodeExpression(
                obj,
                GetHashElementsUnary(obj));
        }
    }
}