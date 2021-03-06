﻿// Copyright (c) 2018 Alessio Gogna
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
    partial class ExpressionEqualityComparer : IEqualityComparer<LoopExpression>
    {
        /// <summary>Determines whether the children of the two <see cref="LoopExpression"/> are equal.</summary>
        /// <param name="x">The first <see cref="LoopExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="LoopExpression"/> to compare.</param>
        /// <param name="context"></param>
        /// <returns>true if the specified <see cref="LoopExpression"/> are equal; otherwise, false.</returns>
        protected virtual bool EqualsLoop([DisallowNull] LoopExpression x, [DisallowNull] LoopExpression y, [DisallowNull] ComparisonContext context)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            return x.Type == y.Type
                   && Equals(x.Body, y.Body, context)
                   && EqualsLabelTarget(x.ContinueLabel, y.ContinueLabel, context)
                   && EqualsLabelTarget(x.BreakLabel, y.BreakLabel, context);
        }

        /// <summary>Gets the hash code for the specified <see cref="LoopExpression"/>.</summary>
        /// <param name="node">The <see cref="LoopExpression"/> for which to get a hash code.</param>
        /// <returns>A hash code for the specified <see cref="LoopExpression"/>.</returns>
        protected virtual int GetHashCodeLoop([DisallowNull] LoopExpression node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));
            return GetHashCode(
                GetDefaultHashCode(node.Type),
                GetHashCode(node.Body),
                GetHashCodeLabelTarget(node.ContinueLabel),
                GetHashCodeLabelTarget(node.BreakLabel));
        }

        /// <summary>Determines whether the specified <see cref="LoopExpression"/>s are equal.</summary>
        /// <param name="x">The first <see cref="LoopExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="LoopExpression"/> to compare.</param>
        /// <returns>true if the specified <see cref="LoopExpression"/>s are equal; otherwise, false.</returns>
        bool IEqualityComparer<LoopExpression>.Equals([AllowNull] LoopExpression? x, [AllowNull] LoopExpression? y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsLoop(x, y, BeginScope());
        }

        /// <summary>Returns a hash code for the specified <see cref="LoopExpression"/>.</summary>
        /// <param name="obj">The <see cref="LoopExpression"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified <see cref="LoopExpression"/>.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<LoopExpression>.GetHashCode([DisallowNull] LoopExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeLoop(obj);
        }
    }
}