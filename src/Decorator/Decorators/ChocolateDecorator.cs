using Interfaces;

namespace Decorators
{
    public class ChocolateDecorator : BeverageDecorator
    {
        public ChocolateDecorator(IBeverage beverage) : base(beverage) { }
        public override decimal GetCost() => 0.70m + _beverage.GetCost();
        public override string GetDescription() => _beverage.GetDescription() + " com Chocolate";
    }
}