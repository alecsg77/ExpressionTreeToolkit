// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Linq.Expressions;

using ExpressionTreeToolkit.UnitTests.Stubs;

using Xunit;

namespace ExpressionTreeToolkit.UnitTests
{
    partial class ExpressionEqualityComparerBehaviour
    {
        [Fact]
        public void DefaultExpressionShouldBeEqual_SameType()
        {
            var x = Expression.Default(typeof(StubObject));
            var y = Expression.Default(typeof(StubObject));

            AssertAreEqual(x, y);
        }

        [Fact]
        public void DefaultExpressionShouldBeNotEqual_DifferentType()
        {
            var x = Expression.Default(typeof(StubObject));
            var y = Expression.Default(typeof(object));

            AssertAreNotEqual(x, y);
        }
    }
}