// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

using ExpressionTreeToolkit.UnitTests.Stubs;

using Xunit;

namespace ExpressionTreeToolkit.UnitTests
{
    partial class ExpressionEqualityComparerBehaviour
    {
        [Fact]
        public void ShouldBeNotEqual_UnknownExpression3_And_UnknownExpression3()
        {
            AssertAreNotEqual(StubExpression.Unknown(3), StubExpression.Unknown(3));
        }

        [Fact]
        public void ShouldBeEqual_EqualityComparableExpression3_And_EqualityComparableExpression3()
        {
            AssertAreEqual(StubExpression.Comparable(3), StubExpression.Comparable(3));
        }

        [Fact]
        public void ShouldBeEqual_ExpressionEqualityComparer_Composition_UnknownExpressionNode()
        {
            var target = new ExpressionEqualityComparer(UnknownExpression.EqualityComparer);
            var x = Expression.Property(StubExpression.Unknown(3), "Id");
            var y = Expression.Property(StubExpression.Unknown(3), "Id");
            AssertAreEqual(x, y, target);
        }

        [ExcludeFromCodeCoverage]
        private sealed class ExtendedExpressionEqualityComparer : ExpressionEqualityComparer
        {
            public override bool Equals(Expression x, Expression y)
            {
                if (ReferenceEquals(x, y)) return true;

                if (x is null || y is null) return false;

                if (x is UnknownExpression myExpressionX && y is UnknownExpression myExpressionY)
                    return myExpressionX.Id == myExpressionY.Id;

                return base.Equals(x, y);
            }

            public override int GetHashCode(Expression expression)
            {
                if (expression is UnknownExpression simpleExpression)
                {
                    unchecked
                    {
                        var hashCode = simpleExpression.Id;
                        hashCode = (hashCode * 397) ^ (int)simpleExpression.NodeType;
                        return (hashCode * 397) ^ simpleExpression.Type.GetHashCode();
                    }
                }

                return base.GetHashCode(expression);
            }
        }

        [Fact]
        public void ShouldBeEqual_ExpressionEqualityComparer_Inheritance()
        {
            var target = new ExtendedExpressionEqualityComparer();
            var x = Expression.Property(StubExpression.Unknown(5), "Id");
            var y = Expression.Property(StubExpression.Unknown(5), "Id");
            AssertAreEqual(x, y, target);
        }
    }
}