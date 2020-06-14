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
        public void IndexExpressionShouldBeEqual_SameArray_SameIndex()
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
        public void IndexExpressionShouldBeNotEqual_DifferentArray_SameIndex()
        {
            var x = Expression.ArrayIndex(
                Expression.Default(typeof(StubObject[])),
                Expression.Default(typeof(int))
            );
            var y = Expression.ArrayIndex(
                Expression.Constant(default(StubObject[]), typeof(StubObject[])),
                Expression.Default(typeof(int))
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void IndexExpressionShouldBeNotEqual_SameArray_DifferentIndex()
        {
            var x = Expression.ArrayIndex(
                Expression.Default(typeof(StubObject[])),
                Expression.Default(typeof(int))
            );
            var y = Expression.ArrayIndex(
                Expression.Default(typeof(StubObject[])),
                Expression.Constant(default(int), typeof(int))
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void IndexExpressionShouldBeNotEqual_DifferentArray_DifferentIndex()
        {
            var x = Expression.ArrayIndex(
                Expression.Default(typeof(StubObject[])),
                Expression.Default(typeof(int))
            );
            var y = Expression.ArrayIndex(
                Expression.Constant(default(StubObject[]), typeof(StubObject[])),
                Expression.Constant(default(int), typeof(int))
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void IndexExpressionShouldBeEqual_SameInstance_SameIndexer_SameArguments()
        {
            var x = Expression.Property(
                Expression.Default(typeof(StubCollection)),
                StubCollection.Properties.Item,
                Expression.Default(typeof(int))
            );
            var y = Expression.Property(
                Expression.Default(typeof(StubCollection)),
                StubCollection.Properties.Item,
                Expression.Default(typeof(int))
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void IndexExpressionShouldBeNotEqual_DifferentInstance_SameIndexer_SameArguments()
        {
            var x = Expression.Property(
                Expression.Default(typeof(StubCollection)),
                StubCollection.Properties.Item,
                Expression.Default(typeof(int))
            );
            var y = Expression.Property(
                Expression.Constant(default(StubCollection), typeof(StubCollection)),
                StubCollection.Properties.Item,
                Expression.Default(typeof(int))
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void IndexExpressionShouldBeNotEqual_SameInstance_DifferentIndexer_SameArguments()
        {
            var x = Expression.Property(
                Expression.Default(typeof(StubCollection)),
                StubCollection.Properties.Item,
                Expression.Default(typeof(int))
            );
            var y = Expression.Property(
                Expression.Default(typeof(StubCollection)),
                Members.Item<StubObject>(),
                Expression.Default(typeof(int))
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void IndexExpressionShouldBeNotEqual_SameInstance_SameIndexer_DifferentArguments()
        {
            var x = Expression.Property(
                Expression.Default(typeof(StubCollection)),
                StubCollection.Properties.Item,
                Expression.Default(typeof(int))
            );
            var y = Expression.Property(
                Expression.Default(typeof(StubCollection)),
                StubCollection.Properties.Item,
                Expression.Constant(default(int), typeof(int))
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void IndexExpressionShouldBeNotEqual_DifferentInstance_DifferentIndexer_DifferentArguments()
        {
            var x = Expression.Property(
                Expression.Default(typeof(StubCollection)),
                StubCollection.Properties.Item,
                Expression.Default(typeof(int))
            );
            var y = Expression.Property(
                Expression.Constant(default(StubCollection), typeof(StubCollection)),
                Members.Item<StubObject>(),
                Expression.Constant(default(int), typeof(int))
            );

            AssertAreNotEqual(x, y);
        }

    }
}