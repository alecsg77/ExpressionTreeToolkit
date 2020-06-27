// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Diagnostics.CodeAnalysis;

#if JETBRAINS_ANNOTATIONS
using AllowNullAttribute  = JetBrains.Annotations.CanBeNullAttribute;
using DisallowNullAttribute = JetBrains.Annotations.NotNullAttribute;
using AllowItemNullAttribute = JetBrains.Annotations.ItemCanBeNullAttribute;
#endif

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<RuntimeVariablesExpression>
    {
        /// <summary>Determines whether the children of the two <see cref="RuntimeVariablesExpression"/> are equal.</summary>
        /// <param name="x">The first <see cref="RuntimeVariablesExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="RuntimeVariablesExpression"/> to compare.</param>
        /// <param name="context"></param>
        /// <returns>true if the specified <see cref="RuntimeVariablesExpression"/> are equal; otherwise, false.</returns>
        protected virtual bool EqualsRuntimeVariables([DisallowNull] RuntimeVariablesExpression x,
            [DisallowNull] RuntimeVariablesExpression y, [DisallowNull] ComparisonContext context)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            return x.Type == y.Type
                   && Equals(x.Variables, y.Variables, EqualsParameter, context);
        }

        /// <summary>Gets the hash code for the specified <see cref="RuntimeVariablesExpression"/>.</summary>
        /// <param name="node">The <see cref="RuntimeVariablesExpression"/> for which to get a hash code.</param>
        /// <returns>A hash code for the specified <see cref="RuntimeVariablesExpression"/>.</returns>
        protected virtual int GetHashCodeRuntimeVariables([DisallowNull] RuntimeVariablesExpression node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));
            return GetHashCode(
                GetDefaultHashCode(node.Type),
                GetHashCode(node.Variables, GetHashCodeParameter));
        }

        /// <summary>Determines whether the specified <see cref="RuntimeVariablesExpression"/>s are equal.</summary>
        /// <param name="x">The first <see cref="RuntimeVariablesExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="RuntimeVariablesExpression"/> to compare.</param>
        /// <returns>true if the specified <see cref="RuntimeVariablesExpression"/>s are equal; otherwise, false.</returns>
        bool IEqualityComparer<RuntimeVariablesExpression>.Equals([AllowNull] RuntimeVariablesExpression? x, [AllowNull] RuntimeVariablesExpression? y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsRuntimeVariables(x, y, BeginScope());
        }

        /// <summary>Returns a hash code for the specified <see cref="RuntimeVariablesExpression"/>.</summary>
        /// <param name="obj">The <see cref="RuntimeVariablesExpression"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified <see cref="RuntimeVariablesExpression"/>.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<RuntimeVariablesExpression>.GetHashCode([DisallowNull] RuntimeVariablesExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeRuntimeVariables(obj);
        }
    }
}