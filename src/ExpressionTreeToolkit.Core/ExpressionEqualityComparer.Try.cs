// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<TryExpression>
    {
        private bool EqualsTry(TryExpression x, TryExpression y)
        {
            return Equals(x.Body, y.Body)
                   && Equals(x.Fault, y.Fault)
                   && Equals(x.Finally, y.Finally)
                   && EqualsList(x.Handlers, y.Handlers, EqualsCatchBlock);
        }

        private bool EqualsCatchBlock(CatchBlock x, CatchBlock y)
        {
            return x.Test == y.Test
                   && Equals(x.Body, y.Body)
                   && Equals(x.Filter, y.Filter)
                   && Equals(x.Variable, y.Variable);
        }

        private IEnumerable<int> GetHashElementsTry(TryExpression node)
        {
            return GetHashElements(
                node.Body,
                node.Fault,
                node.Finally,
                node.Handlers.SelectMany(GetHashElementsCatchBlock));
        }

        private IEnumerable<int> GetHashElementsCatchBlock(CatchBlock catchBlock)
        {
            return GetHashElements(
                catchBlock.Test,
                catchBlock.Body,
                catchBlock.Filter,
                catchBlock.Variable);
        }

        public bool Equals(TryExpression x, TryExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y)
                   && EqualsTry(x, y);
        }

        public int GetHashCode(TryExpression obj)
        {
            if (obj == null) return 0;

            return GetHashCodeExpression(
                obj,
                GetHashElementsTry(obj));
        }
    }
}