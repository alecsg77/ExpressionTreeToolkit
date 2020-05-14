﻿// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JetBrains.Annotations;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<ConditionalExpression>
    {
        /// <summary>Determines whether the children of the two ConditionalExpression are equal.</summary>
        /// <param name="x">The first ConditionalExpression to compare.</param>
        /// <param name="y">The second ConditionalExpression to compare.</param>
        /// <returns>true if the specified ConditionalExpression are equal; otherwise, false.</returns>
        protected virtual bool EqualsConditional([NotNull] ConditionalExpression x, [NotNull] ConditionalExpression y)
        {
            return x.Type == y.Type
                   && Equals(x.Test, y.Test)
                   && Equals(x.IfTrue, y.IfTrue)
                   && Equals(x.IfFalse, y.IfFalse);
        }

        /// <summary>Gets the hash code for the specified ConditionalExpression.</summary>
        /// <param name="node">The ConditionalExpression for which to get a hash code.</param>
        /// <returns>A hash code for the specified ConditionalExpression.</returns>
        protected virtual int GetHashCodeConditional([NotNull] ConditionalExpression node)
        {
            return GetHashCode(
                GetDefaultHashCode(node.Type),
                GetHashCode(node.Test),
                GetHashCode(node.IfTrue),
                GetHashCode(node.IfFalse));
        }

        /// <summary>Determines whether the specified ConditionalExpressions are equal.</summary>
        /// <param name="x">The first ConditionalExpression to compare.</param>
        /// <param name="y">The second ConditionalExpression to compare.</param>
        /// <returns>true if the specified ConditionalExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<ConditionalExpression>.Equals(ConditionalExpression x, ConditionalExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsConditional(x, y);
        }

        /// <summary>Returns a hash code for the specified ConditionalExpression.</summary>
        /// <param name="obj">The <see cref="ConditionalExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified ConditionalExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<ConditionalExpression>.GetHashCode(ConditionalExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeConditional(obj);
        }
    }
}