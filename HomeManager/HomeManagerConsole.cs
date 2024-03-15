using System.Collections.Generic;

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
