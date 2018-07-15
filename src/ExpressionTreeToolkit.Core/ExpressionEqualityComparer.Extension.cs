// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    public partial class ExpressionEqualityComparer
    {
        private bool EqualsExtension(Expression x, Expression y)
        {
            return EqualsExpression(x.ReduceExtensions(), y.ReduceExtensions());
        }

        private int GetHashCodeExtension(Expression obj)
        {
            return GetHashCode(obj.ReduceExtensions());
        }
    }
}