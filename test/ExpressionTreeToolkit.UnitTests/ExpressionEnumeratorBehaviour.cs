﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

using Moq;

using Xunit;

namespace ExpressionTreeToolkit.UnitTests
{
    public class ExpressionEnumeratorBehaviour
    {
        private static readonly CallSiteBinder CallSiteBinder = Mock.Of<CallSiteBinder>();

        private sealed class Stub : Expression
        {
            public static readonly Stub Extension = new Stub(ExpressionType.Extension);

            public static Stub StaticMethod() => Extension;

            public Stub()
                : this(ExpressionType.Extension)
            {
            }

            public Stub(ExpressionType nodeType)
            {
                this.NodeType = nodeType;
                Type = typeof(void);
            }

            public Stub(ExpressionType nodeType, Type type)
            {
                this.NodeType = nodeType;
                Type = type;
            }

            public override ExpressionType NodeType { get; }

            public override Type Type { get; }

            public Stub Parent { get; set; }
            public ICollection<Stub> Children { get; set; }

            public static readonly FieldInfo StaticFieldInfo = typeof(Stub).GetField(nameof(Extension));
            public static readonly MethodInfo StaticMethodInfo = typeof(Stub).GetMethod(nameof(StaticMethod));
            public static readonly ConstructorInfo CtorInfo = typeof(Stub).GetConstructor(Array.Empty<Type>());
            public static readonly ConstructorInfo CtorExpressionTypeInfo = typeof(Stub).GetConstructor(new[] { typeof(ExpressionType) });
            public static readonly ConstructorInfo CtorExpressionTypeTypeInfo = typeof(Stub).GetConstructor(new[] { typeof(ExpressionType), typeof(Type) });

            public static readonly PropertyInfo TypePropertyInfo = typeof(Stub).GetProperty(nameof(Type));
            public static readonly PropertyInfo ParentPropertyInfo = typeof(Stub).GetProperty(nameof(Parent));
            public static readonly PropertyInfo ChildrenPropertyInfo = typeof(Stub).GetProperty(nameof(Children));
            public static readonly MethodInfo ChildrenAddMethodInfo = typeof(ICollection<Stub>).GetMethod(nameof(ICollection<Stub>.Add), new[] { typeof(Stub) });

            public static readonly MethodInfo ReduceMethodInfo = typeof(Stub).GetMethod(nameof(Reduce));
            public static readonly MethodInfo DefaultMethodInfo = typeof(Expression).GetMethod(nameof(Default));
            public static readonly MethodInfo EqualsMethodInfo = typeof(Expression).GetMethod(nameof(Equals));

            public static readonly ConstructorInfo ListCtorInfo = typeof(List<Stub>).GetConstructor(Array.Empty<Type>());
        }

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

