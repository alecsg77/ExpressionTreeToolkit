// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using ExpressionTreeToolkit.UnitTests.Stubs;

using Xunit;

namespace ExpressionTreeToolkit.UnitTests
{
    partial class ExpressionEqualityComparerBehaviour
    {
        [Fact]
        public void LambdaExpressionShouldBeEqual_SameBody()
        {
            var x = Expression.Lambda(
                StubObject.Expressions.Default
            );
            var y = Expression.Lambda(
                StubObject.Expressions.Default
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void LambdaExpressionShouldBeNotEqual_DifferentBody()
        {
            var x = Expression.Lambda(
                StubObject.Expressions.Default
            );
            var y = Expression.Lambda(
                StubObject.Expressions.Constant
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void LambdaExpressionShouldBeEqual_SameBody_WithOrWithoutTailCall()
        {
            var x = Expression.Lambda(
                StubObject.Expressions.Default
            );
            var y = Expression.Lambda(
                StubObject.Expressions.Default,
                false
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void LambdaExpressionShouldBeEqual_SameBody_WithOrWithoutName()
        {
            var x = Expression.Lambda(
                StubObject.Expressions.Default,
                default(IEnumerable<ParameterExpression>)
            );
            var y = Expression.Lambda(
                StubObject.Expressions.Default,
                "Lambda",
                default(IEnumerable<ParameterExpression>)
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void LambdaExpressionShouldBeEqual_SameBody_SameName()
        {
            var x = Expression.Lambda(
                StubObject.Expressions.Default,
                "Lambda",
                default(IEnumerable<ParameterExpression>)
            );
            var y = Expression.Lambda(
                StubObject.Expressions.Default,
                "Lambda",
                default(IEnumerable<ParameterExpression>)
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void LambdaExpressionShouldBeEqual_SameBody_SameName_WithOrWithoutTailCall()
        {
            var x = Expression.Lambda(
                StubObject.Expressions.Default,
                "Lambda",
                default(IEnumerable<ParameterExpression>)
            );
            var y = Expression.Lambda(
                StubObject.Expressions.Default,
                "Lambda",
                true,
                default(IEnumerable<ParameterExpression>)
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void LambdaExpressionShouldBeEqual_SameBody_WithOrWithoutName_DifferentTailCall()
        {
            var x = Expression.Lambda(
                StubObject.Expressions.Default,
                false,
                default(IEnumerable<ParameterExpression>)
            );
            var y = Expression.Lambda(
                StubObject.Expressions.Default,
                "Lambda",
                true,
                default(IEnumerable<ParameterExpression>)
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void LambdaExpressionShouldBeEqual_SameBody_SameTailCall()
        {
            var x = Expression.Lambda(
                StubObject.Expressions.Default,
                true
            );
            var y = Expression.Lambda(
                StubObject.Expressions.Default,
                true
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void LambdaExpressionShouldBeEqual_SameBody_DifferentTailCall()
        {
            var x = Expression.Lambda(
                StubObject.Expressions.Default,
                true
            );
            var y = Expression.Lambda(
                StubObject.Expressions.Default,
                false
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void LambdaExpressionShouldBeNotEqual_DifferentBody_SameTailCall()
        {
            var x = Expression.Lambda(
                StubObject.Expressions.Default,
                true
            );
            var y = Expression.Lambda(
                StubObject.Expressions.Constant,
                true
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void LambdaExpressionShouldBeNotEqual_DifferentBody_DifferentTailCall()
        {
            var x = Expression.Lambda(
                StubObject.Expressions.Default,
                true
            );
            var y = Expression.Lambda(
                StubObject.Expressions.Constant,
                false
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void LambdaExpressionShouldBeEqual_SameBody_SameParameters()
        {
            var x = Expression.Lambda(
                StubObject.Expressions.Default,
                Expression.Parameter(typeof(StubObject)),
                Expression.Parameter(typeof(int))
            );
            var y = Expression.Lambda(
                StubObject.Expressions.Default,
                Expression.Parameter(typeof(StubObject)),
                Expression.Parameter(typeof(int))
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void LambdaExpressionShouldBeNotEqual_SameBody_DifferentParameters()
        {
            var x = Expression.Lambda(
                StubObject.Expressions.Default,
                Expression.Parameter(typeof(StubObject)),
                Expression.Parameter(typeof(int))
            );
            var y = Expression.Lambda(
                StubObject.Expressions.Default,
                Expression.Parameter(typeof(int)),
                Expression.Parameter(typeof(StubObject))
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void LambdaExpressionShouldBeNotEqual_DifferentBody_SameParameters()
        {
            var x = Expression.Lambda(
                StubObject.Expressions.Default,
                Expression.Parameter(typeof(StubObject)),
                Expression.Parameter(typeof(int))
            );
            var y = Expression.Lambda(
                StubObject.Expressions.Constant,
                Expression.Parameter(typeof(StubObject)),
                Expression.Parameter(typeof(int))
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void LambdaExpressionShouldBeNotEqual_DifferentBody_DifferentParameters()
        {
            var x = Expression.Lambda(
                StubObject.Expressions.Default,
                Expression.Parameter(typeof(StubObject)),
                Expression.Parameter(typeof(int))
            );
            var y = Expression.Lambda(
                StubObject.Expressions.Constant,
                Expression.Parameter(typeof(int)),
                Expression.Parameter(typeof(StubObject))
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void LambdaExpressionShouldBeEqual_SameDelegateType_SameBody()
        {
            var x = Expression.Lambda(
                typeof(Action<StubObject, int>),
                StubObject.Expressions.Default,
                Expression.Parameter(typeof(StubObject)),
                Expression.Parameter(typeof(int))
            );
            var y = Expression.Lambda(
                typeof(Action<StubObject, int>),
                StubObject.Expressions.Default,
                Expression.Parameter(typeof(StubObject)),
                Expression.Parameter(typeof(int))
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void LambdaExpressionShouldBeNotEqual_SameDelegateType_DifferentBody()
        {
            var x = Expression.Lambda(
                typeof(Action<StubObject, int>),
                StubObject.Expressions.Default,
                Expression.Parameter(typeof(StubObject)),
                Expression.Parameter(typeof(int))
            );
            var y = Expression.Lambda(
                typeof(Action<StubObject, int>),
                StubObject.Expressions.Constant,
                Expression.Parameter(typeof(StubObject)),
                Expression.Parameter(typeof(int))
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void LambdaExpressionShouldBeNotEqual_DifferentDelegateType_SameBody()
        {
            var x = Expression.Lambda(
                typeof(Action<StubObject, int>),
                StubObject.Expressions.Default,
                Expression.Parameter(typeof(StubObject)),
                Expression.Parameter(typeof(int))
            );
            var y = Expression.Lambda(
                typeof(Func<StubObject, int, StubObject>),
                StubObject.Expressions.Default,
                Expression.Parameter(typeof(StubObject)),
                Expression.Parameter(typeof(int))
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void LambdaExpressionShouldBeNotEqual_DifferentDelegateType_DifferentBody()
        {
            var x = Expression.Lambda(
                typeof(Action<StubObject, int>),
                StubObject.Expressions.Default,
                Expression.Parameter(typeof(StubObject)),
                Expression.Parameter(typeof(int))
            );
            var y = Expression.Lambda(
                typeof(Func<StubObject, int, StubObject>),
                StubObject.Expressions.Constant,
                Expression.Parameter(typeof(StubObject)),
                Expression.Parameter(typeof(int))
            );

            AssertAreNotEqual(x, y);
        }
    }
}