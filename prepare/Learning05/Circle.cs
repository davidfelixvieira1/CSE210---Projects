using System;

public class Circle : Shape
{
    private double _radius;

    // Constructor
    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    // Override method to get area for circle
    public override double GetArea()
    {
        return Math.PI * Math.Pow(_radius, 2);
    }
}