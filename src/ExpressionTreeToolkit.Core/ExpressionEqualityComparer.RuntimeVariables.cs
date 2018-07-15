// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<RuntimeVariablesExpression>
    {
        private bool EqualsRuntimeVariables(RuntimeVariablesExpression x, RuntimeVariablesExpression y)
        {
            return x.Type == y.Type
                   && EqualsExpressionList(x.Variables, y.Variables);
        }

        private int GetHashCodeRuntimeVariables(RuntimeVariablesExpression node)
        {
            return GetHashCode(
                GetHashCodeSafe(node.Type),
                GetHashCodeList(node.Variables));
        }

        /// <summary>Determines whether the specified RuntimeVariablesExpressions are equal.</summary>
        /// <param name="x">The first RuntimeVariablesExpression to compare.</param>
        /// <param name="y">The second RuntimeVariablesExpression to compare.</param>
        /// <returns>true if the specified RuntimeVariablesExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<RuntimeVariablesExpression>.Equals(RuntimeVariablesExpression x, RuntimeVariablesExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsRuntimeVariables(x, y);
        }

        /// <summary>Returns a hash code for the specified RuntimeVariablesExpression.</summary>
        /// <param name="obj">The <see cref="RuntimeVariablesExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified RuntimeVariablesExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<RuntimeVariablesExpression>.GetHashCode(RuntimeVariablesExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeRuntimeVariables(obj);
        }
    }
}