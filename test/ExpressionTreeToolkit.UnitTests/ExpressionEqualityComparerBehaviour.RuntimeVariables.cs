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
        public void RuntimeVariablesExpressionShouldBeEqual_Empty()
        {
            var x = Expression.RuntimeVariables(
            );
            var y = Expression.RuntimeVariables(
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void RuntimeVariablesExpressionShouldBeEqual_SameParameters()
        {
            var x = Expression.RuntimeVariables(
                Expression.Parameter(typeof(StubObject)),
                Expression.Parameter(typeof(StubCollection))
            );
            var y = Expression.RuntimeVariables(
                Expression.Parameter(typeof(StubObject)),
                Expression.Parameter(typeof(StubCollection))
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void RuntimeVariablesExpressionShouldBeNotEqual_DifferentParameters()
        {
            var x = Expression.RuntimeVariables(
                Expression.Parameter(typeof(StubObject)),
                Expression.Parameter(typeof(StubCollection))
            );
            var y = Expression.RuntimeVariables(
                Expression.Parameter(typeof(StubCollection)),
                Expression.Parameter(typeof(StubObject))
            );

            AssertAreNotEqual(x, y);
        }
    }
}