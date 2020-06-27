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
        public void ConditionalExpressionShouldBeEqual_SameTest_SameIfTrue()
        {
            var x = Expression.IfThen(
                Expression.Default(typeof(bool)),
                Expression.Default(typeof(StubObject))
            );
            var y = Expression.IfThen(
                Expression.Default(typeof(bool)),
                Expression.Default(typeof(StubObject))
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void ConditionalExpressionShouldBeNotEqual_SameTest_DifferentIfTrue()
        {
            var x = Expression.IfThen(
                Expression.Default(typeof(bool)),
                Expression.Default(typeof(StubObject))
            );
            var y = Expression.IfThen(
                Expression.Default(typeof(bool)),
                Expression.Parameter(typeof(StubObject))
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void ConditionalExpressionShouldBeNotEqual_DifferentTest_SameIfTrue()
        {
            var x = Expression.IfThen(
                Expression.Default(typeof(bool)),
                Expression.Default(typeof(StubObject))
            );
            var y = Expression.IfThen(
                Expression.Parameter(typeof(bool)),
                Expression.Default(typeof(StubObject))
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void ConditionalExpressionShouldBeNotEqual_DifferentTest_DifferentIfTrue()
        {
            var x = Expression.IfThen(
                Expression.Default(typeof(bool)),
                Expression.Default(typeof(StubObject))
            );
            var y = Expression.IfThen(
                Expression.Parameter(typeof(bool)),
                Expression.Parameter(typeof(StubObject))
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void ConditionalExpressionShouldBeEqual_SameTest_SameIfTrue_SameIfElse()
        {
            var x = Expression.IfThenElse(
                Expression.Default(typeof(bool)),
                Expression.Default(typeof(StubObject)),
                Expression.Default(typeof(StubObject))
            );
            var y = Expression.IfThenElse(
                Expression.Default(typeof(bool)),
                Expression.Default(typeof(StubObject)),
                Expression.Default(typeof(StubObject))
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void ConditionalExpressionShouldBeNotEqual_SameTest_SameIfTrue_DifferentIfElse()
        {
            var x = Expression.IfThenElse(
                Expression.Default(typeof(bool)),
                Expression.Default(typeof(StubObject)),
                Expression.Default(typeof(StubObject))
            );
            var y = Expression.IfThenElse(
                Expression.Default(typeof(bool)),
                Expression.Default(typeof(StubObject)),
                Expression.Parameter(typeof(StubObject))
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void ConditionalExpressionShouldBeEqual_SameTest_SameIfTrue_SameIfElse_SameType()
        {
            var x = Expression.Condition(
                Expression.Default(typeof(bool)),
                Expression.Default(typeof(StubObject)),
                Expression.Default(typeof(StubObject)),
                typeof(object)
            );
            var y = Expression.Condition(
                Expression.Default(typeof(bool)),
                Expression.Default(typeof(StubObject)),
                Expression.Default(typeof(StubObject)),
                typeof(object)
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void ConditionalExpressionShouldBeNotEqual_SameTest_SameIfTrue_SameIfElse_DifferentType()
        {
            var x = Expression.Condition(
                Expression.Default(typeof(bool)),
                Expression.Default(typeof(StubObject)),
                Expression.Default(typeof(StubObject)),
                typeof(object)
            );
            var y = Expression.Condition(
                Expression.Default(typeof(bool)),
                Expression.Default(typeof(StubObject)),
                Expression.Default(typeof(StubObject)),
                typeof(StubObject)
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void ConditionalExpressionShouldBeEqual_SameTest_SameIfTrue_EmptyIfElse_VoidType()
        {
            var x = Expression.IfThen(
                Expression.Default(typeof(bool)),
                Expression.Default(typeof(StubObject))
            );
            var y = Expression.Condition(
                Expression.Default(typeof(bool)),
                Expression.Default(typeof(StubObject)),
                Expression.Empty(),
                typeof(void)
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void ConditionalExpressionShouldBeEqual_SameTest_SameIfTrue_SameIfElse_VoidType()
        {
            var x = Expression.IfThenElse(
                Expression.Default(typeof(bool)),
                Expression.Default(typeof(StubObject)),
                Expression.Default(typeof(StubObject))
            );
            var y = Expression.Condition(
                Expression.Default(typeof(bool)),
                Expression.Default(typeof(StubObject)),
                Expression.Default(typeof(StubObject)),
                typeof(void)
            );

            AssertAreEqual(x, y);
        }
    }
}