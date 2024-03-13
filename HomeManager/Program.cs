using System;
using System.Collections.Generic;
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
            CommandHome(commandHome);
        }
    }
    public static void CommandHome(ICommandHome[] commandHome)
    {
        for (int i = 0; i < commandHome.Length; i++)
        {
            Console.WriteLine($"{i + 1}--{commandHome[i]}");
        }
        Console.WriteLine('\n');
        int.TryParse(Console.ReadLine(), out int intvalue);
        commandHome[intvalue - 1].Run();
        Console.WriteLine('\n');
    }
}
class HomeManagerConsole
{
    public static readonly HomeManagerConsole homeManager;
    private HomeManagerConsole()
    { }
    static HomeManagerConsole()
    {
        homeManager = new HomeManagerConsole();
    }
    List<ICommandHome> Icommands = new List<ICommandHome>()
    {
        new OnSun(),
        new OffSun(),
        new Onvacuum_cleaner(),
        new water_supply(),
        new Onsignaling(),
        new order_food()
    };
    public void RunCommand<T>() where T : ICommandHome
    {
        foreach (var item in Icommands)
        {
            if (item.GetType() == typeof(T))
            {
                item.Run();
                break;
            }
        }
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
public interface ICommandHome
{
    public void Run();
}