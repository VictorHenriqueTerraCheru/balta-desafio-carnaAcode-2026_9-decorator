using Interfaces;

namespace Models
{
    public class Espresso : IBeverage
    {
        public decimal GetCost() => 3.50m;
        public string GetDescription() => "Espresso";
    }
}