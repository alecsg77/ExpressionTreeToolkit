﻿// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JetBrains.Annotations;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<LabelExpression>
    {
        /// <summary>Determines whether the children of the two LabelExpression are equal.</summary>
        /// <param name="x">The first LabelExpression to compare.</param>
        /// <param name="y">The second LabelExpression to compare.</param>
        /// <returns>true if the specified LabelExpression are equal; otherwise, false.</returns>
        protected virtual bool EqualsLabel([NotNull] LabelExpression x, [NotNull] LabelExpression y)
        {
            return x.Type == y.Type
                   && EqualsLabelTarget(x.Target, y.Target)
                   && Equals(x.DefaultValue, y.DefaultValue);
        }

        /// <summary>Gets the hash code for the specified LabelExpression.</summary>
        /// <param name="node">The LabelExpression for which to get a hash code.</param>
        /// <returns>A hash code for the specified LabelExpression.</returns>
        protected virtual int GetHashCodeLabel([NotNull] LabelExpression node)
        {
            return GetHashCode(
                GetDefaultHashCode(node.Type),
                GetHashCodeLabelTarget(node.Target),
                GetHashCode(node.DefaultValue));
        }

        /// <summary>Determines whether the specified LabelExpressions are equal.</summary>
        /// <param name="x">The first LabelExpression to compare.</param>
        /// <param name="y">The second LabelExpression to compare.</param>
        /// <returns>true if the specified LabelExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<LabelExpression>.Equals(LabelExpression x, LabelExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsLabel(x, y);
        }

        /// <summary>Returns a hash code for the specified LabelExpression.</summary>
        /// <param name="obj">The <see cref="LabelExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified LabelExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<LabelExpression>.GetHashCode(LabelExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeLabel(obj);
        }
    }
}