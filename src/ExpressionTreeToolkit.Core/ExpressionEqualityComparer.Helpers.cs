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

        private bool EqualsElementInit(ElementInit ex, ElementInit ey)
        {
            if (ReferenceEquals(ex, ey))
            {
                return true;
            }

            if (ex == null || ey == null)
            {
                return false;
            }

            return Equals(ex.AddMethod, ey.AddMethod) && EqualsExpressionList(ex.Arguments, ey.Arguments);
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
                    return EqualsMemberAssignment((MemberAssignment) x, (MemberAssignment) y);
                case MemberBindingType.MemberBinding:
                    return EqualsMemberMemberBinding((MemberMemberBinding) x, (MemberMemberBinding) y);
                case MemberBindingType.ListBinding:
                    return EqualsMemberListBinding((MemberListBinding) x, (MemberListBinding) y);
                default:
                    throw new Exception($"Unhandled binding type '{x.BindingType}'");
            }
        }

        private bool EqualsMemberAssignment(MemberAssignment x, MemberAssignment y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

            return Equals(x.Member, y.Member)
                   && Equals(x.Expression, y.Expression);
        }

        private bool EqualsMemberMemberBinding(MemberMemberBinding x, MemberMemberBinding y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

            return Equals(x.Member, y.Member)
                   && EqualsList(x.Bindings, y.Bindings, EqualsBinding);
        }

        private bool EqualsMemberListBinding(MemberListBinding x, MemberListBinding y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

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
                   && x.Name == y.Name;
        }

        private int GetHashCode(int h1, int h2)
        {
            unchecked
            {
                return ((h1 << 5) + h1) ^ h2;
            }
        }

        private IEnumerable<int> GetHashElements(object element)
        {
            if (element == null)
            {
                return Enumerable.Empty<int>();
            }

            if (element is IEnumerable<int> funcs)
            {
                return funcs;
            }

            if (element is IEnumerable<object> objects)
            {
                return GetHashElements(objects);
            }

            if (element is Expression expression)
            {
                return GetHashElements(expression);
            }

            return Enumerable.Repeat(element.GetHashCode(), 1);
        }

        private IEnumerable<int> GetHashElements(Expression expression)
        {
            if (expression == null)
            {
                return Enumerable.Empty<int>();
            }

            return Enumerable.Repeat(GetHashCode(expression), 1);
        }

        private IEnumerable<int> GetHashElementsLabelTarget(LabelTarget labelTarget)
        {
            if (labelTarget == null)
            {
                return Enumerable.Empty<int>();
            }

            return GetHashElements(labelTarget.Name, labelTarget.Type);
        }

        private IEnumerable<int> GetHashElements(IEnumerable<Expression> objects)
        {
            return objects.Where(x => x != null).SelectMany(GetHashElements);
        }

        private IEnumerable<int> GetHashElements(IEnumerable<object> objects)
        {
            return objects.Where(x => x != null).SelectMany(GetHashElements);
        }

        private IEnumerable<int> GetHashElements(params object[] elements)
        {
            return GetHashElements(elements.AsEnumerable());
        }
    }
}