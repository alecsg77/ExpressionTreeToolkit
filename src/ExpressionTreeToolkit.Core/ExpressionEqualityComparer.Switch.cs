// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<SwitchExpression>
    {
        private bool EqualsSwitch(SwitchExpression x, SwitchExpression y)
        {
            return Equals(x.SwitchValue, y.SwitchValue)
                   && x.Comparison == y.Comparison
                   && EqualsList(x.Cases, y.Cases, EqualsSwitchCase)
                   && Equals(x.DefaultBody, y.DefaultBody);
        }

        private bool EqualsSwitchCase(SwitchCase x, SwitchCase y)
        {
            return Equals(x.Body, y.Body)
                   && EqualsExpressionList(x.TestValues, y.TestValues);
        }

        private IEnumerable<int> GetHashElementsSwitch(SwitchExpression node)
        {
            return GetHashElements(
                node.SwitchValue,
                node.Comparison,
                node.Cases.SelectMany(GetHashElementsSwitchCase));
        }

        private IEnumerable<int> GetHashElementsSwitchCase(SwitchCase switchCase)
        {
            return GetHashElements(
                switchCase.Body,
                switchCase.TestValues);
        }

        public bool Equals(SwitchExpression x, SwitchExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y)
                   && EqualsSwitch(x, y);
        }

        public int GetHashCode(SwitchExpression obj)
        {
            if (obj == null) return 0;

            return GetHashCodeExpression(
                obj,
                GetHashElementsSwitch(obj));
        }
    }
}