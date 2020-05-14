﻿// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JetBrains.Annotations;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<NewArrayExpression>
    {
        /// <summary>Determines whether the children of the two NewArrayExpression are equal.</summary>
        /// <param name="x">The first NewArrayExpression to compare.</param>
        /// <param name="y">The second NewArrayExpression to compare.</param>
        /// <returns>true if the specified NewArrayExpression are equal; otherwise, false.</returns>
        protected virtual bool EqualsNewArray([NotNull] NewArrayExpression x, [NotNull] NewArrayExpression y)
        {
            return x.Type == y.Type
                   && Equals(x.Expressions, y.Expressions);
        }

        /// <summary>Gets the hash code for the specified NewArrayExpression.</summary>
        /// <param name="node">The NewArrayExpression for which to get a hash code.</param>
        /// <returns>A hash code for the specified NewArrayExpression.</returns>
        protected virtual int GetHashCodeNewArray([NotNull] NewArrayExpression node)
        {
            return GetHashCode(
                GetDefaultHashCode(node.Type),
                GetHashCode(node.Expressions));
        }

        /// <summary>Determines whether the specified NewArrayExpressions are equal.</summary>
        /// <param name="x">The first NewArrayExpression to compare.</param>
        /// <param name="y">The second NewArrayExpression to compare.</param>
        /// <returns>true if the specified NewArrayExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<NewArrayExpression>.Equals(NewArrayExpression x, NewArrayExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsNewArray(x, y);
        }

        /// <summary>Returns a hash code for the specified NewArrayExpression.</summary>
        /// <param name="obj">The <see cref="NewArrayExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified NewArrayExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<NewArrayExpression>.GetHashCode(NewArrayExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeNewArray(obj);
        }
    }
}