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
        public void TypeBinaryExpressionShouldBeEqual_SameExpression_SameTypeOperand()
        {
            var x = Expression.TypeEqual(
                Expression.Default(typeof(StubObject)),
                typeof(StubObject)
            );
            var y = Expression.TypeEqual(
                Expression.Default(typeof(StubObject)),
                typeof(StubObject)
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void TypeBinaryExpressionShouldBeNotEqual_SameExpression_DifferentTypeOperand()
        {
            var x = Expression.TypeEqual(
                Expression.Default(typeof(StubObject)),
                typeof(StubObject)
            );
            var y = Expression.TypeEqual(
                Expression.Default(typeof(StubObject)),
                typeof(object)
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void TypeBinaryExpressionShouldBeNotEqual_DifferentExpression_SameTypeOperand()
        {
            var x = Expression.TypeEqual(
                Expression.Default(typeof(StubObject)),
                typeof(StubObject)
            );
            var y = Expression.TypeEqual(
                Expression.Parameter(typeof(StubObject)),
                typeof(StubObject)
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void TypeBinaryExpressionShouldBeNotEqual_DifferentExpression_DifferentTypeOperand()
        {
            var x = Expression.TypeEqual(
                Expression.Default(typeof(StubObject)),
                typeof(StubObject)
            );
            var y = Expression.TypeEqual(
                Expression.Parameter(typeof(StubObject)),
                typeof(object)
            );

            AssertAreNotEqual(x, y);
        }
    }
}