// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JetBrains.Annotations;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<DynamicExpression>
    {
        /// <summary>Determines whether the children of the two DynamicExpression are equal.</summary>
        /// <param name="x">The first DynamicExpression to compare.</param>
        /// <param name="y">The second DynamicExpression to compare.</param>
        /// <returns>true if the specified DynamicExpression are equal; otherwise, false.</returns>
        protected virtual bool EqualsDynamic([NotNull] DynamicExpression x, [NotNull] DynamicExpression y)
        {
            return x.Type == y.Type
                   && x.DelegateType == y.DelegateType
                   && Equals(x.Arguments, y.Arguments)
                   && Equals(x.Binder, y.Binder);
        }

        /// <summary>Gets the hash code for the specified DynamicExpression.</summary>
        /// <param name="node">The DynamicExpression for which to get a hash code.</param>
        /// <returns>A hash code for the specified DynamicExpression.</returns>
        protected virtual int GetHashCodeDynamic([NotNull] DynamicExpression node)
        {
            return GetHashCode(
                GetDefaultHashCode(node.Type),
                GetDefaultHashCode(node.DelegateType),
                GetHashCode(node.Arguments),
                GetDefaultHashCode(node.Binder));
        }

        /// <summary>Determines whether the specified DynamicExpressions are equal.</summary>
        /// <param name="x">The first DynamicExpression to compare.</param>
        /// <param name="y">The second DynamicExpression to compare.</param>
        /// <returns>true if the specified DynamicExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<DynamicExpression>.Equals(DynamicExpression x, DynamicExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsDynamic(x, y);
        }

        /// <summary>Returns a hash code for the specified DynamicExpression.</summary>
        /// <param name="obj">The <see cref="DynamicExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified DynamicExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<DynamicExpression>.GetHashCode(DynamicExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeDynamic(obj);
        }
    }
}