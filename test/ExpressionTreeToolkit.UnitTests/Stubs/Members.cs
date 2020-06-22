// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace ExpressionTreeToolkit.UnitTests.Stubs
{
    [ExcludeFromCodeCoverage]
    internal static class Members
    {
        private static class Stub<T>
        {
            public static readonly T Field = default;
            public static T Single
            {
                get => throw new NotImplementedException();
                set => throw new NotImplementedException();
            }
            public static ICollection<T> Collection
            {
                get => throw new NotImplementedException();
                set => throw new NotImplementedException();
            }
        }
        public static FieldInfo Field<T>() => typeof(Stub<T>).GetField(nameof(Stub<T>.Field));
        public static PropertyInfo Single<T>() => typeof(Stub<T>).GetProperty(nameof(Stub<T>.Single));
        public static PropertyInfo Collection<T>() => typeof(Stub<T>).GetProperty(nameof(Stub<T>.Collection));
        public static PropertyInfo Item<T>() => typeof(IList<T>).GetProperty("Item");
    }
}