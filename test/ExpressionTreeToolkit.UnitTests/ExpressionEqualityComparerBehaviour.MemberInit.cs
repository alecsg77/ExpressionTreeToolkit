// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Linq.Expressions;

using ExpressionTreeToolkit.UnitTests.Stubs;

using Xunit;

namespace ExpressionTreeToolkit.UnitTests
{
    partial class ExpressionEqualityComparerBehaviour
    {
        private static NewExpression New => Expression.New(StubObject.Constructors.Default);
        private static NewExpression NewCopy => Expression.New(StubObject.Constructors.Copy, StubObject.Expressions.Default);

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
        public void MemberInitExpressionShouldBeEqual_SameNewExpression_SameMemberBindBindings()
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
        public void MemberInitExpressionShouldBeNotEqual_SameNewExpression_DifferentMemberBindBindings()
        {
            var x = Expression.MemberInit(
                New,
                Expression.MemberBind(StubObject.Members.Single)
            );
            var y = Expression.MemberInit(
                New,
                Expression.MemberBind(StubObject.Members.Field)
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void MemberInitExpressionShouldBeEqual_SameNewExpression_SameBindBindings()
        {
            var x = Expression.MemberInit(
                New,
                Expression.Bind(
                    StubObject.Members.Single,
                    StubObject.Expressions.Default
                )
            );
            var y = Expression.MemberInit(
                New,
                Expression.Bind(
                    StubObject.Members.Single,
                    StubObject.Expressions.Default
                )
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void MemberInitExpressionShouldBeNotEqual_SameNewExpression_DifferentBindBindings()
        {
            var x = Expression.MemberInit(
                New,
                Expression.Bind(
                    StubObject.Members.Single,
                    StubObject.Expressions.Default
                )
            );
            var y = Expression.MemberInit(
                New,
                Expression.Bind(
                    StubObject.Members.Single,
                    StubObject.Expressions.Constant
                )
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void MemberInitExpressionShouldBeEqual_SameNewExpression_SameListBindBindings()
        {
            var x = Expression.MemberInit(
                New,
                Expression.ListBind(
                    StubObject.Members.Collection,
                    Expression.ElementInit(
                        Methods.CollectionAdd<StubObject>(),
                        StubObject.Expressions.Default
                    )
                )
            );
            var y = Expression.MemberInit(
                New,
                Expression.ListBind(
                    StubObject.Members.Collection,
                    Expression.ElementInit(
                        Methods.CollectionAdd<StubObject>(),
                        StubObject.Expressions.Default
                    )
                )
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void MemberInitExpressionShouldBeNotEqual_SameNewExpression_DifferentListBindBindings()
        {
            var x = Expression.MemberInit(
                New,
                Expression.ListBind(
                    StubObject.Members.Collection,
                    Expression.ElementInit(
                        Methods.CollectionAdd<StubObject>(),
                        StubObject.Expressions.Default
                    )
                )
            );
            var y = Expression.MemberInit(
                New,
                Expression.ListBind(
                    StubObject.Members.Collection,
                    Expression.ElementInit(
                        Methods.CollectionAdd<StubObject>(),
                        StubObject.Expressions.Constant
                    )
                )
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void MemberInitExpressionShouldBeNotEqual_DifferentNewExpression_DifferentBindings()
        {
            var x = Expression.MemberInit(
                New,
                Expression.MemberBind(StubObject.Members.Single),
                Expression.Bind(
                    StubObject.Members.Single,
                    StubObject.Expressions.Default
                ),
                Expression.ListBind(
                    StubObject.Members.Collection,
                    Expression.ElementInit(
                        Methods.CollectionAdd<StubObject>(),
                        StubObject.Expressions.Default
                    )
                )
            );
            var y = Expression.MemberInit(
                NewCopy,
                Expression.MemberBind(StubObject.Members.Field),
                Expression.Bind(
                    StubObject.Members.Single,
                    StubObject.Expressions.Constant
                ),
                Expression.ListBind(
                    StubObject.Members.Collection,
                    Expression.ElementInit(
                        Methods.CollectionAdd<StubObject>(),
                        StubObject.Expressions.Constant
                    )
                )
            );

            AssertAreNotEqual(x, y);
        }
    }
}