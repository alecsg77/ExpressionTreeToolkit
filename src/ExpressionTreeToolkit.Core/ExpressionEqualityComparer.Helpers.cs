﻿// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using JetBrains.Annotations;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer
    {
        /// <summary>Determines whether two collections are equal by comparing the nodes.</summary>
        /// <param name="first">A collection of Expression to compare.</param>
        /// <param name="second">A collection of Expression to compare to the first sequence.</param>
        /// <returns>true if the two nodes sequences are of equal length and their corresponding elements are equal; otherwise, false.</returns>
        protected bool Equals([CanBeNull] [ItemCanBeNull] ReadOnlyCollection<Expression> first, [CanBeNull] [ItemCanBeNull] ReadOnlyCollection<Expression> second)
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

                    if (!Equals(e1.Current, e2.Current))
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
        /// <param name="first">An <see cref="T:System.Collections.ObjectModel.ReadOnlyCollection`1"></see> to compare to second.</param>
        /// <param name="second">An <see cref="T:System.Collections.ObjectModel.ReadOnlyCollection`1"></see> to compare to the first sequence.</param>
        /// <typeparam name="T">The type of the elements of the input sequences.</typeparam>
        /// <returns>true if the two source sequences are of equal length and their corresponding elements are equal according to the default equality comparer for their type; otherwise, false.</returns>
        protected bool Equals<T>([CanBeNull] [ItemCanBeNull] ReadOnlyCollection<T> first, [CanBeNull] [ItemCanBeNull] ReadOnlyCollection<T> second)
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

        /// <summary>Determines whether two sequences are equal by comparing their elements by using a specified <see cref="T:System.Func{T,T,bool}"></see>.</summary>
        /// <param name="first">An <see cref="T:System.Collections.ObjectModel.ReadOnlyCollection`1"></see> to compare to second.</param>
        /// <param name="second">An <see cref="T:System.Collections.ObjectModel.ReadOnlyCollection`1"></see> to compare to the first sequence.</param>
        /// <param name="equalityComparer">An <see cref="T:System.Func{T,T,bool}"></see> to use to compare elements.</param>
        /// <typeparam name="T">The type of the elements of the input sequences.</typeparam>
        /// <returns>true if the two source sequences are of equal length and their corresponding elements compare equal according to <paramref name="equalityComparer">equality comparer</paramref>; otherwise, false.</returns>
        protected bool Equals<T>([CanBeNull] [ItemCanBeNull] ReadOnlyCollection<T> first, [CanBeNull] [ItemCanBeNull] ReadOnlyCollection<T> second, [CanBeNull] Func<T, T, bool> equalityComparer)
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

                    if (!equalityComparer(x, y))
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
        /// <returns>true if the specified ElementInit are equal; otherwise, false.</returns>
        protected virtual bool EqualsElementInit([CanBeNull] ElementInit x, [CanBeNull] ElementInit y)
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
                && Equals(x.Arguments, y.Arguments);
        }

        /// <summary>Determines whether the children of the two MemberBinding are equal.</summary>
        /// <param name="x">The first MemberBinding to compare.</param>
        /// <param name="y">The second MemberBinding to compare.</param>
        /// <returns>true if the specified MemberBinding are equal; otherwise, false.</returns>
        protected virtual bool EqualsMemberBinding([CanBeNull] MemberBinding x, [CanBeNull] MemberBinding y)
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

        /// <summary>Determines whether the children of the two MemberAssignment are equal.</summary>
        /// <param name="x">The first MemberAssignment to compare.</param>
        /// <param name="y">The second MemberAssignment to compare.</param>
        /// <returns>true if the specified MemberAssignment are equal; otherwise, false.</returns>
        protected virtual bool EqualsMemberAssignment([NotNull] MemberAssignment x, [NotNull] MemberAssignment y)
        {
            return Equals(x.Member, y.Member)
                   && Equals(x.Expression, y.Expression);
        }

        /// <summary>Determines whether the children of the two MemberMemberBinding are equal.</summary>
        /// <param name="x">The first MemberMemberBinding to compare.</param>
        /// <param name="y">The second MemberMemberBinding to compare.</param>
        /// <returns>true if the specified MemberMemberBinding are equal; otherwise, false.</returns>
        protected virtual bool EqualsMemberMemberBinding([NotNull] MemberMemberBinding x, [NotNull] MemberMemberBinding y)
        {
            return Equals(x.Member, y.Member)
                   && Equals(x.Bindings, y.Bindings, EqualsMemberBinding);
        }

        /// <summary>Determines whether the children of the two MemberListBinding are equal.</summary>
        /// <param name="x">The first MemberListBinding to compare.</param>
        /// <param name="y">The second MemberListBinding to compare.</param>
        /// <returns>true if the specified MemberListBinding are equal; otherwise, false.</returns>
        protected virtual bool EqualsMemberListBinding([NotNull] MemberListBinding x, [NotNull] MemberListBinding y)
        {
            return Equals(x.Member, y.Member)
                   && Equals(x.Initializers, y.Initializers, EqualsElementInit);
        }

        /// <summary>Determines whether the children of the two LabelTarget are equal.</summary>
        /// <param name="x">The first LabelTarget to compare.</param>
        /// <param name="y">The second LabelTarget to compare.</param>
        /// <returns>true if the specified LabelTarget are equal; otherwise, false.</returns>
        protected virtual bool EqualsLabelTarget([CanBeNull] LabelTarget x, [CanBeNull] LabelTarget y)
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

        private static int GetDefaultHashCode<T>([CanBeNull] T obj)
        {
            return EqualityComparer<T>.Default.GetHashCode(obj);
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

        /// <summary>Computes the hash of a sequence of <see cref="T:Expression"></see> nodes.</summary>
        /// <param name="nodes">A sequence of <see cref="T:Expression"></see> nodes to calculate the hash of.</param>
        /// <returns>The hash of the sequence of nodes.</returns>
        protected int GetHashCode([CanBeNull] [ItemCanBeNull] ReadOnlyCollection<Expression> nodes)
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
        protected int GetHashCode<T>([CanBeNull] [ItemCanBeNull] ReadOnlyCollection<T> values)
        {
            if (values == null)
                return 0;

            return values
                .Select(GetDefaultHashCode)
                .DefaultIfEmpty()
                .Aggregate(GetHashCode);
        }

        /// <summary>Computes the hash of a sequence of values by using a specified <see cref="T:System.Func{T,int}"></see>.</summary>
        /// <param name="values">A sequence of values to calculate the hash of.</param>
        /// <param name="getHashCode">An <see cref="T:System.Func{T,int}"></see> to use to computes the hash of elements.</param>
        /// <typeparam name="T">The type of the elements of values.</typeparam>
        /// <returns>The hash of the sequence of values.</returns>
        protected int GetHashCode<T>([ItemCanBeNull] [CanBeNull] ReadOnlyCollection<T> values, [CanBeNull] Func<T, int> getHashCode)
            where T: class
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
        protected virtual int GetHashCodeElementInit([CanBeNull] ElementInit elementInit)
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
        protected virtual int GetHashCodeMemberBinding([CanBeNull] MemberBinding memberBinding)
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
        protected virtual int GetHashCodeMemberAssignment([NotNull] MemberAssignment memberAssignment)
        {
            return GetHashCode(
                GetDefaultHashCode(memberAssignment.Member),
                GetHashCode(memberAssignment.Expression));
        }

        /// <summary>Gets the hash code for the specified MemberMemberBinding.</summary>
        /// <param name="memberMemberBinding">The MemberMemberBinding for which to get a hash code.</param>
        /// <returns>A hash code for the specified MemberMemberBinding.</returns>
        protected virtual int GetHashCodeMemberMemberBinding([NotNull] MemberMemberBinding memberMemberBinding)
        {
            return GetHashCode(
                GetDefaultHashCode(memberMemberBinding.Member),
                GetHashCode(memberMemberBinding.Bindings, GetHashCodeMemberBinding));
        }

        /// <summary>Gets the hash code for the specified MemberListBinding.</summary>
        /// <param name="memberListBinding">The MemberListBinding for which to get a hash code.</param>
        /// <returns>A hash code for the specified MemberListBinding.</returns>
        protected virtual int GetHashCodeMemberListBinding([NotNull] MemberListBinding memberListBinding)
        {
            return GetHashCode(
                GetDefaultHashCode(memberListBinding.Member),
                GetHashCode(memberListBinding.Initializers, GetHashCodeElementInit));
        }

        /// <summary>Gets the hash code for the specified LabelTarget.</summary>
        /// <param name="labelTarget">The LabelTarget for which to get a hash code.</param>
        /// <returns>A hash code for the specified LabelTarget.</returns>
        protected virtual int GetHashCodeLabelTarget([CanBeNull] LabelTarget labelTarget)
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