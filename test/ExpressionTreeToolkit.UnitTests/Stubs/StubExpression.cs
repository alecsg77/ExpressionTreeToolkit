using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit.UnitTests.Stubs
{
    [ExcludeFromCodeCoverage]
    internal static class StubExpression
    {
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
            return new ExtensionExpression(type, reducer);
        }

        public static Expression Unknown(int id)
        {
            return new UnknownExpression(id);
        }

        public static EqualityComparableExpression Comparable(int id)
        {
            return new EqualityComparableExpression(id);
        }
    }
}