        private static void AssertEnumerateAs(Expression target, params Expression[] expected)
        {
            var actual = ExpressionExtensions.AsEnumerable(target);

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> InvariantExpressionNodes => new[]
        {
            new object[] {Expression.Constant(0)},
            new object[] {Expression.Parameter(typeof(int))},
            new object[] {Expression.DebugInfo(Expression.SymbolDocument(string.Empty),1,1,1,1)},
            new object[] {Stub.Extension},
            new object[] {Expression.Default(typeof(double))},
            new object[] {Expression.MakeMemberAccess(null, Stub.StaticFieldInfo)},
            new object[] {Expression.Call(null, Stub.StaticMethodInfo)},
            new object[] {Expression.New(Stub.CtorInfo)},
            new object[] {Expression.NewArrayInit(typeof(int))},
            new object[] {Expression.Goto(Expression.Label())},
            new object[] {Expression.Label(Expression.Label())},
            new object[] {Expression.RuntimeVariables()},
        };

        [Theory]
        [MemberData(nameof(InvariantExpressionNodes))]
        public void ExpressionShouldEnumerateAs_Expression(Expression expression)
        {
            Expression target = expression;
            AssertEnumerateAs(target, expression);
        }

        [Fact]
        public void UnaryExpressionShouldEnumerateAs_Operand_Unary()
        {
            var operand = Expression.Default(typeof(bool));
            var unary = Expression.Not(operand);

            Expression target = unary;

            AssertEnumerateAs(target, operand, unary);
        }

        [Fact]
        public void BinaryExpressionShouldEnumerateAs_Left_Right_Binary()
        {
            var left = Expression.Default(typeof(bool));
            var right = Expression.Default(typeof(bool));
            var and = Expression.And(left, right);

            Expression target = and;

            AssertEnumerateAs(target, left, right, and);
        }

        [Fact]
        public void TypeBinaryExpressionShouldEnumerateAs_Expression_TypeBinary()
        {
            var expression = Expression.Default(typeof(bool));
            var typeEqual = Expression.TypeEqual(expression, typeof(int));

            Expression target = typeEqual;

            AssertEnumerateAs(target, expression, typeEqual);
        }

        [Fact]
        public void ConditionalExpressionShouldEnumerateAs_Test_IfTrue_IfFalse_Conditional()
        {
            var test = Expression.Default(typeof(bool));
            var ifTrue = Expression.Default(typeof(int));
            var ifFalse = Expression.Default(typeof(int));
            var condition = Expression.Condition(test, ifTrue, ifFalse);

            Expression target = condition;

            AssertEnumerateAs(target, test, ifTrue, ifFalse, condition);
        }

        [Fact]
        public void MemberExpressionShouldEnumerateAs_Expression_Member()
        {
            var expression = Expression.Default(typeof(Stub));
            var member = Expression.MakeMemberAccess(expression, Stub.TypePropertyInfo);

            Expression target = member;

            AssertEnumerateAs(target, expression, member);
        }

        [Fact]
        public void MethodCallExpressionShouldEnumerateAs_Instance_MethodCall()
        {
            var instance = Expression.Default(typeof(Stub));
            var call = Expression.Call(instance, Stub.ReduceMethodInfo);

            Expression target = call;

            AssertEnumerateAs(target, instance, call);
        }

        [Fact]
        public void MethodCallExpressionShouldEnumerateAs_Args_MethodCall()
        {
            var argument = Expression.Default(typeof(Type));
            var call = Expression.Call(null, Stub.DefaultMethodInfo, argument);

            Expression target = call;

            AssertEnumerateAs(target, argument, call);
        }

        [Fact]
        public void MethodCallExpressionShouldEnumerateAs_Instance_Arguments_MethodCall()
        {
            var instance = Expression.Default(typeof(Stub));
            var argument = Expression.Default(typeof(Stub));
            var call = Expression.Call(instance, Stub.EqualsMethodInfo, argument);

            Expression target = call;

            AssertEnumerateAs(target, instance, argument, call);
        }

        [Fact]
        public void LambdaExpressionShouldEnumerateAs_Body_Lambda()
        {
            var body = Expression.Default(typeof(int));
            var lambda = Expression.Lambda(body);

            Expression target = lambda;

            AssertEnumerateAs(target, body, lambda);
        }

        [Fact]
        public void LambdaExpressionShouldEnumerateAs_Body_Params_Lambda()
        {
            var body = Expression.Default(typeof(int));
            var parameter = Expression.Parameter(typeof(string));
            var lambda = Expression.Lambda(body, parameter);

            Expression target = lambda;

            AssertEnumerateAs(target, body, parameter, lambda);
        }

        [Fact]
        public void NewExpressionShouldEnumerateAs_Arguments_New()
        {
            var argument = Expression.Default(typeof(ExpressionType));
            var @new = Expression.New(Stub.CtorExpressionTypeInfo, argument);

            Expression target = @new;

            AssertEnumerateAs(target, argument, @new);
        }

        [Fact]
        public void NewArrayExpressionShouldEnumerateAs_Initializers_NewArray()
        {
            var initializer = Expression.Default(typeof(int));
            var newArray = Expression.NewArrayInit(typeof(int), initializer);

            Expression target = newArray;

            AssertEnumerateAs(target, initializer, newArray);
        }

        [Fact]
        public void InvocationExpressionShouldEnumerateAs_Body_Lambda_Invocation()
        {
            var body = Expression.Empty();
            var lambda = Expression.Lambda(body);
            var invoke = Expression.Invoke(lambda);

            Expression target = invoke;

            AssertEnumerateAs(target, body, lambda, invoke);
        }

        [Fact]
        public void InvocationExpressionShouldEnumerateAs_Body_Params_Lambda_Args_Invocation()
        {
            var body = Expression.Empty();
            var parameter = Expression.Parameter(typeof(int));
            var lambda = Expression.Lambda(body, parameter);
            var argument = Expression.Default(typeof(int));
            var invoke = Expression.Invoke(lambda, argument);

            Expression target = invoke;

            AssertEnumerateAs(target, body, parameter, lambda, argument, invoke);
        }

        [Fact]
        public void MemberInitExpressionShouldEnumerateAs_New_MemberInit()
        {
            var newExpression = Expression.New(Stub.CtorInfo);
            var memberInit = Expression.MemberInit(newExpression);

            Expression target = memberInit;

            AssertEnumerateAs(target, newExpression, memberInit);
        }

        [Fact]
        public void MemberInitExpressionShouldEnumerateAs_New_MemberAssignments_MemberInit()
        {
            var newExpression = Expression.New(Stub.CtorInfo);
            var assignment = Expression.Default(typeof(Stub));
            var memberInit = Expression.MemberInit(newExpression,
                Expression.Bind(Stub.ParentPropertyInfo, assignment)
                );

            Expression target = memberInit;

            AssertEnumerateAs(target, newExpression, assignment, memberInit);
        }

        [Fact]
        public void MemberInitExpressionShouldEnumerateAs_New_MemberMemberBindings_MemberInit()
        {
            var newExpression = Expression.New(Stub.CtorInfo);
            var assignment = Expression.Default(typeof(Stub));
            var memberInit = Expression.MemberInit(newExpression,
                Expression.MemberBind(Stub.ParentPropertyInfo,
                    Expression.Bind(Stub.ParentPropertyInfo, assignment)
                    )
                );

            Expression target = memberInit;

            AssertEnumerateAs(target, newExpression, assignment, memberInit);
        }

        [Fact]
        public void MemberInitExpressionShouldEnumerateAs_New_MemberListBindings_MemberInit()
        {
            var newExpression = Expression.New(Stub.CtorInfo);
            var assignment = Expression.Default(typeof(Stub));
            var memberInit = Expression.MemberInit(newExpression,
                Expression.ListBind(Stub.ChildrenPropertyInfo,
                    Expression.ElementInit(Stub.ChildrenAddMethodInfo, assignment)
                    )
                );

            Expression target = memberInit;

            AssertEnumerateAs(target, newExpression, assignment, memberInit);
        }

        [Fact]
        public void ListInitExpressionShouldEnumerateAs_New_Initializers_ListInit()
        {
            var newExpression = Expression.New(Stub.ListCtorInfo);
            var initializer = Expression.Default(typeof(Stub));
            var listInit = Expression.ListInit(newExpression, initializer);

            Expression target = listInit;

            AssertEnumerateAs(target, newExpression, initializer, listInit);
        }

        [Fact]
        public void BlockExpressionShouldEnumerateAs_Expressions_Block()
        {
            var expression = Expression.Empty();
            var block = Expression.Block(expression);

            Expression target = block;

            AssertEnumerateAs(target, expression, block);
        }

        [Fact]
        public void BlockExpressionShouldEnumerateAs_Variables_Expressions_Block()
        {
            var variable = Expression.Parameter(typeof(bool));
            var expression = Expression.Empty();
            var block = Expression.Block(new[] { variable }, expression);

            Expression target = block;

            AssertEnumerateAs(target, variable, expression, block);
        }

        [Fact]
        public void DynamicExpressionShouldEnumerateAs_Arguments_Dynamic()
        {
            var argument = Expression.Default(typeof(int));
            var dynamic = Expression.Dynamic(CallSiteBinder, typeof(object), argument);

            Expression target = dynamic;

            AssertEnumerateAs(target, argument, dynamic);
        }

        [Fact]
        public void GotoExpressionShouldEnumerateAs_Value_Goto()
        {
            var value = Expression.Empty();
            var @goto = Expression.Goto(Expression.Label(), value);

            Expression target = @goto;

            AssertEnumerateAs(target, value, @goto);
        }

        [Fact]
        public void IndexExpressionShouldEnumerateAs_Instance_Arguments_Index()
        {
            var instance = Expression.Default(typeof(Stub[]));
            var argument = Expression.Default(typeof(int));
            var index = Expression.MakeIndex(instance, null, new[] { argument });

            Expression target = index;

            AssertEnumerateAs(target, instance, argument, index);
        }

        [Fact]
        public void LabelLabelExpressionShouldEnumerateAs_DefaultValue_Label()
        {
            var defaultValue = Expression.Default(typeof(int));
            var label = Expression.Label(Expression.Label(), defaultValue);

            Expression target = label;

            AssertEnumerateAs(target, defaultValue, label);
        }

        [Fact]
        public void RuntimeVariablesExpressionShouldEnumerateAs_Variables_RuntimeVariables()
        {
            var variable = Expression.Parameter(typeof(int));
            var runtimeVariables = Expression.RuntimeVariables(variable);

            Expression target = runtimeVariables;

            AssertEnumerateAs(target, variable, runtimeVariables);
        }

        [Fact]
        public void ShouldEnumerateIfNotLeftEqualRightThenOneElseTwoAs_Left_Right_Equal_Not_One_Two_IfThenElse()
        {
            var left = Expression.Variable(typeof(int));
            var right = Expression.Variable(typeof(int));
            var equal = Expression.Equal(left, right);
            var not = Expression.Not(equal);
            var one = Expression.Constant(1);
            var two = Expression.Constant(2);
            var ifThenElse = Expression.IfThenElse(not, one, two);

            Expression target = ifThenElse;

            AssertEnumerateAs(target, left, right, equal, not, one, two, ifThenElse);
        }

        [Fact]
        public void ShouldEnumerateTypeEqualCallInstanceMethodTypeOfParentOfStub_Instance_Stub_Parent_Type_Call_TypeEqual()
        {
            var stub = Expression.Default(typeof(Stub));
            var parent = Expression.MakeMemberAccess(stub, Stub.ParentPropertyInfo);
            var type = Expression.MakeMemberAccess(parent, Stub.TypePropertyInfo);

            var instance = Expression.Default(typeof(object));
            var call = Expression.Call(instance, Stub.EqualsMethodInfo, type);
            var typeEqual = Expression.TypeEqual(call, typeof(int));

            Expression target = typeEqual;

            AssertEnumerateAs(target, instance, stub, parent, type, call, typeEqual);
        }

        [Fact]
        public void ShouldEnumerateInvokeLambdaAs_Initializers_NewArray_Parameter_Lambda_Arguments_New_Invoke()
        {
            var initializer = Expression.Default(typeof(int));
            var newArray = Expression.NewArrayInit(typeof(int), initializer);
            var parameter = Expression.Parameter(typeof(Stub));
            var lambda = Expression.Lambda(newArray, parameter);

            var argument1 = Expression.Default(typeof(ExpressionType));
            var argument2 = Expression.Default(typeof(Type));
            var @new = Expression.New(Stub.CtorExpressionTypeTypeInfo, argument1, argument2);
            var invoke = Expression.Invoke(lambda, @new);

            Expression target = invoke;

            AssertEnumerateAs(target, initializer, newArray, parameter, lambda, argument1, argument2, @new, invoke);
        }

        [Fact]
        public void ShouldEnumerateBlockListInitAs_Variables_NewList_NewStubs_StubInits_ListInit_Block()
        {
            var variable1 = Expression.Parameter(typeof(Stub));
            var variable2 = Expression.Parameter(typeof(Stub));

            var newList = Expression.New(Stub.ListCtorInfo);

            var newStub1 = Expression.New(Stub.CtorInfo);
            var stub1Init = Expression.MemberInit(newStub1, Expression.Bind(Stub.ParentPropertyInfo, variable1));

            var newStub2 = Expression.New(Stub.CtorInfo);
            var stub2Init = Expression.MemberInit(newStub2,
                Expression.MemberBind(Stub.ParentPropertyInfo,
                    Expression.Bind(
                        Stub.ParentPropertyInfo, variable2
                        )
                    )
                );
            var newStub3 = Expression.New(Stub.CtorInfo);
            var stub3Init = Expression.MemberInit(newStub3,
                Expression.ListBind(Stub.ChildrenPropertyInfo,
                    Expression.ElementInit(Stub.ChildrenAddMethodInfo, stub2Init)
                    )
                );

            var listInit = Expression.ListInit(newList, stub1Init, stub3Init);

            var block = Expression.Block(new[] { variable1, variable2 }, listInit);

            Expression target = block;

            var expected = new Expression[]
            {
                variable1,
                variable2,
                    newList,

                        newStub1,
                        variable1,
                        stub1Init,

                        newStub3,
                            newStub2,
                            variable2,
                            stub2Init,
                        stub3Init,

                    listInit,
                block
            };

            AssertEnumerateAs(target, expected);
        }

        [Fact]
        public void ShouldEnumerateGotoDynamicLabelIndexAs_Instance_Arguments_Index_Label_Dynamic_Goto()
        {
            var labelTarget = Expression.Label(typeof(Stub));

            var instance = Expression.Default(typeof(Stub[]));
            var expression = Expression.Constant(0);
            var argument = Expression.Negate(expression);
            var index = Expression.MakeIndex(instance, null, new[] { argument });
            var label = Expression.Label(labelTarget, index);

            var dynamic = Expression.Dynamic(CallSiteBinder, typeof(Stub), label);

            var @goto = Expression.Goto(labelTarget, dynamic);

            Expression target = @goto;

            var expected = new Expression[]
            {
                instance,
                expression,
                argument,
                index,
                label,
                dynamic,
                @goto
            };

            AssertEnumerateAs(target, expected);
        }
    }
}
