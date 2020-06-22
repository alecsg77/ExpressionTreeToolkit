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
        public void GotoExpressionShouldBeEqual_SameKind_SameLabelTargetType()
        {
            var x = Expression.Goto(
                Expression.Label()
            );
            var y = Expression.Goto(
                Expression.Label()
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void GotoExpressionShouldBeNotEqual_DifferentKind_SameLabelTargetType()
        {
            var x = Expression.Goto(
                Expression.Label()
            );
            var y = Expression.Continue(
                Expression.Label()
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void GotoExpressionShouldBeNotEqual_SameKind_DifferentLabelTargetType()
        {
            var x = Expression.Goto(
                Expression.Label()
            );
            var y = Expression.Goto(
                Expression.Label(typeof(StubObject)),
                StubObject.Expressions.Default
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void GotoExpressionShouldBeEqual_SameKind_SameLabelTargetType_SameLabelTargetName()
        {
            var x = Expression.Goto(
                Expression.Label("name")
            );
            var y = Expression.Goto(
                Expression.Label("name")
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void GotoExpressionShouldBeNotEqual_SameKind_SameLabelTargetType_DifferentLabelTargetName()
        {
            var x = Expression.Goto(
                Expression.Label("name")
            );
            var y = Expression.Goto(
                Expression.Label("other")
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void GotoExpressionShouldBeEqual_SameKind_SameLabelTargetType_SameValue()
        {
            var x = Expression.Goto(
                Expression.Label(typeof(StubObject)),
                StubObject.Expressions.Default
            );
            var y = Expression.Goto(
                Expression.Label(typeof(StubObject)),
                StubObject.Expressions.Default
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void GotoExpressionShouldBeNotEqual_SameKind_SameLabelTargetType_DifferentValue()
        {
            var x = Expression.Goto(
                Expression.Label(typeof(StubObject)),
                StubObject.Expressions.Default
            );
            var y = Expression.Goto(
                Expression.Label(typeof(StubObject)),
                StubObject.Expressions.Constant
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void GotoExpressionShouldBeEqual_SameKind_SameLabelTargetType_SameLabelTargetName_SameValue()
        {
            var x = Expression.Goto(
                Expression.Label(typeof(StubObject), "name"),
                StubObject.Expressions.Default
            );
            var y = Expression.Goto(
                Expression.Label(typeof(StubObject), "name"),
                StubObject.Expressions.Default
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void GotoExpressionShouldBeNotEqual_DifferentKind_DifferentLabelTargetType_DifferentLabelTargetName_DifferentValue()
        {
            var x = Expression.Goto(
                Expression.Label(typeof(void), "name"),
                StubObject.Expressions.Default
            );

            var y = Expression.Return(
                Expression.Label(typeof(StubObject), "other"),
                StubObject.Expressions.Constant
            );

            AssertAreNotEqual(x, y);
        }

    }
}