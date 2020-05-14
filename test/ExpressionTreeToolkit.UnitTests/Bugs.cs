// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xunit;

namespace ExpressionTreeToolkit.UnitTests
{
    public class Bugs
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
        public void Issue_4()
        {
            // Expression similar to this code `try { } catch (Exception) { }`
            // Same expression twice to evade reference equality check
            var x = Expression.TryCatch(Expression.Empty(), Expression.Catch(typeof(Exception), Expression.Empty()));
            var y = Expression.TryCatch(Expression.Empty(), Expression.Catch(typeof(Exception), Expression.Empty()));

            AssertAreEqual(x, y);
        }
    }
}