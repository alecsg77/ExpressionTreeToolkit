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
