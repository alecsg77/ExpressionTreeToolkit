// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<ConstantExpression>
    {
        private bool EqualsConstant(ConstantExpression x, ConstantExpression y)
        {
            return Equals(x.Value, y.Value);
        }

        private IEnumerable<int> GetHashElementsConstant(ConstantExpression node)
        {
            return GetHashElements(node.Value);
        }


        public bool Equals(ConstantExpression x, ConstantExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y)
                   && EqualsConstant(x, y);
        }

        public int GetHashCode(ConstantExpression obj)
        {
            if (obj == null) return 0;

            return GetHashCodeExpression(
                obj,
                GetHashElementsConstant(obj));
        }
    }
}