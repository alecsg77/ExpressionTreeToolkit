// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using ExpressionTreeToolkit.UnitTests.Stubs;

using System.Linq.Expressions;

using Xunit;

namespace ExpressionTreeToolkit.UnitTests
{
    partial class ExpressionEqualityComparerBehaviour
    {
        [Fact]
        public void BlockExpressionShouldBeEqual_SameExpressions()
        {
            var x = Expression.Block(
                Expression.Empty()
            );
            var y = Expression.Block(
                Expression.Empty()
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void BlockExpressionShouldBeNotEqual_DifferentExpressions()
        {
            var x = Expression.Block(
                Expression.Empty()
            );
            var y = Expression.Block(
                StubObject.Expressions.Default
            );

            AssertAreNotEqual(x, y);
        }
    }
}