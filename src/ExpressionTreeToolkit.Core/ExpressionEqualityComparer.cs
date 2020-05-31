﻿// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Diagnostics.CodeAnalysis;

#if JETBRAINS_ANNOTATIONS
using AllowNullAttribute  = JetBrains.Annotations.CanBeNullAttribute;
using DisallowNullAttribute = JetBrains.Annotations.NotNullAttribute;
using AllowItemNullAttribute = JetBrains.Annotations.ItemCanBeNullAttribute;
#endif

namespace ExpressionTreeToolkit
{
    /// <summary>
    /// Expression Equality Comparer
    /// </summary>
    public partial class ExpressionEqualityComparer : IEqualityComparer<Expression>, System.Collections.IEqualityComparer
    {
        private readonly IEqualityComparer<Expression> _equalityComparer;

        /// <summary>
        /// Returns a default Expression equality comparer.
        /// </summary>
        public static readonly ExpressionEqualityComparer Default = new ExpressionEqualityComparer();

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
        public ExpressionEqualityComparer([AllowNull] IEqualityComparer<Expression>? equalityComparer)
        {
            _equalityComparer = equalityComparer ?? EqualityComparer<Expression>.Default;
        }

        /// <summary>Determines whether two Expressions are equal.</summary>
        /// <param name="x">The first Expression to compare.</param>
        /// <param name="y">The second Expression to compare.</param>
        /// <returns>true if the specified Expressions are equal; otherwise, false.</returns>
        public virtual bool Equals([AllowNull] Expression? x, [AllowNull] Expression? y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            if (!Equals(x.NodeType, y.NodeType))
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
                    return EqualsUnary((UnaryExpression)x, (UnaryExpression)y);
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
                    return EqualsBinary((BinaryExpression)x, (BinaryExpression)y);
                case ExpressionType.TypeIs:
                case ExpressionType.TypeEqual:
                    return EqualsTypeBinary((TypeBinaryExpression)x, (TypeBinaryExpression)y);
                case ExpressionType.Conditional:
                    return EqualsConditional((ConditionalExpression)x, (ConditionalExpression)y);
                case ExpressionType.Constant:
                    return EqualsConstant((ConstantExpression)x, (ConstantExpression)y);
                case ExpressionType.Parameter:
                    return EqualsParameter((ParameterExpression)x, (ParameterExpression)y);
                case ExpressionType.MemberAccess:
                    return EqualsMember((MemberExpression)x, (MemberExpression)y);
                case ExpressionType.Call:
                    return EqualsMethodCall((MethodCallExpression)x, (MethodCallExpression)y);
                case ExpressionType.Lambda:
                    return EqualsLambda((LambdaExpression)x, (LambdaExpression)y);
                case ExpressionType.New:
                    return EqualsNew((NewExpression)x, (NewExpression)y);
                case ExpressionType.NewArrayInit:
                case ExpressionType.NewArrayBounds:
                    return EqualsNewArray((NewArrayExpression)x, (NewArrayExpression)y);
                case ExpressionType.Invoke:
                    return EqualsInvocation((InvocationExpression)x, (InvocationExpression)y);
                case ExpressionType.MemberInit:
                    return EqualsMemberInit((MemberInitExpression)x, (MemberInitExpression)y);
                case ExpressionType.ListInit:
                    return EqualsListInit((ListInitExpression)x, (ListInitExpression)y);
                case ExpressionType.Block:
                    return EqualsBlock((BlockExpression)x, (BlockExpression)y);
                case ExpressionType.DebugInfo:
                    return EqualsDebugInfo((DebugInfoExpression)x, (DebugInfoExpression)y);
                case ExpressionType.Dynamic:
                    return EqualsDynamic((DynamicExpression)x, (DynamicExpression)y);
                case ExpressionType.Goto:
                    return EqualsGoto((GotoExpression)x, (GotoExpression)y);
                case ExpressionType.Index:
                    return EqualsIndex((IndexExpression)x, (IndexExpression)y);
                case ExpressionType.Label:
                    return EqualsLabel((LabelExpression)x, (LabelExpression)y);
                case ExpressionType.RuntimeVariables:
                    return EqualsRuntimeVariables((RuntimeVariablesExpression)x, (RuntimeVariablesExpression)y);
                case ExpressionType.Loop:
                    return EqualsLoop((LoopExpression)x, (LoopExpression)y);
                case ExpressionType.Switch:
                    return EqualsSwitch((SwitchExpression)x, (SwitchExpression)y);
                case ExpressionType.Try:
                    return EqualsTry((TryExpression)x, (TryExpression)y);
                case ExpressionType.Default:
                    return EqualsDefault((DefaultExpression)x, (DefaultExpression)y);
                case ExpressionType.Extension:
                    return EqualsExtension(x, y);
                default:
                    return _equalityComparer.Equals(x, y);
            }
        }

