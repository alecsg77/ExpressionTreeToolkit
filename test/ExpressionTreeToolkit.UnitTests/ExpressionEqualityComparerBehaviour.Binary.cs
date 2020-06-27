// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using ExpressionTreeToolkit.UnitTests.Stubs;

using System.Linq.Expressions;

using Xunit;

namespace ExpressionTreeToolkit.UnitTests
{
    partial class ExpressionEqualityComparerBehaviour
    {
        [Fact]
        public void BinaryExpressionShouldBeEqual_SameLeft_SameRight()
        {
            var x = Expression.ArrayIndex(
                Expression.Default(typeof(StubObject[])),
                Expression.Default(typeof(int))
            );
            var y = Expression.ArrayIndex(
                Expression.Default(typeof(StubObject[])),
                Expression.Default(typeof(int))
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void BinaryExpressionShouldBeNotEqual_SameLeft_DifferentRight()
        {
            var x = Expression.ArrayIndex(
                Expression.Default(typeof(StubObject[])),
                Expression.Default(typeof(int))
            );
            var y = Expression.ArrayIndex(
                Expression.Default(typeof(StubObject[])),
                Expression.Parameter(typeof(int))
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void BinaryExpressionShouldBeNotEqual_DifferentLeft_SameRight()
        {
            var x = Expression.ArrayIndex(
                Expression.Default(typeof(StubObject[])),
                Expression.Default(typeof(int))
            );
            var y = Expression.ArrayIndex(
                Expression.Parameter(typeof(StubObject[])),
                Expression.Default(typeof(int))
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void BinaryExpressionShouldBeEqual_SameLeft_SameRight_SameMethod()
        {
            var x = Expression.Add(
                Expression.Default(typeof(StubObject)),
                Expression.Default(typeof(StubObject)),
                Methods.Add<StubObject>()
            );
            var y = Expression.Add(
                Expression.Default(typeof(StubObject)),
                Expression.Default(typeof(StubObject)),
                Methods.Add<StubObject>()
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void BinaryExpressionShouldBeNotEqual_SameLeft_SameRight_DifferentMethod()
        {
            var x = Expression.Add(
                Expression.Default(typeof(StubObject)),
                Expression.Default(typeof(StubObject)),
                Methods.Add<StubObject>()
            );
            var y = Expression.Add(
                Expression.Default(typeof(StubObject)),
                Expression.Default(typeof(StubObject)),
                Methods.Func<StubObject, StubObject, StubObject>()
            );

            AssertAreNotEqual(x, y);
        }
        
        [Fact]
        public void BinaryExpressionShouldBeEqual_SameLeft_SameRight_SameConversion()
        {
            var x = Expression.Coalesce(
                Expression.Default(typeof(StubObject)),
                Expression.Default(typeof(StubObject)),
                Expression.Lambda(
                    Expression.Default(typeof(StubObject)),
                    Expression.Parameter(typeof(StubObject))
                    )
            );
            var y = Expression.Coalesce(
                Expression.Default(typeof(StubObject)),
                Expression.Default(typeof(StubObject)),
                Expression.Lambda(
                    Expression.Default(typeof(StubObject)),
                    Expression.Parameter(typeof(StubObject))
                    )
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void BinaryExpressionShouldBeNotEqual_SameLeft_SameRight_DifferentConversion()
        {
            var x = Expression.Coalesce(
                Expression.Default(typeof(StubObject)),
                Expression.Default(typeof(StubObject)),
                Expression.Lambda(
                    Expression.Default(typeof(StubObject)),
                    Expression.Parameter(typeof(StubObject))
                )
            );
            var y = Expression.Coalesce(
                Expression.Default(typeof(StubObject)),
                Expression.Default(typeof(StubObject)),
                Expression.Lambda(
                    Expression.Parameter(typeof(StubObject)),
                    Expression.Parameter(typeof(StubObject))
                )
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void BinaryExpressionShouldBeEqual_SameLeft_SameRight_SameMethod_SameConversion()
        {
            var x = Expression.AddAssign(
                Expression.Variable(typeof(StubObject)),
                Expression.Default(typeof(StubObject)),
                Methods.Add<StubObject>(),
                Expression.Lambda(
                    Expression.Default(typeof(StubObject)),
                    Expression.Parameter(typeof(StubObject))
                )
            );
            var y = Expression.AddAssign(
                Expression.Variable(typeof(StubObject)),
                Expression.Default(typeof(StubObject)),
                Methods.Add<StubObject>(),
                Expression.Lambda(
                    Expression.Default(typeof(StubObject)),
                    Expression.Parameter(typeof(StubObject))
                )
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void BinaryExpressionShouldBeNotEqual_SameLeft_SameRight_SameMethod_DifferentConversion()
        {
            var x = Expression.AddAssign(
                Expression.Variable(typeof(StubObject)),
                Expression.Default(typeof(StubObject)),
                Methods.Add<StubObject>(),
                Expression.Lambda(
                    Expression.Default(typeof(StubObject)),
                    Expression.Parameter(typeof(StubObject))
                )
            );
            var y = Expression.AddAssign(
                Expression.Variable(typeof(StubObject)),
                Expression.Default(typeof(StubObject)),
                Methods.Add<StubObject>(),
                Expression.Lambda(
                    Expression.Parameter(typeof(StubObject)),
                    Expression.Parameter(typeof(StubObject))
                )
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void BinaryExpressionShouldBeNotEqual_DifferentLeft_DifferentRight_DifferentMethod_DifferentConversion()
        {
            var x = Expression.AddAssign(
                Expression.Variable(typeof(StubObject)),
                Expression.Default(typeof(StubObject)),
                Methods.Add<StubObject>(),
                Expression.Lambda(
                    Expression.Default(typeof(StubObject)),
                    Expression.Parameter(typeof(StubObject))
                )
            );
            var y = Expression.AddAssign(
                Expression.ArrayAccess(Expression.Default(typeof(StubObject[])), Expression.Default(typeof(int))),
                Expression.Parameter(typeof(StubObject)),
                Methods.Func<StubObject, StubObject, StubObject>(),
                Expression.Lambda(
                    Expression.Parameter(typeof(StubObject)),
                    Expression.Parameter(typeof(StubObject))
                )
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void BinaryExpressionShouldBeEqual_SameLeft_SameRight_SameLiftToNull_SameMethod()
        {
            var x = Expression.Equal(
                Expression.Default(typeof(int?)),
                Expression.Default(typeof(int?)),
                true,
                Methods.Equal<int>()
            );
            var y = Expression.Equal(
                Expression.Default(typeof(int?)),
                Expression.Default(typeof(int?)),
                true,
                Methods.Equal<int>()
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void BinaryExpressionShouldBeNotEqual_SameLeft_SameRight_DifferentLiftToNull_SameMethod()
        {
            var x = Expression.Equal(
                Expression.Default(typeof(int?)),
                Expression.Default(typeof(int?)),
                true,
                Methods.Func<int, int, bool>()
            );
            var y = Expression.Equal(
                Expression.Default(typeof(int?)),
                Expression.Default(typeof(int?)),
                false,
                Methods.Func<int, int, bool>()
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void BinaryExpressionShouldBeNotEqual_DifferentLeft_DifferentRight_DifferentLiftToNull_DifferentMethod()
        {
            var x = Expression.Equal(
                Expression.Default(typeof(int?)),
                Expression.Default(typeof(int?)),
                true,
                Methods.Equal<int>()
            );
            var y = Expression.Equal(
                Expression.Parameter(typeof(int?)),
                Expression.Parameter(typeof(int?)),
                false,
                Methods.Func<int, int, bool>()
            );

            AssertAreNotEqual(x, y);
        }
    }
}