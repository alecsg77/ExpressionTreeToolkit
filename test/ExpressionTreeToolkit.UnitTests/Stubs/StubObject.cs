// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ExpressionTreeToolkit.UnitTests.Stubs
{
    [ExcludeFromCodeCoverage]
    internal sealed partial class StubObject
    {
        public static readonly StubObject Singleton = new StubObject();

        public StubObject() { }

        public StubObject(StubObject arg1) => throw new NotImplementedException();

        public void Action() => throw new NotImplementedException();

        public void Action<T1>(T1 arg1) => throw new NotImplementedException();
        public void Action<T1, T2>(T1 arg1, T2 arg2) => throw new NotImplementedException();

        public void Insert(StubObject arg1) => throw new NotImplementedException();

        public readonly StubObject Field = null;

        public StubObject Single
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public ICollection<StubObject> Collection
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public static class Expressions
        {
            public static DefaultExpression Default => Expression.Default(typeof(StubObject));
            public static ConstantExpression Constant => Expression.Constant(Singleton, typeof(StubObject));
        }

        public static class Constructors
        {
            public static readonly ConstructorInfo Default = typeof(StubObject).GetConstructor(Type.EmptyTypes);
            public static readonly ConstructorInfo Copy = typeof(StubObject).GetConstructor(new[] { typeof(StubObject) });
        }

        public static class Members
        {
            public static readonly FieldInfo Field = typeof(StubObject).GetField(nameof(StubObject.Field));
            public static readonly PropertyInfo Single = typeof(StubObject).GetProperty(nameof(StubObject.Single));
            public static readonly PropertyInfo Collection = typeof(StubObject).GetProperty(nameof(StubObject.Collection));
        }

        public static class Methods
        {
            private static readonly Dictionary<int, MethodInfo> ActionMethodInfos = typeof(StubObject)
                .GetMember(nameof(StubObject.Action), MemberTypes.Method, BindingFlags.Instance | BindingFlags.Public)
                .OfType<MethodInfo>().ToDictionary(m => m.GetGenericArguments().Length);

            public static readonly MethodInfo Insert = typeof(StubObject).GetMethod(nameof(StubObject.Insert));

            public static MethodInfo Action() => ActionMethodInfos[0];
            public static MethodInfo Action<T1>() => ActionMethodInfos[1].MakeGenericMethod(typeof(T1));
        }
    }
}