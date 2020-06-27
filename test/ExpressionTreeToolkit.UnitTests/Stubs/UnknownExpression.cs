// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit.UnitTests.Stubs
{
    [ExcludeFromCodeCoverage]
    internal class UnknownExpression : Expression
    {
        public int Id { get; }

        public UnknownExpression(int id)
        {
            Id = id;
        }

        public override ExpressionType NodeType => (ExpressionType) (-1);
        public override Type Type => typeof(UnknownExpression);

        public static readonly IEqualityComparer<Expression> EqualityComparer = new ExpressionEqualityComparer();
        private sealed class ExpressionEqualityComparer : EqualityComparer<Expression>
        {
            public override bool Equals(Expression x, Expression y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (x is null || y is null) return false;

                if (x.GetType() != y.GetType()) return false;

                if (!(x.NodeType == y.NodeType && x.Type == y.Type))
                    return false;

                if ((x is UnknownExpression myExpressionX) && (y is UnknownExpression myExpressionY))
                    return myExpressionX.Id == myExpressionY.Id;

                throw new ArgumentException();
            }

            public override int GetHashCode(Expression obj)
            {
                if (obj == null) throw new ArgumentNullException(nameof(obj));

                if (obj is UnknownExpression expression)
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

    }
}