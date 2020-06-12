using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#if JETBRAINS_ANNOTATIONS
using AllowNullAttribute = JetBrains.Annotations.CanBeNullAttribute;
using DisallowNullAttribute = JetBrains.Annotations.NotNullAttribute;
using AllowItemNullAttribute = JetBrains.Annotations.ItemCanBeNullAttribute;
#endif

namespace ExpressionTreeToolkit
{
    public static partial class ExpressionExtensions
    {
        public static IEnumerable<Expression> AsEnumerable([DisallowNull] this Expression source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return ExpressionIterator(source);
        }

        private static IEnumerable<Expression> ExpressionIterator([DisallowNull] Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            switch (expression.NodeType)
            {
                case ExpressionType.Negate:
                case ExpressionType.NegateChecked:
                case ExpressionType.Not:
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                case ExpressionType.ArrayLength:
                case ExpressionType.Quote:
                case ExpressionType.TypeAs:
                case ExpressionType.UnaryPlus:
                case ExpressionType.PreIncrementAssign:
                case ExpressionType.PreDecrementAssign:
                case ExpressionType.PostIncrementAssign:
                case ExpressionType.PostDecrementAssign:
                case ExpressionType.IsTrue:
                case ExpressionType.IsFalse:
                case ExpressionType.OnesComplement:
                case ExpressionType.Decrement:
                case ExpressionType.Increment:
                case ExpressionType.Throw:
                case ExpressionType.Unbox:
                    return UnaryIterator((UnaryExpression) expression);
                case ExpressionType.Add:
                case ExpressionType.AddChecked:
                case ExpressionType.Subtract:
                case ExpressionType.SubtractChecked:
                case ExpressionType.Multiply:
                case ExpressionType.MultiplyChecked:
                case ExpressionType.Divide:
                case ExpressionType.Modulo:
                case ExpressionType.And:
                case ExpressionType.AndAlso:
                case ExpressionType.Or:
                case ExpressionType.OrElse:
                case ExpressionType.LessThan:
                case ExpressionType.LessThanOrEqual:
                case ExpressionType.GreaterThan:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.Equal:
                case ExpressionType.NotEqual:
                case ExpressionType.Coalesce:
                case ExpressionType.ArrayIndex:
                case ExpressionType.RightShift:
                case ExpressionType.LeftShift:
                case ExpressionType.ExclusiveOr:
                case ExpressionType.Power:
                case ExpressionType.Assign:
                case ExpressionType.AddAssign:
                case ExpressionType.AndAssign:
                case ExpressionType.DivideAssign:
                case ExpressionType.ExclusiveOrAssign:
                case ExpressionType.LeftShiftAssign:
                case ExpressionType.ModuloAssign:
                case ExpressionType.MultiplyAssign:
                case ExpressionType.OrAssign:
                case ExpressionType.PowerAssign:
                case ExpressionType.RightShiftAssign:
                case ExpressionType.SubtractAssign:
                case ExpressionType.AddAssignChecked:
                case ExpressionType.MultiplyAssignChecked:
                case ExpressionType.SubtractAssignChecked:
                    return BinaryIterator((BinaryExpression) expression);
                case ExpressionType.TypeIs:
                case ExpressionType.TypeEqual:
                    return TypeBinaryIterator((TypeBinaryExpression) expression);
                case ExpressionType.Conditional:
                    return ConditionalIterator((ConditionalExpression) expression);
                case ExpressionType.MemberAccess:
                    return MemberIterator((MemberExpression) expression);
                case ExpressionType.Call:
                    return MethodCallIterator((MethodCallExpression) expression);
                case ExpressionType.Lambda:
                    return LambdaIterator((LambdaExpression) expression);
                case ExpressionType.New:
                    return NewIterator((NewExpression) expression);
                case ExpressionType.NewArrayInit:
                case ExpressionType.NewArrayBounds:
                    return NewArrayIterator((NewArrayExpression) expression);
                case ExpressionType.Invoke:
                    return InvocationIterator((InvocationExpression) expression);
                case ExpressionType.MemberInit:
                    return MemberInitIterator((MemberInitExpression) expression);
                case ExpressionType.ListInit:
                    return ListInitIterator((ListInitExpression) expression);
                case ExpressionType.Block:
                    return BlockIterator((BlockExpression) expression);
                case ExpressionType.Dynamic:
                    return DynamicIterator((DynamicExpression) expression);
                case ExpressionType.Goto:
                    return GotoIterator((GotoExpression) expression);
                case ExpressionType.Index:
                    return IndexIterator((IndexExpression) expression);
                case ExpressionType.Label:
                    return LabelIterator((LabelExpression) expression);
                case ExpressionType.RuntimeVariables:
                    return RuntimeVariablesIterator((RuntimeVariablesExpression) expression);
                case ExpressionType.Loop:
                    return LoopIterator((LoopExpression) expression);
                case ExpressionType.Switch:
                    return SwitchIterator((SwitchExpression) expression);
                case ExpressionType.Try:
                    return TryIterator((TryExpression) expression);
                case ExpressionType.Constant:
                case ExpressionType.Parameter:
                case ExpressionType.DebugInfo:
                case ExpressionType.Extension:
                case ExpressionType.Default:
                default:
                    return new[] {expression};
            }
        }

