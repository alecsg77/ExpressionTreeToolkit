// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<ParameterExpression>
    {
        private readonly ReadOnlyCollection<ParameterExpression> _xParameters;
        private readonly ReadOnlyCollection<ParameterExpression> _yParameters;

        private ExpressionEqualityComparer(
            ReadOnlyCollection<ParameterExpression> xParameters,
            ReadOnlyCollection<ParameterExpression> yParameters)
        {
            _xParameters = xParameters;
            _yParameters = yParameters;
        }

        private bool EqualsParameter(ParameterExpression x, ParameterExpression y)
        {
            return Equals(_xParameters?.IndexOf(x), _yParameters?.IndexOf(y))
                   && Equals(x.IsByRef, y.IsByRef);
        }

        private IEnumerable<int> GetHashElementsParameter(ParameterExpression node)
        {
            return GetHashElements(node.IsByRef);
        }

        public bool Equals(ParameterExpression x, ParameterExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y)
                   && EqualsParameter(x, y);
        }

        public int GetHashCode(ParameterExpression obj)
        {
            if (obj == null) return 0;

            return GetHashCodeExpression(
                obj,
                GetHashElementsParameter(obj));
        }
    }
}