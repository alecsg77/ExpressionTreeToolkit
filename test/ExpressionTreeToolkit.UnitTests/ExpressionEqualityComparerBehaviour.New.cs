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
        public void NewExpressionShouldBeEqual_SameConstructor()
        {
            var x = Expression.New(
                StubObject.Constructors.Default
            );
            var y = Expression.New(
                StubObject.Constructors.Default
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void NewExpressionShouldBeEqual_SameConstructor_SameParameters()
        {
            var x = Expression.New(
                StubObject.Constructors.Copy,
                StubObject.Expressions.Default
            );
            var y = Expression.New(
                StubObject.Constructors.Copy,
                StubObject.Expressions.Default
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void NewExpressionShouldBeNotEqual_SameConstructor_DifferentParameters()
        {
            var x = Expression.New(
                StubObject.Constructors.Copy,
                StubObject.Expressions.Default
            );
            var y = Expression.New(
                StubObject.Constructors.Copy,
                StubObject.Expressions.Constant
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void NewExpressionShouldBeNotEqual_DifferentConstructor_DifferentParameters()
        {
            var x = Expression.New(
                StubObject.Constructors.Default,
                default
            );
            var y = Expression.New(
                StubObject.Constructors.Copy,
                StubObject.Expressions.Default
            );

            AssertAreNotEqual(x, y);
        }

    }
}