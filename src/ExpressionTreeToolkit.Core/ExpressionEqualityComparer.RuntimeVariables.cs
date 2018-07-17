// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JetBrains.Annotations;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<RuntimeVariablesExpression>
    {
        /// <summary>Determines whether the children of the two RuntimeVariablesExpression are equal.</summary>
        /// <param name="x">The first RuntimeVariablesExpression to compare.</param>
        /// <param name="y">The second RuntimeVariablesExpression to compare.</param>
        /// <returns>true if the specified RuntimeVariablesExpression are equal; otherwise, false.</returns>
        protected virtual bool EqualsRuntimeVariables([NotNull] RuntimeVariablesExpression x, [NotNull] RuntimeVariablesExpression y)
        {
            return x.Type == y.Type
                   && Equals(x.Variables, y.Variables, EqualsParameter);
        }

        /// <summary>Gets the hash code for the specified RuntimeVariablesExpression.</summary>
        /// <param name="node">The RuntimeVariablesExpression for which to get a hash code.</param>
        /// <returns>A hash code for the specified RuntimeVariablesExpression.</returns>
        protected virtual int GetHashCodeRuntimeVariables([NotNull] RuntimeVariablesExpression node)
        {
            return GetHashCode(
                GetDefaultHashCode(node.Type),
                GetHashCode(node.Variables, GetHashCodeParameter));
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