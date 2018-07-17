// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Linq.Expressions;
using JetBrains.Annotations;

namespace ExpressionTreeToolkit
{
    public partial class ExpressionEqualityComparer
    {
        /// <summary>Determines whether the children of the two extension Expression are equal.</summary>
        /// <param name="x">The first extension Expression to compare.</param>
        /// <param name="y">The second extension Expression to compare.</param>
        /// <returns>true if the specified extension Expression are equal; otherwise, false.</returns>
        protected virtual bool EqualsExtension([NotNull] Expression x, [NotNull] Expression y)
        {
            return Equals(x.ReduceExtensions(), y.ReduceExtensions());
        }

        /// <summary>Gets the hash code for the specified extension Expression.</summary>
        /// <param name="node">The extension Expression for which to get a hash code.</param>
        /// <returns>A hash code for the specified extension Expression.</returns>
        protected virtual int GetHashCodeExtension([NotNull] Expression obj)
        {
            return GetHashCode(obj.ReduceExtensions());
        }
    }
}