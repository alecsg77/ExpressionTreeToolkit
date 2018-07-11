// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
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

        /// <summary>Determines whether the specified ParameterExpressions are equal.</summary>
        /// <param name="x">The first ParameterExpression to compare.</param>
        /// <param name="y">The second ParameterExpression to compare.</param>
        /// <returns>true if the specified ParameterExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<ParameterExpression>.Equals(ParameterExpression x, ParameterExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y)
                   && EqualsParameter(x, y);
        }

        /// <summary>Returns a hash code for the specified ParameterExpression.</summary>
        /// <param name="obj">The <see cref="ParameterExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified ParameterExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<ParameterExpression>.GetHashCode(ParameterExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeExpression(
                obj,
                GetHashElementsParameter(obj));
        }
    }
}