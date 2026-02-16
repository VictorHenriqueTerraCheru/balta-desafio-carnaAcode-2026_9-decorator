using Interfaces;

namespace Decorators
{
    public class ChantillyDecorator : BeverageDecorator
    {
        public ChantillyDecorator(IBeverage beverage) : base(beverage) { }
        public override decimal GetCost() => 1.00m + _beverage.GetCost();
        public override string GetDescription() => _beverage.GetDescription() + " com Chantilly";
    }
}