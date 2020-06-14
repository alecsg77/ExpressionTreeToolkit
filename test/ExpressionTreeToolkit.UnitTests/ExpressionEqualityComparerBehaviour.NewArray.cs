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
        public void NewArrayExpressionShouldBeEqual_SameType()
        {
            var x = Expression.NewArrayInit(
                typeof(StubObject)
            );
            var y = Expression.NewArrayInit(
                typeof(StubObject)
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void NewArrayExpressionShouldBeNotEqual_DifferentType()
        {
            var x = Expression.NewArrayInit(
                typeof(StubObject)
            );
            var y = Expression.NewArrayInit(
                typeof(object)
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void NewArrayExpressionShouldBeEqual_SameType_SameInitializers()
        {
            var x = Expression.NewArrayInit(
                typeof(StubObject),
                StubObject.Expressions.Default,
                StubObject.Expressions.Constant
            );
            var y = Expression.NewArrayInit(
                typeof(StubObject),
                StubObject.Expressions.Default,
                StubObject.Expressions.Constant
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void NewArrayExpressionShouldBeNotEqual_SameType_DifferentInitializers()
        {
            var x = Expression.NewArrayInit(
                typeof(StubObject),
                StubObject.Expressions.Default,
                StubObject.Expressions.Constant
            );
            var y = Expression.NewArrayInit(
                typeof(StubObject),
                StubObject.Expressions.Constant,
                StubObject.Expressions.Default
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void NewArrayExpressionShouldBeEqual_DifferentType_SameInitializers()
        {
            var x = Expression.NewArrayInit(
                typeof(StubObject),
                StubObject.Expressions.Default,
                StubObject.Expressions.Constant
            );
            var y = Expression.NewArrayInit(
                typeof(object),
                StubObject.Expressions.Default,
                StubObject.Expressions.Constant
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void NewArrayExpressionShouldBeEqual_DifferentType_DifferentInitializers()
        {
            var x = Expression.NewArrayInit(
                typeof(StubObject),
                StubObject.Expressions.Default,
                StubObject.Expressions.Constant
            );
            var y = Expression.NewArrayInit(
                typeof(object),
                StubObject.Expressions.Constant,
                StubObject.Expressions.Default
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void NewArrayExpressionShouldBeEqual_SameType_SameBounds()
        {
            var x = Expression.NewArrayBounds(
                typeof(StubObject),
                Expression.Default(typeof(int)),
                Expression.Parameter(typeof(int))
            );
            var y = Expression.NewArrayBounds(
                typeof(StubObject),
                Expression.Default(typeof(int)),
                Expression.Parameter(typeof(int))
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void NewArrayExpressionShouldBeNotEqual_SameType_DifferentBounds()
        {
            var x = Expression.NewArrayBounds(
                typeof(StubObject),
                Expression.Default(typeof(int)),
                Expression.Parameter(typeof(int))
            );
            var y = Expression.NewArrayBounds(
                typeof(StubObject),
                Expression.Parameter(typeof(int)),
                Expression.Default(typeof(int))
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void NewArrayExpressionShouldBeNotEqual_DifferentType_SameBounds()
        {
            var x = Expression.NewArrayBounds(
                typeof(StubObject),
                Expression.Default(typeof(int)),
                Expression.Parameter(typeof(int))
            );
            var y = Expression.NewArrayBounds(
                typeof(object),
                Expression.Default(typeof(int)),
                Expression.Parameter(typeof(int))
            );

            AssertAreNotEqual(x, y);
        }
        [Fact]
        public void NewArrayExpressionShouldBeNotEqual_DifferentType_DifferentBounds()
        {
            var x = Expression.NewArrayBounds(
                typeof(StubObject),
                Expression.Default(typeof(int)),
                Expression.Parameter(typeof(int))
            );
            var y = Expression.NewArrayBounds(
                typeof(object),
                Expression.Parameter(typeof(int)),
                Expression.Default(typeof(int))
            );

            AssertAreNotEqual(x, y);
        }
    }
}