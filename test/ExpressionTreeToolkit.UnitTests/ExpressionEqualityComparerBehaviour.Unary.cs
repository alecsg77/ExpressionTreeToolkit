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
        public void UnaryExpressionShouldBeEqual_SameOperand_SameType()
        {
            var x = Expression.TypeAs(
                    StubObject.Expressions.Default,
                    typeof(StubObject)
                );
            var y = Expression.TypeAs(
                    StubObject.Expressions.Default,
                    typeof(StubObject)
                );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void UnaryExpressionShouldBeNotEqual_SameOperand_DifferentType()
        {
            var x = Expression.TypeAs(
                    StubObject.Expressions.Default,
                    typeof(StubObject)
                );
            var y = Expression.TypeAs(
                    StubObject.Expressions.Default,
                    typeof(object)
                );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void UnaryExpressionShouldBeNotEqual_DifferentOperand_SameType()
        {
            var x = Expression.TypeAs(
                    StubObject.Expressions.Default,
                    typeof(StubObject)
                );
            var y = Expression.TypeAs(
                    StubObject.Expressions.Constant,
                    typeof(StubObject)
                );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void UnaryExpressionShouldBeEqual_SameOperand_SameType_SameMethod()
        {
            var x = Expression.Convert(
                    StubObject.Expressions.Default,
                    typeof(StubObject),
                    Methods.Func<StubObject,StubObject>()
                );
            var y = Expression.Convert(
                    StubObject.Expressions.Default,
                    typeof(StubObject),
                    Methods.Func<StubObject,StubObject>()
                );
            
            AssertAreEqual(x, y);
        }

        [Fact]
        public void UnaryExpressionShouldBeNotEqual_SameOperand_SameType_DifferentMethod()
        {
            var x = Expression.Convert(
                    StubObject.Expressions.Default,
                    typeof(StubObject),
                    Methods.Func<StubObject,StubObject>()
                );
            var y = Expression.Convert(
                    StubObject.Expressions.Default,
                    typeof(StubObject),
                    Methods.Convert<StubObject,StubObject>()
                );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void UnaryExpressionShouldBeNotEqual_DifferentOperand_DifferentType_DifferentMethod()
        {
            var x = Expression.Convert(
                    StubObject.Expressions.Default,
                    typeof(StubObject),
                    Methods.Func<StubObject,StubObject>()
                );
            var y = Expression.Convert(
                    StubObject.Expressions.Constant,
                    typeof(int),
                    Methods.Func<StubObject,int>()
                );
            
            AssertAreNotEqual(x, y);
        }
    }
}