// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xunit;

namespace ExpressionTreeToolkit.UnitTests
{
    public class ExpressionEqualityComparer_ExtensionBehavours
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

        class MyExpression : Expression
        {
            public int Id { get; }

            public MyExpression(int id)
            {
                Id = id;
                NodeType = (ExpressionType) (-1);
                Type = typeof(object);
            }

            public override ExpressionType NodeType { get; }
            public override Type Type { get; }
        }

        [Fact]
        public void ShouldBeNotEqual_MyExpression3_And_MyExpression3()
        {
            AssertAreNotEqual(new MyExpression(3), new MyExpression(3));
        }

        class MyExpressionEqualityComparable : MyExpression, IEquatable<MyExpressionEqualityComparable>
        {
            public MyExpressionEqualityComparable(int id) : base(id)
            {
            }

            public bool Equals(MyExpressionEqualityComparable other)
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
                return Equals((MyExpressionEqualityComparable) obj);
            }

            public override int GetHashCode()
            {
                return Id;
            }

            public static bool operator ==(MyExpressionEqualityComparable left, MyExpressionEqualityComparable right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(MyExpressionEqualityComparable left, MyExpressionEqualityComparable right)
            {
                return !Equals(left, right);
            }
        }

        [Fact]
        public void ShouldBeEqual_MyEqualityComparableExtension3_And_MyEqualityComparableExtension3()
        {
            AssertAreEqual(new MyExpressionEqualityComparable(3), new MyExpressionEqualityComparable(3));
        }

        private sealed class MyExpressionEqualityComparer : ExpressionEqualityComparer<MyExpression>
        {
            public MyExpressionEqualityComparer()
                : this(null)
            {
            }

            public MyExpressionEqualityComparer(IEqualityComparer<Expression> equalityComparer)
                : base(equalityComparer)
            {
            }

            protected override bool EqualsExpression(MyExpression x, MyExpression y)
            {
                return x.Id == y.Id;
            }

            protected override int GetHashCodeExpression(MyExpression obj)
            {
                unchecked
                {
                    var hashCode = obj.Id;
                    hashCode = (hashCode * 397) ^ (int) obj.NodeType;
                    hashCode = (hashCode * 397) ^ obj.Type.GetHashCode();
                    return hashCode;
                }
            }

            public static MyExpressionEqualityComparer Default { get; } = new MyExpressionEqualityComparer();
        }

        [Fact]
        public void ShouldBeEqual_MyExpression3_And_MyExpression3_WithEqualityComparare()
        {
            AssertAreEqual(new MyExpression(3), new MyExpression(3),
                new ExpressionEqualityComparer(MyExpressionEqualityComparer.Default));
        }
    }
}