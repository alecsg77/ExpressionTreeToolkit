// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<DebugInfoExpression>
    {
        private bool EqualsDebugInfo(DebugInfoExpression x, DebugInfoExpression y)
        {
            return Equals(x.IsClear, y.IsClear)
                   && EqualsSymbolDocumentInfo(x.Document, y.Document)
                   && Equals(x.StartLine, y.StartLine)
                   && Equals(x.StartColumn, y.StartColumn)
                   && Equals(x.EndLine, y.EndLine)
                   && Equals(x.EndColumn, y.EndColumn);
        }

        private bool EqualsSymbolDocumentInfo(SymbolDocumentInfo x, SymbolDocumentInfo y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

            return x.DocumentType == y.DocumentType
                   && x.Language == y.Language
                   && x.LanguageVendor == y.LanguageVendor
                   && x.FileName == y.FileName;
        }

        private IEnumerable<int> GetHashElementsDebugInfo(DebugInfoExpression node)
        {
            return GetHashElements(
                node.IsClear,
                node.Document?.DocumentType,
                node.Document?.Language,
                node.Document?.LanguageVendor,
                node.Document?.FileName,
                node.StartLine,
                node.StartColumn,
                node.EndLine,
                node.EndColumn);
        }


        /// <summary>Determines whether the specified DebugInfoExpressions are equal.</summary>
        /// <param name="x">The first DebugInfoExpression to compare.</param>
        /// <param name="y">The second DebugInfoExpression to compare.</param>
        /// <returns>true if the specified DebugInfoExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<DebugInfoExpression>.Equals(DebugInfoExpression x, DebugInfoExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y)
                   && EqualsDebugInfo(x, y);
        }

        /// <summary>Returns a hash code for the specified DebugInfoExpression.</summary>
        /// <param name="obj">The <see cref="DebugInfoExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified DebugInfoExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<DebugInfoExpression>.GetHashCode(DebugInfoExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeExpression(
                obj,
                GetHashElementsDebugInfo(obj));
        }
    }
}