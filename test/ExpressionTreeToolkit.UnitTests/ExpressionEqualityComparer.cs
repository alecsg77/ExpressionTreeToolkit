// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit.UnitTests
{
    public abstract class ExpressionEqualityComparer<T> : EqualityComparer<Expression>
        where T : Expression
    {
        private readonly IEqualityComparer<Expression> _equalityComparer;

        protected ExpressionEqualityComparer()
            : this(null)
        {
        }

        protected ExpressionEqualityComparer(IEqualityComparer<Expression> equalityComparer)
        {
            _equalityComparer = equalityComparer ?? Default;
        }

        protected abstract bool EqualsExpression(T x, T y);
        protected abstract int GetHashCodeExpression(T obj);

        public override bool Equals(Expression x, Expression y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null) return false;

            if (x.GetType() != y.GetType()) return false;

            if (!(x.NodeType == y.NodeType && x.Type == y.Type))
                return false;

            if ((x is T expressionX) && (y is T expressionY))
                return EqualsExpression(expressionX, expressionY);

            return _equalityComparer.Equals(x, y);
        }

        public override int GetHashCode(Expression obj)
        {
            if (obj == null) return 0;
            if (obj is T expression)
            {
                return GetHashCodeExpression(expression);
            }

            return _equalityComparer.GetHashCode(obj);
        }
    }
}