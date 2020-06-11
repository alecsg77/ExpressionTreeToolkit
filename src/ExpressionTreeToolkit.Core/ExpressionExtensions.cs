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
    public static partial class ExpressionExtensions
    {
        public static IEnumerable<Expression> AsEnumerable([DisallowNull] this Expression source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return ExpressionIterator(source);

        }

        private static IEnumerable<Expression> ExpressionIterator([DisallowNullAttribute] Expression expression)
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
                    return null;
            }
        }

        private static IEnumerable<Expression> UnaryIterator(UnaryExpression expression)
        {
            yield return expression.Operand;
            yield return expression;
        }

        private static IEnumerable<Expression> BinaryIterator(BinaryExpression expression)
        {
            yield return expression.Left;
            yield return expression.Right;
            yield return expression;
        }

        private static IEnumerable<Expression> TypeBinaryIterator(TypeBinaryExpression expression)
        {
            yield return expression.Expression;
            yield return expression;
        }

        private static IEnumerable<Expression> ConditionalIterator(ConditionalExpression expression)
        {
            yield return expression.Test;
            yield return expression.IfTrue;
            yield return expression.IfFalse;
            yield return expression;
        }

        private static IEnumerable<Expression> ConstantIterator(ConstantExpression expression)
        {
            yield return expression;
        }

        private static IEnumerable<Expression> ParameterIterator(ParameterExpression expression)
        {
            yield return expression;
        }

        private static IEnumerable<Expression> MemberIterator(MemberExpression expression)
        {
            if (expression.Expression != null) yield return expression.Expression;
            yield return expression;
        }

        private static IEnumerable<Expression> MethodCallIterator(MethodCallExpression expression)
        {
            if (expression.Object != null) yield return expression.Object;
            foreach (var argument in expression.Arguments)
            {
                yield return argument;
            }
            yield return expression;
        }

        private static IEnumerable<Expression> LambdaIterator(LambdaExpression expression)
        {
            throw new NotImplementedException();
        }

        private static IEnumerable<Expression> NewIterator(NewExpression expression)
        {
            throw new NotImplementedException();
        }

        private static IEnumerable<Expression> NewArrayIterator(NewArrayExpression expression)
        {
            throw new NotImplementedException();
        }

        private static IEnumerable<Expression> InvocationIterator(InvocationExpression expression)
        {
            throw new NotImplementedException();
        }

        private static IEnumerable<Expression> MemberInitIterator(MemberInitExpression expression)
        {
            throw new NotImplementedException();
        }

        private static IEnumerable<Expression> ListInitIterator(ListInitExpression expression)
        {
            throw new NotImplementedException();
        }

        private static IEnumerable<Expression> BlockIterator(BlockExpression expression)
        {
            throw new NotImplementedException();
        }

        private static IEnumerable<Expression> DebugInfoIterator(DebugInfoExpression expression)
        {
            throw new NotImplementedException();
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

        private static IEnumerable<Expression> DefaultIterator(DefaultExpression expression)
        {
            yield return expression;
        }

        private static IEnumerable<Expression> ExtensionIterator(Expression expression)
        {
            throw new NotImplementedException();
        }
    }

}
