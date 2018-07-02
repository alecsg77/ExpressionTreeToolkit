// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<NewExpression>
    {
        private bool EqualsNew(NewExpression x, NewExpression y)
        {
            return Equals(x.Constructor, y.Constructor)
                   && EqualsList(x.Members, y.Members)
                   && EqualsExpressionList(x.Arguments, y.Arguments);
        }

        private IEnumerable<int> GetHashElementsNew(NewExpression node)
        {
            return GetHashElements(
                node.Constructor,
                node.Members,
                node.Arguments);
        }

        public bool Equals(NewExpression x, NewExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y)
                   && EqualsNew(x, y);
        }

        public int GetHashCode(NewExpression obj)
        {
            if (obj == null) return 0;

            return GetHashCodeExpression(
                obj,
                GetHashElementsNew(obj));
        }
    }
}