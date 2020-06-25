// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Linq.Expressions;
using System.Diagnostics.CodeAnalysis;

#if JETBRAINS_ANNOTATIONS
using AllowNullAttribute  = JetBrains.Annotations.CanBeNullAttribute;
using DisallowNullAttribute = JetBrains.Annotations.NotNullAttribute;
using AllowItemNullAttribute = JetBrains.Annotations.ItemCanBeNullAttribute;
#endif

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer
    {
        /// <summary>Determines whether the children of the two extension <see cref="Expression"/> are equal.</summary>
        /// <param name="x">The first extension <see cref="Expression"/> to compare.</param>
        /// <param name="y">The second extension <see cref="Expression"/> to compare.</param>
        /// <param name="context"></param>
        /// <returns>true if the specified extension <see cref="Expression"/> are equal; otherwise, false.</returns>
        protected virtual bool EqualsExtension([DisallowNull] Expression x, [DisallowNull] Expression y, [DisallowNull] ComparisonContext context)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            return Equals(x.ReduceExtensions(), y.ReduceExtensions(), context);
        }

        /// <summary>Gets the hash code for the specified extension <see cref="Expression"/>.</summary>
        /// <param name="node">The extension <see cref="Expression"/> for which to get a hash code.</param>
        /// <returns>A hash code for the specified extension <see cref="Expression"/>.</returns>
        protected virtual int GetHashCodeExtension([DisallowNull] Expression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            return GetHashCode(obj.ReduceExtensions());
        }
    }
}