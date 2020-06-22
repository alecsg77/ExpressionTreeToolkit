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
        public void MethodCallExpressionShouldBeEqual_SameMethod()
        {
            var x = Expression.Call(
                Methods.Method
            );
            var y = Expression.Call(
                Methods.Method
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void MethodCallExpressionShouldBeNotEqual_DifferentMethod()
        {
            var x = Expression.Call(
                Methods.Method
            );
            var y = Expression.Call(
                Methods.Action()
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void MethodCallExpressionShouldBeEqual_SameMethod_SameArguments()
        {
            var x = Expression.Call(
                Methods.Add<StubObject>(),
                StubObject.Expressions.Default,
                StubObject.Expressions.Constant
            );
            var y = Expression.Call(
                Methods.Add<StubObject>(),
                StubObject.Expressions.Default,
                StubObject.Expressions.Constant
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void MethodCallExpressionShouldBeNotEqual_SameMethod_DifferentArguments()
        {
            var x = Expression.Call(
                Methods.Add<StubObject>(),
                StubObject.Expressions.Default,
                StubObject.Expressions.Constant
            );
            var y = Expression.Call(
                Methods.Add<StubObject>(),
                StubObject.Expressions.Constant,
                StubObject.Expressions.Default
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void MethodCallExpressionShouldBeEqual_SameInstance_SameMethod_SameArguments()
        {
            var x = Expression.Call(
                StubObject.Expressions.Default,
                StubObject.Methods.Insert,
                StubObject.Expressions.Default
            );
            var y = Expression.Call(
                StubObject.Expressions.Default,
                StubObject.Methods.Insert,
                StubObject.Expressions.Default
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void MethodCallExpressionShouldBeNotEqual_DifferentInstance_SameMethod_SameArguments()
        {
            var x = Expression.Call(
                StubObject.Expressions.Default,
                StubObject.Methods.Insert,
                StubObject.Expressions.Default
            );
            var y = Expression.Call(
                StubObject.Expressions.Constant,
                StubObject.Methods.Insert,
                StubObject.Expressions.Default
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void MethodCallExpressionShouldBeNotEqual_DifferentInstance_DifferentMethod_DifferentArguments()
        {
            var x = Expression.Call(
                StubObject.Expressions.Default,
                StubObject.Methods.Insert,
                StubObject.Expressions.Default
            );
            var y = Expression.Call(
                StubObject.Expressions.Constant,
                StubObject.Methods.Action<StubObject>(),
                StubObject.Expressions.Constant
            );

            AssertAreNotEqual(x, y);
        }
    }
}