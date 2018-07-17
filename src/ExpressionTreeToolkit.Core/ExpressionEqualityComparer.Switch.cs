// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JetBrains.Annotations;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<SwitchExpression>
    {
        /// <summary>Determines whether the children of the two SwitchExpression are equal.</summary>
        /// <param name="x">The first SwitchExpression to compare.</param>
        /// <param name="y">The second SwitchExpression to compare.</param>
        /// <returns>true if the specified SwitchExpression are equal; otherwise, false.</returns>
        protected virtual bool EqualsSwitch([NotNull] SwitchExpression x, [NotNull] SwitchExpression y)
        {
            return x.Type == y.Type
                   && Equals(x.SwitchValue, y.SwitchValue)
                   && Equals(x.Comparison, y.Comparison)
                   && Equals(x.Cases, y.Cases, EqualsSwitchCase)
                   && Equals(x.DefaultBody, y.DefaultBody);
        }

        /// <summary>Determines whether the children of the two SwitchCase are equal.</summary>
        /// <param name="x">The first SwitchCase to compare.</param>
        /// <param name="y">The second SwitchCase to compare.</param>
        /// <returns>true if the specified SwitchCase are equal; otherwise, false.</returns>
        protected virtual bool EqualsSwitchCase([NotNull] SwitchCase x, [NotNull] SwitchCase y)
        {
            return Equals(x.Body, y.Body)
                   && Equals(x.TestValues, y.TestValues);
        }

        /// <summary>Gets the hash code for the specified SwitchExpression.</summary>
        /// <param name="node">The SwitchExpression for which to get a hash code.</param>
        /// <returns>A hash code for the specified SwitchExpression.</returns>
        protected virtual int GetHashCodeSwitch([NotNull] SwitchExpression node)
        {
            return GetHashCode(
                GetDefaultHashCode(node.Type),
                GetHashCode(node.SwitchValue),
                GetDefaultHashCode(node.Comparison),
                GetHashCode(node.Cases, GetHashCodeSwitchCase));
        }

        /// <summary>Gets the hash code for the specified SwitchCase.</summary>
        /// <param name="switchCase">The SwitchCase for which to get a hash code.</param>
        /// <returns>A hash code for the specified SwitchCase.</returns>
        protected virtual int GetHashCodeSwitchCase([NotNull] SwitchCase switchCase)
        {
            return GetHashCode(
                GetHashCode(switchCase.Body),
                GetHashCode(switchCase.TestValues));
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