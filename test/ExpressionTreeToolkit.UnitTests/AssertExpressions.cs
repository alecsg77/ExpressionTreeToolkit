// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

using Xunit;

namespace ExpressionTreeToolkit.UnitTests
{
    internal static class AssertExpressions
    {
        [ExcludeFromCodeCoverage]
        public static void Equal<T>(T x, T y) where T : Expression
        {
            Equal<T>(x, y, ExpressionEqualityComparer.Default);
        }

        [ExcludeFromCodeCoverage]
        public static void Equal(Expression x, Expression y)
        {
            Equal(x, y, ExpressionEqualityComparer.Default);
        }

        [ExcludeFromCodeCoverage]
        public static void NotEqual<T>(T x, T y) where T : Expression
        {
            NotEqual<T>(x, y, ExpressionEqualityComparer.Default);
        }

        [ExcludeFromCodeCoverage]
        public static void NotEqual(Expression x, Expression y)
        {
            NotEqual(x, y, ExpressionEqualityComparer.Default);
        }

        [ExcludeFromCodeCoverage]
        public static void Equal<T>(T x, T y, IEqualityComparer<T> equalityComparer) where T : Expression
        {
            Assert.Equal(x, y, equalityComparer);
        }

        [ExcludeFromCodeCoverage]
        public static void NotEqual<T>(T x, T y, IEqualityComparer<T> equalityComparer) where T : Expression
        {
            Assert.NotEqual(x, y, equalityComparer);
        }
    }
}