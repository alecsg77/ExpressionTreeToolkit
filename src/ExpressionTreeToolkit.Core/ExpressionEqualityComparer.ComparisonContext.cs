// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer
    {
        /// <summary>
        /// Provides contextual information that can be use to verify elements in a global or local scopes. 
        /// </summary>
        protected class ComparisonContext
        {
            private readonly ComparisonContext? _parent;
            private readonly ReadOnlyCollection<ParameterExpression>? _xParameters;
            private readonly ReadOnlyCollection<ParameterExpression>? _yParameters;
            private readonly List<LabelTarget> _xLabelTarget;
            private readonly List<LabelTarget> _yLabelTarget;

            /// <summary>
            /// Initializes a new instance of the ComparisonContext class.
            /// </summary>
            public ComparisonContext()
            {
                _parent = null;
                _xParameters = null;
                _yParameters = null;
                _xLabelTarget = new List<LabelTarget>();
                _yLabelTarget = new List<LabelTarget>();
            }

            /// <summary>
            /// Initializes a new instance of the ComparisonContext class that represents a nested scope.
            /// </summary>
            /// <param name="parent">The parent ComparisonContext.</param>
            /// <param name="xParameters">The [ReadOnlyCollection](xref:System.Collections.ObjectModel.ReadOnlyCollection`1)&lt;<see cref="ParameterExpression"/>&gt; parameters of x</param>
            /// <param name="yParameters">The [ReadOnlyCollection](xref:System.Collections.ObjectModel.ReadOnlyCollection`1)&lt;<see cref="ParameterExpression"/>&gt; parameters of y</param>
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

            /// <summary>
            /// Returns a new nested <see cref="ComparisonContext"/>.
            /// </summary>
            /// <param name="xVariables">The first [ReadOnlyCollection](xref:System.Collections.ObjectModel.ReadOnlyCollection`1)&lt;<see cref="ParameterExpression"/>&gt;</param>
            /// <param name="yVariables">The second [ReadOnlyCollection](xref:System.Collections.ObjectModel.ReadOnlyCollection`1)&lt;<see cref="ParameterExpression"/>&gt;</param>
            /// <returns>The nested ComparisonContext.</returns>
            public ComparisonContext NestedScope(
                ReadOnlyCollection<ParameterExpression> xVariables,
                ReadOnlyCollection<ParameterExpression> yVariables
            )
            {
                return new ComparisonContext(this, xVariables, yVariables);
            }

            /// <summary>
            /// Determines whether the two <see cref="ParameterExpression"/> are equal in the context.
            /// </summary>
            /// <param name="x">The first <see cref="ParameterExpression"/> to compare.</param>
            /// <param name="y">The second <see cref="ParameterExpression"/> to compare.</param>
            /// <returns>true if the specified <see cref="ParameterExpression"/> are equal in the context; otherwise, false.</returns>
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

            /// <summary>
            /// Determines whether the two LabelTarget are equal in the context.
            /// </summary>
            /// <param name="x">The first LabelTarget to compare.</param>
            /// <param name="y">The second LabelTarget to compare.</param>
            /// <returns>true if the specified LabelTarget are equal in the context; otherwise, false.</returns>
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

        /// <summary>
        /// Returns a new ComparisonContext that represents root scope.
        /// </summary>
        /// <returns>The root ComparisonContext.</returns>
        protected virtual ComparisonContext BeginScope()
        {
            return new ComparisonContext();
        }
    }
}