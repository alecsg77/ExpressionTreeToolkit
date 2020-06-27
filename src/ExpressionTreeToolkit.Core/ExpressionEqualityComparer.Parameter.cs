// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
#if JETBRAINS_ANNOTATIONS
using AllowNullAttribute  = JetBrains.Annotations.CanBeNullAttribute;
using DisallowNullAttribute = JetBrains.Annotations.NotNullAttribute;
using AllowItemNullAttribute = JetBrains.Annotations.ItemCanBeNullAttribute;
#endif

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<ParameterExpression>
    {
        /// <summary>Determines whether the children of the two <see cref="ParameterExpression"/> are equal.</summary>
        /// <param name="x">The first <see cref="ParameterExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="ParameterExpression"/> to compare.</param>
        /// <param name="context"></param>
        /// <returns>true if the specified <see cref="ParameterExpression"/> are equal; otherwise, false.</returns>
        protected virtual bool EqualsParameter([DisallowNull] ParameterExpression x, [DisallowNull] ParameterExpression y, [DisallowNull] ComparisonContext context)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            return x.Type == y.Type
                   && x.IsByRef == y.IsByRef
                   && context.VerifyParameter(x,y);
        }

        /// <summary>Gets the hash code for the specified <see cref="ParameterExpression"/>.</summary>
        /// <param name="node">The <see cref="ParameterExpression"/> for which to get a hash code.</param>
        /// <returns>A hash code for the specified <see cref="ParameterExpression"/>.</returns>
        protected virtual int GetHashCodeParameter([DisallowNull] ParameterExpression node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));
            return GetHashCode(
                GetDefaultHashCode(node.Type),
                node.IsByRef.GetHashCode());
        }

        /// <summary>Determines whether the specified <see cref="ParameterExpression"/>s are equal.</summary>
        /// <param name="x">The first <see cref="ParameterExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="ParameterExpression"/> to compare.</param>
        /// <returns>true if the specified <see cref="ParameterExpression"/>s are equal; otherwise, false.</returns>
        bool IEqualityComparer<ParameterExpression>.Equals([AllowNull] ParameterExpression? x, [AllowNull] ParameterExpression? y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsParameter(x, y, BeginScope());
        }

        /// <summary>Returns a hash code for the specified <see cref="ParameterExpression"/>.</summary>
        /// <param name="obj">The <see cref="ParameterExpression"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified <see cref="ParameterExpression"/>.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<ParameterExpression>.GetHashCode([DisallowNull] ParameterExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeParameter(obj);
        }
    }
}