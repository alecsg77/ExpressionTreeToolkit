// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Linq.Expressions;

using ExpressionTreeToolkit.UnitTests.Stubs;

using Xunit;

namespace ExpressionTreeToolkit.UnitTests
{
    partial class ExpressionEqualityComparerBehaviour
    {
        private static readonly NewExpression New = Expression.New(StubObject.Constructors.Default);
        private static readonly NewExpression NewCopy = Expression.New(StubObject.Constructors.Copy, StubObject.Expressions.Default);

        [Fact]
        public void MemberInitExpressionShouldBeEqual_SameNewExpression()
        {
            var x = Expression.MemberInit(
                New
            );
            var y = Expression.MemberInit(
                New
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void MemberInitExpressionShouldBeNotEqual_DifferentNewExpression()
        {
            var x = Expression.MemberInit(
                New
            );
            var y = Expression.MemberInit(
                NewCopy
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void MemberInitExpressionShouldBeEqual_SameNewExpression_SameBindings()
        {
            var x = Expression.MemberInit(
                New,
                Expression.MemberBind(StubObject.Members.Single)
            );
            var y = Expression.MemberInit(
                New,
                Expression.MemberBind(StubObject.Members.Single)
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void MemberInitExpressionShouldBeNotEqual_SameNewExpression_DifferentBindings()
        {
            var x = Expression.MemberInit(
                New,
                Expression.MemberBind(StubObject.Members.Single)
            );
            var y = Expression.MemberInit(
                New,
                Expression.Bind(StubObject.Members.Single, StubObject.Expressions.Default)
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void MemberInitExpressionShouldBeNotEqual_DifferentNewExpression_SameBindings()
        {
            var x = Expression.MemberInit(
                New,
                Expression.MemberBind(StubObject.Members.Single)
            );
            var y = Expression.MemberInit(
                NewCopy,
                Expression.MemberBind(StubObject.Members.Single)
                );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void MemberInitExpressionShouldBeNotEqual_DifferentNewExpression_DifferentBindings()
        {
            var x = Expression.MemberInit(
                New,
                Expression.MemberBind(StubObject.Members.Single)
            );
            var y = Expression.MemberInit(
                NewCopy,
                Expression.Bind(StubObject.Members.Single, StubObject.Expressions.Default)
            );

            AssertAreNotEqual(x, y);
        }
    }
}