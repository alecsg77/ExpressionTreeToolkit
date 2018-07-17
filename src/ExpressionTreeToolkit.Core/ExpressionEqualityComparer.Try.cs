// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JetBrains.Annotations;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<TryExpression>
    {
        /// <summary>Determines whether the children of the two TryExpression are equal.</summary>
        /// <param name="x">The first TryExpression to compare.</param>
        /// <param name="y">The second TryExpression to compare.</param>
        /// <returns>true if the specified TryExpression are equal; otherwise, false.</returns>
        protected virtual bool EqualsTry([NotNull] TryExpression x, [NotNull] TryExpression y)
        {
            return x.Type == y.Type
                   && Equals(x.Body, y.Body)
                   && Equals(x.Fault, y.Fault)
                   && Equals(x.Finally, y.Finally)
                   && Equals(x.Handlers, y.Handlers, EqualsCatchBlock);
        }

        /// <summary>Determines whether the children of the two CatchBlock are equal.</summary>
        /// <param name="x">The first CatchBlock to compare.</param>
        /// <param name="y">The second CatchBlock to compare.</param>
        /// <returns>true if the specified CatchBlock are equal; otherwise, false.</returns>
        protected virtual bool EqualsCatchBlock([NotNull] CatchBlock x, [NotNull] CatchBlock y)
        {
            return x.Test == y.Test
                   && Equals(x.Body, y.Body)
                   && Equals(x.Filter, y.Filter)
                   && EqualsParameter(x.Variable, y.Variable);
        }

        /// <summary>Gets the hash code for the specified TryExpression.</summary>
        /// <param name="node">The TryExpression for which to get a hash code.</param>
        /// <returns>A hash code for the specified TryExpression.</returns>
        protected virtual int GetHashCodeTry([NotNull] TryExpression node)
        {
            return GetHashCode(
                GetDefaultHashCode(node.Type),
                GetHashCode(node.Body),
                GetHashCode(node.Fault),
                GetHashCode(node.Finally),
                GetHashCode(node.Handlers, GetHashCodeCatchBlock));
        }

        /// <summary>Gets the hash code for the specified CatchBlock.</summary>
        /// <param name="catchBlock">The CatchBlock for which to get a hash code.</param>
        /// <returns>A hash code for the specified CatchBlock.</returns>
        protected virtual int GetHashCodeCatchBlock([NotNull] CatchBlock catchBlock)
        {
            return GetHashCode(
                GetDefaultHashCode(catchBlock.Test),
                GetHashCode(catchBlock.Body),
                GetHashCode(catchBlock.Filter),
                GetHashCodeParameter(catchBlock.Variable));
        }

        /// <summary>Determines whether the specified TryExpressions are equal.</summary>
        /// <param name="x">The first TryExpression to compare.</param>
        /// <param name="y">The second TryExpression to compare.</param>
        /// <returns>true if the specified TryExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<TryExpression>.Equals(TryExpression x, TryExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsTry(x, y);
        }

        /// <summary>Returns a hash code for the specified TryExpression.</summary>
        /// <param name="obj">The <see cref="TryExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified TryExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<TryExpression>.GetHashCode(TryExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeTry(obj);
        }
    }
}