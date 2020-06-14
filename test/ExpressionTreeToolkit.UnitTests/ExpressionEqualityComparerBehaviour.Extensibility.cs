// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

using ExpressionTreeToolkit.UnitTests.Stubs;

using Xunit;

namespace ExpressionTreeToolkit.UnitTests
{
    partial class ExpressionEqualityComparerBehaviour
    {
        [Fact]
        public void ShouldBeNotEqual_SimpleExpression3_And_SimpleExpression3()
        {
            AssertAreNotEqual(StubExpression.Simple(3), StubExpression.Simple(3));
        }

        [Fact]
        public void ShouldBeEqual_EqualityComparableExpression3_And_EqualityComparableExpression3()
        {
            AssertAreEqual(StubExpression.Comparable(3), StubExpression.Comparable(3));
        }

        [Fact]
        public void ShouldBeNotEqual_ExpressionEqualityComparer_SimpleExpressionNode()
        {
            var target = new ExpressionEqualityComparer();
            var expressionX = Expression.Property(StubExpression.Simple(3), "Id");
            var expressionY = Expression.Property(StubExpression.Simple(3), "Id");
            AssertAreNotEqual(expressionX, expressionY, target);
        }

        [ExcludeFromCodeCoverage]
        private sealed class SimpleExpressionEqualityComparer : EqualityComparer<Expression>
        {
            public override bool Equals(Expression x, Expression y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (x is null || y is null) return false;

                if (x.GetType() != y.GetType()) return false;

                if (!(x.NodeType == y.NodeType && x.Type == y.Type))
                    return false;

                if ((x is SimpleExpression myExpressionX) && (y is SimpleExpression myExpressionY))
                    return myExpressionX.Id == myExpressionY.Id;

                throw new ArgumentException();
            }

            public override int GetHashCode(Expression obj)
            {
                if (obj == null) throw new ArgumentNullException(nameof(obj));

                if (obj is SimpleExpression expression)
                {
                    unchecked
                    {
                        var hashCode = expression.Id;
                        hashCode = (hashCode * 397) ^ (int)expression.NodeType;
                        hashCode = (hashCode * 397) ^ expression.Type.GetHashCode();
                        return hashCode;
                    }
                }

                throw new ArgumentException();
            }
        }

        [Fact]
        public void ShouldBeEqual_ExpressionEqualityComparer_Composition_SimpleExpressionNode()
        {
            var target = new ExpressionEqualityComparer(new SimpleExpressionEqualityComparer());
            var expressionX = Expression.Property(StubExpression.Simple(3), "Id");
            var expressionY = Expression.Property(StubExpression.Simple(3), "Id");
            AssertAreEqual(expressionX, expressionY, target);
        }

        [ExcludeFromCodeCoverage]
        private sealed class ExtendedExpressionEqualityComparer : ExpressionEqualityComparer
        {
            public override bool Equals(Expression x, Expression y)
            {
                if (ReferenceEquals(x, y)) return true;

                if (x is null || y is null) return false;

                if (x is SimpleExpression myExpressionX && y is SimpleExpression myExpressionY)
                    return myExpressionX.Id == myExpressionY.Id;

                return base.Equals(x, y);
            }

            public override int GetHashCode(Expression expression)
            {
                if (expression is SimpleExpression simpleExpression)
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
            var expressionX = Expression.Property(StubExpression.Simple(5), "Id");
            var expressionY = Expression.Property(StubExpression.Simple(5), "Id");
            AssertAreEqual(expressionX, expressionY, target);
        }
    }
}