// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#if JETBRAINS_ANNOTATIONS
using AllowNullAttribute = JetBrains.Annotations.CanBeNullAttribute;
using DisallowNullAttribute = JetBrains.Annotations.NotNullAttribute;
using AllowItemNullAttribute = JetBrains.Annotations.ItemCanBeNullAttribute;
#endif

namespace ExpressionTreeToolkit
{
    partial class ExpressionExtensions
    {
        /// <summary>
        /// Returns an [IEnumerable](xref:System.Collections.Generic.IEnumerable`1)&lt;<see cref="Expression"/>&gt;. This object can be used in a LINQ expression or method query.
        /// </summary>
        /// <param name="source">The source <see cref="Expression"/> to make enumerable.</param>
        /// <returns>An [IEnumerable](xref:System.Collections.Generic.IEnumerable`1)&lt;<see cref="Expression"/>&gt; object.</returns>
        /// <exception cref="ArgumentNullException">The source <see cref="Expression"/> is null.</exception>
        public static IEnumerable<Expression> AsEnumerable([DisallowNull] this Expression source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source is IEnumerable<Expression> enumerable)
            {
                return enumerable;
            }

            return ExpressionIterator.Default.Iterator(source);
        }
    }
}