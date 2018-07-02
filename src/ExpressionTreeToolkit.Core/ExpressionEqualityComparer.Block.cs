// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<BlockExpression>
    {
        private bool EqualsBlock(BlockExpression x, BlockExpression y)
        {
            return EqualsExpressionList(x.Expressions, y.Expressions)
                   && EqualsExpressionList(x.Variables, y.Variables)
                   && Equals(x.Result, y.Result);
        }

        private IEnumerable<int> GetHashElementsBlock(BlockExpression node)
        {
            return GetHashElements(
                node.Expressions,
                node.Variables,
                node.Result);
        }

        public bool Equals(BlockExpression x, BlockExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y)
                   && EqualsBlock(x, y);
        }

        public int GetHashCode(BlockExpression obj)
        {
            if (obj == null) return 0;

            return GetHashCodeExpression(
                obj,
                GetHashElementsBlock(obj));
        }
    }
}