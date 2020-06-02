// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xunit;

namespace ExpressionTreeToolkit.UnitTests
{
    public class ExpressionEqualityComparerEqualsBehaviour
    {
        private readonly IEqualityComparer<Expression> _target = ExpressionEqualityComparer.Default;

        private void AssertAreEqual(Expression x, Expression y)
        {
            Assert.True(_target.Equals(x, y));
            Assert.Equal(_target.GetHashCode(x), _target.GetHashCode(y));
        }

        private void AssertAreNotEqual(Expression x, Expression y)
        {
            Assert.False(_target.Equals(x, y));
        }

        [Fact]
        public void ShouldBeEqual_Null_And_Null()
        {
            Assert.True(_target.Equals(null, null));
        }

        [Fact]
        public void ShouldBeNotEqual_ConstantNull_And_Null()
        {
            AssertAreNotEqual(Expression.Constant(null), null);
        }

        [Fact]
        public void ShouldBeEqual_ConstantNull_And_ConstantNull()
        {
            AssertAreEqual(Expression.Constant(null), Expression.Constant(null));
        }

        [Fact]
        public void ShouldBeNotEqual_ConstantNull_And_ConstantInt()
        {
            AssertAreNotEqual(Expression.Constant(null), Expression.Constant(5));
        }

        [Fact]
        public void ShouldBeEqual_Constant_And_Itself()
        {
            var constant = Expression.Constant(5);
            AssertAreEqual(constant, constant);
        }

        [Fact]
        public void ShouldBeNotEqual_ConstantInt5_And_ConstantInt3()
        {
            AssertAreNotEqual(Expression.Constant(5), Expression.Constant(3));
        }

        [Fact]
        public void ShouldBeEqual_Empty_And_Empty()
        {
            AssertAreEqual(Expression.Empty(), Expression.Empty());
        }

        [Fact]
        public void ShouldBeEqual_FuncReturningNullObject_And_FuncReturningNullObject()
        {
            Expression<Func<object>> x = () => null;
            Expression<Func<object>> y = () => null;
            AssertAreEqual(x, y);
        }

        [Fact]
        public void ShouldBeNotEqual_FuncReturningNullObject_And_FuncReturningConstantObject()
        {
            Expression<Func<object>> x = () => null;
            Expression<Func<object>> y = () => 5;
            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void ShouldBeNotEqual_FuncReturningNullObject_And_FuncReturningNullInt()
        {
            Expression<Func<object>> x = () => null;
            Expression<Func<int?>> y = () => null;
            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void ShouldBeNotEqual_FuncReturningNullObject_And_FuncObjectReturningNullObject()
        {
            Expression<Func<object>> x = () => null;
            Expression<Func<object, object>> y = o => null;
            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void ShouldBeEqual_FuncIPlusI_And_FuncIPlusI()
        {
            Expression<Func<int, int>> x = i => i + i;
            Expression<Func<int, int>> y = i => i + i;
            AssertAreEqual(x, y);
        }

        [Fact]
        public void ShouldBeNotEqual_FuncIPlusOne_And_FuncIPlusTwo()
        {
            Expression<Func<int, int>> x = i => i + 1;
            Expression<Func<int, int>> y = i => i + 2;
            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void ShouldBeNotEqual_FuncOnePlusI_And_FuncTwoPlusI()
        {
            Expression<Func<int, int>> x = i => 1 + i;
            Expression<Func<int, int>> y = i => 2 + i;
            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void ShouldBeNotEqual_FuncIPlusI_And_FuncITimesI()
        {
            Expression<Func<int, int>> x = i => i + i;
            Expression<Func<int, int>> y = i => i * i;
            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void ShouldBeEqual_FuncAReturningA_And_FuncBReturningB()
        {
            Expression<Func<int, int>> x = a => a;
            Expression<Func<int, int>> y = b => b;
            AssertAreEqual(x, y);
        }

        [Fact]
        public void ShouldBeEqual_FuncABReturningAPlusB_And_FuncBAReturningBPlusA()
        {
            Expression<Func<int, int, int>> x = (a, b) => a + b;
            Expression<Func<int, int, int>> y = (b, a) => b + a;
            AssertAreEqual(x, y);
        }

        [Fact]
        public void ShouldBeNotEqual_FuncABReturningAPlusB_And_FuncABReturningBPlusA()
        {
            Expression<Func<int, int, int>> x = (a, b) => a + b;
            Expression<Func<int, int, int>> y = (b, a) => a + b;
            AssertAreNotEqual(x, y);
        }
    }
}