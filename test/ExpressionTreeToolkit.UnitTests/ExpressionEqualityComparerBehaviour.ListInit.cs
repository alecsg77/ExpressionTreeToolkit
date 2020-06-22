// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using ExpressionTreeToolkit.UnitTests.Stubs;

using Xunit;

namespace ExpressionTreeToolkit.UnitTests
{
    partial class ExpressionEqualityComparerBehaviour
    {
#if NETFRAMEWORK != true
        [Fact]
        public void ListInitExpressionShouldBeEqual_SameNewExpression()
        {
            var x = Expression.ListInit(
                Expression.New(typeof(StubCollection)),
                Enumerable.Empty<ElementInit>()
            );
            var y = Expression.ListInit(
                Expression.New(typeof(StubCollection)),
                Enumerable.Empty<ElementInit>()
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void ListInitExpressionShouldBeNotEqual_DifferentNewExpression()
        {
            var x = Expression.ListInit(
                Expression.New(typeof(StubCollection)),
                Enumerable.Empty<ElementInit>()
            );
            var y = Expression.ListInit(
                Expression.New(typeof(List<StubObject>)),
                Enumerable.Empty<ElementInit>()
            );

            AssertAreNotEqual(x, y);
        }
#endif

        [Fact]
        public void ListInitExpressionShouldBeEqual_SameNewExpression_SameInitializers()
        {
            var x = Expression.ListInit(
                Expression.New(typeof(StubCollection)),
                StubObject.Expressions.Default,
                StubObject.Expressions.Constant
            );
            var y = Expression.ListInit(
                Expression.New(typeof(StubCollection)),
                StubObject.Expressions.Default,
                StubObject.Expressions.Constant
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void ListInitExpressionShouldBeNotEqual_SameNewExpression_DifferentInitializers()
        {
            var x = Expression.ListInit(
                Expression.New(typeof(StubCollection)),
                StubObject.Expressions.Default,
                StubObject.Expressions.Constant
            );
            var y = Expression.ListInit(
                Expression.New(typeof(StubCollection)),
                StubObject.Expressions.Constant,
                StubObject.Expressions.Default
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void ListInitExpressionShouldBeEqual_SameNewExpression_SameMethod_SameInitializers()
        {
            var x = Expression.ListInit(
                Expression.New(typeof(StubCollection)),
                StubCollection.Methods.Add,
                StubObject.Expressions.Default,
                StubObject.Expressions.Constant
            );
            var y = Expression.ListInit(
                Expression.New(typeof(StubCollection)),
                StubCollection.Methods.Add,
                StubObject.Expressions.Default,
                StubObject.Expressions.Constant
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void ListInitExpressionShouldBeNotEqual_SameNewExpression_DifferentMethod_SameInitializers()
        {
            var x = Expression.ListInit(
                Expression.New(typeof(StubCollection)),
                StubCollection.Methods.Add,
                StubObject.Expressions.Default,
                StubObject.Expressions.Constant
            );
            var y = Expression.ListInit(
                Expression.New(typeof(StubCollection)),
                Methods.CollectionAdd<StubObject>(),
                StubObject.Expressions.Default,
                StubObject.Expressions.Constant
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void ListInitExpressionShouldBeNotEqual_DifferentNewExpression_DifferentMethod_DifferentInitializers()
        {
            var x = Expression.ListInit(
                Expression.New(typeof(StubCollection)),
                StubCollection.Methods.Add,
                StubObject.Expressions.Default,
                StubObject.Expressions.Constant
            );
            var y = Expression.ListInit(
                Expression.New(typeof(List<StubObject>)),
                Methods.CollectionAdd<StubObject>(),
                StubObject.Expressions.Constant,
                StubObject.Expressions.Default
            );

            AssertAreNotEqual(x, y);
        }
    }
}