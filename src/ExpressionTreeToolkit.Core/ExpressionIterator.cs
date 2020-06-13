// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;

#if JETBRAINS_ANNOTATIONS
using AllowNullAttribute = JetBrains.Annotations.CanBeNullAttribute;
using DisallowNullAttribute = JetBrains.Annotations.NotNullAttribute;
using AllowItemNullAttribute = JetBrains.Annotations.ItemCanBeNullAttribute;
#endif


namespace ExpressionTreeToolkit
{
    public class ExpressionIterator
    {
        internal static readonly ExpressionIterator Default = new ExpressionIterator();

        protected ExpressionIterator()
        {
        }

        public virtual IEnumerable<Expression> Iterator([DisallowNull] Expression expression)
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
                    return UnaryIterator((UnaryExpression)expression);
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
                    return BinaryIterator((BinaryExpression)expression);
                case ExpressionType.TypeIs:
                case ExpressionType.TypeEqual:
                    return TypeBinaryIterator((TypeBinaryExpression)expression);
                case ExpressionType.Conditional:
                    return ConditionalIterator((ConditionalExpression)expression);
                case ExpressionType.Constant:
                    return ConstantIterator((ConstantExpression)expression);
                case ExpressionType.Parameter:
                    return ParameterIterator((ParameterExpression)expression);
                case ExpressionType.MemberAccess:
                    return MemberIterator((MemberExpression)expression);
                case ExpressionType.Call:
                    return MethodCallIterator((MethodCallExpression)expression);
                case ExpressionType.Lambda:
                    return LambdaIterator((LambdaExpression)expression);
                case ExpressionType.New:
                    return NewIterator((NewExpression)expression);
                case ExpressionType.NewArrayInit:
                case ExpressionType.NewArrayBounds:
                    return NewArrayIterator((NewArrayExpression)expression);
                case ExpressionType.Invoke:
                    return InvocationIterator((InvocationExpression)expression);
                case ExpressionType.MemberInit:
                    return MemberInitIterator((MemberInitExpression)expression);
                case ExpressionType.ListInit:
                    return ListInitIterator((ListInitExpression)expression);
                case ExpressionType.Block:
                    return BlockIterator((BlockExpression)expression);
                case ExpressionType.DebugInfo:
                    return DebugInfoIterator((DebugInfoExpression)expression);
                case ExpressionType.Dynamic:
                    return DynamicIterator((DynamicExpression)expression);
                case ExpressionType.Goto:
                    return GotoIterator((GotoExpression)expression);
                case ExpressionType.Index:
                    return IndexIterator((IndexExpression)expression);
                case ExpressionType.Label:
                    return LabelIterator((LabelExpression)expression);
                case ExpressionType.RuntimeVariables:
                    return RuntimeVariablesIterator((RuntimeVariablesExpression)expression);
                case ExpressionType.Loop:
                    return LoopIterator((LoopExpression)expression);
                case ExpressionType.Switch:
                    return SwitchIterator((SwitchExpression)expression);
                case ExpressionType.Try:
                    return TryIterator((TryExpression)expression);
                case ExpressionType.Default:
                    return DefaultIterator((DefaultExpression)expression);
                case ExpressionType.Extension:
                    return ExtensionIterator(expression);
                default:
                    return new[] { expression };
            }
        }

        protected IEnumerable<Expression> Iterator([DisallowNull] ReadOnlyCollection<Expression> expressions)
        {
            if (expressions == null)
            {
                throw new ArgumentNullException(nameof(expressions));
            }
            return expressions.SelectMany(Iterator);
        }

        protected IEnumerable<Expression> Iterator<T>([DisallowNull] ReadOnlyCollection<T> values, Func<T, IEnumerable<Expression>> iterator)
            where T : class
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }
            return values.SelectMany(iterator);
        }

        protected virtual IEnumerable<Expression> UnaryIterator([DisallowNull] UnaryExpression expression)
        {
            foreach (var operand in Iterator(expression.Operand))
            {
                yield return operand;
            }

            yield return expression;
        }

        protected virtual IEnumerable<Expression> BinaryIterator([DisallowNull] BinaryExpression expression)
        {
            foreach (var left in Iterator(expression.Left))
            {
                yield return left;
            }

            foreach (var right in Iterator(expression.Right))
            {
                yield return right;
            }

            yield return expression;
        }

        protected virtual IEnumerable<Expression> TypeBinaryIterator([DisallowNull] TypeBinaryExpression expression)
        {
            foreach (var subExpression in Iterator(expression.Expression))
            {
                yield return subExpression;
            }

            yield return expression;
        }

        protected virtual IEnumerable<Expression> ConditionalIterator([DisallowNull] ConditionalExpression expression)
        {
            foreach (var test in Iterator(expression.Test))
            {
                yield return test;
            }

            foreach (var ifTrue in Iterator(expression.IfTrue))
            {
                yield return ifTrue;
            }

            foreach (var ifFalse in Iterator(expression.IfFalse))
            {
                yield return ifFalse;
            }

            yield return expression;
        }

        protected virtual IEnumerable<Expression> ConstantIterator([DisallowNull] ConstantExpression expression)
        {
            return new[] { expression };
        }

        protected virtual IEnumerable<Expression> ParameterIterator([DisallowNull] ParameterExpression expression)
        {
            return new[] { expression };
        }

        protected virtual IEnumerable<Expression> MemberIterator([DisallowNull] MemberExpression expression)
        {
            if (expression.Expression != null)
            {
                foreach (var subExpression in Iterator(expression.Expression))
                {
                    yield return subExpression;
                }
            }

            yield return expression;
        }

        protected virtual IEnumerable<Expression> MethodCallIterator([DisallowNull] MethodCallExpression expression)
        {
            if (expression.Object != null)
            {
                foreach (var obj in Iterator(expression.Object))
                {
                    yield return obj;
                }
            }

            foreach (var argument in Iterator(expression.Arguments))
            {
                yield return argument;
            }

            yield return expression;
        }

        protected virtual IEnumerable<Expression> LambdaIterator([DisallowNull] LambdaExpression expression)
        {
            foreach (var body in Iterator(expression.Body))
            {
                yield return body;
            }

            foreach (var parameter in expression.Parameters)
            {
                yield return parameter;
            }

            yield return expression;
        }

        protected virtual IEnumerable<Expression> NewIterator([DisallowNull] NewExpression expression)
        {
            foreach (var parameter in Iterator(expression.Arguments))
            {
                yield return parameter;
            }

            yield return expression;
        }

        protected virtual IEnumerable<Expression> NewArrayIterator([DisallowNull] NewArrayExpression expression)
        {
            foreach (var expr in Iterator(expression.Expressions))
            {
                yield return expr;
            }

            yield return expression;
        }

        protected virtual IEnumerable<Expression> InvocationIterator([DisallowNull] InvocationExpression expression)
        {
            foreach (var subExpression in Iterator(expression.Expression))
            {
                yield return subExpression;
            }

            foreach (var parameter in Iterator(expression.Arguments))
            {
                yield return parameter;
            }

            yield return expression;
        }

        protected virtual IEnumerable<Expression> MemberInitIterator([DisallowNull] MemberInitExpression expression)
        {
            foreach (var newExpression in Iterator(expression.NewExpression))
            {
                yield return newExpression;
            }

            foreach (var memberBinding in Iterator(expression.Bindings, MemberBindingIterator))
            {
                yield return memberBinding;
            }
            yield return expression;
        }

        protected virtual IEnumerable<Expression> MemberBindingIterator([DisallowNull] MemberBinding memberBinding)
        {
            if (memberBinding == null)
            {
                throw new ArgumentNullException(nameof(memberBinding));
            }
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

        protected virtual IEnumerable<Expression> MemberAssignmentIterator([DisallowNull] MemberAssignment memberAssignment)
        {
            if (memberAssignment == null)
            {
                throw new ArgumentNullException(nameof(memberAssignment));
            }
            return Iterator(memberAssignment.Expression);
        }

        protected virtual IEnumerable<Expression> MemberMemberBindingIterator([DisallowNull] MemberMemberBinding memberMemberBinding)
        {
            if (memberMemberBinding == null)
            {
                throw new ArgumentNullException(nameof(memberMemberBinding));
            }
            return Iterator(memberMemberBinding.Bindings, MemberBindingIterator);
        }

        protected virtual IEnumerable<Expression> MemberListBindingIterator([DisallowNull] MemberListBinding memberListBinding)
        {
            if (memberListBinding == null)
            {
                throw new ArgumentNullException(nameof(memberListBinding));
            }
            return Iterator(memberListBinding.Initializers, ElementInitIterator);
        }

        protected virtual IEnumerable<Expression> ElementInitIterator([DisallowNull] ElementInit elementInit)
        {
            if (elementInit == null)
            {
                throw new ArgumentNullException(nameof(elementInit));
            }
            return Iterator(elementInit.Arguments);
        }

        protected virtual IEnumerable<Expression> ListInitIterator([DisallowNull] ListInitExpression expression)
        {
            foreach (var newExpression in Iterator(expression.NewExpression))
            {
                yield return newExpression;
            }

            foreach (var initializer in Iterator(expression.Initializers, ElementInitIterator))
            {
                yield return initializer;
            }

            yield return expression;
        }

        protected virtual IEnumerable<Expression> BlockIterator([DisallowNull] BlockExpression expression)
        {
            foreach (var variable in expression.Variables)
            {
                yield return variable;
            }

            foreach (var subExpression in Iterator(expression.Expressions))
            {
                yield return subExpression;
            }
            yield return expression;
        }

        protected virtual IEnumerable<Expression> DebugInfoIterator([DisallowNull] DebugInfoExpression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }
            return new[] { expression };
        }

        protected virtual IEnumerable<Expression> DynamicIterator([DisallowNull] DynamicExpression expression)
        {
            foreach (var argument in Iterator(expression.Arguments))
            {
                yield return argument;
            }
            yield return expression;
        }

        protected virtual IEnumerable<Expression> GotoIterator([DisallowNull] GotoExpression expression)
        {
            if (expression.Value != null)
            {
                foreach (var value in Iterator(expression.Value))
                {
                    yield return value;
                }
            }
            yield return expression;
        }

        protected virtual IEnumerable<Expression> IndexIterator([DisallowNull] IndexExpression expression)
        {
            foreach (var @object in Iterator(expression.Object))
            {
                yield return @object;
            }
            foreach (var argument in Iterator(expression.Arguments))
            {
                yield return argument;
            }
            yield return expression;
        }

        protected virtual IEnumerable<Expression> LabelIterator([DisallowNull] LabelExpression expression)
        {
            if (expression.DefaultValue != null)
            {
                foreach (var defaultValue in Iterator(expression.DefaultValue))
                {
                    yield return defaultValue;
                }
            }
            yield return expression;
        }

        protected virtual IEnumerable<Expression> RuntimeVariablesIterator([DisallowNull] RuntimeVariablesExpression expression)
        {
            foreach (var variable in expression.Variables)
            {
                yield return variable;
            }
            yield return expression;
        }

        protected virtual IEnumerable<Expression> LoopIterator([DisallowNull] LoopExpression expression)
        {
            foreach (var body in Iterator(expression.Body))
            {
                yield return body;
            }
            yield return expression;
        }

        protected virtual IEnumerable<Expression> SwitchIterator([DisallowNull] SwitchExpression expression)
        {
            yield return expression.SwitchValue;
            foreach (var switchCase in expression.Cases)
            {
                foreach (var testValue in Iterator(switchCase.TestValues))
                {
                    yield return testValue;
                }
                foreach (var body in Iterator(switchCase.Body))
                {
                    yield return body;
                }
            }
            if (expression.DefaultBody != null)
            {
                foreach (var defaultBody in Iterator(expression.DefaultBody))
                {
                    yield return defaultBody;
                }
            }
            yield return expression;
        }

        protected virtual IEnumerable<Expression> TryIterator([DisallowNull] TryExpression expression)
        {
            foreach (var body in Iterator(expression.Body))
            {
                yield return body;
            }

            foreach (var catchBlock in Iterator(expression.Handlers, CatchBlockIterator))
            {
                yield return catchBlock;
            }

            if (expression.Fault != null)
            {
                foreach (var fault in Iterator(expression.Fault))
                {
                    yield return fault;
                }
            }

            if (expression.Finally != null)
            {
                foreach (var @finally in Iterator(expression.Finally))
                {
                    yield return @finally;
                }
            }

            yield return expression;
        }

        protected virtual IEnumerable<Expression> CatchBlockIterator([DisallowNull] CatchBlock catchBlock)
        {
            if (catchBlock.Variable != null)
            {
                yield return catchBlock.Variable;
            }

            if (catchBlock.Filter != null)
            {
                foreach (var filter in Iterator(catchBlock.Filter))
                {
                    yield return filter;
                }
            }

            foreach (var body in Iterator(catchBlock.Body))
            {
                yield return body;
            }
        }

        protected virtual IEnumerable<Expression> DefaultIterator([DisallowNull] DefaultExpression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }
            return new[] { expression };
        }

        protected virtual IEnumerable<Expression> ExtensionIterator([DisallowNull] Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }
            return new[] { expression };
        }
    }
}