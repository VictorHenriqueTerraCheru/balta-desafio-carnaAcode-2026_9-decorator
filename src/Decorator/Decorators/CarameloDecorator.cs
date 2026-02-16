using Interfaces;

namespace Decorator.Decorators
{
    public class CarameloDecorator : BeverageDecorator
    {
        public CarameloDecorator(IBeverage beverage) : base(beverage) { }
        public override decimal GetCost() => 0.80m + _beverage.GetCost();
        public override string GetDescription() => _beverage.GetDescription() + " com Caramelo";
    }
}