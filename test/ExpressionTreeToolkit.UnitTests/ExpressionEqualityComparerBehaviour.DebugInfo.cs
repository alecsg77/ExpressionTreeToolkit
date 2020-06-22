// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Linq.Expressions;

using Xunit;

namespace ExpressionTreeToolkit.UnitTests
{
    partial class ExpressionEqualityComparerBehaviour
    {
        private static readonly Guid LanguageGuid = Guid.NewGuid();
        private static readonly Guid LanguageVendorGuid = Guid.NewGuid();
        private static readonly Guid DocumentTypeGuid = Guid.NewGuid();

        [Fact]
        public void DebugInfoExpressionShouldBeEqual_SameFileName_SameLocation()
        {
            var x = Expression.DebugInfo(
                Expression.SymbolDocument("filename"),
                1, 1, 1, 1
            );
            var y = Expression.DebugInfo(
                Expression.SymbolDocument("filename"),
                1, 1, 1, 1
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void DebugInfoExpressionShouldBeNotEqual_SameFileName_DifferentLocation()
        {
            var x = Expression.DebugInfo(
                Expression.SymbolDocument("filename"),
                1, 1, 1, 1
            );
            var y = Expression.DebugInfo(
                Expression.SymbolDocument("filename"),
                2, 1, 2, 1
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void DebugInfoExpressionShouldBeNotEqual_DifferentFileName_SameLocation()
        {
            var x = Expression.DebugInfo(
                Expression.SymbolDocument("filename"),
                1, 1, 1, 1
            );
            var y = Expression.DebugInfo(
                Expression.SymbolDocument("other"),
                1, 1, 1, 1
            );

            AssertAreNotEqual(x, y);
        }
        
        [Fact]
        public void DebugInfoExpressionShouldBeEqual_SameFileName_SameLanguage_SameLocation()
        {
            var x = Expression.DebugInfo(
                Expression.SymbolDocument("filename", LanguageGuid),
                1, 1, 1, 1
            );
            var y = Expression.DebugInfo(
                Expression.SymbolDocument("filename", LanguageGuid),
                1, 1, 1, 1
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void DebugInfoExpressionShouldBeNotEqual_SameFileName_DifferentLanguage_SameLocation()
        {
            var x = Expression.DebugInfo(
                Expression.SymbolDocument("filename"),
                1, 1, 1, 1
            );
            var y = Expression.DebugInfo(
                Expression.SymbolDocument("filename", LanguageGuid),
                1, 1, 1, 1
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void DebugInfoExpressionShouldBeEqual_SameFileName_SameLanguage_SameLanguageVendor_SameLocation()
        {
            var x = Expression.DebugInfo(
                Expression.SymbolDocument("filename", LanguageGuid, LanguageVendorGuid),
                1, 1, 1, 1
            );
            var y = Expression.DebugInfo(
                Expression.SymbolDocument("filename", LanguageGuid, LanguageVendorGuid),
                1, 1, 1, 1
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void DebugInfoExpressionShouldBeNotEqual_SameFileName_SameLanguage_DifferentLanguageVendor_SameLocation()
        {
            var x = Expression.DebugInfo(
                Expression.SymbolDocument("filename", LanguageGuid),
                1, 1, 1, 1
            );
            var y = Expression.DebugInfo(
                Expression.SymbolDocument("filename", LanguageGuid, LanguageVendorGuid),
                1, 1, 1, 1
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void DebugInfoExpressionShouldBeEqual_SameFileName_SameLanguage_SameLanguageVendor_SameDocumentType_SameLocation()
        {
            var x = Expression.DebugInfo(
                Expression.SymbolDocument("filename", LanguageGuid, LanguageVendorGuid, DocumentTypeGuid),
                1, 1, 1, 1
            );
            var y = Expression.DebugInfo(
                Expression.SymbolDocument("filename", LanguageGuid, LanguageVendorGuid, DocumentTypeGuid),
                1, 1, 1, 1
            );

            AssertAreEqual(x, y);
        }

        [Fact]
        public void DebugInfoExpressionShouldBeNotEqual_SameFileName_SameLanguage_SameLanguageVendor_DifferentDocumentType_SameLocation()
        {
            var x = Expression.DebugInfo(
                Expression.SymbolDocument("filename", LanguageGuid, LanguageVendorGuid),
                1, 1, 1, 1
            );
            var y = Expression.DebugInfo(
                Expression.SymbolDocument("filename", LanguageGuid, LanguageVendorGuid, DocumentTypeGuid),
                1, 1, 1, 1
            );

            AssertAreNotEqual(x, y);
        }

        [Fact]
        public void DebugInfoExpressionShouldBeNotEqual_DifferentFileName_DifferentLanguage_DifferentLanguageVendor_DifferentDocumentType_DifferentLocation()
        {
            var x = Expression.DebugInfo(
                Expression.SymbolDocument("filename"),
                1, 1, 1, 1
            );
            var y = Expression.DebugInfo(
                Expression.SymbolDocument("other", LanguageGuid, LanguageVendorGuid, DocumentTypeGuid),
                2, 2, 2, 2
            );

            AssertAreNotEqual(x, y);
        }
    }
}