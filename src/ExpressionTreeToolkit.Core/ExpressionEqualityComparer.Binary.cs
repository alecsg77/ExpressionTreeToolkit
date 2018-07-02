// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<BinaryExpression>
    {
        private bool EqualsBinary(BinaryExpression x, BinaryExpression y)
        {
            return Equals(x.Method, y.Method)
                   && Equals(x.Left, y.Left)
                   && Equals(x.Right, y.Right)
                   && Equals(x.Conversion, y.Conversion);
        }

        private IEnumerable<int> GetHashElementsBinary(BinaryExpression node)
        {
            return GetHashElements(
                node.Method,
                node.Left,
                node.Right,
                node.Conversion);
        }

        public bool Equals(BinaryExpression x, BinaryExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y)
                   && EqualsBinary(x, y);
        }

        public int GetHashCode(BinaryExpression obj)
        {
            if (obj == null) return 0;

            return GetHashCodeExpression(
                obj,
                GetHashElementsBinary(obj));
        }
    }
}