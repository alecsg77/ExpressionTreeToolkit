// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer
    {
        protected class ComparisonContext
        {
            private readonly ComparisonContext? _parent;
            private readonly ReadOnlyCollection<ParameterExpression>? _xParameters;
            private readonly ReadOnlyCollection<ParameterExpression>? _yParameters;
            private readonly List<LabelTarget> _xLabelTarget;
            private readonly List<LabelTarget> _yLabelTarget;

            public ComparisonContext()
            {
                _parent = null;
                _xParameters = null;
                _yParameters = null;
                _xLabelTarget = new List<LabelTarget>();
                _yLabelTarget = new List<LabelTarget>();
            }

            protected ComparisonContext(
                ComparisonContext parent,
                ReadOnlyCollection<ParameterExpression> xParameters,
                ReadOnlyCollection<ParameterExpression> yParameters
            )
            {
                _parent = parent;
                _xParameters = xParameters;
                _yParameters = yParameters;
                _xLabelTarget = parent._xLabelTarget;
                _yLabelTarget = parent._yLabelTarget;
            }

            public ComparisonContext NestedScope(
                ReadOnlyCollection<ParameterExpression> xVariables,
                ReadOnlyCollection<ParameterExpression> yVariables
            )
            {
                return new ComparisonContext(this, xVariables, yVariables);
            }

            public bool VerifyParameter(ParameterExpression x, ParameterExpression y)
            {
                var xIndex = _xParameters?.IndexOf(x) ?? -1;
                var yIndex = _yParameters?.IndexOf(y) ?? -1;

                if (xIndex != yIndex)
                {
                    return false;
                }

                return xIndex != -1 || _parent == null || _parent.VerifyParameter(x, y);
            }

            public virtual bool VerifyLabelTarget(LabelTarget x, LabelTarget y)
            {
                var xIndex = _xLabelTarget.IndexOf(x);
                if (xIndex == -1)
                {
                    xIndex = _xLabelTarget.Count;
                    _xLabelTarget.Insert(0, x);
                }

                var yIndex = _yLabelTarget.IndexOf(y);
                if (yIndex == -1)
                {
                    yIndex = _yLabelTarget.Count;
                    _yLabelTarget.Insert(0, y);
                }

                return xIndex == yIndex;
            }
        }

        protected virtual ComparisonContext BeginScope()
        {
            return new ComparisonContext();
        }
    }
}