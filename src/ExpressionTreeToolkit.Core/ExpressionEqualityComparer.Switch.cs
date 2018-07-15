// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<SwitchExpression>
    {
        private bool EqualsSwitch(SwitchExpression x, SwitchExpression y)
        {
            return x.Type == y.Type
                   && EqualsExpression(x.SwitchValue, y.SwitchValue)
                   && Equals(x.Comparison, y.Comparison)
                   && EqualsList(x.Cases, y.Cases, EqualsSwitchCase)
                   && EqualsExpression(x.DefaultBody, y.DefaultBody);
        }

        private bool EqualsSwitchCase(SwitchCase x, SwitchCase y)
        {
            return EqualsExpression(x.Body, y.Body)
                   && EqualsExpressionList(x.TestValues, y.TestValues);
        }

        private int GetHashCodeSwitch(SwitchExpression node)
        {
            return GetHashCode(
                GetHashCodeSafe(node.Type),
                GetHashCodeExpression(node.SwitchValue),
                GetHashCodeSafe(node.Comparison),
                GetHashCodeList(node.Cases, GetHashCodeSwitchCase));
        }

        private int GetHashCodeSwitchCase(SwitchCase switchCase)
        {
            return GetHashCode(
                GetHashCode(switchCase.Body),
                GetHashCodeExpressionList(switchCase.TestValues));
        }

        /// <summary>Determines whether the specified SwitchExpressions are equal.</summary>
        /// <param name="x">The first SwitchExpression to compare.</param>
        /// <param name="y">The second SwitchExpression to compare.</param>
        /// <returns>true if the specified SwitchExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<SwitchExpression>.Equals(SwitchExpression x, SwitchExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsSwitch(x, y);
        }

        /// <summary>Returns a hash code for the specified SwitchExpression.</summary>
        /// <param name="obj">The <see cref="SwitchExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified SwitchExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<SwitchExpression>.GetHashCode(SwitchExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeSwitch(obj);
        }
    }
}