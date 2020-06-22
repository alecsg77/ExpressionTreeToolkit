// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Linq.Expressions;

using ExpressionTreeToolkit.UnitTests.Stubs;

using Xunit;

namespace ExpressionTreeToolkit.UnitTests
{
    partial class ExpressionEqualityComparerBehaviour
    {
        [Fact]
        public void InvocationExpressionShouldBeEqual_SameExpression()
        {
            var x = Expression.Invoke(
                Expression.Default(typeof(Action))
            );
            var y = Expression.Invoke(
                Expression.Default(typeof(Action))
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void InvocationExpressionShouldBeNotEqual_DifferentExpression()
        {
            var x = Expression.Invoke(
                Expression.Default(typeof(Action))
            );
            var y = Expression.Invoke(
                Expression.Parameter(typeof(Action))
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void InvocationExpressionShouldBeEqual_SameExpression_SameArguments()
        {
            var x = Expression.Invoke(
                Expression.Default(typeof(Action<StubObject, StubObject>)),
                StubObject.Expressions.Default,
                StubObject.Expressions.Constant
            );
            var y = Expression.Invoke(
                Expression.Default(typeof(Action<StubObject, StubObject>)),
                StubObject.Expressions.Default,
                StubObject.Expressions.Constant
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void InvocationExpressionShouldBeNotEqual_SameExpression_DifferentArguments()
        {
            var x = Expression.Invoke(
                Expression.Default(typeof(Action<StubObject, StubObject>)),
                StubObject.Expressions.Default,
                StubObject.Expressions.Constant
            );
            var y = Expression.Invoke(
                Expression.Default(typeof(Action<StubObject, StubObject>)),
                StubObject.Expressions.Constant,
                StubObject.Expressions.Default
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void InvocationExpressionShouldBeNotEqual_DifferentExpression_SameArguments()
        {
            var x = Expression.Invoke(
                Expression.Default(typeof(Action<StubObject, StubObject>)),
                StubObject.Expressions.Default,
                StubObject.Expressions.Constant
            );
            var y = Expression.Invoke(
                Expression.Parameter(typeof(Action<StubObject, StubObject>)),
                StubObject.Expressions.Default,
                StubObject.Expressions.Constant
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void InvocationExpressionShouldBeNotEqual_DifferentExpression_DifferentArguments()
        {
            var x = Expression.Invoke(
                Expression.Default(typeof(Action<StubObject, StubObject>)),
                StubObject.Expressions.Default,
                StubObject.Expressions.Constant
            );
            var y = Expression.Invoke(
                Expression.Parameter(typeof(Action<StubObject, StubObject>)),
                StubObject.Expressions.Constant,
                StubObject.Expressions.Default
            );

            AssertAreNotEqual(x, y);
        }
    }
}