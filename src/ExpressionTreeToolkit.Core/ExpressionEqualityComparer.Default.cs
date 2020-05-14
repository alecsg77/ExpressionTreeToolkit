﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JetBrains.Annotations;

namespace ExpressionTreeToolkit
{
    public partial class ExpressionEqualityComparer : IEqualityComparer<DefaultExpression>
    {
        /// <summary>Determines whether the children of the two DefaultExpression are equal.</summary>
        /// <param name="x">The first DefaultExpression to compare.</param>
        /// <param name="y">The second DefaultExpression to compare.</param>
        /// <returns>true if the specified DefaultExpression are equal; otherwise, false.</returns>
        protected virtual bool EqualsDefault([NotNull] DefaultExpression x, [NotNull] DefaultExpression y)
        {
            return x.Type == y.Type;
        }

        /// <summary>Gets the hash code for the specified DefaultExpression.</summary>
        /// <param name="node">The DefaultExpression for which to get a hash code.</param>
        /// <returns>A hash code for the specified DefaultExpression.</returns>
        protected virtual int GetHashCodeDefault([NotNull] DefaultExpression node)
        {
            return GetDefaultHashCode(node.Type);
        }

        /// <summary>Determines whether the specified DefaultExpressions are equal.</summary>
        /// <param name="x">The first DefaultExpression to compare.</param>
        /// <param name="y">The second DefaultExpression to compare.</param>
        /// <returns>true if the specified DefaultExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<DefaultExpression>.Equals(DefaultExpression x, DefaultExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsDefault(x, y);
        }

        /// <summary>Returns a hash code for the specified DefaultExpression.</summary>
        /// <param name="obj">The <see cref="DefaultExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified DefaultExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<DefaultExpression>.GetHashCode(DefaultExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeDefault(obj);
        }
    }
}