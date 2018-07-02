// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<MemberInitExpression>
    {
        private bool EqualsMemberInit(MemberInitExpression x, MemberInitExpression y)
        {
            return Equals(x.NewExpression, y.NewExpression)
                   && EqualsList(x.Bindings, y.Bindings, EqualsBinding);
        }

        private IEnumerable<int> GetHashElementsMemberInit(MemberInitExpression node)
        {
            return GetHashElements(
                node.NewExpression,
                node.Bindings.Select(x => GetHashElements(x.BindingType, x.Member)));
        }

        public bool Equals(MemberInitExpression x, MemberInitExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y)
                   && EqualsMemberInit(x, y);
        }

        public int GetHashCode(MemberInitExpression obj)
        {
            if (obj == null) return 0;

            return GetHashCodeExpression(
                obj,
                GetHashElementsMemberInit(obj));
        }
    }
}