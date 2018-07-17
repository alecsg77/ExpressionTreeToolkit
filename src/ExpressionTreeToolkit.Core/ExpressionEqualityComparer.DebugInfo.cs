// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JetBrains.Annotations;

namespace ExpressionTreeToolkit
{
    partial class ExpressionEqualityComparer : IEqualityComparer<DebugInfoExpression>
    {
        /// <summary>Determines whether the children of the two DebugInfoExpression are equal.</summary>
        /// <param name="x">The first DebugInfoExpression to compare.</param>
        /// <param name="y">The second DebugInfoExpression to compare.</param>
        /// <returns>true if the specified DebugInfoExpression are equal; otherwise, false.</returns>
        protected virtual bool EqualsDebugInfo([NotNull] DebugInfoExpression x, [NotNull] DebugInfoExpression y)
        {
            return x.Type == y.Type
                   && x.IsClear == y.IsClear
                   && EqualsSymbolDocumentInfo(x.Document, y.Document)
                   && x.StartLine == y.StartLine
                   && x.StartColumn == y.StartColumn
                   && x.EndLine == y.EndLine
                   && x.EndColumn == y.EndColumn;
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

        /// <summary>Gets the hash code for the specified DebugInfoExpression.</summary>
        /// <param name="node">The DebugInfoExpression for which to get a hash code.</param>
        /// <returns>A hash code for the specified DebugInfoExpression.</returns>
        protected virtual int GetHashCodeDebugInfo([NotNull] DebugInfoExpression node)
        {
            return GetHashCode(
                GetDefaultHashCode(node.Type),
                node.IsClear.GetHashCode(),
                GetHashSymbolDocumentInfo(node.Document),
                node.StartLine.GetHashCode(),
                node.StartColumn.GetHashCode(),
                node.EndLine.GetHashCode(),
                node.EndColumn.GetHashCode());
        }

        private int GetHashSymbolDocumentInfo(SymbolDocumentInfo symbolDocumentInfo)
        {
            if (symbolDocumentInfo == null)
            {
                return 0;
            }

            return GetHashCode(
                symbolDocumentInfo.DocumentType.GetHashCode(),
                symbolDocumentInfo.Language.GetHashCode(),
                symbolDocumentInfo.LanguageVendor.GetHashCode(),
                GetDefaultHashCode(symbolDocumentInfo.FileName));
        }

        /// <summary>Determines whether the specified DebugInfoExpressions are equal.</summary>
        /// <param name="x">The first DebugInfoExpression to compare.</param>
        /// <param name="y">The second DebugInfoExpression to compare.</param>
        /// <returns>true if the specified DebugInfoExpressions are equal; otherwise, false.</returns>
        bool IEqualityComparer<DebugInfoExpression>.Equals(DebugInfoExpression x, DebugInfoExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return EqualsDebugInfo(x, y);
        }

        /// <summary>Returns a hash code for the specified DebugInfoExpression.</summary>
        /// <param name="obj">The <see cref="DebugInfoExpression"></see> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified DebugInfoExpression.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="obj">obj</paramref> is null.</exception>
        int IEqualityComparer<DebugInfoExpression>.GetHashCode(DebugInfoExpression obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return GetHashCodeDebugInfo(obj);
        }
    }
}