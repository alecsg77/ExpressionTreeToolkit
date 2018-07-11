// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    /// <summary>
    /// Expression Equality Comparer
    /// </summary>
    public partial class ExpressionEqualityComparer : EqualityComparer<Expression>
    {
        private readonly IEqualityComparer<Expression> _equalityComparer;
        /// <summary>
        /// Returns a default Expression equality comparer.
        /// </summary>
        public new static readonly ExpressionEqualityComparer Default = new ExpressionEqualityComparer();

        /// <summary>
        /// Initializes a new instance of the ExpressionEqualityComparer class.
        /// </summary>
        public ExpressionEqualityComparer()
            : this(EqualityComparer<Expression>.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ExpressionEqualityComparer class and uses the specified equality comparer for the unknown Expression node.
        /// </summary>
        /// <param name="equalityComparer">The EqualityComparer for comparing unknown Expression node in the Expression tree, or null to use the default EqualityComparer implementation.</param>
        public ExpressionEqualityComparer(IEqualityComparer<Expression> equalityComparer)
        {
            _equalityComparer = equalityComparer ?? EqualityComparer<Expression>.Default;
        }

        /// <summary>Determines whether two Expressions are equal.</summary>
        /// <param name="x">The first Expression to compare.</param>
        /// <param name="y">The second Expression to compare.</param>
        /// <returns>true if the specified Expressions are equal; otherwise, false.</returns>
        public sealed override bool Equals(Expression x, Expression y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (!EqualsExpression(x, y))
                return false;

            switch (x.NodeType)
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
                    return EqualsUnary((UnaryExpression) x, (UnaryExpression) y);
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
                    return EqualsBinary((BinaryExpression) x, (BinaryExpression) y);
                case ExpressionType.TypeIs:
                case ExpressionType.TypeEqual:
                    return EqualsTypeBinary((TypeBinaryExpression) x, (TypeBinaryExpression) y);
                case ExpressionType.Conditional:
                    return EqualsConditional((ConditionalExpression) x, (ConditionalExpression) y);
                case ExpressionType.Constant:
                    return EqualsConstant((ConstantExpression) x, (ConstantExpression) y);
                case ExpressionType.Parameter:
                    return EqualsParameter((ParameterExpression) x, (ParameterExpression) y);
                case ExpressionType.MemberAccess:
                    return EqualsMember((MemberExpression) x, (MemberExpression) y);
                case ExpressionType.Call:
                    return EqualsMethodCall((MethodCallExpression) x, (MethodCallExpression) y);
                case ExpressionType.Lambda:
                    return EqualsLambda((LambdaExpression) x, (LambdaExpression) y);
                case ExpressionType.New:
                    return EqualsNew((NewExpression) x, (NewExpression) y);
                case ExpressionType.NewArrayInit:
                case ExpressionType.NewArrayBounds:
                    return EqualsNewArray((NewArrayExpression) x, (NewArrayExpression) y);
                case ExpressionType.Invoke:
                    return EqualsInvocation((InvocationExpression) x, (InvocationExpression) y);
                case ExpressionType.MemberInit:
                    return EqualsMemberInit((MemberInitExpression) x, (MemberInitExpression) y);
                case ExpressionType.ListInit:
                    return EqualsListInit((ListInitExpression) x, (ListInitExpression) y);
                case ExpressionType.Block:
                    return EqualsBlock((BlockExpression) x, (BlockExpression) y);
                case ExpressionType.DebugInfo:
                    return EqualsDebugInfo((DebugInfoExpression) x, (DebugInfoExpression) y);
                case ExpressionType.Dynamic:
                    return EqualsDynamic((DynamicExpression) x, (DynamicExpression) y);
                case ExpressionType.Goto:
                    return EqualsGoto((GotoExpression) x, (GotoExpression) y);
                case ExpressionType.Index:
                    return EqualsIndex((IndexExpression) x, (IndexExpression) y);
                case ExpressionType.Label:
                    return EqualsLabel((LabelExpression) x, (LabelExpression) y);
                case ExpressionType.RuntimeVariables:
                    return EqualsRuntimeVariables((RuntimeVariablesExpression) x, (RuntimeVariablesExpression) y);
                case ExpressionType.Loop:
                    return EqualsLoop((LoopExpression) x, (LoopExpression) y);
                case ExpressionType.Switch:
                    return EqualsSwitch((SwitchExpression) x, (SwitchExpression) y);
                case ExpressionType.Try:
                    return EqualsTry((TryExpression) x, (TryExpression) y);
                case ExpressionType.Default:
                    return EqualsDefault((DefaultExpression) x, (DefaultExpression) y);
                case ExpressionType.Extension:
                    return EqualsExtension(x, y);
                default:
                    return _equalityComparer.Equals(x, y);
            }
        }

        private bool EqualsExpression(Expression x, Expression y)
        {
            if (x == null || y == null)
            {
                return false;
            }

            return EqualsType(x, y) && EqualsNodeType(x, y);
        }

        private bool EqualsType(Expression x, Expression y)
        {
            return x.Type == y.Type;
        }

        private bool EqualsNodeType(Expression x, Expression y)
        {
            return x.NodeType == y.NodeType;
        }

        /// <summary>Serves as a hash function for the specified Expression for hashing algorithms and data structures, such as a hash table.</summary>
        /// <param name="obj">The Expression for which to get a hash code.</param>
        /// <returns>A hash code for the specified Expression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        public sealed override int GetHashCode(Expression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            IEnumerable<int> hashElements;
            switch (obj.NodeType)
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
                    hashElements = GetHashElementsUnary((UnaryExpression) obj);
                    break;
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
                    hashElements = GetHashElementsBinary((BinaryExpression) obj);
                    break;
                case ExpressionType.TypeIs:
                case ExpressionType.TypeEqual:
                    hashElements = GetHashElementsTypeBinary((TypeBinaryExpression) obj);
                    break;
                case ExpressionType.Conditional:
                    hashElements = GetHashElementsConditional((ConditionalExpression) obj);
                    break;
                case ExpressionType.Constant:
                    hashElements = GetHashElementsConstant((ConstantExpression) obj);
                    break;
                case ExpressionType.Parameter:
                    hashElements = GetHashElementsParameter((ParameterExpression) obj);
                    break;
                case ExpressionType.MemberAccess:
                    hashElements = GetHashElementsMember((MemberExpression) obj);
                    break;
                case ExpressionType.Call:
                    hashElements = GetHashElementsMethodCall((MethodCallExpression) obj);
                    break;
                case ExpressionType.Lambda:
                    hashElements = GetHashElementsLambda((LambdaExpression) obj);
                    break;
                case ExpressionType.New:
                    hashElements = GetHashElementsNew((NewExpression) obj);
                    break;
                case ExpressionType.NewArrayInit:
                case ExpressionType.NewArrayBounds:
                    hashElements = GetHashElementsNewArray((NewArrayExpression) obj);
                    break;
                case ExpressionType.Invoke:
                    hashElements = GetHashElementsInvocation((InvocationExpression) obj);
                    break;
                case ExpressionType.MemberInit:
                    hashElements = GetHashElementsMemberInit((MemberInitExpression) obj);
                    break;
                case ExpressionType.ListInit:
                    hashElements = GetHashElementsListInit((ListInitExpression) obj);
                    break;
                case ExpressionType.Block:
                    hashElements = GetHashElementsBlock((BlockExpression) obj);
                    break;
                case ExpressionType.DebugInfo:
                    hashElements = GetHashElementsDebugInfo((DebugInfoExpression) obj);
                    break;
                case ExpressionType.Dynamic:
                    hashElements = GetHashElementsDynamic((DynamicExpression) obj);
                    break;
                case ExpressionType.Goto:
                    hashElements = GetHashElementsGoto((GotoExpression) obj);
                    break;
                case ExpressionType.Index:
                    hashElements = GetHashElementsIndex((IndexExpression) obj);
                    break;
                case ExpressionType.Label:
                    hashElements = GetHashElementsLabel((LabelExpression) obj);
                    break;
                case ExpressionType.RuntimeVariables:
                    hashElements = GetHashElementsRuntimeVariables((RuntimeVariablesExpression) obj);
                    break;
                case ExpressionType.Loop:
                    hashElements = GetHashElementsLoop((LoopExpression) obj);
                    break;
                case ExpressionType.Switch:
                    hashElements = GetHashElementsSwitch((SwitchExpression) obj);
                    break;
                case ExpressionType.Try:
                    hashElements = GetHashElementsTry((TryExpression) obj);
                    break;
                case ExpressionType.Default:
                    hashElements = GetHashElementsDefault((DefaultExpression) obj);
                    break;
                case ExpressionType.Extension:
                    hashElements = GetHashElementsExtension(obj);
                    break;
                default:
                    return _equalityComparer.GetHashCode(obj);
            }

            return GetHashCodeExpression(obj, hashElements);
        }

        private int GetHashCodeExpression(Expression exp, IEnumerable<int> hashElements)
        {
            return GetHashElements(exp.NodeType, exp.Type, hashElements).Aggregate(GetHashCode);
        }
    }
}