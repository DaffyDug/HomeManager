using System;
class Program
{
    static void Main(string[] args)
    {
        ICommandHome[] commandHome = new ICommandHome[]
{
        new OnSun(),
        new OffSun(),
        new Onvacuum_cleaner(),
        new water_supply(),
        new Onsignaling(),
        new order_food()
};
        while (true)
        {
            StartMenu(commandHome);
            if (InputHelper.Input("введите что вы хотите делать: ", 1, commandHome.Length, out int inputvalue))
            {
                commandHome[inputvalue - 1].Run();
            }
        }
    }
    public static void StartMenu(ICommandHome[] commandHome)
    {
        for (int i = 0; i < commandHome.Length; i++)
        {
            Console.WriteLine($"{i + 1}--{commandHome[i]}");
        }
        Console.WriteLine('\n');
    }
}
class OnSun : ICommandHome
{
    public void Run()
    {
        Console.WriteLine("свет включился");
    }
}
class OffSun : ICommandHome
{
    public void Run()
    {
        Console.WriteLine("свет выключился");
    }
}
class Onvacuum_cleaner : ICommandHome
{
    public void Run()
    {
        Console.WriteLine("пылесос работает");
    }
}
class water_supply : ICommandHome
{
    public void Run()
    {
        Console.WriteLine("подача воды");
    }
}
class Onsignaling : ICommandHome
{
    public void Run()
    {
        Console.WriteLine("сигнализация включена");
    }
}
class order_food : ICommandHome
{
    public void Run()
    {
        Console.WriteLine("еда заказана");
    }
}
