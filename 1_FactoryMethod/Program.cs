// See https://aka.ms/new-console-template for more information
Console.WriteLine("FactoryMethod");

Developer dev = new PanelDeveloper("Фирма 1");
House house = dev.Create();

dev = new WoodDeveloper("Фирма 2");
House house2 = dev.Create();

Console.ReadLine();

abstract class Developer
{
    public string Name { get; set; }
    public Developer (string n)
    {
        Name = n;
    }

    // Factory Method
    abstract public House Create();
}

class PanelDeveloper : Developer
{
    public PanelDeveloper(string n) : base(n)
    { }

    public override House Create()
    {
        return new PanelHouse();
    }
}

class WoodDeveloper : Developer
{
    public WoodDeveloper(string n) : base(n) 
    {}

    public override House Create()
    {
        return new WoodHouse();
    }
}

abstract class House
{}

class PanelHouse : House
{
    public PanelHouse()
    {
        Console.WriteLine("Панельный дом построен");
    }
}

class WoodHouse : House
{
    public WoodHouse()
    {
        Console.WriteLine("Деревянный дом построен");
    }
}