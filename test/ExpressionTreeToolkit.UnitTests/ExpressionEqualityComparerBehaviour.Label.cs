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
        public void LabelExpressionShouldBeEqual_SameLabelTargetType()
        {
            var x = Expression.Label(
                Expression.Label()
            );
            var y = Expression.Label(
                Expression.Label()
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void LabelExpressionShouldBeNotEqual_DifferentLabelTargetType()
        {
            var x = Expression.Label(
                Expression.Label()
            );
            var y = Expression.Label(
                Expression.Label(typeof(StubObject)),
                StubObject.Expressions.Default
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void LabelExpressionShouldBeEqual_SameLabelTargetType_SameLabelTargetName()
        {
            var x = Expression.Label(
                Expression.Label("name")
            );
            var y = Expression.Label(
                Expression.Label("name")
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void LabelExpressionShouldBeNotEqual_SameLabelTargetType_DifferentLabelTargetName()
        {
            var x = Expression.Label(
                Expression.Label("name")
            );
            var y = Expression.Label(
                Expression.Label("other")
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void LabelExpressionShouldBeEqual_SameLabelTargetType_SameDefaultValue()
        {
            var x = Expression.Label(
                Expression.Label(typeof(StubObject)),
                StubObject.Expressions.Default
            );
            var y = Expression.Label(
                Expression.Label(typeof(StubObject)),
                StubObject.Expressions.Default
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void LabelExpressionShouldBeNotEqual_SameLabelTargetType_DifferentDefaultValue()
        {
            var x = Expression.Label(
                Expression.Label(typeof(StubObject)),
                StubObject.Expressions.Default
            );
            var y = Expression.Label(
                Expression.Label(typeof(StubObject)),
                StubObject.Expressions.Constant
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void LabelExpressionShouldBeNotEqual_DifferentLabelTargetType_DifferentLabelTargetName_DifferentDefaultValue()
        {
            var x = Expression.Label(
                Expression.Label("name"),
                default(Expression)
            );
            var y = Expression.Label(
                Expression.Label(typeof(StubObject), "other"),
                StubObject.Expressions.Constant
            );

            AssertAreNotEqual(x, y);
        }
    }
}