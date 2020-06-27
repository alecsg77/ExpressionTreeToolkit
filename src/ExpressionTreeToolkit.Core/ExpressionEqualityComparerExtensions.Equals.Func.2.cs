// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparerExtensions
    {
        /// <summary>Determines whether one LambdaExpression and one <see cref="Expression"/> are equal.</summary>
        /// <param name="target">An [IEqualityComparer](xref:System.Collections.Generic.IEqualityComparer`1)&lt;<see cref="Expression"/>&gt; used to compare the two <see cref="Expression"/>.</param>
        /// <param name="x">The first <see cref="LambdaExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="Expression"/> to compare.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T14">The type of the fourteenth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T15">The type of the fifteenth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T16">The type of the sixteenth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <returns>true if the specified <see cref="Expression"/>s are equal; otherwise, false.</returns>
        public static bool Equals<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
            this IEqualityComparer<Expression> target,
            Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>> x,
            Expression y)
        {
            return target.Equals(x, y);
        }

        /// <summary>Determines whether one LambdaExpression and one <see cref="Expression"/> are equal.</summary>
        /// <param name="target">An [IEqualityComparer](xref:System.Collections.Generic.IEqualityComparer`1)&lt;<see cref="Expression"/>&gt; used to compare the two <see cref="Expression"/>.</param>
        /// <param name="x">The first <see cref="LambdaExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="Expression"/> to compare.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T14">The type of the fourteenth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T15">The type of the fifteenth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <returns>true if the specified <see cref="Expression"/>s are equal; otherwise, false.</returns>
        public static bool Equals<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
            this IEqualityComparer<Expression> target,
            Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>> x, Expression y)
        {
            return target.Equals(x, y);
        }

        /// <summary>Determines whether one LambdaExpression and one <see cref="Expression"/> are equal.</summary>
        /// <param name="target">An [IEqualityComparer](xref:System.Collections.Generic.IEqualityComparer`1)&lt;<see cref="Expression"/>&gt; used to compare the two <see cref="Expression"/>.</param>
        /// <param name="x">The first <see cref="LambdaExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="Expression"/> to compare.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T14">The type of the fourteenth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <returns>true if the specified <see cref="Expression"/>s are equal; otherwise, false.</returns>
        public static bool Equals<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
            this IEqualityComparer<Expression> target,
            Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>> x, Expression y)
        {
            return target.Equals(x, y);
        }

        /// <summary>Determines whether one LambdaExpression and one <see cref="Expression"/> are equal.</summary>
        /// <param name="target">An [IEqualityComparer](xref:System.Collections.Generic.IEqualityComparer`1)&lt;<see cref="Expression"/>&gt; used to compare the two <see cref="Expression"/>.</param>
        /// <param name="x">The first <see cref="LambdaExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="Expression"/> to compare.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <returns>true if the specified <see cref="Expression"/>s are equal; otherwise, false.</returns>
        public static bool Equals<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
            this IEqualityComparer<Expression> target,
            Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>> x, Expression y)
        {
            return target.Equals(x, y);
        }

        /// <summary>Determines whether one LambdaExpression and one <see cref="Expression"/> are equal.</summary>
        /// <param name="target">An [IEqualityComparer](xref:System.Collections.Generic.IEqualityComparer`1)&lt;<see cref="Expression"/>&gt; used to compare the two <see cref="Expression"/>.</param>
        /// <param name="x">The first <see cref="LambdaExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="Expression"/> to compare.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <returns>true if the specified <see cref="Expression"/>s are equal; otherwise, false.</returns>
        public static bool Equals<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
            this IEqualityComparer<Expression> target,
            Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>> x, Expression y)
        {
            return target.Equals(x, y);
        }

        /// <summary>Determines whether one LambdaExpression and one <see cref="Expression"/> are equal.</summary>
        /// <param name="target">An [IEqualityComparer](xref:System.Collections.Generic.IEqualityComparer`1)&lt;<see cref="Expression"/>&gt; used to compare the two <see cref="Expression"/>.</param>
        /// <param name="x">The first <see cref="LambdaExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="Expression"/> to compare.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <returns>true if the specified <see cref="Expression"/>s are equal; otherwise, false.</returns>
        public static bool Equals<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
            this IEqualityComparer<Expression> target,
            Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>> x, Expression y)
        {
            return target.Equals(x, y);
        }

        /// <summary>Determines whether one LambdaExpression and one <see cref="Expression"/> are equal.</summary>
        /// <param name="target">An [IEqualityComparer](xref:System.Collections.Generic.IEqualityComparer`1)&lt;<see cref="Expression"/>&gt; used to compare the two <see cref="Expression"/>.</param>
        /// <param name="x">The first <see cref="LambdaExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="Expression"/> to compare.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <returns>true if the specified <see cref="Expression"/>s are equal; otherwise, false.</returns>
        public static bool Equals<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
            this IEqualityComparer<Expression> target,
            Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>> x, Expression y)
        {
            return target.Equals(x, y);
        }

        /// <summary>Determines whether one LambdaExpression and one <see cref="Expression"/> are equal.</summary>
        /// <param name="target">An [IEqualityComparer](xref:System.Collections.Generic.IEqualityComparer`1)&lt;<see cref="Expression"/>&gt; used to compare the two <see cref="Expression"/>.</param>
        /// <param name="x">The first <see cref="LambdaExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="Expression"/> to compare.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <returns>true if the specified <see cref="Expression"/>s are equal; otherwise, false.</returns>
        public static bool Equals<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
            this IEqualityComparer<Expression> target,
            Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>> x, Expression y)
        {
            return target.Equals(x, y);
        }

        /// <summary>Determines whether one LambdaExpression and one <see cref="Expression"/> are equal.</summary>
        /// <param name="target">An [IEqualityComparer](xref:System.Collections.Generic.IEqualityComparer`1)&lt;<see cref="Expression"/>&gt; used to compare the two <see cref="Expression"/>.</param>
        /// <param name="x">The first <see cref="LambdaExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="Expression"/> to compare.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <returns>true if the specified <see cref="Expression"/>s are equal; otherwise, false.</returns>
        public static bool Equals<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
            this IEqualityComparer<Expression> target, Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>> x,
            Expression y)
        {
            return target.Equals(x, y);
        }

        /// <summary>Determines whether one LambdaExpression and one <see cref="Expression"/> are equal.</summary>
        /// <param name="target">An [IEqualityComparer](xref:System.Collections.Generic.IEqualityComparer`1)&lt;<see cref="Expression"/>&gt; used to compare the two <see cref="Expression"/>.</param>
        /// <param name="x">The first <see cref="LambdaExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="Expression"/> to compare.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <returns>true if the specified <see cref="Expression"/>s are equal; otherwise, false.</returns>
        public static bool Equals<T1, T2, T3, T4, T5, T6, T7, TResult>(this IEqualityComparer<Expression> target,
            Expression<Func<T1, T2, T3, T4, T5, T6, T7, TResult>> x, Expression y)
        {
            return target.Equals(x, y);
        }

        /// <summary>Determines whether one LambdaExpression and one <see cref="Expression"/> are equal.</summary>
        /// <param name="target">An [IEqualityComparer](xref:System.Collections.Generic.IEqualityComparer`1)&lt;<see cref="Expression"/>&gt; used to compare the two <see cref="Expression"/>.</param>
        /// <param name="x">The first <see cref="LambdaExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="Expression"/> to compare.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <returns>true if the specified <see cref="Expression"/>s are equal; otherwise, false.</returns>
        public static bool Equals<T1, T2, T3, T4, T5, T6, TResult>(this IEqualityComparer<Expression> target,
            Expression<Func<T1, T2, T3, T4, T5, T6, TResult>> x, Expression y)
        {
            return target.Equals(x, y);
        }

        /// <summary>Determines whether one LambdaExpression and one <see cref="Expression"/> are equal.</summary>
        /// <param name="target">An [IEqualityComparer](xref:System.Collections.Generic.IEqualityComparer`1)&lt;<see cref="Expression"/>&gt; used to compare the two <see cref="Expression"/>.</param>
        /// <param name="x">The first <see cref="LambdaExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="Expression"/> to compare.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <returns>true if the specified <see cref="Expression"/>s are equal; otherwise, false.</returns>
        public static bool Equals<T1, T2, T3, T4, T5, TResult>(this IEqualityComparer<Expression> target,
            Expression<Func<T1, T2, T3, T4, T5, TResult>> x, Expression y)
        {
            return target.Equals(x, y);
        }

        /// <summary>Determines whether one LambdaExpression and one <see cref="Expression"/> are equal.</summary>
        /// <param name="target">An [IEqualityComparer](xref:System.Collections.Generic.IEqualityComparer`1)&lt;<see cref="Expression"/>&gt; used to compare the two <see cref="Expression"/>.</param>
        /// <param name="x">The first <see cref="LambdaExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="Expression"/> to compare.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <returns>true if the specified <see cref="Expression"/>s are equal; otherwise, false.</returns>
        public static bool Equals<T1, T2, T3, T4, TResult>(this IEqualityComparer<Expression> target,
            Expression<Func<T1, T2, T3, T4, TResult>> x, Expression y)
        {
            return target.Equals(x, y);
        }

        /// <summary>Determines whether one LambdaExpression and one <see cref="Expression"/> are equal.</summary>
        /// <param name="target">An [IEqualityComparer](xref:System.Collections.Generic.IEqualityComparer`1)&lt;<see cref="Expression"/>&gt; used to compare the two <see cref="Expression"/>.</param>
        /// <param name="x">The first <see cref="LambdaExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="Expression"/> to compare.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <returns>true if the specified <see cref="Expression"/>s are equal; otherwise, false.</returns>
        public static bool Equals<T1, T2, T3, TResult>(this IEqualityComparer<Expression> target,
            Expression<Func<T1, T2, T3, TResult>> x, Expression y)
        {
            return target.Equals(x, y);
        }

        /// <summary>Determines whether one LambdaExpression and one <see cref="Expression"/> are equal.</summary>
        /// <param name="target">An [IEqualityComparer](xref:System.Collections.Generic.IEqualityComparer`1)&lt;<see cref="Expression"/>&gt; used to compare the two <see cref="Expression"/>.</param>
        /// <param name="x">The first <see cref="LambdaExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="Expression"/> to compare.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <returns>true if the specified <see cref="Expression"/>s are equal; otherwise, false.</returns>
        public static bool Equals<T1, T2, TResult>(this IEqualityComparer<Expression> target,
            Expression<Func<T1, T2, TResult>> x, Expression y)
        {
            return target.Equals(x, y);
        }

        /// <summary>Determines whether one LambdaExpression and one <see cref="Expression"/> are equal.</summary>
        /// <param name="target">An [IEqualityComparer](xref:System.Collections.Generic.IEqualityComparer`1)&lt;<see cref="Expression"/>&gt; used to compare the two <see cref="Expression"/>.</param>
        /// <param name="x">The first <see cref="LambdaExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="Expression"/> to compare.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <returns>true if the specified <see cref="Expression"/>s are equal; otherwise, false.</returns>
        public static bool Equals<T1, TResult>(this IEqualityComparer<Expression> target,
            Expression<Func<T1, TResult>> x, Expression y)
        {
            return target.Equals(x, y);
        }

        /// <summary>Determines whether one LambdaExpression and one <see cref="Expression"/> are equal.</summary>
        /// <param name="target">An [IEqualityComparer](xref:System.Collections.Generic.IEqualityComparer`1)&lt;<see cref="Expression"/>&gt; used to compare the two <see cref="Expression"/>.</param>
        /// <param name="x">The first <see cref="LambdaExpression"/> to compare.</param>
        /// <param name="y">The second <see cref="Expression"/> to compare.</param>
        /// <typeparam name="TResult">The type of the return value of the method that this <see cref="LambdaExpression"/> encapsulates.</typeparam>
        /// <returns>true if the specified <see cref="Expression"/>s are equal; otherwise, false.</returns>
        public static bool Equals<TResult>(this IEqualityComparer<Expression> target, Expression<Func<TResult>> x,
            Expression y)
        {
            return target.Equals(x, y);
        }
    }
}