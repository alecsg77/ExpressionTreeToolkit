// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Diagnostics.CodeAnalysis;

#if JETBRAINS_ANNOTATIONS
using AllowNullAttribute  = JetBrains.Annotations.CanBeNullAttribute;
using DisallowNullAttribute = JetBrains.Annotations.NotNullAttribute;
using AllowItemNullAttribute = JetBrains.Annotations.ItemCanBeNullAttribute;
#endif

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<TryExpression>
    {
        /// <summary>Determines whether the children of the two TryExpression are equal.</summary>
        /// <param name="x">The first TryExpression to compare.</param>
        /// <param name="y">The second TryExpression to compare.</param>
        /// <param name="context"></param>
        /// <returns>true if the specified TryExpression are equal; otherwise, false.</returns>
        protected virtual bool EqualsTry([DisallowNull] TryExpression x, [DisallowNull] TryExpression y, [DisallowNull] ComparisonContext context)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            return x.Type == y.Type
                   && Equals(x.Body, y.Body, context)
                   && Equals(x.Fault, y.Fault, context)
                   && Equals(x.Finally, y.Finally, context)
                   && Equals(x.Handlers, y.Handlers, EqualsCatchBlock, context);
        }

        /// <summary>Determines whether the children of the two CatchBlock are equal.</summary>
        /// <param name="x">The first CatchBlock to compare.</param>
        /// <param name="y">The second CatchBlock to compare.</param>
        /// <param name="context"></param>
        /// <returns>true if the specified CatchBlock are equal; otherwise, false.</returns>
        protected virtual bool EqualsCatchBlock([DisallowNull] CatchBlock x, [DisallowNull] CatchBlock y, [DisallowNull] ComparisonContext context)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            return x.Test == y.Test
                   && Equals(x.Body, y.Body, context)
                   && Equals(x.Filter, y.Filter, context)
                   && Equals(x.Variable, y.Variable, context);
        }

        /// <summary>Gets the hash code for the specified TryExpression.</summary>
        /// <param name="node">The TryExpression for which to get a hash code.</param>
        /// <returns>A hash code for the specified TryExpression.</returns>
        protected virtual int GetHashCodeTry([DisallowNull] TryExpression node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));
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
        protected virtual int GetHashCodeCatchBlock([DisallowNull] CatchBlock catchBlock)
        {
            if (catchBlock == null) throw new ArgumentNullException(nameof(catchBlock));
            return GetHashCode(
                GetDefaultHashCode(catchBlock.Test),
                GetHashCode(catchBlock.Body),
                GetHashCode(catchBlock.Filter),
                GetHashCode(catchBlock.Variable));
        }

        /// <summary>Determines whether the specified TryExpressions are equal.</summary>
        /// <param name="x">The first TryExpression to compare.</param>
        /// <param name="y">The second TryExpression to compare.</param>
        /// <returns>true if the specified TryExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<TryExpression>.Equals([AllowNull] TryExpression? x, [AllowNull] TryExpression? y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsTry(x, y, BeginScope());
        }

        /// <summary>Returns a hash code for the specified TryExpression.</summary>
        /// <param name="obj">The <see cref="TryExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified TryExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<TryExpression>.GetHashCode([DisallowNull] TryExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeTry(obj);
        }
    }
}