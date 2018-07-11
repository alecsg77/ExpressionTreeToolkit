// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<LabelExpression>
    {
        private bool EqualsLabel(LabelExpression x, LabelExpression y)
        {
            return EqualsLabelTarget(x.Target, y.Target)
                   && Equals(x.DefaultValue, y.DefaultValue);
        }

        private IEnumerable<int> GetHashElementsLabel(LabelExpression node)
        {
            return GetHashElements(
                GetHashElementsLabelTarget(node.Target),
                node.DefaultValue);
        }

        /// <summary>Determines whether the specified LabelExpressions are equal.</summary>
        /// <param name="x">The first LabelExpression to compare.</param>
        /// <param name="y">The second LabelExpression to compare.</param>
        /// <returns>true if the specified LabelExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<LabelExpression>.Equals(LabelExpression x, LabelExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y)
                   && EqualsLabel(x, y);
        }

        /// <summary>Returns a hash code for the specified LabelExpression.</summary>
        /// <param name="obj">The <see cref="LabelExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified LabelExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<LabelExpression>.GetHashCode(LabelExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeExpression(
                obj,
                GetHashElementsLabel(obj));
        }
    }
}