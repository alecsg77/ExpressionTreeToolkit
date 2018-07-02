// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<MemberExpression>
    {
        private bool EqualsMember(MemberExpression x, MemberExpression y)
        {
            return Equals(x.Member, y.Member)
                   && Equals(x.Expression, y.Expression);
        }

        private IEnumerable<int> GetHashElementsMember(MemberExpression node)
        {
            return GetHashElements(
                node.Member,
                node.Expression);
        }

        public bool Equals(MemberExpression x, MemberExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y)
                   && EqualsMember(x, y);
        }

        public int GetHashCode(MemberExpression obj)
        {
            if (obj == null) return 0;

            return GetHashCodeExpression(
                obj,
                GetHashElementsMember(obj));
        }
    }
}