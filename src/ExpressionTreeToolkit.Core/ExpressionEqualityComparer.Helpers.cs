// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer
    {
        private bool EqualsList<T>(IEnumerable<T> x, IEnumerable<T> y, Func<T, T, bool> equalityComparer)
            where T : class
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

            using (var ex = x.GetEnumerator())
            using (var ey = y.GetEnumerator())
            {
                while (ex.MoveNext())
                {
                    if (!ey.MoveNext())
                    {
                        return false;
                    }

                    var objX = ex.Current;
                    var objY = ey.Current;

                    if (ReferenceEquals(objX, objY))
                    {
                        continue;
                    }

                    if (objX == null || objY == null)
                    {
                        return false;
                    }

                    if (!equalityComparer(objX, objY))
                    {
                        return false;
                    }
                }

                if (ey.MoveNext())
                {
                    return false;
                }
            }

            return true;
        }

        private bool EqualsList<T>(IEnumerable<T> x, IEnumerable<T> y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

            return x.SequenceEqual(y);
        }

        private bool EqualsExpressionList(IEnumerable<Expression> x, IEnumerable<Expression> y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

            return x.SequenceEqual(y, this);
        }

        private bool EqualsElementInit(ElementInit x, ElementInit y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

            return Equals(x.AddMethod, y.AddMethod)
                && EqualsExpressionList(x.Arguments, y.Arguments);
        }

        private bool EqualsBinding(MemberBinding x, MemberBinding y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

            if (!Equals(x.BindingType, y.BindingType))
            {
                return false;
            }

            switch (x.BindingType)
            {
                case MemberBindingType.Assignment:
                    return EqualsMemberAssignment((MemberAssignment)x, (MemberAssignment)y);
                case MemberBindingType.MemberBinding:
                    return EqualsMemberMemberBinding((MemberMemberBinding)x, (MemberMemberBinding)y);
                case MemberBindingType.ListBinding:
                    return EqualsMemberListBinding((MemberListBinding)x, (MemberListBinding)y);
                default:
                    throw new Exception($"Unhandled binding type '{x.BindingType}'");
            }
        }

        private bool EqualsMemberAssignment(MemberAssignment x, MemberAssignment y)
        {
            return Equals(x.Member, y.Member)
                   && EqualsExpression(x.Expression, y.Expression);
        }

        private bool EqualsMemberMemberBinding(MemberMemberBinding x, MemberMemberBinding y)
        {
            return Equals(x.Member, y.Member)
                   && EqualsList(x.Bindings, y.Bindings, EqualsBinding);
        }

        private bool EqualsMemberListBinding(MemberListBinding x, MemberListBinding y)
        {
            return Equals(x.Member, y.Member)
                   && EqualsList(x.Initializers, y.Initializers, EqualsElementInit);
        }

        private bool EqualsLabelTarget(LabelTarget x, LabelTarget y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

            return x.Type == y.Type
                   && Equals(x.Name, y.Name);
        }

        private int GetHashCodeSafe<T>(T obj)
            where T : class
        {
            return obj?.GetHashCode() ?? 0;
        }

        private int GetHashCode(int h1, int h2)
        {
            unchecked
            {
                return ((h1 << 5) + h1) ^ h2;
            }
        }

        private int GetHashCode(int h1, int h2, int h3)
        {
            return GetHashCode(GetHashCode(h1, h2), h3);
        }

        private int GetHashCode(int h1, int h2, int h3, int h4)
        {
            return GetHashCode(GetHashCode(GetHashCode(h1, h2), h3), h4);
        }

        private int GetHashCode(int h1, params int[] args)
        {
            return args.Aggregate(h1, GetHashCode);
        }

        private int GetHashCodeList<T>(IEnumerable<T> list, Func<T, int> getHashCode)
            where T : class
        {
            return list.Select(getHashCode).DefaultIfEmpty().Aggregate(GetHashCode);
        }

        private int GetHashCodeList<T>(IEnumerable<T> list)
            where T : class
        {
            return list.Select(GetHashCodeSafe).DefaultIfEmpty().Aggregate(GetHashCode);
        }

        private int GetHashCodeExpressionList(IEnumerable<Expression> expressionList)
        {
            return expressionList.Select(GetHashCodeExpression).DefaultIfEmpty().Aggregate(GetHashCode);
        }

        private int GetHashCodeElementInit(ElementInit elementInit)
        {
            if (elementInit == null)
            {
                return 0;
            }

            return GetHashCode(
                GetHashCodeSafe(elementInit.AddMethod),
                GetHashCodeExpressionList(elementInit.Arguments));
        }

        private int GetHashCodeBinding(MemberBinding memberBinding)
        {
            if (memberBinding == null)
            {
                return 0;
            }

            switch (memberBinding.BindingType)
            {
                case MemberBindingType.Assignment:
                    return GetHashCodeMemberAssignment((MemberAssignment)memberBinding);
                case MemberBindingType.MemberBinding:
                    return GetHashCodeMemberMemberBinding((MemberMemberBinding)memberBinding);
                case MemberBindingType.ListBinding:
                    return GetHashCodeMemberListBinding((MemberListBinding)memberBinding);
                default:
                    throw new Exception($"Unhandled binding type '{memberBinding.BindingType}'");
            }
        }

        private int GetHashCodeMemberAssignment(MemberAssignment memberAssignment)
        {
            return GetHashCode(
                GetHashCodeSafe(memberAssignment.Member),
                GetHashCodeExpression(memberAssignment.Expression));
        }

        private int GetHashCodeMemberMemberBinding(MemberMemberBinding memberMemberBinding)
        {
            return GetHashCode(
                GetHashCodeSafe(memberMemberBinding.Member),
                GetHashCodeList(memberMemberBinding.Bindings, GetHashCodeBinding));
        }

        private int GetHashCodeMemberListBinding(MemberListBinding memberListBinding)
        {
            return GetHashCode(
                GetHashCodeSafe(memberListBinding.Member),
                GetHashCodeList(memberListBinding.Initializers, GetHashCodeElementInit));
        }

        private int GetHashCodeLabelTarget(LabelTarget labelTarget)
        {
            if (labelTarget == null)
            {
                return 0;
            }

            return GetHashCode(
                GetHashCodeSafe(labelTarget.Type),
                GetHashCodeSafe(labelTarget.Name));
        }
    }
}