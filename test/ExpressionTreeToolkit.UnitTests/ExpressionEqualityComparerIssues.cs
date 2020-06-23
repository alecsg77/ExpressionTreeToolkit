// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using ExpressionTreeToolkit.UnitTests.Stubs;

using Xunit;

namespace ExpressionTreeToolkit.UnitTests
{
    [Collection("Issue")]
    public class ExpressionEqualityComparerIssues
    {
        [Fact]
        public void Issue_4_Catch_Without_Variable()
        {
            // Expression similar to this code `try { } catch (Exception) { }`
            // Same expression twice to evade reference equality check
            var x = Expression.TryCatch(Expression.Empty(), Expression.Catch(typeof(Exception), Expression.Empty()));
            var y = Expression.TryCatch(Expression.Empty(), Expression.Catch(typeof(Exception), Expression.Empty()));

            AssertExpressions.Equal(x, y);
        }

        [Fact]
        public void Issue_12_Equals_ListInit()
        {
            // Expressions similar to this code `new List<int> { 0|1 }`
            var x = Expression.ListInit(Expression.New(typeof(List<int>)), Expression.Constant(0));
            var y = Expression.ListInit(Expression.New(typeof(List<int>)), Expression.Constant(1));

            AssertExpressions.NotEqual(x, y);
        }

        [Fact]
        public void Issue_27_EqualityComparer_Ignored_Lambda_Body_Evaluation()
        {
            var target = new ExpressionEqualityComparer(UnknownExpression.EqualityComparer);
            var x = Expression.Lambda(StubExpression.Unknown(3));
            var y = Expression.Lambda(StubExpression.Unknown(3));
            AssertExpressions.Equal(x, y, target);
        }

        [Fact]
        public void Issue_21_Equals_Block_Swapped_Variables()
        {
            var var1X = Expression.Variable(typeof(int));
            var var2X = Expression.Variable(typeof(int));
            var x = Expression.Block(
                new[] {var1X, var2X},
                var1X,
                var2X
            );

            var var1Y = Expression.Variable(typeof(int));
            var var2Y = Expression.Variable(typeof(int));
            var y = Expression.Block(
                new[] {var1Y, var2Y},
                var2Y,
                var1Y
            );

            AssertExpressions.NotEqual(x, y);
        }

        [Fact]
        public void Issue_25_Nested_Lambda_Swapped_Parameters()
        {
            Expression<Func<int, int, Func<int>>> x = (a1, a2) => () => a1;
            Expression<Func<int, int, Func<int>>> y = (a1, a2) => () => a2;

            AssertExpressions.NotEqual(x,y);
        }

        [Fact]
        public void Issue_20_Equals_Block_Swapped_Labels()
        {
            var returnX = Expression.Label();
            var labelX = Expression.Label();
            var x = Expression.Block(
                Expression.Label(labelX),
                Expression.Goto(returnX),
                Expression.Label(returnX)
            );

            var returnY = Expression.Label();
            var labelY = Expression.Label();
            var y = Expression.Block(
                Expression.Label(labelY),
                Expression.Goto(labelY),
                Expression.Label(returnY)
            );

            AssertExpressions.NotEqual(x, y);
        }
    }
}