using System;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit.UnitTests.Stubs
{
    internal static class StubExpression
    {
        private class ExtensionExpression : Expression
        {
            private readonly Func<Expression> _reducer;

            public ExtensionExpression(Type type, Func<Expression> reducer)
            {
                Type = type;
                _reducer = reducer;
            }

            public override ExpressionType NodeType => ExpressionType.Extension;

            public override Type Type { get; }

            public override bool CanReduce => true;

            public override Expression Reduce()
            {
                return _reducer();
            }
        }

        public static Expression Extension()
        {
            return Extension(Expression.Empty());
        }

        public static Expression Extension(Expression reduceExpression)
        {
            return Extension(reduceExpression.Type, () => reduceExpression);
        }

        public static Expression Extension(Type type, Func<Expression> reducer)
        {
            return new ExtensionExpression(type,reducer);
        }

        public static Expression Simple(int id)
        {
            return new SimpleExpression(id);
        }

        public static EqualityComparableExpression Comparable(int id)
        {
            return new EqualityComparableExpression(id);
        }
    }
}