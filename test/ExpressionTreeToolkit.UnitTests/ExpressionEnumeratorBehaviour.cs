using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using Xunit;

namespace ExpressionTreeToolkit.UnitTests
{
    public class ExpressionEnumeratorBehaviour
    {
        [Fact]
        public void ShouldThrowArgumentNullExceptionOnNull()
        {
            Assert.Throws<ArgumentNullException>(() => ExpressionExtensions.AsEnumerable(null));
        }

        [Fact]
        public void ShouldReturnEnumerableOnExpression()
        {
            var source = Expression.Empty();
            var actual = ExpressionExtensions.AsEnumerable(source);
            Assert.IsAssignableFrom<IEnumerable<Expression>>(actual);
        }

        [Fact]
        public void ShouldMoveNextOnExpression()
        {
            var source = Expression.Empty();
            using (var actual = ExpressionExtensions.AsEnumerable(source).GetEnumerator())
            {
                Assert.True(actual.MoveNext());
            }
        }

        [Fact]
        public void ShouldCurrentBeTheSameAsSource()
        {
            var source = Expression.Empty();
            using (var actual = ExpressionExtensions.AsEnumerable(source).GetEnumerator())
            {
                actual.MoveNext();
                Assert.Same(source, actual.Current);
            }
        }

        [Fact]
        public void ShouldEnumerateUnaryExpressionAs_Operand_Node()
        {
            var operand = Expression.Default(typeof(bool));
            var node = Expression.Not(operand);
            var expected = new Expression[] { operand, node };

            var actual = ExpressionExtensions.AsEnumerable(node);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldEnumerateBinaryExpressionAs_Left_Right_Node()
        {
            var left = Expression.Default(typeof(bool));
            var right = Expression.Default(typeof(bool));
            var node = Expression.And(left, right);
            var expected = new Expression[] { left, right, node };

            var actual = ExpressionExtensions.AsEnumerable(node);

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void ShouldEnumerateTypeBinaryExpressionAs_Expression_Node()
        {
            var expression = Expression.Default(typeof(bool));
            var node = Expression.TypeEqual(expression, typeof(int));
            var expected = new Expression[] { expression, node };

            var actual = ExpressionExtensions.AsEnumerable(node);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldEnumerateConditionalExpressionAs_Test_IfTrue_IfFalse_Node()
        {
            var test = Expression.Default(typeof(bool));
            var ifTrue = Expression.Default(typeof(int));
            var ifFalse = Expression.Default(typeof(int));
            var node = Expression.Condition(test, ifTrue, ifFalse);
            var expected = new Expression[] { test, ifTrue, ifFalse, node };

            var actual = ExpressionExtensions.AsEnumerable(node);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldEnumerateConstantExpressionAs_TNode()
        {
            var node = Expression.Constant(0);
            var expected = new Expression[] { node };

            var actual = ExpressionExtensions.AsEnumerable(node);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldEnumerateParameterExpressionAs_TNode()
        {
            var node = Expression.Parameter(typeof(int));
            var expected = new Expression[] { node };

            var actual = ExpressionExtensions.AsEnumerable(node);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldEnumerateMemberExpressionAs_Node()
        {
            var memberInfo = typeof(int).GetField(nameof(int.MinValue));
            var node = Expression.MakeMemberAccess(null, memberInfo);
            var expected = new Expression[] { node };

            var actual = ExpressionExtensions.AsEnumerable(node);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldEnumerateMemberExpressionAs_Expression_Node()
        {
            var expression = Expression.Default(typeof(Expression));
            var propertyInfo = typeof(Expression).GetProperty(nameof(Expression.NodeType));
            var node = Expression.MakeMemberAccess(expression, propertyInfo);
            var expected = new Expression[] { expression, node };

            var actual = ExpressionExtensions.AsEnumerable(node);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldEnumerateMethodCallExpressionAs_Node()
        {
            var methodInfo = typeof(Expression).GetMethod(nameof(Expression.Empty));
            var node = Expression.Call(null, methodInfo);
            var expected = new Expression[] { node };

            var actual = ExpressionExtensions.AsEnumerable(node);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldEnumerateMethodCallExpressionAs_Object_Node()
        {
            var @object = Expression.Default(typeof(Expression));
            var methodInfo = typeof(Expression).GetMethod(nameof(Expression.Reduce));
            var node = Expression.Call(@object, methodInfo);
            var expected = new Expression[] { @object, node };

            var actual = ExpressionExtensions.AsEnumerable(node);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldEnumerateMethodCallExpressionAs_Args_Node()
        {
            var methodInfo = typeof(Expression).GetMethod(nameof(Expression.ReferenceEqual));
            var arg0 = Expression.Default(typeof(Expression));
            var arg1 = Expression.Default(typeof(Expression));
            var node = Expression.Call(null, methodInfo, arg0, arg1);
            var expected = new Expression[] { arg0, arg1, node };

            var actual = ExpressionExtensions.AsEnumerable(node);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldEnumerateMethodCallExpressionAs_Object_Args_Node()
        {
            var @object = Expression.Default(typeof(Expression));
            var methodInfo = typeof(Expression).GetMethod(nameof(Expression.Equals));
            var arg0 = Expression.Default(typeof(Expression));
            var node = Expression.Call(@object, methodInfo, arg0);
            var expected = new Expression[] { @object, arg0, node };

            var actual = ExpressionExtensions.AsEnumerable(node);

            Assert.Equal(expected, actual);
        }

        // TODO Complete the single node test cases

        [Fact]
        public void ShouldEnumerateIfNotAEqualBThenOneElseTwoAs_A_B_Equal_Not_1_2_IfThenElse()
        {
            var a = Expression.Variable(typeof(int), "a");
            var b = Expression.Variable(typeof(int), "b");
            var equal = Expression.Equal(a, b);
            var not = Expression.Not(equal);
            var one = Expression.Constant(1);
            var two = Expression.Constant(2);
            var ifThenElse = Expression.IfThenElse(not, one, two);
            var expected = new Expression[] { a, b, equal, not, one, two, ifThenElse };

            var actual = ExpressionExtensions.AsEnumerable(ifThenElse);

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void ShouldEnumerateStringPadLeftDateTimeDateDayIsIntAs_String_DateTime_Date_Day_PadLeft_TypeEqual()
        {
            var dateProperty = typeof(DateTime).GetProperty(nameof(DateTime.Date));
            var dayProperty = typeof(DateTime).GetProperty(nameof(DateTime.Day));
            var padLeftMethod = typeof(String).GetMethod(nameof(String.PadLeft), new[] { typeof(int) });

            var dateTime = Expression.Default(typeof(DateTime));
            var date = Expression.MakeMemberAccess(dateTime, dateProperty);
            var day = Expression.MakeMemberAccess(date, dayProperty);

            var @string = Expression.Default(typeof(String));
            var padLeft = Expression.Call(@string, padLeftMethod, day);
            var typeEqual = Expression.TypeEqual(padLeft, typeof(int));
            var expected = new Expression[] { @string, dateTime, date, day, padLeft, typeEqual };

            var actual = ExpressionExtensions.AsEnumerable(typeEqual);

            Assert.Equal(expected, actual);
        }
    }

}
