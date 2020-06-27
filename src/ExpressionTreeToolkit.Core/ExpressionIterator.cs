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
    /// <summary>
    /// Generate enumerators for <see cref="Expression"/> tree.
    /// </summary>
    public class ExpressionIterator
    {
        internal static readonly ExpressionIterator Default = new ExpressionIterator();

        /// <summary>
        /// Default constructor
        /// </summary>
        protected ExpressionIterator()
        {
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="Expression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to iterate.</param>
        /// <returns>An enumerator that can be used to iterate through the <see cref="Expression"/>.</returns>
        /// <exception cref="ArgumentNullException">The <see cref="Expression"/> is null.</exception>
        public virtual IEnumerable<Expression> Iterator([DisallowNull] Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            if (expression is IEnumerable<Expression> enumerable)
            {
                return enumerable;
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

        /// <summary>
        /// Returns an enumerator that iterates through the [ReadOnlyCollection](xref:System.Collections.ObjectModel.ReadOnlyCollection`1)&lt;<see cref="Expression"/>&gt; elements.
        /// </summary>
        /// <param name="expressions">The [ReadOnlyCollection](xref:System.Collections.ObjectModel.ReadOnlyCollection`1)&lt;<see cref="Expression"/>&gt; to iterate.</param>
        /// <returns>An enumerator that can be used to iterate through the [ReadOnlyCollection](xref:System.Collections.ObjectModel.ReadOnlyCollection`1)&lt;<see cref="Expression"/>&gt;</returns>
        /// <exception cref="ArgumentNullException">The [ReadOnlyCollection](xref:System.Collections.ObjectModel.ReadOnlyCollection`1)&lt;<see cref="Expression"/>&gt; is null.</exception>
        protected IEnumerable<Expression> Iterator([DisallowNull] ReadOnlyCollection<Expression> expressions)
        {
            if (expressions == null)
            {
                throw new ArgumentNullException(nameof(expressions));
            }
            return expressions.SelectMany(Iterator);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the ReadOnlyCollection&lt;t&gt; elements using an iterator.
        /// </summary>
        /// <param name="values">The [ReadOnlyCollection](xref:System.Collections.ObjectModel.ReadOnlyCollection`1)&lt;<see cref="Expression"/>&gt; to iterate.</param>
        /// <param name="iterator">The iterator to apply to each element.</param>
        /// <typeparam name="T">The type of the elements of values</typeparam>
        /// <returns>An enumerator that can be used to iterate through the [ReadOnlyCollection](xref:System.Collections.ObjectModel.ReadOnlyCollection`1)&lt;<see cref="Expression"/>&gt; elements using the iterator.</returns>
        /// <exception cref="ArgumentNullException">The [ReadOnlyCollection](xref:System.Collections.ObjectModel.ReadOnlyCollection`1)&lt;<see cref="Expression"/>&gt; is null</exception>
        protected IEnumerable<Expression> Iterator<T>([DisallowNull] ReadOnlyCollection<T> values, Func<T, IEnumerable<Expression>> iterator)
            where T : class
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }
            return values.SelectMany(iterator);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="UnaryExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="UnaryExpression"/> to iterate.</param>
        /// <returns>An enumerator that can be used to iterate through the <see cref="UnaryExpression"/>.</returns>
        /// <exception cref="ArgumentNullException">The <see cref="UnaryExpression"/> is null.</exception>
        protected virtual IEnumerable<Expression> UnaryIterator([DisallowNull] UnaryExpression expression)
        {
            foreach (var operand in Iterator(expression.Operand))
            {
                yield return operand;
            }

            yield return expression;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="BinaryExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="BinaryExpression"/> to iterate.</param>
        /// <returns>An enumerator that can be used to iterate through the <see cref="BinaryExpression"/>.</returns>
        /// <exception cref="ArgumentNullException">The <see cref="BinaryExpression"/> is null.</exception>
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

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="TypeBinaryExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="TypeBinaryExpression"/> to iterate.</param>
        /// <returns>An enumerator that can be used to iterate through the <see cref="TypeBinaryExpression"/>.</returns>
        /// <exception cref="ArgumentNullException">The <see cref="TypeBinaryExpression"/> is null.</exception>
        protected virtual IEnumerable<Expression> TypeBinaryIterator([DisallowNull] TypeBinaryExpression expression)
        {
            foreach (var subExpression in Iterator(expression.Expression))
            {
                yield return subExpression;
            }

            yield return expression;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="ConditionalExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="ConditionalExpression"/> to iterate.</param>
        /// <returns>An enumerator that can be used to iterate through the <see cref="ConditionalExpression"/>.</returns>
        /// <exception cref="ArgumentNullException">The <see cref="ConditionalExpression"/> is null.</exception>
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

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="ConstantExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="ConstantExpression"/> to iterate.</param>
        /// <returns>An enumerator that can be used to iterate through the <see cref="ConstantExpression"/>.</returns>
        /// <exception cref="ArgumentNullException">The <see cref="ConstantExpression"/> is null.</exception>
        protected virtual IEnumerable<Expression> ConstantIterator([DisallowNull] ConstantExpression expression)
        {
            return new[] { expression };
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="ParameterExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="ParameterExpression"/> to iterate.</param>
        /// <returns>An enumerator that can be used to iterate through the <see cref="ParameterExpression"/>.</returns>
        /// <exception cref="ArgumentNullException">The <see cref="ParameterExpression"/> is null.</exception>
        protected virtual IEnumerable<Expression> ParameterIterator([DisallowNull] ParameterExpression expression)
        {
            return new[] { expression };
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="MemberExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="MemberExpression"/> to iterate.</param>
        /// <returns>An enumerator that can be used to iterate through the <see cref="MemberExpression"/>.</returns>
        /// <exception cref="ArgumentNullException">The <see cref="MemberExpression"/> is null.</exception>
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

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="MethodCallExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="MethodCallExpression"/> to iterate.</param>
        /// <returns>An enumerator that can be used to iterate through the <see cref="MethodCallExpression"/>.</returns>
        /// <exception cref="ArgumentNullException">The <see cref="MethodCallExpression"/> is null.</exception>
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

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="LambdaExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="LambdaExpression"/> to iterate.</param>
        /// <returns>An enumerator that can be used to iterate through the <see cref="LambdaExpression"/>.</returns>
        /// <exception cref="ArgumentNullException">The <see cref="LambdaExpression"/> is null.</exception>
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

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="NewExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="NewExpression"/> to iterate.</param>
        /// <returns>An enumerator that can be used to iterate through the <see cref="NewExpression"/>.</returns>
        /// <exception cref="ArgumentNullException">The <see cref="NewExpression"/> is null.</exception>
        protected virtual IEnumerable<Expression> NewIterator([DisallowNull] NewExpression expression)
        {
            foreach (var parameter in Iterator(expression.Arguments))
            {
                yield return parameter;
            }

            yield return expression;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="NewArrayExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="NewArrayExpression"/> to iterate.</param>
        /// <returns>An enumerator that can be used to iterate through the <see cref="NewArrayExpression"/>.</returns>
        /// <exception cref="ArgumentNullException">The <see cref="NewArrayExpression"/> is null.</exception>
        protected virtual IEnumerable<Expression> NewArrayIterator([DisallowNull] NewArrayExpression expression)
        {
            foreach (var expr in Iterator(expression.Expressions))
            {
                yield return expr;
            }

            yield return expression;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="InvocationExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="InvocationExpression"/> to iterate.</param>
        /// <returns>An enumerator that can be used to iterate through the <see cref="InvocationExpression"/>.</returns>
        /// <exception cref="ArgumentNullException">The <see cref="InvocationExpression"/> is null.</exception>
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

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="MemberInitExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="MemberInitExpression"/> to iterate.</param>
        /// <returns>An enumerator that can be used to iterate through the <see cref="MemberInitExpression"/>.</returns>
        /// <exception cref="ArgumentNullException">The <see cref="MemberInitExpression"/> is null.</exception>
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

        /// <summary>
        /// Returns an enumerator that iterates through the MemberBinding.
        /// </summary>
        /// <param name="memberBinding">The MemberBinding to iterate.</param>
        /// <returns>An enumerator that can be used to iterate through the MemberBinding.</returns>
        /// <exception cref="ArgumentNullException">The MemberBinding is null.</exception>
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

        /// <summary>
        /// Returns an enumerator that iterates through the MemberAssignment.
        /// </summary>
        /// <param name="memberAssignment">The MemberAssignment to iterate.</param>
        /// <returns>An enumerator that can be used to iterate through the MemberAssignment.</returns>
        /// <exception cref="ArgumentNullException">The MemberAssignment is null.</exception>
        protected virtual IEnumerable<Expression> MemberAssignmentIterator([DisallowNull] MemberAssignment memberAssignment)
        {
            if (memberAssignment == null)
            {
                throw new ArgumentNullException(nameof(memberAssignment));
            }
            return Iterator(memberAssignment.Expression);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the MemberMemberBinding.
        /// </summary>
        /// <param name="memberMemberBinding">The MemberMemberBinding to iterate.</param>
        /// <returns>An enumerator that can be used to iterate through the MemberMemberBinding.</returns>
        /// <exception cref="ArgumentNullException">The MemberMemberBinding is null.</exception>
        protected virtual IEnumerable<Expression> MemberMemberBindingIterator([DisallowNull] MemberMemberBinding memberMemberBinding)
        {
            if (memberMemberBinding == null)
            {
                throw new ArgumentNullException(nameof(memberMemberBinding));
            }
            return Iterator(memberMemberBinding.Bindings, MemberBindingIterator);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the MemberListBinding.
        /// </summary>
        /// <param name="memberListBinding">The MemberListBinding to iterate.</param>
        /// <returns>An enumerator that can be used to iterate through the MemberListBinding.</returns>
        /// <exception cref="ArgumentNullException">The MemberListBinding is null.</exception>
        protected virtual IEnumerable<Expression> MemberListBindingIterator([DisallowNull] MemberListBinding memberListBinding)
        {
            if (memberListBinding == null)
            {
                throw new ArgumentNullException(nameof(memberListBinding));
            }
            return Iterator(memberListBinding.Initializers, ElementInitIterator);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the ElementInit.
        /// </summary>
        /// <param name="elementInit">The ElementInit to iterate.</param>
        /// <returns>An enumerator that can be used to iterate through the ElementInit.</returns>
        /// <exception cref="ArgumentNullException">The ElementInit is null.</exception>
        protected virtual IEnumerable<Expression> ElementInitIterator([DisallowNull] ElementInit elementInit)
        {
            if (elementInit == null)
            {
                throw new ArgumentNullException(nameof(elementInit));
            }
            return Iterator(elementInit.Arguments);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="ListInitExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="ListInitExpression"/> to iterate.</param>
        /// <returns>An enumerator that can be used to iterate through the <see cref="ListInitExpression"/>.</returns>
        /// <exception cref="ArgumentNullException">The <see cref="ListInitExpression"/> is null.</exception>
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

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="BlockExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="BlockExpression"/> to iterate.</param>
        /// <returns>An enumerator that can be used to iterate through the <see cref="BlockExpression"/>.</returns>
        /// <exception cref="ArgumentNullException">The <see cref="BlockExpression"/> is null.</exception>
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

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="DebugInfoExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="DebugInfoExpression"/> to iterate.</param>
        /// <returns>An enumerator that can be used to iterate through the <see cref="DebugInfoExpression"/>.</returns>
        /// <exception cref="ArgumentNullException">The <see cref="DebugInfoExpression"/> is null.</exception>
        protected virtual IEnumerable<Expression> DebugInfoIterator([DisallowNull] DebugInfoExpression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }
            return new[] { expression };
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="DynamicExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="DynamicExpression"/> to iterate.</param>
        /// <returns>An enumerator that can be used to iterate through the <see cref="DynamicExpression"/>.</returns>
        /// <exception cref="ArgumentNullException">The <see cref="DynamicExpression"/> is null.</exception>
        protected virtual IEnumerable<Expression> DynamicIterator([DisallowNull] DynamicExpression expression)
        {
            foreach (var argument in Iterator(expression.Arguments))
            {
                yield return argument;
            }
            yield return expression;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="GotoExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="GotoExpression"/> to iterate.</param>
        /// <returns>An enumerator that can be used to iterate through the <see cref="GotoExpression"/>.</returns>
        /// <exception cref="ArgumentNullException">The <see cref="GotoExpression"/> is null.</exception>
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

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="IndexExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="IndexExpression"/> to iterate.</param>
        /// <returns>An enumerator that can be used to iterate through the <see cref="IndexExpression"/>.</returns>
        /// <exception cref="ArgumentNullException">The <see cref="IndexExpression"/> is null.</exception>
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

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="LabelExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="LabelExpression"/> to iterate.</param>
        /// <returns>An enumerator that can be used to iterate through the <see cref="LabelExpression"/>.</returns>
        /// <exception cref="ArgumentNullException">The <see cref="LabelExpression"/> is null.</exception>
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

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="RuntimeVariablesExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="RuntimeVariablesExpression"/> to iterate.</param>
        /// <returns>An enumerator that can be used to iterate through the <see cref="RuntimeVariablesExpression"/>.</returns>
        /// <exception cref="ArgumentNullException">The <see cref="RuntimeVariablesExpression"/> is null.</exception>
        protected virtual IEnumerable<Expression> RuntimeVariablesIterator([DisallowNull] RuntimeVariablesExpression expression)
        {
            foreach (var variable in expression.Variables)
            {
                yield return variable;
            }
            yield return expression;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="LoopExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="LoopExpression"/> to iterate.</param>
        /// <returns>An enumerator that can be used to iterate through the <see cref="LoopExpression"/>.</returns>
        /// <exception cref="ArgumentNullException">The <see cref="LoopExpression"/> is null.</exception>
        protected virtual IEnumerable<Expression> LoopIterator([DisallowNull] LoopExpression expression)
        {
            foreach (var body in Iterator(expression.Body))
            {
                yield return body;
            }
            yield return expression;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="SwitchExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="SwitchExpression"/> to iterate.</param>
        /// <returns>An enumerator that can be used to iterate through the <see cref="SwitchExpression"/>.</returns>
        /// <exception cref="ArgumentNullException">The <see cref="SwitchExpression"/> is null.</exception>
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

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="TryExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="TryExpression"/> to iterate.</param>
        /// <returns>An enumerator that can be used to iterate through the <see cref="TryExpression"/>.</returns>
        /// <exception cref="ArgumentNullException">The <see cref="TryExpression"/> is null.</exception>
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

        /// <summary>
        /// Returns an enumerator that iterates through the CatchBlock.
        /// </summary>
        /// <param name="catchBlock">The CatchBlock to iterate.</param>
        /// <returns>An enumerator that can be used to iterate through the CatchBlock.</returns>
        /// <exception cref="ArgumentNullException">The CatchBlock is null.</exception>
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

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="DefaultExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="DefaultExpression"/> to iterate.</param>
        /// <returns>An enumerator that can be used to iterate through the <see cref="DefaultExpression"/>.</returns>
        /// <exception cref="ArgumentNullException">The <see cref="DefaultExpression"/> is null.</exception>
        protected virtual IEnumerable<Expression> DefaultIterator([DisallowNull] DefaultExpression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }
            return new[] { expression };
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="Expression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to iterate.</param>
        /// <returns>An enumerator that can be used to iterate through the <see cref="Expression"/>.</returns>
        /// <exception cref="ArgumentNullException">The <see cref="Expression"/> is null.</exception>
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