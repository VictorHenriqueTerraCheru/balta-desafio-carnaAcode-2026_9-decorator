using Decorator.Decorators;
using Decorators;
using Interfaces;
using Models;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Decorator Pattern - Cafeteria ===\n");

        TestSimpleBeverages();
        Console.WriteLine("\n" + new string('-', 60) + "\n");

        TestSingleDecorator();
        Console.WriteLine("\n" + new string('-', 60) + "\n");

        TestMultipleDecorators();
        Console.WriteLine("\n" + new string('-', 60) + "\n");

        TestComplexOrders();
        Console.WriteLine("\n" + new string('-', 60) + "\n");

        ShowBenefits();
    }

    static void TestSimpleBeverages()
    {
        Console.WriteLine("TESTE 1: Bebidas Simples\n");

        var espresso = new Espresso();
        Console.WriteLine($"{espresso.GetDescription()}: R$ {espresso.GetCost():N2}");

        var cappuccino = new Cappuccino();
        Console.WriteLine($"{cappuccino.GetDescription()}: R$ {cappuccino.GetCost():N2}");

        var cha = new Cha();
        Console.WriteLine($"{cha.GetDescription()}: R$ {cha.GetCost():N2}");
    }

    static void TestSingleDecorator()
    {
        Console.WriteLine("TESTE 2: Um Complemento\n");

        var cafe1 = new LeiteDecorator(new Espresso());
        Console.WriteLine($"{cafe1.GetDescription()}: R$ {cafe1.GetCost():N2}");

        var cafe2 = new ChocolateDecorator(new Cappuccino());
        Console.WriteLine($"{cafe2.GetDescription()}: R$ {cafe2.GetCost():N2}");

        var cafe3 = new ChantillyDecorator(new Cha());
        Console.WriteLine($"{cafe3.GetDescription()}: R$ {cafe3.GetCost():N2}");
    }

    static void TestMultipleDecorators()
    {
        Console.WriteLine("TESTE 3: Múltiplos Complementos\n");
        // testando dessa forma feia so para deixar claro o sentido de como os decorators se empilham

        var cafe1 = new ChocolateDecorator(
                        new LeiteDecorator(
                            new Espresso()));
        Console.WriteLine($"{cafe1.GetDescription()}: R$ {cafe1.GetCost():N2}");

        var cafe2 = new ChantillyDecorator(
                        new ChocolateDecorator(
                            new LeiteDecorator(
                                new Cappuccino())));
        Console.WriteLine($"{cafe2.GetDescription()}: R$ {cafe2.GetCost():N2}");

        var cafe3 = new CarameloDecorator(
                        new ChantillyDecorator(
                            new ChocolateDecorator(
                                new Espresso())));
        Console.WriteLine($"{cafe3.GetDescription()}: R$ {cafe3.GetCost():N2}");
    }

    static void TestComplexOrders()
    {
        Console.WriteLine("TESTE 4: Pedidos Complexos\n");
        // agora fazendo de forma mais fluida, sem se preocupar com a ordem de empilhamento dos decorators e deixando mais agradavel de ler
        IBeverage pedido1 = new Espresso();
        pedido1 = new LeiteDecorator(pedido1);
        pedido1 = new ChocolateDecorator(pedido1);
        pedido1 = new ChantillyDecorator(pedido1);
        pedido1 = new CarameloDecorator(pedido1);

        Console.WriteLine($"Pedido 1: {pedido1.GetDescription()}");
        Console.WriteLine($"Total: R$ {pedido1.GetCost():N2}\n");

        IBeverage pedido2 = new Cappuccino();
        pedido2 = new LeiteDecorator(pedido2);
        pedido2 = new ChocolateDecorator(pedido2);
        pedido2 = new ChocolateDecorator(pedido2);

        Console.WriteLine($"Pedido 2: {pedido2.GetDescription()}");
        Console.WriteLine($"Total: R$ {pedido2.GetCost():N2}");
    }

    static void ShowBenefits()
    {
        Console.WriteLine(">>> BENEFÍCIOS DO DECORATOR PATTERN\n");

        Console.WriteLine("ANTES: 3 bebidas × 2^4 combinações = 48 classes");
        Console.WriteLine("DEPOIS: 3 bebidas + 4 decorators = 7 classes");
        Console.WriteLine();

        Console.WriteLine("Adicionar novo complemento? Apenas +1 classe");
        Console.WriteLine("Combinar de infinitas formas sem criar novas classes");
        Console.WriteLine("Adicionar comportamento dinamicamente em runtime");
        Console.WriteLine("Open/Closed Principle respeitado");
        Console.WriteLine();

        Console.WriteLine("✅ ESTRUTURA:");
        Console.WriteLine("   IBeverage (interface)");
        Console.WriteLine("      ├── Espresso, Cappuccino, Cha (componentes)");
        Console.WriteLine("      └── BeverageDecorator (decorators)");
        Console.WriteLine("            └── Leite, Chocolate, Chantilly, Caramelo");
    }
}