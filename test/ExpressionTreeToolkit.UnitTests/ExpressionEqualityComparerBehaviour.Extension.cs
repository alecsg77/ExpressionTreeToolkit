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
        public void ExtensionShouldBeEqual_SameReduceExpression()
        {
            var x = StubExpression.Extension(Expression.Empty());
            var y = StubExpression.Extension(Expression.Empty());

            AssertAreEqual(x, y);
        }

        [Fact]
        public void ExtensionShouldBeNotEqual_DifferentReduceExpression()
        {
            var x = StubExpression.Extension(StubObject.Expressions.Default);
            var y = StubExpression.Extension(StubObject.Expressions.Constant);

            AssertAreNotEqual(x, y);
        }
    }
}