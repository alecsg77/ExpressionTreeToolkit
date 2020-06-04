using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparerExtensions
    {
        /// <summary>Serves as a hash function for the specified LambdaExpression for hashing algorithms and data structures, such as a hash table.</summary>
        /// <param name="target">An <see cref="IEqualityComparer{Expression}"/> used to serve the hash function.</param>
        /// <param name="obj">The LambdaExpression for which to get a hash code.</param>
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
        /// <returns>A hash code for the specified LambdaExpression.</returns>
        public static int GetHashCode<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            this IEqualityComparer<Expression> target,
            Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> obj)
        {
            return target.GetHashCode(obj);
        }

        /// <summary>Serves as a hash function for the specified LambdaExpression for hashing algorithms and data structures, such as a hash table.</summary>
        /// <param name="target">An <see cref="IEqualityComparer{Expression}"/> used to serve the hash function.</param>
        /// <param name="obj">The LambdaExpression for which to get a hash code.</param>
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
        /// <returns>A hash code for the specified LambdaExpression.</returns>
        public static int GetHashCode<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
            this IEqualityComparer<Expression> target,
            Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> obj)
        {
            return target.GetHashCode(obj);
        }

        /// <summary>Serves as a hash function for the specified LambdaExpression for hashing algorithms and data structures, such as a hash table.</summary>
        /// <param name="target">An <see cref="IEqualityComparer{Expression}"/> used to serve the hash function.</param>
        /// <param name="obj">The LambdaExpression for which to get a hash code.</param>
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
        /// <returns>A hash code for the specified LambdaExpression.</returns>
        public static int GetHashCode<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
            this IEqualityComparer<Expression> target,
            Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> obj)
        {
            return target.GetHashCode(obj);
        }

        /// <summary>Serves as a hash function for the specified LambdaExpression for hashing algorithms and data structures, such as a hash table.</summary>
        /// <param name="target">An <see cref="IEqualityComparer{Expression}"/> used to serve the hash function.</param>
        /// <param name="obj">The LambdaExpression for which to get a hash code.</param>
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
        /// <returns>A hash code for the specified LambdaExpression.</returns>
        public static int GetHashCode<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
            this IEqualityComparer<Expression> target,
            Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> obj)
        {
            return target.GetHashCode(obj);
        }

        /// <summary>Serves as a hash function for the specified LambdaExpression for hashing algorithms and data structures, such as a hash table.</summary>
        /// <param name="target">An <see cref="IEqualityComparer{Expression}"/> used to serve the hash function.</param>
        /// <param name="obj">The LambdaExpression for which to get a hash code.</param>
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
        /// <returns>A hash code for the specified LambdaExpression.</returns>
        public static int GetHashCode<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
            this IEqualityComparer<Expression> target,
            Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> obj)
        {
            return target.GetHashCode(obj);
        }

        /// <summary>Serves as a hash function for the specified LambdaExpression for hashing algorithms and data structures, such as a hash table.</summary>
        /// <param name="target">An <see cref="IEqualityComparer{Expression}"/> used to serve the hash function.</param>
        /// <param name="obj">The LambdaExpression for which to get a hash code.</param>
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
        /// <returns>A hash code for the specified LambdaExpression.</returns>
        public static int GetHashCode<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
            this IEqualityComparer<Expression> target,
            Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> obj)
        {
            return target.GetHashCode(obj);
        }

        /// <summary>Serves as a hash function for the specified LambdaExpression for hashing algorithms and data structures, such as a hash table.</summary>
        /// <param name="target">An <see cref="IEqualityComparer{Expression}"/> used to serve the hash function.</param>
        /// <param name="obj">The LambdaExpression for which to get a hash code.</param>
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
        /// <returns>A hash code for the specified LambdaExpression.</returns>
        public static int GetHashCode<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
            this IEqualityComparer<Expression> target, Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> obj)
        {
            return target.GetHashCode(obj);
        }

        /// <summary>Serves as a hash function for the specified LambdaExpression for hashing algorithms and data structures, such as a hash table.</summary>
        /// <param name="target">An <see cref="IEqualityComparer{Expression}"/> used to serve the hash function.</param>
        /// <param name="obj">The LambdaExpression for which to get a hash code.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <returns>A hash code for the specified LambdaExpression.</returns>
        public static int GetHashCode<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IEqualityComparer<Expression> target,
            Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> obj)
        {
            return target.GetHashCode(obj);
        }

        /// <summary>Serves as a hash function for the specified LambdaExpression for hashing algorithms and data structures, such as a hash table.</summary>
        /// <param name="target">An <see cref="IEqualityComparer{Expression}"/> used to serve the hash function.</param>
        /// <param name="obj">The LambdaExpression for which to get a hash code.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <returns>A hash code for the specified LambdaExpression.</returns>
        public static int GetHashCode<T1, T2, T3, T4, T5, T6, T7, T8>(this IEqualityComparer<Expression> target,
            Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8>> obj)
        {
            return target.GetHashCode(obj);
        }

        /// <summary>Serves as a hash function for the specified LambdaExpression for hashing algorithms and data structures, such as a hash table.</summary>
        /// <param name="target">An <see cref="IEqualityComparer{Expression}"/> used to serve the hash function.</param>
        /// <param name="obj">The LambdaExpression for which to get a hash code.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <returns>A hash code for the specified LambdaExpression.</returns>
        public static int GetHashCode<T1, T2, T3, T4, T5, T6, T7>(this IEqualityComparer<Expression> target,
            Expression<Action<T1, T2, T3, T4, T5, T6, T7>> obj)
        {
            return target.GetHashCode(obj);
        }

        /// <summary>Serves as a hash function for the specified LambdaExpression for hashing algorithms and data structures, such as a hash table.</summary>
        /// <param name="target">An <see cref="IEqualityComparer{Expression}"/> used to serve the hash function.</param>
        /// <param name="obj">The LambdaExpression for which to get a hash code.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <returns>A hash code for the specified LambdaExpression.</returns>
        public static int GetHashCode<T1, T2, T3, T4, T5, T6>(this IEqualityComparer<Expression> target,
            Expression<Action<T1, T2, T3, T4, T5, T6>> obj)
        {
            return target.GetHashCode(obj);
        }

        /// <summary>Serves as a hash function for the specified LambdaExpression for hashing algorithms and data structures, such as a hash table.</summary>
        /// <param name="target">An <see cref="IEqualityComparer{Expression}"/> used to serve the hash function.</param>
        /// <param name="obj">The LambdaExpression for which to get a hash code.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <returns>A hash code for the specified LambdaExpression.</returns>
        public static int GetHashCode<T1, T2, T3, T4, T5>(this IEqualityComparer<Expression> target,
            Expression<Action<T1, T2, T3, T4, T5>> obj)
        {
            return target.GetHashCode(obj);
        }

        /// <summary>Serves as a hash function for the specified LambdaExpression for hashing algorithms and data structures, such as a hash table.</summary>
        /// <param name="target">An <see cref="IEqualityComparer{Expression}"/> used to serve the hash function.</param>
        /// <param name="obj">The LambdaExpression for which to get a hash code.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <returns>A hash code for the specified LambdaExpression.</returns>
        public static int GetHashCode<T1, T2, T3, T4>(this IEqualityComparer<Expression> target,
            Expression<Action<T1, T2, T3, T4>> obj)
        {
            return target.GetHashCode(obj);
        }

        /// <summary>Serves as a hash function for the specified LambdaExpression for hashing algorithms and data structures, such as a hash table.</summary>
        /// <param name="target">An <see cref="IEqualityComparer{Expression}"/> used to serve the hash function.</param>
        /// <param name="obj">The LambdaExpression for which to get a hash code.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <returns>A hash code for the specified LambdaExpression.</returns>
        public static int GetHashCode<T1, T2, T3>(this IEqualityComparer<Expression> target,
            Expression<Action<T1, T2, T3>> obj)
        {
            return target.GetHashCode(obj);
        }

        /// <summary>Serves as a hash function for the specified LambdaExpression for hashing algorithms and data structures, such as a hash table.</summary>
        /// <param name="target">An <see cref="IEqualityComparer{Expression}"/> used to serve the hash function.</param>
        /// <param name="obj">The LambdaExpression for which to get a hash code.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <returns>A hash code for the specified LambdaExpression.</returns>
        public static int GetHashCode<T1, T2>(this IEqualityComparer<Expression> target, Expression<Action<T1, T2>> obj)
        {
            return target.GetHashCode(obj);
        }

        /// <summary>Serves as a hash function for the specified LambdaExpression for hashing algorithms and data structures, such as a hash table.</summary>
        /// <param name="target">An <see cref="IEqualityComparer{Expression}"/> used to serve the hash function.</param>
        /// <param name="obj">The LambdaExpression for which to get a hash code.</param>
        /// <typeparam name="T1">The type of the first parameter of the method that this LambdaExpression encapsulates.</typeparam>
        /// <returns>A hash code for the specified LambdaExpression.</returns>
        public static int GetHashCode<T1>(this IEqualityComparer<Expression> target, Expression<Action<T1>> obj)
        {
            return target.GetHashCode(obj);
        }

        /// <summary>Serves as a hash function for the specified LambdaExpression for hashing algorithms and data structures, such as a hash table.</summary>
        /// <param name="target">An <see cref="IEqualityComparer{Expression}"/> used to serve the hash function.</param>
        /// <param name="obj">The LambdaExpression for which to get a hash code.</param>
        /// <returns>A hash code for the specified LambdaExpression.</returns>
        public static int GetHashCode(this IEqualityComparer<Expression> target, Expression<Action> obj)
        {
            return target.GetHashCode(obj);
        }
    }
}