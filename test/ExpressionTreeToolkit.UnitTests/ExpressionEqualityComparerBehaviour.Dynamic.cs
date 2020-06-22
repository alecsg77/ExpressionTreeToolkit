// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Linq.Expressions;
using System.Runtime.CompilerServices;

using ExpressionTreeToolkit.UnitTests.Stubs;

using Moq;

using Xunit;

namespace ExpressionTreeToolkit.UnitTests
{
    partial class ExpressionEqualityComparerBehaviour
    {
        private static readonly CallSiteBinder CallSiteBinder = Mock.Of<CallSiteBinder>();
        private static readonly CallSiteBinder AnotherCallSiteBinder = Mock.Of<CallSiteBinder>();

        [Fact]
        public void DynamicExpressionShouldBeEqual_SameCallSiteBinder_SameReturnType_SameArguments()
        {
            var x = Expression.Dynamic(
                CallSiteBinder,
                typeof(StubObject),
                StubObject.Expressions.Default
            );
            var y = Expression.Dynamic(
                CallSiteBinder,
                typeof(StubObject),
                StubObject.Expressions.Default
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void DynamicExpressionShouldBeNotEqual_SameCallSiteBinder_SameReturnType_DifferentArguments()
        {
            var x = Expression.Dynamic(
                CallSiteBinder,
                typeof(StubObject),
                StubObject.Expressions.Default
            );
            var y = Expression.Dynamic(
                CallSiteBinder,
                typeof(StubObject),
                StubObject.Expressions.Constant
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void DynamicExpressionShouldBeNotEqual_SameCallSiteBinder_DifferentReturnType_SameArguments()
        {
            var x = Expression.Dynamic(
                CallSiteBinder,
                typeof(StubObject),
                StubObject.Expressions.Default
            );
            var y = Expression.Dynamic(
                CallSiteBinder,
                typeof(StubCollection),
                StubObject.Expressions.Default
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void DynamicExpressionShouldBeNotEqual_DifferentCallSiteBinder_SameReturnType_SameArguments()
        {
            var x = Expression.Dynamic(
                CallSiteBinder,
                typeof(StubObject),
                StubObject.Expressions.Default
            );
            var y = Expression.Dynamic(
                AnotherCallSiteBinder,
                typeof(StubObject),
                StubObject.Expressions.Default
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void DynamicExpressionShouldBeNotEqual_DifferentCallSiteBinder_DifferentReturnType_DifferentArguments()
        {
            var x = Expression.Dynamic(
                CallSiteBinder,
                typeof(StubObject),
                StubObject.Expressions.Default
            );
            var y = Expression.Dynamic(
                AnotherCallSiteBinder,
                typeof(StubCollection),
                StubObject.Expressions.Constant
            );

            AssertAreNotEqual(x, y);
        }
    }
}