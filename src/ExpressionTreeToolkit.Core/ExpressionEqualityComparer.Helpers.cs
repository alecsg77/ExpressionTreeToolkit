// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Diagnostics.CodeAnalysis;

#if JETBRAINS_ANNOTATIONS
using AllowNullAttribute = JetBrains.Annotations.CanBeNullAttribute;
using DisallowNullAttribute = JetBrains.Annotations.NotNullAttribute;
using AllowItemNullAttribute = JetBrains.Annotations.ItemCanBeNullAttribute;
#endif

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer
    {
        /// <summary>Determines whether two collections are equal by comparing the nodes.</summary>
        /// <param name="first">A collection of <see cref="Expression"/> to compare.</param>
        /// <param name="second">A collection of <see cref="Expression"/> to compare to the first sequence.</param>
        /// <param name="context"></param>
        /// <returns>true if the two nodes sequences are of equal length and their corresponding elements are equal; otherwise, false.</returns>
        protected bool Equals(
            [AllowNull][AllowItemNull] ReadOnlyCollection<Expression?>? first,
            [AllowNull][AllowItemNull] ReadOnlyCollection<Expression?>? second,
            [DisallowNull] ComparisonContext context
        )
        {
            if (ReferenceEquals(first, second))
            {
                return true;
            }

            if (first == null || second == null)
            {
                return false;
            }

            using (var e1 = first.GetEnumerator())
            using (var e2 = second.GetEnumerator())
            {
                while (e1.MoveNext())
                {
                    if (!e2.MoveNext())
                    {
                        return false;
                    }

                    if (!Equals(e1.Current, e2.Current, context))
                    {
                        return false;
                    }
                }

                if (e2.MoveNext())
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>Determines whether two sequences are equal by comparing the elements by using the default equality comparer for their type.</summary>
        /// <param name="first">An <see cref="ReadOnlyCollection{T}"></see> to compare to second.</param>
        /// <param name="second">An <see cref="ReadOnlyCollection{T}"></see> to compare to the first sequence.</param>
        /// <param name="context"></param>
        /// <typeparam name="T">The type of the elements of the input sequences.</typeparam>
        /// <returns>true if the two source sequences are of equal length and their corresponding elements are equal according to the default equality comparer for their type; otherwise, false.</returns>
        protected bool Equals<T>(
            [AllowNull, AllowItemNull] ReadOnlyCollection<T?>? first,
            [AllowNull, AllowItemNull] ReadOnlyCollection<T?>? second,
            [DisallowNull] ComparisonContext context
        )
            where T : class
        {
            if (ReferenceEquals(first, second))
            {
                return true;
            }

            if (first == null || second == null)
            {
                return false;
            }

            return first.SequenceEqual(second);
        }

        /// <summary>Determines whether two sequences are equal by comparing their elements by using a specified <see cref="System.Func{T,T,bool}"></see>.</summary>
        /// <param name="first">An <see cref="ReadOnlyCollection{T}"></see> to compare to second.</param>
        /// <param name="second">An <see cref="ReadOnlyCollection{T}"></see> to compare to the first sequence.</param>
        /// <param name="equalityComparer">An <see cref="System.Func{T,T,bool}"></see> to use to compare elements.</param>
        /// <param name="context"></param>
        /// <typeparam name="T">The type of the elements of the input sequences.</typeparam>
        /// <returns>true if the two source sequences are of equal length and their corresponding elements compare equal according to <paramref name="equalityComparer">equality comparer</paramref>; otherwise, false.</returns>
        protected bool Equals<T>(
            [AllowNull][AllowItemNull] ReadOnlyCollection<T?>? first,
            [AllowNull][AllowItemNull] ReadOnlyCollection<T?>? second,
            Func<T, T, ComparisonContext, bool>? equalityComparer,
            [DisallowNull] ComparisonContext context
        )
            where T : class
        {
            if (equalityComparer == null) throw new ArgumentNullException(nameof(equalityComparer));

            if (ReferenceEquals(first, second))
            {
                return true;
            }

            if (first == null || second == null)
            {
                return false;
            }

            using (var e1 = first.GetEnumerator())
            using (var e2 = second.GetEnumerator())
            {
                while (e1.MoveNext())
                {
                    if (!e2.MoveNext())
                    {
                        return false;
                    }

                    var x = e1.Current;
                    var y = e2.Current;

                    if (ReferenceEquals(x, y))
                    {
                        return true;
                    }

                    if (x == null || y == null)
                    {
                        return false;
                    }

                    if (!equalityComparer(x, y, context))
                    {
                        return false;
                    }
                }

                if (e2.MoveNext())
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>Determines whether the children of the two ElementInit are equal.</summary>
        /// <param name="x">The first ElementInit to compare.</param>
        /// <param name="y">The second ElementInit to compare.</param>
        /// <param name="context"></param>
        /// <returns>true if the specified ElementInit are equal; otherwise, false.</returns>
        protected virtual bool EqualsElementInit([AllowNull] ElementInit? x, [AllowNull] ElementInit? y, [DisallowNull] ComparisonContext context)
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
                && Equals(x.Arguments, y.Arguments, context);
        }

        /// <summary>Determines whether the children of the two MemberBinding are equal.</summary>
        /// <param name="x">The first MemberBinding to compare.</param>
        /// <param name="y">The second MemberBinding to compare.</param>
        /// <param name="context"></param>
        /// <returns>true if the specified MemberBinding are equal; otherwise, false.</returns>
        protected virtual bool EqualsMemberBinding([AllowNull] MemberBinding? x, [AllowNull] MemberBinding? y, [DisallowNull] ComparisonContext context)
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
                    return EqualsMemberAssignment((MemberAssignment)x, (MemberAssignment)y, context);
                case MemberBindingType.MemberBinding:
                    return EqualsMemberMemberBinding((MemberMemberBinding)x, (MemberMemberBinding)y, context);
                case MemberBindingType.ListBinding:
                    return EqualsMemberListBinding((MemberListBinding)x, (MemberListBinding)y, context);
                default:
                    throw new Exception($"Unhandled binding type '{x.BindingType}'");
            }
        }

        /// <summary>Determines whether the children of the two MemberAssignment are equal.</summary>
        /// <param name="x">The first MemberAssignment to compare.</param>
        /// <param name="y">The second MemberAssignment to compare.</param>
        /// <param name="context"></param>
        /// <returns>true if the specified MemberAssignment are equal; otherwise, false.</returns>
        protected virtual bool EqualsMemberAssignment([DisallowNull] MemberAssignment x, [DisallowNull] MemberAssignment y, [DisallowNull] ComparisonContext context)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            return Equals(x.Member, y.Member)
                   && Equals(x.Expression, y.Expression, context);
        }

        /// <summary>Determines whether the children of the two MemberMemberBinding are equal.</summary>
        /// <param name="x">The first MemberMemberBinding to compare.</param>
        /// <param name="y">The second MemberMemberBinding to compare.</param>
        /// <param name="context"></param>
        /// <returns>true if the specified MemberMemberBinding are equal; otherwise, false.</returns>
        protected virtual bool EqualsMemberMemberBinding([DisallowNull] MemberMemberBinding x, [DisallowNull] MemberMemberBinding y, [DisallowNull] ComparisonContext context)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            return Equals(x.Member, y.Member)
                   && Equals(x.Bindings, y.Bindings, EqualsMemberBinding, context);
        }

        /// <summary>Determines whether the children of the two MemberListBinding are equal.</summary>
        /// <param name="x">The first MemberListBinding to compare.</param>
        /// <param name="y">The second MemberListBinding to compare.</param>
        /// <param name="context"></param>
        /// <returns>true if the specified MemberListBinding are equal; otherwise, false.</returns>
        protected virtual bool EqualsMemberListBinding([DisallowNull] MemberListBinding x, [DisallowNull] MemberListBinding y, [DisallowNull] ComparisonContext context)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            return Equals(x.Member, y.Member)
                   && Equals(x.Initializers, y.Initializers, EqualsElementInit, context);
        }

        /// <summary>Determines whether the children of the two LabelTarget are equal.</summary>
        /// <param name="x">The first LabelTarget to compare.</param>
        /// <param name="y">The second LabelTarget to compare.</param>
        /// <param name="context"></param>
        /// <returns>true if the specified LabelTarget are equal; otherwise, false.</returns>
        protected virtual bool EqualsLabelTarget([AllowNull] LabelTarget? x, [AllowNull] LabelTarget? y, [DisallowNull] ComparisonContext context)
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
                   && Equals(x.Name, y.Name)
                   && context.VerifyLabelTarget(x, y);
            ;
        }

        private static int GetDefaultHashCode<T>([AllowNull] T? obj)
            where T : class
        {
            return obj != null ? EqualityComparer<T>.Default.GetHashCode(obj) : 0;
        }

        private static int GetHashCode(int h1, int h2)
        {
            unchecked
            {
                return ((h1 << 5) + h1) ^ h2;
            }
        }

        private static int GetHashCode(int h1, int h2, int h3)
        {
            return GetHashCode(GetHashCode(h1, h2), h3);
        }

        private static int GetHashCode(int h1, int h2, int h3, int h4)
        {
            return GetHashCode(GetHashCode(GetHashCode(h1, h2), h3), h4);
        }

        private static int GetHashCode(int h1, params int[] args)
        {
            return args.Aggregate(h1, GetHashCode);
        }

        /// <summary>Computes the hash of a sequence of <see cref="Expression"/> nodes.</summary>
        /// <param name="nodes">A sequence of <see cref="Expression"/> nodes to calculate the hash of.</param>
        /// <returns>The hash of the sequence of nodes.</returns>
        protected int GetHashCode([AllowNull, AllowItemNull] ReadOnlyCollection<Expression?>? nodes)
        {
            if (nodes == null)
                return 0;

            return nodes
                .Select(GetHashCode)
                .DefaultIfEmpty()
                .Aggregate(GetHashCode);
        }

        /// <summary>Computes the hash of a sequence of values by using the default equality comparer for their type.</summary>
        /// <param name="values">A sequence of values to calculate the hash of.</param>
        /// <typeparam name="T">The type of the elements of values.</typeparam>
        /// <returns>The hash of the sequence of values.</returns>
        protected int GetHashCode<T>([AllowNull, AllowItemNull] ReadOnlyCollection<T?>? values)
            where T : class
        {
            if (values == null)
                return 0;

            return values
                .Select(GetDefaultHashCode)
                .DefaultIfEmpty()
                .Aggregate(GetHashCode);
        }

        /// <summary>Computes the hash of a sequence of values by using a specified <see cref="System.Func{T,int}"></see>.</summary>
        /// <param name="values">A sequence of values to calculate the hash of.</param>
        /// <param name="getHashCode">An <see cref="System.Func{T,int}"></see> to use to computes the hash of elements.</param>
        /// <typeparam name="T">The type of the elements of values.</typeparam>
        /// <returns>The hash of the sequence of values.</returns>
        protected int GetHashCode<T>([AllowNull, AllowItemNull] ReadOnlyCollection<T?>? values, Func<T, int>? getHashCode)
            where T : class
        {
            if (values == null)
                return 0;

            if (getHashCode == null)
            {
                getHashCode = GetDefaultHashCode;
            }

            return values
                .Select(x => x != null ? getHashCode(x) : 0)
                .DefaultIfEmpty()
                .Aggregate(GetHashCode);
        }

        /// <summary>Gets the hash code for the specified ElementInit.</summary>
        /// <param name="elementInit">The ElementInit for which to get a hash code.</param>
        /// <returns>A hash code for the specified ElementInit.</returns>
        protected virtual int GetHashCodeElementInit([AllowNull] ElementInit? elementInit)
        {
            if (elementInit == null)
            {
                return 0;
            }

            return GetHashCode(
                GetDefaultHashCode(elementInit.AddMethod),
                GetHashCode(elementInit.Arguments));
        }

        /// <summary>Gets the hash code for the specified MemberBinding.</summary>
        /// <param name="memberBinding">The MemberBinding for which to get a hash code.</param>
        /// <returns>A hash code for the specified MemberBinding.</returns>
        protected virtual int GetHashCodeMemberBinding([AllowNull] MemberBinding? memberBinding)
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

        /// <summary>Gets the hash code for the specified MemberAssignment.</summary>
        /// <param name="memberAssignment">The MemberAssignment for which to get a hash code.</param>
        /// <returns>A hash code for the specified MemberAssignment.</returns>
        protected virtual int GetHashCodeMemberAssignment([DisallowNull] MemberAssignment memberAssignment)
        {
            if (memberAssignment == null) throw new ArgumentNullException(nameof(memberAssignment));
            return GetHashCode(
                GetDefaultHashCode(memberAssignment.Member),
                GetHashCode(memberAssignment.Expression));
        }

        /// <summary>Gets the hash code for the specified MemberMemberBinding.</summary>
        /// <param name="memberMemberBinding">The MemberMemberBinding for which to get a hash code.</param>
        /// <returns>A hash code for the specified MemberMemberBinding.</returns>
        protected virtual int GetHashCodeMemberMemberBinding([DisallowNull] MemberMemberBinding memberMemberBinding)
        {
            if (memberMemberBinding == null) throw new ArgumentNullException(nameof(memberMemberBinding));
            return GetHashCode(
                GetDefaultHashCode(memberMemberBinding.Member),
                GetHashCode(memberMemberBinding.Bindings, GetHashCodeMemberBinding));
        }

        /// <summary>Gets the hash code for the specified MemberListBinding.</summary>
        /// <param name="memberListBinding">The MemberListBinding for which to get a hash code.</param>
        /// <returns>A hash code for the specified MemberListBinding.</returns>
        protected virtual int GetHashCodeMemberListBinding([DisallowNull] MemberListBinding memberListBinding)
        {
            if (memberListBinding == null) throw new ArgumentNullException(nameof(memberListBinding));
            return GetHashCode(
                GetDefaultHashCode(memberListBinding.Member),
                GetHashCode(memberListBinding.Initializers, GetHashCodeElementInit));
        }

        /// <summary>Gets the hash code for the specified LabelTarget.</summary>
        /// <param name="labelTarget">The LabelTarget for which to get a hash code.</param>
        /// <returns>A hash code for the specified LabelTarget.</returns>
        protected virtual int GetHashCodeLabelTarget([AllowNull] LabelTarget? labelTarget)
        {
            if (labelTarget == null)
            {
                return 0;
            }

            return GetHashCode(
                GetDefaultHashCode(labelTarget.Type),
                GetDefaultHashCode(labelTarget.Name));
        }
    }
}