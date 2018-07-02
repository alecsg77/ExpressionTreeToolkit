// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<RuntimeVariablesExpression>
    {
        private bool EqualsRuntimeVariables(RuntimeVariablesExpression x, RuntimeVariablesExpression y)
        {
            return EqualsExpressionList(x.Variables, y.Variables);
        }

        private IEnumerable<int> GetHashElementsRuntimeVariables(RuntimeVariablesExpression node)
        {
            return GetHashElements(node.Variables);
        }

        public bool Equals(RuntimeVariablesExpression x, RuntimeVariablesExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y)
                   && EqualsRuntimeVariables(x, y);
        }

        public int GetHashCode(RuntimeVariablesExpression obj)
        {
            if (obj == null) return 0;

            return GetHashCodeExpression(
                obj,
                GetHashElementsRuntimeVariables(obj));
        }
    }
}