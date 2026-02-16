using Interfaces;

public abstract class BeverageDecorator : IBeverage
{
    protected IBeverage _beverage; // Guarda a bebida que envolve

    public BeverageDecorator(IBeverage beverage) => _beverage = beverage;

    public virtual decimal GetCost() => _beverage.GetCost(); // Delega para a bebida interna

    public virtual string GetDescription() => _beverage.GetDescription();
}