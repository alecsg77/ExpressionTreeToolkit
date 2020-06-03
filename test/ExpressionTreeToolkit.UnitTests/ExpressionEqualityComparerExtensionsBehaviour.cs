﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

using Moq;

using Xunit;

namespace ExpressionTreeToolkit.UnitTests
{
    using Target = ExpressionEqualityComparerExtensions;

    public class ExpressionEqualityComparerExtensionsBehaviour
    {
        private readonly Mock<IEqualityComparer<Expression>> _mock;
        private readonly IEqualityComparer<Expression> _target;

        public ExpressionEqualityComparerExtensionsBehaviour()
        {
            _mock = new Mock<IEqualityComparer<Expression>>();
            _target = _mock.Object;
        }

        private void VerifyEquals<T1, T2>()
            where T1 : Expression
            where T2 : Expression
        {
            _mock.Verify(t => t.Equals(It.IsAny<T1>(), It.IsAny<T2>()), Times.Once);
        }

        [Fact]
        public void Equals1_Action()
        {
            var _ = Target.Equals(_target, () => Equals1_Action(), () => Equals1_Action());
            VerifyEquals<Expression<Action>, Expression<Action>>();
        }

        [Fact]
        public void Equals1_Func()
        {
            var _ = Target.Equals(_target, () => true, () => false);
            VerifyEquals<Expression<Func<bool>>, Expression<Func<bool>>>();
        }

        [Fact]
        public void Equals2_Action()
        {
            var _ = Target.Equals(_target, () => Equals2_Action(), Expression.Empty());
            VerifyEquals<Expression<Action>, DefaultExpression>();
        }

        [Fact]
        public void Equals2_Func()
        {
            var _ = Target.Equals(_target, () => true, Expression.Empty());
            VerifyEquals<Expression<Func<bool>>, DefaultExpression>();
        }

        [Fact]
        public void Equals3_Action()
        {
            var _ = Target.Equals(_target, Expression.Empty(), () => Equals3_Action());
            VerifyEquals<DefaultExpression, Expression<Action>>();
        }

        [Fact]
        public void Equals3_Func()
        {
            var _ = Target.Equals(_target, Expression.Empty(), () => false);
            VerifyEquals<DefaultExpression, Expression<Func<bool>>>();
        }

        private void VerifyGetHashCode<T>()
            where T : Expression
        {
            _mock.Verify(t => t.GetHashCode(It.IsAny<T>()), Times.Once);
        }

        [Fact]
        public void GetHashCode_Action()
        {
            var _ = Target.GetHashCode(_target, () => GetHashCode_Action());
            VerifyGetHashCode<Expression<Action>>();
        }

        [Fact]
        public void GetHashCode_Func()
        {
            var _ = Target.GetHashCode(_target, () => true);
            VerifyGetHashCode<Expression<Func<bool>>>();
        }
    }
}