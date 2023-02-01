namespace WizardSpells.Tests.Utilities.Common.Extensions
{
    public static class CreateExtensions
    {
        public static T NewIfDefault<T>(this T obj) where T : class, new() => obj ?? new T();
    }
}