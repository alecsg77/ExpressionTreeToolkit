﻿// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JetBrains.Annotations;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<GotoExpression>
    {
        /// <summary>Determines whether the children of the two GotoExpression are equal.</summary>
        /// <param name="x">The first GotoExpression to compare.</param>
        /// <param name="y">The second GotoExpression to compare.</param>
        /// <returns>true if the specified GotoExpression are equal; otherwise, false.</returns>
        protected virtual bool EqualsGoto([NotNull] GotoExpression x, [NotNull] GotoExpression y)
        {
            return x.Type == y.Type
                   && x.Kind == y.Kind
                   && EqualsLabelTarget(x.Target, y.Target)
                   && Equals(x.Value, y.Value);
        }

        /// <summary>Gets the hash code for the specified GotoExpression.</summary>
        /// <param name="node">The GotoExpression for which to get a hash code.</param>
        /// <returns>A hash code for the specified GotoExpression.</returns>
        protected virtual int GetHashCodeGoto([NotNull] GotoExpression node)
        {
            return GetHashCode(
                GetDefaultHashCode(node.Type),
                node.Kind.GetHashCode(),
                GetHashCodeLabelTarget(node.Target),
                GetHashCode(node.Value));
        }

        /// <summary>Determines whether the specified GotoExpressions are equal.</summary>
        /// <param name="x">The first GotoExpression to compare.</param>
        /// <param name="y">The second GotoExpression to compare.</param>
        /// <returns>true if the specified GotoExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<GotoExpression>.Equals(GotoExpression x, GotoExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsGoto(x, y);
        }

        /// <summary>Returns a hash code for the specified GotoExpression.</summary>
        /// <param name="obj">The <see cref="GotoExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified GotoExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<GotoExpression>.GetHashCode(GotoExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeGoto(obj);
        }
    }
}