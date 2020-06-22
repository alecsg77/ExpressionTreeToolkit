// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Linq.Expressions;

using ExpressionTreeToolkit.UnitTests.Stubs;

using Xunit;

namespace ExpressionTreeToolkit.UnitTests
{
    public partial class ExpressionEqualityComparerBehaviour
    {
        [Fact]
        public void ParameterExpressionShouldBeEqual_SameType()
        {
            var x = Expression.Parameter(typeof(StubObject));
            var y = Expression.Parameter(typeof(StubObject));

            AssertAreEqual(x, y);
        }

        [Fact]
        public void ParameterExpressionShouldBeNotEqual_DifferentType()
        {
            var x = Expression.Parameter(typeof(StubObject));
            var y = Expression.Parameter(typeof(object));

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void ParameterExpressionShouldBeEqual_SameType_SameIsByRef()
        {
            var x = Expression.Parameter(typeof(StubObject).MakeByRefType());
            var y = Expression.Parameter(typeof(StubObject).MakeByRefType());

            AssertAreEqual(x, y);
        }

        [Fact]
        public void ParameterExpressionShouldBeNotEqual_SameType_DifferentIsByRef()
        {
            var x = Expression.Parameter(typeof(StubObject).MakeByRefType());
            var y = Expression.Parameter(typeof(StubObject));

            AssertAreNotEqual(x, y);
        }
    }
}