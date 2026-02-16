using Interfaces;

namespace Models
{
    public class Cha : IBeverage
    {
        public decimal GetCost() => 2.50m;
        public string GetDescription() => "Cha";
    }
}