// See https://aka.ms/new-console-template for more information

Car auto = new Car(3, "Kia", new PetrolMove());
auto.Move();
auto.Movable = new ElectricMove();
auto.Move();
Console.ReadLine();

interface IMovable
{
    void Move();
}

class PetrolMove : IMovable
{
    public void Move()
    {
        Console.WriteLine("Едем на бензине");
    }
}

class ElectricMove : IMovable
{
    public void Move()
    {
        Console.WriteLine("Едем на электричестве");
    }
}
class Car
{
    protected int passengers;
    protected string model;

    public Car(int num, string model, IMovable mov)
    {
        this.passengers = num;
        this.model = model;
        Movable = mov;
    }
    public IMovable Movable { private get; set; }
    public void Move()
    {
        Movable.Move();
    }
}