// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit.UnitTests.Stubs
{
    [ExcludeFromCodeCoverage]
    internal class SimpleExpression : Expression
    {
        public int Id { get; }

        public SimpleExpression(int id)
        {
            Id = id;
        }

        public override ExpressionType NodeType => (ExpressionType) (-1);
        public override Type Type => typeof(SimpleExpression);
    }
}