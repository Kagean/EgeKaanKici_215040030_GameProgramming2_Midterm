using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public abstract class Item
{
    public string Name { get; protected set; }

    public Item(string name)
    {
        Name = name;
    }

    public abstract Task Collect();
}
public class Hilt : Item
{
    public Hilt() : base("Hilt") { }

    public override async Task Collect()
    {
        Console.WriteLine($"You've collected the {Name}.");
        await Task.Delay(1000);
    }
}

public class Cross : Item
{
    public Cross() : base("Cross") { }

    public override async Task Collect()
    {
        Console.WriteLine($"You've collected the {Name}.");
        await Task.Delay(1000);
    }
}

public class Blade : Item
{
    public Blade() : base("Blade") { }

    public override async Task Collect()
    {
        Console.WriteLine($"You've collected the {Name}.");
        await Task.Delay(1000);
    }
}