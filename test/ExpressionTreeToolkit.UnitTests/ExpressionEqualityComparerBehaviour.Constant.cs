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
        public void ConstantExpressionShouldBeEqual_SameValue()
        {
            var x = Expression.Constant(StubObject.Singleton);
            var y = Expression.Constant(StubObject.Singleton);

            AssertAreEqual(x, y);
        }

        [Fact]
        public void ConstantExpressionShouldBeNotEqual_DifferentValue()
        {
            var x = Expression.Constant(StubObject.Singleton);
            var y = Expression.Constant(new StubObject());

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void ConstantExpressionShouldBeEqual_SameValue_SameType()
        {
            var x = Expression.Constant(StubObject.Singleton, typeof(object));
            var y = Expression.Constant(StubObject.Singleton, typeof(object));

            AssertAreEqual(x, y);
        }

        [Fact]
        public void ConstantExpressionShouldBeNotEqual_SameValue_DifferentType()
        {
            var x = Expression.Constant(StubObject.Singleton, typeof(object));
            var y = Expression.Constant(StubObject.Singleton, typeof(StubObject));

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void ConstantExpressionShouldBeNotEqual_DifferentValue_DifferentType()
        {
            var x = Expression.Constant(StubObject.Singleton, typeof(StubObject));
            var y = Expression.Constant(new StubObject(), typeof(object));

            AssertAreNotEqual(x, y);
        }
    }
}