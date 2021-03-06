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
    partial class ExpressionEqualityComparer : IEqualityComparer<MemberInitExpression>
    {
        /// <summary>Determines whether the children of the two <see cref="MemberInitExpression"/> are equal.</summary>
        /// <param name="x">The first <see cref="MemberInitExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="MemberInitExpression"/> to compare.</param>
        /// <param name="context"></param>
        /// <returns>true if the specified <see cref="MemberInitExpression"/> are equal; otherwise, false.</returns>
        protected virtual bool EqualsMemberInit([DisallowNull] MemberInitExpression x,
            [DisallowNull] MemberInitExpression y, [DisallowNull] ComparisonContext context)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            return x.Type == y.Type
                   && Equals(x.NewExpression, y.NewExpression, context)
                   && Equals(x.Bindings, y.Bindings, EqualsMemberBinding, context);
        }

        /// <summary>Gets the hash code for the specified <see cref="MemberInitExpression"/>.</summary>
        /// <param name="node">The <see cref="MemberInitExpression"/> for which to get a hash code.</param>
        /// <returns>A hash code for the specified <see cref="MemberInitExpression"/>.</returns>
        protected virtual int GetHashCodeMemberInit([DisallowNull] MemberInitExpression node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));
            return GetHashCode(
                GetDefaultHashCode(node.Type),
                GetHashCode(node.NewExpression),
                GetHashCode(node.Bindings, GetHashCodeMemberBinding));
        }

        /// <summary>Determines whether the specified <see cref="MemberInitExpression"/>s are equal.</summary>
        /// <param name="x">The first <see cref="MemberInitExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="MemberInitExpression"/> to compare.</param>
        /// <returns>true if the specified <see cref="MemberInitExpression"/>s are equal; otherwise, false.</returns>
        bool IEqualityComparer<MemberInitExpression>.Equals([AllowNull] MemberInitExpression? x, [AllowNull] MemberInitExpression? y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsMemberInit(x, y, BeginScope());
        }

        /// <summary>Returns a hash code for the specified <see cref="MemberInitExpression"/>.</summary>
        /// <param name="obj">The <see cref="MemberInitExpression"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified <see cref="MemberInitExpression"/>.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<MemberInitExpression>.GetHashCode([DisallowNull] MemberInitExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeMemberInit(obj);
        }
    }
}