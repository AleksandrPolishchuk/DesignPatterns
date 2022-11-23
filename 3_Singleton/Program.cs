// See https://aka.ms/new-console-template for more information
Console.WriteLine("Singleton");

Computer comp = new Computer();
comp.Launch("Linux");

if (comp.OS != null) Console.WriteLine(comp.OS.Name);

comp.OS = OS.getInstance("Win10");
Console.WriteLine(comp.OS.Name);

Console.ReadLine();

class Computer
{
    public OS? OS { get; set; }
    public void Launch(string osName)
    {
        OS = OS.getInstance(osName);
    }
}

class OS
{
    private static OS? instance;
    public string Name { get; private set; }

    protected OS(string name)
    {
        this.Name = name;
    }

    public static OS getInstance(string name)
    {
        if (instance == null)
            instance = new OS(name);
        return instance;
    }
}
