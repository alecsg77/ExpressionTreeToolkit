// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xunit;

namespace ExpressionTreeToolkit.UnitTests
{
    public class ExpressionEqualityComparerExtensibilityBehavours
    {
        private void AssertAreEqual(Expression x, Expression y)
        {
            AssertAreEqual(x, y, ExpressionEqualityComparer.Default);
        }

        private void AssertAreNotEqual(Expression x, Expression y)
        {
            AssertAreNotEqual(x, y, ExpressionEqualityComparer.Default);
        }

        private static void AssertAreEqual(Expression x, Expression y, IEqualityComparer<Expression> equalityComparer)
        {
            if (equalityComparer == null) throw new ArgumentNullException(nameof(equalityComparer));
            Assert.True(equalityComparer.Equals(x, y));
            Assert.Equal(equalityComparer.GetHashCode(x), equalityComparer.GetHashCode(y));
        }

        private static void AssertAreNotEqual(Expression x, Expression y,
            IEqualityComparer<Expression> equalityComparer)
        {
            if (equalityComparer == null) throw new ArgumentNullException(nameof(equalityComparer));
            Assert.False(equalityComparer.Equals(x, y));
        }

        class SimpleExpression : Expression
        {
            public int Id { get; }

            public SimpleExpression(int id)
            {
                Id = id;
                NodeType = (ExpressionType)(-1);
                Type = typeof(SimpleExpression);
            }

            public override ExpressionType NodeType { get; }
            public override Type Type { get; }
        }

        [Fact]
        public void ShouldBeNotEqual_SimpleExpression3_And_SimpleExpression3()
        {
            AssertAreNotEqual(new SimpleExpression(3), new SimpleExpression(3));
        }

        class EqualityComparableExpression : SimpleExpression, IEquatable<EqualityComparableExpression>
        {
            public EqualityComparableExpression(int id) : base(id)
            {
            }

            public bool Equals(EqualityComparableExpression other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return Id == other.Id;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((EqualityComparableExpression)obj);
            }

            public override int GetHashCode()
            {
                return Id;
            }

            public static bool operator ==(EqualityComparableExpression left, EqualityComparableExpression right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(EqualityComparableExpression left, EqualityComparableExpression right)
            {
                return !Equals(left, right);
            }
        }

        [Fact]
        public void ShouldBeEqual_EqualityComparableExpression3_And_EqualityComparableExpression3()
        {
            AssertAreEqual(new EqualityComparableExpression(3), new EqualityComparableExpression(3));
        }
        
        [Fact]
        public void ShouldBeNotEqual_ExpressionEqualityComparer_SimpleExpressionNode()
        {
            var target = new ExpressionEqualityComparer();
            var expressionX = Expression.Property(new SimpleExpression(3), "Id");
            var expressionY = Expression.Property(new SimpleExpression(3), "Id");
            AssertAreNotEqual(expressionX, expressionY, target);
        }

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
            var expressionX = Expression.Property(new SimpleExpression(3), "Id");
            var expressionY = Expression.Property(new SimpleExpression(3), "Id");
            AssertAreEqual(expressionX, expressionY, target);
        }

        //[Fact]
        //public void ShouldBeEqual_ExpressionEqualityComparer_Inheritance()
        //{
        //}
    }
}