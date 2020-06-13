// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparerExtensions
    {
        /// <summary>Determines whether two LambdaExpression are equal.</summary>
        /// <param name="target">An <see cref="IEqualityComparer{Expression}"/> used to compare the two LambdaExpression.</param>
        /// <param name="x">The first LambdaExpression to compare.</param>
        /// <param name="y">The second LambdaExpression to compare.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T14">The type of the fourteenth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T15">The type of the fifteenth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T16">The type of the sixteenth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <returns>true if the specified LambdaExpressions are equal; otherwise, false.</returns>
        public static bool Equals<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            this IEqualityComparer<Expression> target,
            Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> x,
            Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> y)
        {
            return target.Equals(x, y);
        }

        /// <summary>Determines whether two LambdaExpression are equal.</summary>
        /// <param name="target">An <see cref="IEqualityComparer{Expression}"/> used to compare the two LambdaExpression.</param>
        /// <param name="x">The first LambdaExpression to compare.</param>
        /// <param name="y">The second LambdaExpression to compare.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T14">The type of the fourteenth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T15">The type of the fifteenth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <returns>true if the specified LambdaExpressions are equal; otherwise, false.</returns>
        public static bool Equals<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
            this IEqualityComparer<Expression> target,
            Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> x,
            Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> y)
        {
            return target.Equals(x, y);
        }

        /// <summary>Determines whether two LambdaExpression are equal.</summary>
        /// <param name="target">An <see cref="IEqualityComparer{Expression}"/> used to compare the two LambdaExpression.</param>
        /// <param name="x">The first LambdaExpression to compare.</param>
        /// <param name="y">The second LambdaExpression to compare.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T14">The type of the fourteenth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <returns>true if the specified LambdaExpressions are equal; otherwise, false.</returns>
        public static bool Equals<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
            this IEqualityComparer<Expression> target,
            Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> x,
            Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> y)
        {
            return target.Equals(x, y);
        }

        /// <summary>Determines whether two LambdaExpression are equal.</summary>
        /// <param name="target">An <see cref="IEqualityComparer{Expression}"/> used to compare the two LambdaExpression.</param>
        /// <param name="x">The first LambdaExpression to compare.</param>
        /// <param name="y">The second LambdaExpression to compare.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <returns>true if the specified LambdaExpressions are equal; otherwise, false.</returns>
        public static bool Equals<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
            this IEqualityComparer<Expression> target,
            Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> x,
            Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> y)
        {
            return target.Equals(x, y);
        }

        /// <summary>Determines whether two LambdaExpression are equal.</summary>
        /// <param name="target">An <see cref="IEqualityComparer{Expression}"/> used to compare the two LambdaExpression.</param>
        /// <param name="x">The first LambdaExpression to compare.</param>
        /// <param name="y">The second LambdaExpression to compare.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <returns>true if the specified LambdaExpressions are equal; otherwise, false.</returns>
        public static bool Equals<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
            this IEqualityComparer<Expression> target,
            Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> x,
            Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> y)
        {
            return target.Equals(x, y);
        }

        /// <summary>Determines whether two LambdaExpression are equal.</summary>
        /// <param name="target">An <see cref="IEqualityComparer{Expression}"/> used to compare the two LambdaExpression.</param>
        /// <param name="x">The first LambdaExpression to compare.</param>
        /// <param name="y">The second LambdaExpression to compare.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T11">The type of the eleventh parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <returns>true if the specified LambdaExpressions are equal; otherwise, false.</returns>
        public static bool Equals<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
            this IEqualityComparer<Expression> target,
            Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> x,
            Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> y)
        {
            return target.Equals(x, y);
        }

        /// <summary>Determines whether two LambdaExpression are equal.</summary>
        /// <param name="target">An <see cref="IEqualityComparer{Expression}"/> used to compare the two LambdaExpression.</param>
        /// <param name="x">The first LambdaExpression to compare.</param>
        /// <param name="y">The second LambdaExpression to compare.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <returns>true if the specified LambdaExpressions are equal; otherwise, false.</returns>
        public static bool Equals<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
            this IEqualityComparer<Expression> target, Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> x,
            Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> y)
        {
            return target.Equals(x, y);
        }

        /// <summary>Determines whether two LambdaExpression are equal.</summary>
        /// <param name="target">An <see cref="IEqualityComparer{Expression}"/> used to compare the two LambdaExpression.</param>
        /// <param name="x">The first LambdaExpression to compare.</param>
        /// <param name="y">The second LambdaExpression to compare.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <returns>true if the specified LambdaExpressions are equal; otherwise, false.</returns>
        public static bool Equals<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IEqualityComparer<Expression> target,
            Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> x,
            Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> y)
        {
            return target.Equals(x, y);
        }

        /// <summary>Determines whether two LambdaExpression are equal.</summary>
        /// <param name="target">An <see cref="IEqualityComparer{Expression}"/> used to compare the two LambdaExpression.</param>
        /// <param name="x">The first LambdaExpression to compare.</param>
        /// <param name="y">The second LambdaExpression to compare.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <returns>true if the specified LambdaExpressions are equal; otherwise, false.</returns>
        public static bool Equals<T1, T2, T3, T4, T5, T6, T7, T8>(this IEqualityComparer<Expression> target,
            Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8>> x, Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8>> y)
        {
            return target.Equals(x, y);
        }

        /// <summary>Determines whether two LambdaExpression are equal.</summary>
        /// <param name="target">An <see cref="IEqualityComparer{Expression}"/> used to compare the two LambdaExpression.</param>
        /// <param name="x">The first LambdaExpression to compare.</param>
        /// <param name="y">The second LambdaExpression to compare.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <returns>true if the specified LambdaExpressions are equal; otherwise, false.</returns>
        public static bool Equals<T1, T2, T3, T4, T5, T6, T7>(this IEqualityComparer<Expression> target,
            Expression<Action<T1, T2, T3, T4, T5, T6, T7>> x, Expression<Action<T1, T2, T3, T4, T5, T6, T7>> y)
        {
            return target.Equals(x, y);
        }

        /// <summary>Determines whether two LambdaExpression are equal.</summary>
        /// <param name="target">An <see cref="IEqualityComparer{Expression}"/> used to compare the two LambdaExpression.</param>
        /// <param name="x">The first LambdaExpression to compare.</param>
        /// <param name="y">The second LambdaExpression to compare.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <returns>true if the specified LambdaExpressions are equal; otherwise, false.</returns>
        public static bool Equals<T1, T2, T3, T4, T5, T6>(this IEqualityComparer<Expression> target,
            Expression<Action<T1, T2, T3, T4, T5, T6>> x, Expression<Action<T1, T2, T3, T4, T5, T6>> y)
        {
            return target.Equals(x, y);
        }

        /// <summary>Determines whether two LambdaExpression are equal.</summary>
        /// <param name="target">An <see cref="IEqualityComparer{Expression}"/> used to compare the two LambdaExpression.</param>
        /// <param name="x">The first LambdaExpression to compare.</param>
        /// <param name="y">The second LambdaExpression to compare.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <returns>true if the specified LambdaExpressions are equal; otherwise, false.</returns>
        public static bool Equals<T1, T2, T3, T4, T5>(this IEqualityComparer<Expression> target,
            Expression<Action<T1, T2, T3, T4, T5>> x, Expression<Action<T1, T2, T3, T4, T5>> y)
        {
            return target.Equals(x, y);
        }

        /// <summary>Determines whether two LambdaExpression are equal.</summary>
        /// <param name="target">An <see cref="IEqualityComparer{Expression}"/> used to compare the two LambdaExpression.</param>
        /// <param name="x">The first LambdaExpression to compare.</param>
        /// <param name="y">The second LambdaExpression to compare.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <returns>true if the specified LambdaExpressions are equal; otherwise, false.</returns>
        public static bool Equals<T1, T2, T3, T4>(this IEqualityComparer<Expression> target,
            Expression<Action<T1, T2, T3, T4>> x, Expression<Action<T1, T2, T3, T4>> y)
        {
            return target.Equals(x, y);
        }

        /// <summary>Determines whether two LambdaExpression are equal.</summary>
        /// <param name="target">An <see cref="IEqualityComparer{Expression}"/> used to compare the two LambdaExpression.</param>
        /// <param name="x">The first LambdaExpression to compare.</param>
        /// <param name="y">The second LambdaExpression to compare.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <returns>true if the specified LambdaExpressions are equal; otherwise, false.</returns>
        public static bool Equals<T1, T2, T3>(this IEqualityComparer<Expression> target,
            Expression<Action<T1, T2, T3>> x, Expression<Action<T1, T2, T3>> y)
        {
            return target.Equals(x, y);
        }

        /// <summary>Determines whether two LambdaExpression are equal.</summary>
        /// <param name="target">An <see cref="IEqualityComparer{Expression}"/> used to compare the two LambdaExpression.</param>
        /// <param name="x">The first LambdaExpression to compare.</param>
        /// <param name="y">The second LambdaExpression to compare.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <returns>true if the specified LambdaExpressions are equal; otherwise, false.</returns>
        public static bool Equals<T1, T2>(this IEqualityComparer<Expression> target, Expression<Action<T1, T2>> x,
            Expression<Action<T1, T2>> y)
        {
            return target.Equals(x, y);
        }

        /// <summary>Determines whether two LambdaExpression are equal.</summary>
        /// <param name="target">An <see cref="IEqualityComparer{Expression}"/> used to compare the two LambdaExpression.</param>
        /// <param name="x">The first LambdaExpression to compare.</param>
        /// <param name="y">The second LambdaExpression to compare.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <returns>true if the specified LambdaExpressions are equal; otherwise, false.</returns>
        public static bool Equals<T1>(this IEqualityComparer<Expression> target, Expression<Action<T1>> x,
            Expression<Action<T1>> y)
        {
            return target.Equals(x, y);
        }

        /// <summary>Determines whether two LambdaExpression are equal.</summary>
        /// <param name="target">An <see cref="IEqualityComparer{Expression}"/> used to compare the two LambdaExpression.</param>
        /// <param name="x">The first LambdaExpression to compare.</param>
        /// <param name="y">The second LambdaExpression to compare.</param>
        /// <returns>true if the specified LambdaExpressions are equal; otherwise, false.</returns>
        public static bool Equals(this IEqualityComparer<Expression> target, Expression<Action> x,
            Expression<Action> y)
        {
            return target.Equals(x, y);
        }
    }
}