// See https://aka.ms/new-console-template for more information
using System.Drawing;

Console.WriteLine("Prototype");

IFigure figure = new Rectangle(30, 40);
IFigure clonedFigure = figure.Clone();
figure.GetInfo();
clonedFigure.GetInfo();

figure = new Circle(30);
clonedFigure = figure.Clone();
figure.GetInfo();
clonedFigure.GetInfo();

Console.Read();

abstract class Prototype
{
    public int Id { get; private set; }
    public Prototype(int id)
    {
        this.Id = id;
    }
    public abstract Prototype Clone();
}

interface IFigure
{
    IFigure Clone();
    void GetInfo();
}

class Rectangle : IFigure
{
    int width;
    int height;
    public Rectangle(int w, int h)
    {
        width = w;
        height = h;
    }
    public IFigure Clone()
    {
        return new Rectangle(this.width, this.height);
    }
    public void GetInfo()
    {
        Console.WriteLine("Прямоугольник длиной {0} и шириной {1}", height, width);
    }
}

class Circle : IFigure
{
    int radius;
    public Circle(int r)
    {
        radius = r;
    }
    public IFigure Clone()
    {
        return new Circle(this.radius);
    }
    public void GetInfo()
    {
        Console.WriteLine("Круг радиусом {0}", radius);
    }
}