        private static IEnumerable<Expression> UnaryIterator(UnaryExpression expression)
        {
            foreach (var operand in ExpressionIterator(expression.Operand))
            {
                yield return operand;
            }

            yield return expression;
        }

        private static IEnumerable<Expression> BinaryIterator(BinaryExpression expression)
        {
            foreach (var left in ExpressionIterator(expression.Left))
            {
                yield return left;
            }

            foreach (var right in ExpressionIterator(expression.Right))
            {
                yield return right;
            }

            yield return expression;
        }

        private static IEnumerable<Expression> TypeBinaryIterator(TypeBinaryExpression expression)
        {
            foreach (var subExpression in ExpressionIterator(expression.Expression))
            {
                yield return subExpression;
            }

            yield return expression;
        }

        private static IEnumerable<Expression> ConditionalIterator(ConditionalExpression expression)
        {
            foreach (var test in ExpressionIterator(expression.Test))
            {
                yield return test;
            }

            foreach (var ifTrue in ExpressionIterator(expression.IfTrue))
            {
                yield return ifTrue;
            }

            foreach (var ifFalse in ExpressionIterator(expression.IfFalse))
            {
                yield return ifFalse;
            }

            yield return expression;
        }

        private static IEnumerable<Expression> MemberIterator(MemberExpression expression)
        {
            if (expression.Expression != null)
            {
                foreach (var subExpression in ExpressionIterator(expression.Expression))
                {
                    yield return subExpression;
                }
            }

            yield return expression;
        }

        private static IEnumerable<Expression> MethodCallIterator(MethodCallExpression expression)
        {
            if (expression.Object != null)
            {
                foreach (var obj in ExpressionIterator(expression.Object))
                {
                    yield return obj;
                }
            }

            foreach (var argument in expression.Arguments.SelectMany(ExpressionIterator))
            {
                yield return argument;
            }

            yield return expression;
        }

        private static IEnumerable<Expression> LambdaIterator(LambdaExpression expression)
        {
            foreach (var body in ExpressionIterator(expression.Body))
            {
                yield return body;
            }

            foreach (var parameter in expression.Parameters.SelectMany(ExpressionIterator))
            {
                yield return parameter;
            }

            yield return expression;
        }

        private static IEnumerable<Expression> NewIterator(NewExpression expression)
        {
            foreach (var parameter in expression.Arguments.SelectMany(ExpressionIterator))
            {
                yield return parameter;
            }

            yield return expression;
        }

