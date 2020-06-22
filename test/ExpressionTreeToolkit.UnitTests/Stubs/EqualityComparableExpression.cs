// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace ExpressionTreeToolkit.UnitTests.Stubs
{
    [ExcludeFromCodeCoverage]
    internal class EqualityComparableExpression : SimpleExpression, IEquatable<EqualityComparableExpression>
    {
        public EqualityComparableExpression(int id) : base(id)
        {
        }

        public bool Equals(EqualityComparableExpression other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((EqualityComparableExpression)obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public static bool operator ==(EqualityComparableExpression left, EqualityComparableExpression right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EqualityComparableExpression left, EqualityComparableExpression right)
        {
            return !Equals(left, right);
        }
    }
}