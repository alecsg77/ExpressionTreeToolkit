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
        public void MemberExpressionShouldBeEqual_SameMember()
        {
            var x = Expression.MakeMemberAccess(
                null,
                Members.Field<StubObject>()
            );
            var y = Expression.MakeMemberAccess(
                null,
                Members.Field<StubObject>()
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void MemberExpressionShouldBeNotEqual_DifferentMember()
        {
            var x = Expression.MakeMemberAccess(
                null,
                Members.Field<StubObject>()
            );
            var y = Expression.MakeMemberAccess(
                null,
                Members.Single<StubObject>()
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void MemberExpressionShouldBeEqual_SameExpression_SameMember()
        {
            var x = Expression.MakeMemberAccess(
                StubObject.Expressions.Default,
                StubObject.Members.Single
            );
            var y = Expression.MakeMemberAccess(
                StubObject.Expressions.Default,
                StubObject.Members.Single
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void MemberExpressionShouldBeNotEqual_DifferentExpression_SameMember()
        {
            var x = Expression.MakeMemberAccess(
                StubObject.Expressions.Default,
                StubObject.Members.Single
            );
            var y = Expression.MakeMemberAccess(
                StubObject.Expressions.Constant,
                StubObject.Members.Single
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void MemberExpressionShouldBeNotEqual_DifferentExpression_DifferentMember()
        {
            var x = Expression.MakeMemberAccess(
                StubObject.Expressions.Default,
                StubObject.Members.Single
            );
            var y = Expression.MakeMemberAccess(
                StubObject.Expressions.Constant,
                StubObject.Members.Field
            );

            AssertAreNotEqual(x, y);
        }
    }
}