// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JetBrains.Annotations;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<NewExpression>
    {
        /// <summary>Determines whether the children of the two NewExpression are equal.</summary>
        /// <param name="x">The first NewExpression to compare.</param>
        /// <param name="y">The second NewExpression to compare.</param>
        /// <returns>true if the specified NewExpression are equal; otherwise, false.</returns>
        protected virtual bool EqualsNew([NotNull] NewExpression x, [NotNull] NewExpression y)
        {
            return x.Type == y.Type
                   && Equals(x.Constructor, y.Constructor)
                   && Equals(x.Members, y.Members)
                   && Equals(x.Arguments, y.Arguments);
        }

        /// <summary>Gets the hash code for the specified NewExpression.</summary>
        /// <param name="node">The NewExpression for which to get a hash code.</param>
        /// <returns>A hash code for the specified NewExpression.</returns>
        protected virtual int GetHashCodeNew([NotNull] NewExpression node)
        {
            return GetHashCode(
                GetDefaultHashCode(node.Type),
                GetDefaultHashCode(node.Constructor),
                GetHashCode(node.Members),
                GetHashCode(node.Arguments));
        }

        /// <summary>Determines whether the specified NewExpressions are equal.</summary>
        /// <param name="x">The first NewExpression to compare.</param>
        /// <param name="y">The second NewExpression to compare.</param>
        /// <returns>true if the specified NewExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<NewExpression>.Equals(NewExpression x, NewExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsNew(x, y);
        }

        /// <summary>Returns a hash code for the specified NewExpression.</summary>
        /// <param name="obj">The <see cref="NewExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified NewExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<NewExpression>.GetHashCode(NewExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeNew(obj);
        }
    }
}