        private static IEnumerable<Expression> NewArrayIterator(NewArrayExpression expression)
        {
            foreach (var expr in expression.Expressions.SelectMany(ExpressionIterator))
            {
                yield return expr;
            }

            yield return expression;
        }

        private static IEnumerable<Expression> InvocationIterator(InvocationExpression expression)
        {
            foreach (var subExpression in ExpressionIterator(expression.Expression))
            {
                yield return subExpression;
            }

            foreach (var parameter in expression.Arguments.SelectMany(ExpressionIterator))
            {
                yield return parameter;
            }

            yield return expression;
        }

        private static IEnumerable<Expression> MemberInitIterator(MemberInitExpression expression)
        {
            foreach (var newExpression in ExpressionIterator(expression.NewExpression))
            {
                yield return newExpression;
            }

            foreach (var memberBinding in expression.Bindings.SelectMany(MemberBindingIterator))
            {
                yield return memberBinding;
            }
            yield return expression;
        }

        private static IEnumerable<Expression> MemberBindingIterator(MemberBinding memberBinding)
        {
            switch (memberBinding.BindingType)
            {
                case MemberBindingType.Assignment:
                    return MemberAssignmentIterator((MemberAssignment)memberBinding);
                case MemberBindingType.MemberBinding:
                    return MemberMemberBindingIterator((MemberMemberBinding)memberBinding);
                case MemberBindingType.ListBinding:
                    return MemberListBindingIterator((MemberListBinding)memberBinding);
                default:
                    throw new Exception($"Unhandled binding type '{memberBinding.BindingType}'");
            }
        }

        private static IEnumerable<Expression> MemberAssignmentIterator(MemberAssignment memberAssignment)
        {
            return ExpressionIterator(memberAssignment.Expression);
        }

        private static IEnumerable<Expression> MemberMemberBindingIterator(MemberMemberBinding memberMemberBinding)
        {
            return memberMemberBinding.Bindings.SelectMany(MemberBindingIterator);
        }

        private static IEnumerable<Expression> MemberListBindingIterator(MemberListBinding memberListBinding)
        {
            return memberListBinding.Initializers.SelectMany(x => x.Arguments.SelectMany(ExpressionIterator));
        }

        private static IEnumerable<Expression> ListInitIterator(ListInitExpression expression)
        {
            foreach (var newExpression in ExpressionIterator(expression.NewExpression))
            {
                yield return newExpression;
            }

            foreach (var initializer in expression.Initializers.SelectMany(x => x.Arguments.SelectMany(ExpressionIterator)))
            {
                yield return initializer;
            }

            yield return expression;
        }

        private static IEnumerable<Expression> BlockIterator(BlockExpression expression)
        {
            foreach (var variable in expression.Variables)
            {
                yield return variable;
            }

            foreach (var subExpression in expression.Expressions.SelectMany(ExpressionIterator))
            {
                yield return subExpression;
            }
            yield return expression;
        }

        private static IEnumerable<Expression> DynamicIterator(DynamicExpression expression)
        {
            throw new NotImplementedException();
        }

        private static IEnumerable<Expression> GotoIterator(GotoExpression expression)
        {
            throw new NotImplementedException();
        }

        private static IEnumerable<Expression> IndexIterator(IndexExpression expression)
        {
            throw new NotImplementedException();
        }

        private static IEnumerable<Expression> LabelIterator(LabelExpression expression)
        {
            throw new NotImplementedException();
        }

        private static IEnumerable<Expression> RuntimeVariablesIterator(RuntimeVariablesExpression expression)
        {
            throw new NotImplementedException();
        }

        private static IEnumerable<Expression> LoopIterator(LoopExpression expression)
        {
            throw new NotImplementedException();
        }

        private static IEnumerable<Expression> SwitchIterator(SwitchExpression expression)
        {
            throw new NotImplementedException();
        }

        private static IEnumerable<Expression> TryIterator(TryExpression expression)
        {
            throw new NotImplementedException();
        }
    }
}