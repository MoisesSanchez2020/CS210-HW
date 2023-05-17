using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Square square = new Square("Red", 5.0);
        Rectangle rectangle = new Rectangle("Blue", 4.0, 6.0);
        Circle circle = new Circle("Green", 3.0);

        List<Shape> shapes = new List<Shape>();
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine("Color: " + shape.Color);
            Console.WriteLine("Area: " + shape.GetArea());
            Console.WriteLine();
        }
    }
}
