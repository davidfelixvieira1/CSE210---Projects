using System;

public class Square : Shape
{
    private double _side;

    // Constructor
    public Square(string color, double side) : base(color)
    {
        _side = side;
    }

    // Override method to get area for square
    public override double GetArea()
    {
        return Math.Pow(_side, 2);
    }
}