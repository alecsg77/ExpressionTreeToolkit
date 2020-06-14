// Copyright (c) 2018 Alessio Gogna
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

#if JETBRAINS_ANNOTATIONS

#else
namespace System.Diagnostics.CodeAnalysis
{
    [Conditional("JETBRAINS_ANNOTATIONS")]
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property)]
    internal sealed class AllowItemNullAttribute : Attribute
    {
    }
}
#endif
