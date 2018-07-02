// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<LoopExpression>
    {
        private bool EqualsLoop(LoopExpression x, LoopExpression y)
        {
            return Equals(x.Body, y.Body)
                   && EqualsLabelTarget(x.ContinueLabel, y.ContinueLabel)
                   && EqualsLabelTarget(x.BreakLabel, y.BreakLabel);
        }

        private IEnumerable<int> GetHashElementsLoop(LoopExpression node)
        {
            return GetHashElements(
                node.Body,
                GetHashElementsLabelTarget(node.ContinueLabel),
                GetHashElementsLabelTarget(node.BreakLabel));
        }

        public bool Equals(LoopExpression x, LoopExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y)
                   && EqualsLoop(x, y);
        }

        public int GetHashCode(LoopExpression obj)
        {
            if (obj == null) return 0;

            return GetHashCodeExpression(
                obj,
                GetHashElementsLoop(obj));
        }
    }
}