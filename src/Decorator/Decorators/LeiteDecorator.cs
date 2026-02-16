using Interfaces;

namespace Decorators
{
    public class LeiteDecorator : BeverageDecorator
    {
        public LeiteDecorator(IBeverage beverage) : base(beverage) { }
        public override decimal GetCost() => 0.50m + _beverage.GetCost(); // SEU preço + bebida interna
        public override string GetDescription() => _beverage.GetDescription() + " com Leite";
    }
}