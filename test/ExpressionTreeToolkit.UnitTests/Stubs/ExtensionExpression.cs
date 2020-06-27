// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit.UnitTests.Stubs
{
    [ExcludeFromCodeCoverage]
    internal class ExtensionExpression : Expression
    {
        private readonly Func<Expression> _reducer;

        public ExtensionExpression(Type type, Func<Expression> reducer)
        {
            Type = type;
            _reducer = reducer;
        }

        public override ExpressionType NodeType => ExpressionType.Extension;

        public override Type Type { get; }

        public override bool CanReduce => true;

        public override Expression Reduce()
        {
            return _reducer();
        }
    }
}