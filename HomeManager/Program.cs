using System;
class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu(new OnSun(), new OffSun(), new Onvacuum_cleaner(), new water_supply(), new order_food());
        menu.Start();
    }
}

public class Menu
{
    private readonly ICommandHome[] command;
    private int _currentindex;
    public Menu(params ICommandHome[] commandHome)
    {
        command = commandHome;
    }
    public void Start()
    {
        Console.Clear();
        for (int i = 0; i < command.Length; i++)
        {
            if (i == _currentindex)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(command[i].description);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine(command[i].description);
            }
        }
        GetUserInput();
    }
    private void GetUserInput()
    {
        switch (Console.ReadKey().Key)
        {
            case ConsoleKey.DownArrow:
                _currentindex++;
                break;
            case ConsoleKey.UpArrow:
                _currentindex--;
                break;
            case ConsoleKey.Enter:
                command[_currentindex].Run();
                Console.WriteLine("нажмите любую клавишу");
                Console.ReadKey();
                break;
        }
        _currentindex = Math.Clamp(_currentindex, 0, command.Length - 1);
        Start();
    }
}

class OnSun : ICommandHome
{
    public string description => "включить свет";

    public void Run()
    {
        Console.WriteLine("свет включился");
    }
}
class OffSun : ICommandHome
{
    public string description => "выключить свет";

    public void Run()
    {
        Console.WriteLine("свет выключился");
    }
}
class Onvacuum_cleaner : ICommandHome
{
    public string description => "включить пылесос";

    public void Run()
    {
        Console.WriteLine("пылесос работает");
    }
}
class water_supply : ICommandHome
{
    public string description => "включить воду";

    public void Run()
    {
        Console.WriteLine("подача воды");
    }
}
class Onsignaling : ICommandHome
{
    public string description => "включить сигнализацию";

    public void Run()
    {
        Console.WriteLine("сигнализация включена");
    }
}
class order_food : ICommandHome
{
    public string description => "заказать еду";

    public void Run()
    {
        Console.WriteLine("еда заказана");
    }
}
