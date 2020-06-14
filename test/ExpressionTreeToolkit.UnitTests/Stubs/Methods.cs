// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace ExpressionTreeToolkit.UnitTests.Stubs
{
    [ExcludeFromCodeCoverage]
    internal static class Methods
    {
        private static class Stub
        {
            public static TTarget Convert<TSource, TTarget>(TSource source) => throw new NotImplementedException();
            public static T Add<T>(T arg1, T arg2) => throw new NotImplementedException();
            public static bool Equal<T>(T arg1, T arg2) => throw new NotImplementedException();
            public static void Method() => throw new NotImplementedException();

            public static void Action() => throw new NotImplementedException();
            public static TResult Func<TResult>() => throw new NotImplementedException();
            public static TResult Func<T1, TResult>(T1 arg1) => throw new NotImplementedException();
            public static TResult Func<T1, T2, TResult>(T1 arg1, T2 arg2) => throw new NotImplementedException();
        }

        private static readonly Dictionary<int, MethodInfo> ActionMethodInfos = typeof(Stub)
            .GetMember(nameof(Stub.Action), MemberTypes.Method, BindingFlags.Static | BindingFlags.Public)
            .OfType<MethodInfo>().ToDictionary(m => m.GetGenericArguments().Length);

        private static readonly Dictionary<int, MethodInfo> FuncMethodInfos = typeof(Stub)
            .GetMember(nameof(Stub.Func), MemberTypes.Method, BindingFlags.Static | BindingFlags.Public)
            .OfType<MethodInfo>().ToDictionary(m => m.GetGenericArguments().Length);


        public static MethodInfo Add<T>() => typeof(Stub).GetMethod(nameof(Stub.Add)).MakeGenericMethod(typeof(T));
        public static MethodInfo CollectionAdd<T>() => typeof(ICollection<T>).GetMethod(nameof(ICollection<T>.Add), new[] { typeof(T) });
        public static MethodInfo Convert<TSource, TTarget>() => typeof(Stub).GetMethod(nameof(Stub.Convert)).MakeGenericMethod(typeof(TSource), typeof(TTarget));
        public static MethodInfo Equal<T>() => typeof(Stub).GetMethod(nameof(Stub.Equal)).MakeGenericMethod(typeof(T));
        public static readonly MethodInfo Method = typeof(Stub).GetMethod(nameof(Stub.Method));

        public static MethodInfo Action() => ActionMethodInfos[0];

        public static MethodInfo Func<TResult>() => FuncMethodInfos[1].MakeGenericMethod(typeof(TResult));
        public static MethodInfo Func<T1, TResult>() => FuncMethodInfos[2].MakeGenericMethod(typeof(T1), typeof(TResult));
        public static MethodInfo Func<T1, T2, TResult>() => FuncMethodInfos[3].MakeGenericMethod(typeof(T1), typeof(T2), typeof(TResult));
    }
}