// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace ExpressionTreeToolkit.UnitTests.Stubs
{
    [ExcludeFromCodeCoverage]
    internal class StubCollection : IList<StubObject>
    {
        public IEnumerator<StubObject> GetEnumerator() => throw new NotImplementedException();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public void Add(StubObject item) => throw new NotImplementedException();
        public void Clear() => throw new NotImplementedException();
        public bool Contains(StubObject item) => throw new NotImplementedException();
        public void CopyTo(StubObject[] array, int arrayIndex) => throw new NotImplementedException();
        public bool Remove(StubObject item) => throw new NotImplementedException();
        public int Count => throw new NotImplementedException();
        public bool IsReadOnly => throw new NotImplementedException();
        public int IndexOf(StubObject item) => throw new NotImplementedException();
        public void Insert(int index, StubObject item) => throw new NotImplementedException();
        public void RemoveAt(int index) => throw new NotImplementedException();
        public StubObject this[int index]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public static class Methods
        {
            public static readonly MethodInfo Add = typeof(StubCollection).GetMethod(nameof(StubCollection.Add));
        }
        public static class Properties
        {
            public static readonly PropertyInfo Item = typeof(StubCollection).GetProperty("Item");
        }
    }
}