using System;

public class Shape
{
    protected string _color;

    // Constructor
    public Shape(string color)
    {
        _color = color;
    }

    // Getter and setter for color
    public string GetColor()
    {
        return _color;
    }

    // Virtual method for getting area
    public virtual double GetArea()
    {
        return 0; // Placeholder implementation, should be overridden in derived classes
    }
}