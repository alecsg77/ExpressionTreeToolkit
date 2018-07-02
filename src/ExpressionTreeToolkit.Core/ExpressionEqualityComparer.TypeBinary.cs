﻿// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<TypeBinaryExpression>
    {
        private bool EqualsTypeBinary(TypeBinaryExpression x, TypeBinaryExpression y)
        {
            return x.TypeOperand == y.TypeOperand
                   && Equals(x.Expression, y.Expression);
        }

        private IEnumerable<int> GetHashElementsTypeBinary(TypeBinaryExpression node)
        {
            return GetHashElements(
                node.TypeOperand,
                node.Expression);
        }

        public bool Equals(TypeBinaryExpression x, TypeBinaryExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y)
                   && EqualsTypeBinary(x, y);
        }

        public int GetHashCode(TypeBinaryExpression obj)
        {
            if (obj == null) return 0;

            return GetHashCodeExpression(
                obj,
                GetHashElementsTypeBinary(obj));
        }
    }
}