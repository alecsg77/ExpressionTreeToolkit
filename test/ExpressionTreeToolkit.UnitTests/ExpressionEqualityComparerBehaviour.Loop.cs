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
        public void LoopExpressionShouldBeEqual_SameBody()
        {
            var x = Expression.Loop(
                Expression.Empty()
            );
            var y = Expression.Loop(
                Expression.Empty()
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void LoopExpressionShouldBeNotEqual_DifferentBody()
        {
            var x = Expression.Loop(
                Expression.Empty()
            );
            var y = Expression.Loop(
                StubObject.Expressions.Default
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void LoopExpressionShouldBeEqual_SameBody_SameBreak()
        {
            var x = Expression.Loop(
                Expression.Empty(),
                Expression.Label()
            );
            var y = Expression.Loop(
                Expression.Empty(),
                Expression.Label()
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void LoopExpressionShouldBeNotEqual_SameBody_DifferentBreak()
        {
            var x = Expression.Loop(
                Expression.Empty()
            );
            var y = Expression.Loop(
                Expression.Empty(),
                Expression.Label()
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void LoopExpressionShouldBeEqual_SameBody_SameBreak_SameContinue()
        {
            var x = Expression.Loop(
                Expression.Empty(),
                Expression.Label(),
                Expression.Label()
            );
            var y = Expression.Loop(
                Expression.Empty(),
                Expression.Label(),
                Expression.Label()
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void LoopExpressionShouldBeNotEqual_SameBody_SameBreak_DifferentContinue()
        {
            var x = Expression.Loop(
                Expression.Empty(),
                Expression.Label()
            );
            var y = Expression.Loop(
                Expression.Empty(),
                Expression.Label(),
                Expression.Label()
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void LoopExpressionShouldBeNotEqual_DifferentBody_DifferentBreak_DifferentContinue()
        {
            var x = Expression.Loop(
                Expression.Empty()
            );
            var y = Expression.Loop(
                StubObject.Expressions.Default,
                Expression.Label(),
                Expression.Label()
            );

            AssertAreNotEqual(x, y);
        }
    }
}