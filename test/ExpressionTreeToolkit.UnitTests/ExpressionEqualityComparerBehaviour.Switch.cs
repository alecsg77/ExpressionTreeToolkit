// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Linq.Expressions;

using ExpressionTreeToolkit.UnitTests.Stubs;

using Xunit;

namespace ExpressionTreeToolkit.UnitTests
{
    partial class ExpressionEqualityComparerBehaviour
    {
#if NETFRAMEWORK != true
        [Fact]
        public void SwitchExpressionShouldBeEqual_SameSwitchValue()
        {
            var x = Expression.Switch(
                StubObject.Expressions.Default
            );
            var y = Expression.Switch(
                StubObject.Expressions.Default
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void SwitchExpressionShouldBeNotEqual_DifferentSwitchValue()
        {
            var x = Expression.Switch(
                StubObject.Expressions.Default
            );
            var y = Expression.Switch(
                StubObject.Expressions.Constant
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void SwitchExpressionShouldBeEqual_SameSwitchValue_SameDefaultCase()
        {
            var x = Expression.Switch(
                StubObject.Expressions.Default,
                Expression.Empty()
            );
            var y = Expression.Switch(
                StubObject.Expressions.Default,
                Expression.Empty()
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void SwitchExpressionShouldBeNotEqual_SameSwitchValue_DifferentDefaultCase()
        {
            var x = Expression.Switch(
                StubObject.Expressions.Default,
                Expression.Empty()
            );
            var y = Expression.Switch(
                StubObject.Expressions.Default,
                Expression.Label(Expression.Label())
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void SwitchExpressionShouldBeEqual_SameSwitchValue_SameDefaultCase_SameComparison()
        {
            var x = Expression.Switch(
                StubObject.Expressions.Default,
                Expression.Empty(),
                Methods.Equal<StubObject>()
            );
            var y = Expression.Switch(
                StubObject.Expressions.Default,
                Expression.Empty(),
                Methods.Equal<StubObject>()
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void SwitchExpressionShouldBeNotEqual_SameSwitchValue_SameDefaultCase_DifferentComparison()
        {
            var x = Expression.Switch(
                StubObject.Expressions.Default,
                Expression.Empty(),
                Methods.Equal<StubObject>()
            );
            var y = Expression.Switch(
                StubObject.Expressions.Default,
                Expression.Empty(),
                Methods.Func<StubObject,StubObject,bool>()
            );

            AssertAreNotEqual(x, y);
        }

#endif
        [Fact]
        public void SwitchExpressionShouldBeEqual_SameSwitchValue_SameSwitchCasesBody_SameSwitchCasesTestValues()
        {
            var x = Expression.Switch(
                StubObject.Expressions.Default,
                Expression.SwitchCase(
                    Expression.Empty(),
                    StubObject.Expressions.Default
                )
            );
            var y = Expression.Switch(
                StubObject.Expressions.Default,
                Expression.SwitchCase(
                    Expression.Empty(),
                    StubObject.Expressions.Default
                )
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void SwitchExpressionShouldBeNotEqual_SameSwitchValue_SameSwitchCasesBody_DifferentSwitchCasesTestValues()
        {
            var x = Expression.Switch(
                StubObject.Expressions.Default,
                Expression.SwitchCase(
                    Expression.Empty(),
                    StubObject.Expressions.Default
                    )
            );
            var y = Expression.Switch(
                StubObject.Expressions.Default,
                Expression.SwitchCase(
                    Expression.Empty(),
                    StubObject.Expressions.Constant
                )
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void SwitchExpressionShouldBeNotEqual_SameSwitchValue_DifferentSwitchCasesBody_SameSwitchCasesTestValues()
        {
            var x = Expression.Switch(
                StubObject.Expressions.Default,
                Expression.SwitchCase(
                    Expression.Empty(),
                    StubObject.Expressions.Default
                )
            );
            var y = Expression.Switch(
                StubObject.Expressions.Default,
                Expression.SwitchCase(
                    Expression.Label(Expression.Label()),
                    StubObject.Expressions.Default
                )
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void SwitchExpressionShouldBeNotEqual_SameSwitchValue_SameSwitchCasesBody_SameSwitchCasesTestValues_DifferentDefaultBody()
        {
            var x = Expression.Switch(
                StubObject.Expressions.Default,
                Expression.SwitchCase(
                    Expression.Empty(),
                    StubObject.Expressions.Default
                )
            );
            var y = Expression.Switch(
                StubObject.Expressions.Default,
                Expression.Empty(),
                Expression.SwitchCase(
                    Expression.Empty(),
                    StubObject.Expressions.Default
                )
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void SwitchExpressionShouldBeEqual_SameSwitchValue_SameComparison_SameSwitchCasesBody_SameSwitchCasesTestValues()
        {
            var x = Expression.Switch(
                StubObject.Expressions.Default,
                null,
                Methods.Equal<StubObject>(),
                Expression.SwitchCase(
                    Expression.Empty(),
                    StubObject.Expressions.Default
                )
            );
            var y = Expression.Switch(
                StubObject.Expressions.Default,
                null,
                Methods.Equal<StubObject>(),
                Expression.SwitchCase(
                    Expression.Empty(),
                    StubObject.Expressions.Default
                )
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void SwitchExpressionShouldBeNotEqual_SameSwitchValue_DifferentComparison_SameSwitchCasesBody_SameSwitchCasesTestValues()
        {
            var x = Expression.Switch(
                StubObject.Expressions.Default,
                null,
                Methods.Equal<StubObject>(),
                Expression.SwitchCase(
                    Expression.Empty(),
                    StubObject.Expressions.Default
                )
            );
            var y = Expression.Switch(
                StubObject.Expressions.Default,
                null,
                Methods.Func<StubObject,StubObject,bool>(),
                Expression.SwitchCase(
                    Expression.Empty(),
                    StubObject.Expressions.Default
                )
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void SwitchExpressionShouldBeEqual_SameSwitchValue_SameDefaultCase_SameComparison_SameSwitchCasesBody_SameSwitchCasesTestValues()
        {
            var x = Expression.Switch(
                StubObject.Expressions.Default,
                Expression.Empty(),
                Methods.Equal<StubObject>(),
                Expression.SwitchCase(
                    Expression.Empty(),
                    StubObject.Expressions.Default
                )
            );
            var y = Expression.Switch(
                StubObject.Expressions.Default,
                Expression.Empty(),
                Methods.Equal<StubObject>(),
                Expression.SwitchCase(
                    Expression.Empty(),
                    StubObject.Expressions.Default
                )
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void SwitchExpressionShouldBeNotEqual_DifferentSwitchValue_DifferentDefaultCase_DifferentComparison_DifferentSwitchCasesBody_DifferentSwitchCasesTestValues()
        {
            var x = Expression.Switch(
                StubObject.Expressions.Default,
                Expression.Empty(),
                Methods.Equal<StubObject>(),
                Expression.SwitchCase(
                    Expression.Empty(),
                    StubObject.Expressions.Default
                )
            );
            var y = Expression.Switch(
                StubObject.Expressions.Constant,
                Expression.Label(Expression.Label()),
                Methods.Func<StubObject,StubObject,bool>(),
                Expression.SwitchCase(
                    Expression.Label(Expression.Label()),
                    StubObject.Expressions.Constant
                )
            );

            AssertAreNotEqual(x, y);
        }

    }
}