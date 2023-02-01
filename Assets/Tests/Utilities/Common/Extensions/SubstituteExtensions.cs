using NSubstitute;

namespace WizardSpells.Tests.Utilities.Common.Extensions
{
    public static class SubstituteExtensions
    {
        public static T SubstituteIfDefault<T>(this T obj) where T : class => obj ?? Substitute.For<T>();
    }
}