        /// <summary>Serves as a hash function for the specified Expression for hashing algorithms and data structures, such as a hash table.</summary>
        /// <param name="expression">The Expression for which to get a hash code.</param>
        /// <returns>A hash code for the specified Expression.</returns>
        public virtual int GetHashCode([AllowNull] Expression? expression)
        {
            if (expression == null)
                return 0;

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
                    return GetHashCodeUnary((UnaryExpression)expression);
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
                    return GetHashCodeBinary((BinaryExpression)expression);
                case ExpressionType.TypeIs:
                case ExpressionType.TypeEqual:
                    return GetHashCodeTypeBinary((TypeBinaryExpression)expression);
                case ExpressionType.Conditional:
                    return GetHashCodeConditional((ConditionalExpression)expression);
                case ExpressionType.Constant:
                    return GetHashCodeConstant((ConstantExpression)expression);
                case ExpressionType.Parameter:
                    return GetHashCodeParameter((ParameterExpression)expression);
                case ExpressionType.MemberAccess:
                    return GetHashCodeMember((MemberExpression)expression);
                case ExpressionType.Call:
                    return GetHashCodeMethodCall((MethodCallExpression)expression);
                case ExpressionType.Lambda:
                    return GetHashCodeLambda((LambdaExpression)expression);
                case ExpressionType.New:
                    return GetHashCodeNew((NewExpression)expression);
                case ExpressionType.NewArrayInit:
                case ExpressionType.NewArrayBounds:
                    return GetHashCodeNewArray((NewArrayExpression)expression);
                case ExpressionType.Invoke:
                    return GetHashCodeInvocation((InvocationExpression)expression);
                case ExpressionType.MemberInit:
                    return GetHashCodeMemberInit((MemberInitExpression)expression);
                case ExpressionType.ListInit:
                    return GetHashCodeListInit((ListInitExpression)expression);
                case ExpressionType.Block:
                    return GetHashCodeBlock((BlockExpression)expression);
                case ExpressionType.DebugInfo:
                    return GetHashCodeDebugInfo((DebugInfoExpression)expression);
                case ExpressionType.Dynamic:
                    return GetHashCodeDynamic((DynamicExpression)expression);
                case ExpressionType.Goto:
                    return GetHashCodeGoto((GotoExpression)expression);
                case ExpressionType.Index:
                    return GetHashCodeIndex((IndexExpression)expression);
                case ExpressionType.Label:
                    return GetHashCodeLabel((LabelExpression)expression);
                case ExpressionType.RuntimeVariables:
                    return GetHashCodeRuntimeVariables((RuntimeVariablesExpression)expression);
                case ExpressionType.Loop:
                    return GetHashCodeLoop((LoopExpression)expression);
                case ExpressionType.Switch:
                    return GetHashCodeSwitch((SwitchExpression)expression);
                case ExpressionType.Try:
                    return GetHashCodeTry((TryExpression)expression);
                case ExpressionType.Default:
                    return GetHashCodeDefault((DefaultExpression)expression);
                case ExpressionType.Extension:
                    return GetHashCodeExtension(expression);
                default:
                    return _equalityComparer.GetHashCode(expression);
            }
        }

        /// <summary>Determines whether two Expressions are equal.</summary>
        /// <param name="x">The first Expression to compare.</param>
        /// <param name="y">The second Expression to compare.</param>
        /// <returns>true if the specified Expressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<Expression>.Equals([AllowNull] Expression? x, [AllowNull] Expression? y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return Equals(x, y);
        }

        /// <summary>Determines whether two Expressions are equal.</summary>
        /// <param name="x">The first Expression to compare.</param>
        /// <param name="y">The second Expression to compare.</param>
        /// <returns>true if the specified Expressions are equal; otherwise, false.</returns>
        /// <exception cref="ArgumentException"><paramref name="x">x</paramref> or <paramref name="y">y</paramref> is of a type that cannot be cast to Expression.</exception>
        bool System.Collections.IEqualityComparer.Equals([AllowNull] object? x, [AllowNull] object? y)
        {
            if (x == y)
                return true;

            if (x == null || y == null)
                return false;

            if (x is Expression expressionX && y is Expression expressionY)
                return Equals(expressionX, expressionY);

            throw new ArgumentException("x or y is of a type that cannot be cast to Expression.");
        }

        /// <summary>Serves as a hash function for the specified Expression for hashing algorithms and data structures, such as a hash table.</summary>
        /// <param name="obj">The Expression for which to get a hash code.</param>
        /// <returns>A hash code for the specified Expression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<Expression>.GetHashCode([DisallowNull] Expression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCode(obj);
        }

        /// <summary>Serves as a hash function for the specified Expression for hashing algorithms and data structures, such as a hash table.</summary>
        /// <param name="obj">The Expression for which to get a hash code.</param>
        /// <returns>A hash code for the specified Expression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        /// <exception cref="System.ArgumentException"><paramref name="obj">obj</paramref> is of a type that cannot be cast to Expression</exception>
        int System.Collections.IEqualityComparer.GetHashCode([DisallowNull] object obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            if (obj is Expression expression)
                return GetHashCode(expression);

            throw new ArgumentException("obj is of a type that cannot be cast to Expression", nameof(obj));
        }
    }
}