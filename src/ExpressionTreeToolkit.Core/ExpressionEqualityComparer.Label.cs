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
    partial class ExpressionEqualityComparer : IEqualityComparer<LabelExpression>
    {
        /// <summary>Determines whether the children of the two <see cref="LabelExpression"/> are equal.</summary>
        /// <param name="x">The first <see cref="LabelExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="LabelExpression"/> to compare.</param>
        /// <param name="context"></param>
        /// <returns>true if the specified <see cref="LabelExpression"/> are equal; otherwise, false.</returns>
        protected virtual bool EqualsLabel([DisallowNull] LabelExpression x, [DisallowNull] LabelExpression y, [DisallowNull] ComparisonContext context)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            return x.Type == y.Type
                   && EqualsLabelTarget(x.Target, y.Target, context)
                   && Equals(x.DefaultValue, y.DefaultValue, context);
        }

        /// <summary>Gets the hash code for the specified <see cref="LabelExpression"/>.</summary>
        /// <param name="node">The <see cref="LabelExpression"/> for which to get a hash code.</param>
        /// <returns>A hash code for the specified <see cref="LabelExpression"/>.</returns>
        protected virtual int GetHashCodeLabel([DisallowNull] LabelExpression node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));
            return GetHashCode(
                GetDefaultHashCode(node.Type),
                GetHashCodeLabelTarget(node.Target),
                GetHashCode(node.DefaultValue));
        }

        /// <summary>Determines whether the specified <see cref="LabelExpression"/>s are equal.</summary>
        /// <param name="x">The first <see cref="LabelExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="LabelExpression"/> to compare.</param>
        /// <returns>true if the specified <see cref="LabelExpression"/>s are equal; otherwise, false.</returns>
        bool IEqualityComparer<LabelExpression>.Equals([AllowNull] LabelExpression? x, [AllowNull] LabelExpression? y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsLabel(x, y, BeginScope());
        }

        /// <summary>Returns a hash code for the specified <see cref="LabelExpression"/>.</summary>
        /// <param name="obj">The <see cref="LabelExpression"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified <see cref="LabelExpression"/>.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<LabelExpression>.GetHashCode([DisallowNull] LabelExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeLabel(obj);
        }
    }
}