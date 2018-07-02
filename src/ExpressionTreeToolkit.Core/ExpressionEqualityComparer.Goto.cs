// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<GotoExpression>
    {
        private bool EqualsGoto(GotoExpression x, GotoExpression y)
        {
            return x.Kind == y.Kind
                   && EqualsLabelTarget(x.Target, y.Target)
                   && Equals(x.Value, y.Value);
        }

        private IEnumerable<int> GetHashElementsGoto(GotoExpression node)
        {
            return GetHashElements(
                node.Kind,
                GetHashElementsLabelTarget(node.Target),
                node.Value);
        }


        public bool Equals(GotoExpression x, GotoExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y)
                   && EqualsGoto(x, y);
        }

        public int GetHashCode(GotoExpression obj)
        {
            if (obj == null) return 0;

            return GetHashCodeExpression(obj, GetHashElementsGoto(obj));
        }
    }
}