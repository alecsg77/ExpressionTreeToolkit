// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

using Xunit;

namespace ExpressionTreeToolkit.UnitTests
{
    partial class ExpressionEqualityComparerBehaviour
    {
        [Fact]
        public void IEqualityComparer_ShouldThrowArgumentExceptionEqual_Expression_NotExpression()
        {
            Assert.Throws<ArgumentException>(IEqualityComparer_Equal_Expression_NotExpression);
        }

        [ExcludeFromCodeCoverage]
        private void IEqualityComparer_Equal_Expression_NotExpression()
        {
            System.Collections.IEqualityComparer target = _target;
            target.Equals(Expression.Empty(), 5);
        }

        [Fact]
        public void IEqualityComparer_ShouldThrowArgumentExceptionEqual_NotExpression_Expression()
        {
            Assert.Throws<ArgumentException>(IEqualityComparer_Equal_NotExpression_Expression);
        }

        [ExcludeFromCodeCoverage]
        private void IEqualityComparer_Equal_NotExpression_Expression()
        {
            System.Collections.IEqualityComparer target = _target;
            target.Equals(5, Expression.Empty());
        }

        [Fact]
        public void IEqualityComparer_ShouldThrowArgumentExceptionGetHashCode_NotExpression()
        {
            Assert.Throws<ArgumentException>(IEqualityComparer_GetHashCode_NotExpression);
        }

        [ExcludeFromCodeCoverage]
        private void IEqualityComparer_GetHashCode_NotExpression()
        {
            System.Collections.IEqualityComparer target = _target;
            target.GetHashCode(5);
        }

        [Fact]
        public void IEqualityComparer_ShouldThrowArgumentNullExceptionGetHashCode_Null()
        {
            Assert.Throws<ArgumentNullException>(IEqualityComparer_GetHashCode_Null);
        }

        [ExcludeFromCodeCoverage]
        private void IEqualityComparer_GetHashCode_Null()
        {
            System.Collections.IEqualityComparer target = _target;
            target.GetHashCode(null);
        }
    }
}