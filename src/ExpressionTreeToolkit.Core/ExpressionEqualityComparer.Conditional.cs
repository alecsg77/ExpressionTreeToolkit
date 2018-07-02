// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<ConditionalExpression>
    {
        private bool EqualsConditional(ConditionalExpression x, ConditionalExpression y)
        {
            return Equals(x.Test, y.Test)
                   && Equals(x.IfTrue, y.IfTrue)
                   && Equals(x.IfFalse, y.IfFalse);
        }

        private IEnumerable<int> GetHashElementsConditional(ConditionalExpression node)
        {
            return GetHashElements(
                node.Test,
                node.IfTrue,
                node.IfFalse);
        }

        public bool Equals(ConditionalExpression x, ConditionalExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y)
                   && EqualsConditional(x, y);
        }

        public int GetHashCode(ConditionalExpression obj)
        {
            if (obj == null) return 0;

            return GetHashCodeExpression(
                obj,
                GetHashElementsConditional(obj));
        }
    }
}