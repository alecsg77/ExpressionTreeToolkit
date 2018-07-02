// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<LabelExpression>
    {
        private bool EqualsLabel(LabelExpression x, LabelExpression y)
        {
            return EqualsLabelTarget(x.Target, y.Target)
                   && Equals(x.DefaultValue, y.DefaultValue);
        }

        private IEnumerable<int> GetHashElementsLabel(LabelExpression node)
        {
            return GetHashElements(
                GetHashElementsLabelTarget(node.Target),
                node.DefaultValue);
        }

        public bool Equals(LabelExpression x, LabelExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y)
                   && EqualsLabel(x, y);
        }

        public int GetHashCode(LabelExpression obj)
        {
            if (obj == null) return 0;

            return GetHashCodeExpression(
                obj,
                GetHashElementsLabel(obj));
        }
    }
}