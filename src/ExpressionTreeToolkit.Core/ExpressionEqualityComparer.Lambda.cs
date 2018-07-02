// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<LambdaExpression>
    {
        private bool EqualsLambda(LambdaExpression x, LambdaExpression y)
        {
            if (!EqualsList(x.Parameters, y.Parameters, EqualsParameter))
            {
                return false;
            }

            var comparer = new ExpressionEqualityComparer(x.Parameters, y.Parameters);
            return comparer.Equals(x.Body, y.Body);
        }

        private IEnumerable<int> GetHashElementsLambda(LambdaExpression node)
        {
            return GetHashElements(node.Parameters, node.Body);
        }

        public bool Equals(LambdaExpression x, LambdaExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y) && EqualsLambda(x, y);
        }

        public int GetHashCode(LambdaExpression obj)
        {
            if (obj == null) return 0;
            return GetHashCodeExpression(obj, GetHashElementsLambda(obj));
        }
    }
}