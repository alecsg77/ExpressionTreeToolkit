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
    public partial class ExpressionEqualityComparer
    {
        /// <summary>Determines whether the children of the two extension Expression are equal.</summary>
        /// <param name="x">The first extension Expression to compare.</param>
        /// <param name="y">The second extension Expression to compare.</param>
        /// <param name="context"></param>
        /// <returns>true if the specified extension Expression are equal; otherwise, false.</returns>
        protected virtual bool EqualsExtension([DisallowNull] Expression x, [DisallowNull] Expression y, [DisallowNull] ComparisonContext context)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            return Equals(x.ReduceExtensions(), y.ReduceExtensions(), context);
        }

        /// <summary>Gets the hash code for the specified extension Expression.</summary>
        /// <param name="node">The extension Expression for which to get a hash code.</param>
        /// <returns>A hash code for the specified extension Expression.</returns>
        protected virtual int GetHashCodeExtension([DisallowNull] Expression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            return GetHashCode(obj.ReduceExtensions());
        }
    }
}