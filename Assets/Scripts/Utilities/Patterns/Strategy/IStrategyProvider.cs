namespace WizardSpells.Utilities.Patterns.Strategy
{
    public interface IStrategyProvider<out TStrategy, in TStrategyKey> where TStrategy : IStrategy
    {
        TStrategy GetStrategy(TStrategyKey strategyKey);
    }
}