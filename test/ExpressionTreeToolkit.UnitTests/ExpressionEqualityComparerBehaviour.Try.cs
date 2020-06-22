// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Linq.Expressions;

using ExpressionTreeToolkit.UnitTests.Stubs;

using Xunit;

namespace ExpressionTreeToolkit.UnitTests
{
    partial class ExpressionEqualityComparerBehaviour
    {
        [Fact]
        public void TryExpressionShouldBeEqual_SameTry_SameFinal()
        {
            var x = Expression.TryFinally(
                Expression.Empty(),
                Expression.Empty()
            );
            var y = Expression.TryFinally(
                Expression.Empty(),
                Expression.Empty()
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void TryExpressionShouldBeNotEqual_DifferentTry_SameFinal()
        {
            var x = Expression.TryFinally(
                Expression.Empty(),
                Expression.Empty()
            );
            var y = Expression.TryFinally(
                Expression.Label(Expression.Label()),
                Expression.Empty()
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void TryExpressionShouldBeNotEqual_SameTry_DifferentFinal()
        {
            var x = Expression.TryFinally(
                Expression.Empty(),
                Expression.Empty()
            );
            var y = Expression.TryFinally(
                Expression.Empty(),
                Expression.Label(Expression.Label())
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void TryExpressionShouldBeEqual_SameTry_SameFault()
        {
            var x = Expression.TryFault(
                Expression.Empty(),
                Expression.Empty()
            );
            var y = Expression.TryFault(
                Expression.Empty(),
                Expression.Empty()
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void TryExpressionShouldBeNotEqual_SameTry_DifferentFault()
        {
            var x = Expression.TryFault(
                Expression.Empty(),
                Expression.Empty()
            );
            var y = Expression.TryFault(
                Expression.Empty(),
                Expression.Label(Expression.Label())
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void TryExpressionShouldBeEqual_SameTry_SameCatchType_SameCatchBody()
        {
            var x = Expression.TryCatch(
                Expression.Empty(),
                Expression.Catch(
                    typeof(Exception),
                    Expression.Empty()
                )
            );
            var y = Expression.TryCatch(
                Expression.Empty(),
                Expression.Catch(
                    typeof(Exception),
                    Expression.Empty()
                )
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void TryExpressionShouldBeNotEqual_SameTry_SameCatchType_DifferentCatchBody()
        {
            var x = Expression.TryCatch(
                Expression.Empty(),
                Expression.Catch(
                    typeof(Exception),
                    Expression.Empty()
                )
            );
            var y = Expression.TryCatch(
                Expression.Empty(),
                Expression.Catch(
                    typeof(Exception),
                    Expression.Label(Expression.Label())
                )
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void TryExpressionShouldBeNotEqual_SameTry_DifferentCatchType_SameCatchBody()
        {
            var x = Expression.TryCatch(
                Expression.Empty(),
                Expression.Catch(
                    typeof(Exception),
                    Expression.Empty()
                )
            );
            var y = Expression.TryCatch(
                Expression.Empty(),
                Expression.Catch(
                    typeof(ApplicationException),
                    Expression.Empty()
                )
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void TryExpressionShouldBeEqual_SameTry_SameCatchType_SameCatchBody_SameCatchFilter()
        {
            var x = Expression.TryCatch(
                Expression.Empty(),
                Expression.Catch(
                    typeof(Exception),
                    Expression.Empty(),
                    Expression.Default(typeof(bool))
                )
            );
            var y = Expression.TryCatch(
                Expression.Empty(),
                Expression.Catch(
                    typeof(Exception),
                    Expression.Empty(),
                    Expression.Default(typeof(bool))
                )
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void TryExpressionShouldBeNotEqual_SameTry_SameCatchType_SameCatchBody_DifferentCatchFilter()
        {
            var x = Expression.TryCatch(
                Expression.Empty(),
                Expression.Catch(
                    typeof(Exception),
                    Expression.Empty(),
                    Expression.Default(typeof(bool))
                )
            );
            var y = Expression.TryCatch(
                Expression.Empty(),
                Expression.Catch(
                    typeof(Exception),
                    Expression.Empty(),
                    Expression.Constant(false, typeof(bool))
                )
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void TryExpressionShouldBeEqual_SameTry_SameCatchVariable_SameCatchBody_SameCatchFilter()
        {
            var x = Expression.TryCatch(
                Expression.Empty(),
                Expression.Catch(
                    Expression.Variable(typeof(Exception)),
                    Expression.Empty(),
                    Expression.Default(typeof(bool))
                )
            );
            var y = Expression.TryCatch(
                Expression.Empty(),
                Expression.Catch(
                    Expression.Variable(typeof(Exception)),
                    Expression.Empty(),
                    Expression.Default(typeof(bool))
                )
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void TryExpressionShouldBeNotEqual_SameTry_DifferentCatchVariable_SameCatchBody_SameCatchFilter()
        {
            var x = Expression.TryCatch(
                Expression.Empty(),
                Expression.Catch(
                    Expression.Variable(typeof(Exception)),
                    Expression.Empty(),
                    Expression.Default(typeof(bool))
                )
            );
            var y = Expression.TryCatch(
                Expression.Empty(),
                Expression.Catch(
                    Expression.Variable(typeof(ApplicationException)),
                    Expression.Empty(),
                    Expression.Default(typeof(bool))
                )
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void TryExpressionShouldBeEqual_SameType_SameTry_SameFinally()
        {
            var x = Expression.MakeTry(
                typeof(StubObject),
                StubObject.Expressions.Default,
                StubObject.Expressions.Default,
                null,
                null
            );
            var y = Expression.MakeTry(
                typeof(StubObject),
                StubObject.Expressions.Default,
                StubObject.Expressions.Default,
                null,
                null
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void TryExpressionShouldBeNotEqual_DifferentType_SameTry_SameFinally()
        {
            var x = Expression.MakeTry(
                typeof(StubObject),
                StubObject.Expressions.Default,
                StubObject.Expressions.Default,
                null,
                null
            );
            var y = Expression.MakeTry(
                typeof(object),
                StubObject.Expressions.Default,
                StubObject.Expressions.Default,
                null,
                null
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void TryExpressionShouldBeNotEqual_DifferentType_DifferentTry_DifferentFinally_DifferentCatchVariable_DifferentCatchBody_DifferentCatchFilter()
        {
            var x = Expression.MakeTry(
                typeof(void),
                Expression.Empty(),
                Expression.Empty(),
                null,
                new[]
                {
                    Expression.Catch(
                        Expression.Variable(typeof(Exception)),
                        Expression.Empty(),
                        Expression.Default(typeof(bool))
                    )
                }
            );
            var y = Expression.MakeTry(
                typeof(StubObject),
                StubObject.Expressions.Default,
                StubObject.Expressions.Default,
                null,
                new[]
                {
                    Expression.Catch(
                        Expression.Variable(typeof(ApplicationException)),
                        StubObject.Expressions.Default,
                        Expression.Constant(false,typeof(bool))
                    )
                }
            );

            AssertAreNotEqual(x, y);
        }

    }
}