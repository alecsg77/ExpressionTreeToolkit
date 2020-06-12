using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

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

        private sealed class ExtensionExpression : Expression
        {
            public override ExpressionType NodeType => ExpressionType.Extension;
            public override Type Type => typeof(void);

            public static readonly ExtensionExpression Void = new ExtensionExpression();
        }

        public static IEnumerable<object[]> ExpressionAsNodeData => new[]
        {
            new object[] {Expression.Constant(0)},
            new object[] {Expression.Parameter(typeof(int))},
            new object[] {Expression.DebugInfo(Expression.SymbolDocument(string.Empty),1,1,1,1)},
            new object[] {ExtensionExpression.Void},
            new object[] {Expression.Default(typeof(double))},
        };

        [Theory]
        [MemberData(nameof(ExpressionAsNodeData))]
        public void ShouldEnumerateExpressionAs_Node(Expression node)
        {
            var expected = new[] { node };

            var actual = ExpressionExtensions.AsEnumerable(node);

            Assert.Equal(expected, actual);
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

        [Fact]
        public void ShouldEnumerateLambdaExpressionAs_Body_Node()
        {
            var body = Expression.Default(typeof(int));
            var node = Expression.Lambda(body);
            var expected = new Expression[] { body, node };

            var actual = ExpressionExtensions.AsEnumerable(node);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldEnumerateLambdaExpressionAs_Body_Params_Node()
        {
            var body = Expression.Default(typeof(int));
            var parameter = Expression.Parameter(typeof(string));
            var node = Expression.Lambda(body, parameter);
            var expected = new Expression[] { body, parameter, node };

            var actual = ExpressionExtensions.AsEnumerable(node);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldEnumerateNewExpressionAs_Node()
        {
            var constructor = typeof(Exception).GetConstructor(Array.Empty<Type>());
            var node = Expression.New(constructor);
            var expected = new Expression[] { node };

            var actual = ExpressionExtensions.AsEnumerable(node);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldEnumerateNewExpressionAs_Arguments_Node()
        {
            var constructor = typeof(Exception).GetConstructor(new[] { typeof(string), typeof(Exception) });
            var argument1 = Expression.Default(typeof(string));
            var argument2 = Expression.Default(typeof(Exception));
            var node = Expression.New(constructor, argument1, argument2);
            var expected = new Expression[] { argument1, argument2, node };

            var actual = ExpressionExtensions.AsEnumerable(node);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldEnumerateNewArrayExpressionAs_Node()
        {
            var node = Expression.NewArrayInit(typeof(int));
            var expected = new Expression[] { node };

            var actual = ExpressionExtensions.AsEnumerable(node);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldEnumerateNewArrayExpressionAs_Initializers_Node()
        {
            var initializer = Expression.Default(typeof(int));
            var node = Expression.NewArrayInit(typeof(int), initializer);
            var expected = new Expression[] { initializer, node };

            var actual = ExpressionExtensions.AsEnumerable(node);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldEnumerateInvocationExpressionAs_Body_Lambda_Node()
        {
            var body = Expression.Empty();
            var lambda = Expression.Lambda(body);

            var node = Expression.Invoke(lambda);
            var expected = new Expression[] { body, lambda, node };

            var actual = ExpressionExtensions.AsEnumerable(node);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldEnumerateInvocationExpressionAs_Body_Params_Lambda_Args_Node()
        {
            var body = Expression.Empty();
            var parameter = Expression.Parameter(typeof(int));
            var lambda = Expression.Lambda(body, parameter);

            var argument = Expression.Default(typeof(int));
            var node = Expression.Invoke(lambda, argument);

            var expected = new Expression[] { body, parameter, lambda, argument, node };

            var actual = ExpressionExtensions.AsEnumerable(node);

            Assert.Equal(expected, actual);
        }


        class Node
        {
            public Node()
            {
            }

            public Node(string name)
            {
            }
            public string Name { get; set; }
            public Node Parent { get; set; }
            public ICollection<Node> Children { get; set; }
        }


        [Fact]
        public void ShouldEnumerateMemberInitExpression_Arguments_New_Node()
        {
            var constructor = typeof(Node).GetConstructor(new[] { typeof(string) });
            var argument1 = Expression.Default(typeof(string));
            var newExpression = Expression.New(constructor, argument1);
            var node = Expression.MemberInit(newExpression);

            var expected = new Expression[] { argument1, newExpression, node };

            var actual = ExpressionExtensions.AsEnumerable(node);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldEnumerateMemberInitExpression_New_MemberAssignments_Node()
        {
            var constructor = typeof(Node).GetConstructor(Array.Empty<Type>());
            var nameProperty = typeof(Node).GetProperty(nameof(Node.Name));
            var newExpression = Expression.New(constructor);
            var assignment = Expression.Default(typeof(string));
            var node = Expression.MemberInit(newExpression, Expression.Bind(nameProperty, assignment));

            var expected = new Expression[] { newExpression, assignment, node };

            var actual = ExpressionExtensions.AsEnumerable(node);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldEnumerateMemberInitExpression_Arguments_New_MemberMemberBindings_Node()
        {
            var constructor = typeof(Node).GetConstructor(Array.Empty<Type>());
            var parentProperty = typeof(Node).GetProperty(nameof(Node.Parent));
            var nameProperty = typeof(Node).GetProperty(nameof(Node.Name));

            var newExpression = Expression.New(constructor);
            var assignment = Expression.Default(typeof(string));
            var node = Expression.MemberInit(newExpression, Expression.MemberBind(parentProperty, Expression.Bind(nameProperty, assignment)));

            var expected = new Expression[] { newExpression, assignment, node };

            var actual = ExpressionExtensions.AsEnumerable(node);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldEnumerateMemberInitExpression_Arguments_New_MemberListBindings_Node()
        {
            var constructor = typeof(Node).GetConstructor(Array.Empty<Type>());
            var childrenProperty = typeof(Node).GetProperty(nameof(Node.Children));
            var addMethod = typeof(ICollection<Node>).GetMethod(nameof(ICollection<Node>.Add), new[] { typeof(Node) });

            var newExpression = Expression.New(constructor);
            var assignment = Expression.Default(typeof(Node));
            var node = Expression.MemberInit(newExpression, Expression.ListBind(childrenProperty, Expression.ElementInit(addMethod, assignment)));

            var expected = new Expression[] { newExpression, assignment, node };

            var actual = ExpressionExtensions.AsEnumerable(node);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldEnumerateListInitExpression_New_Initializers_Node()
        {
            var constructor = typeof(List<int>).GetConstructor(Array.Empty<Type>());
            var newExpression = Expression.New(constructor);
            var initializer = Expression.Default(typeof(int));
            var node = Expression.ListInit(newExpression, initializer);

            var expected = new Expression[] { newExpression, initializer, node };

            var actual = ExpressionExtensions.AsEnumerable(node);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldEnumerateBlockExpression_Expressions_Node()
        {
            var expression = Expression.Empty();
            var node = Expression.Block(expression);

            var expected = new Expression[] { expression, node };

            var actual = ExpressionExtensions.AsEnumerable(node);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldEnumerateBlockExpression_Variables_Expressions_Node()
        {
            var variable = Expression.Parameter(typeof(bool));
            var expression = Expression.Empty();
            var node = Expression.Block(new[] { variable }, expression);

            var expected = new Expression[] { variable, expression, node };

            var actual = ExpressionExtensions.AsEnumerable(node);

            Assert.Equal(expected, actual);
        }

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

        [Fact]
        public void ShouldEnumerateInvokeLambdaAs_Initializers_NewArray_Parameter_Lambda_Arguments_New_Invoke()
        {
            var constructor = typeof(Exception).GetConstructor(new[] { typeof(string), typeof(Exception) });

            var initializer = Expression.Default(typeof(int));
            var newArray = Expression.NewArrayInit(typeof(int), initializer);
            var parameter = Expression.Parameter(typeof(Exception));
            var lambda = Expression.Lambda(newArray, parameter);

            var argument1 = Expression.Default(typeof(string));
            var argument2 = Expression.Default(typeof(Exception));
            var @new = Expression.New(constructor, argument1, argument2);
            var invoke = Expression.Invoke(lambda, @new);

            var expected = new Expression[] { initializer, newArray, parameter, lambda, argument1, argument2, @new, invoke };

            var actual = ExpressionExtensions.AsEnumerable(invoke);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldEnumerateBlockListInitAs_Variables_NewList_NewNode_NodeInit_ListInit_Block()
        {
            var nodeConstructor = typeof(Node).GetConstructor(Array.Empty<Type>());
            var nameProperty = typeof(Node).GetProperty(nameof(Node.Name));
            var parentProperty = typeof(Node).GetProperty(nameof(Node.Parent));
            var childrenProperty = typeof(Node).GetProperty(nameof(Node.Children));
            var addMethod = typeof(ICollection<Node>).GetMethod(nameof(ICollection<Node>.Add), new[] { typeof(Node) });
            var listConstructor = typeof(List<Node>).GetConstructor(Array.Empty<Type>());

            var variable1 = Expression.Parameter(typeof(string));
            var variable2 = Expression.Parameter(typeof(string));

                var newList = Expression.New(listConstructor);

                    var newNode1 = Expression.New(nodeConstructor);
                    var node1Init = Expression.MemberInit(newNode1, Expression.Bind(nameProperty, variable1));

                    var newNode3 = Expression.New(nodeConstructor);
                        var newNode2 = Expression.New(nodeConstructor);
                        var node2Init = Expression.MemberInit(newNode2, Expression.MemberBind(parentProperty, Expression.Bind(nameProperty, variable2)));
                    var node3Init = Expression.MemberInit(newNode3, Expression.ListBind(childrenProperty, Expression.ElementInit(addMethod, node2Init)));

                var listInit = Expression.ListInit(newList, node1Init, node3Init);

            var block = Expression.Block(new[] { variable1, variable2 }, listInit);

            var expected = new Expression[]
            {
                variable1,
                variable2,
                    newList,

                        newNode1,
                        variable1,
                        node1Init,

                        newNode3,
                            newNode2,
                            variable2,
                            node2Init,
                        node3Init,

                    listInit,
                block
            };

            var actual = ExpressionExtensions.AsEnumerable(block);

            Assert.Equal(expected, actual);
        }
    }

}
