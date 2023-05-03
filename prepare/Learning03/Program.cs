using System;

class Fraction
{
    // Declare private attributes to hold the numerator and denominator
    private int top;
    private int bottom;

    // Constructor with no parameters, initializes to 1/1
    public Fraction()
    {
        top = 1;
        bottom = 1;
    }

    // Constructor with one parameter for the numerator, initializes denominator to 1
    public Fraction(int topValue)
    {
        top = topValue;
        bottom = 1;
    }

    // Constructor with two parameters for numerator and denominator
    public Fraction(int topValue, int bottomValue)
    {
        top = topValue;
        bottom = bottomValue;
    }

    // Getter and setter methods for the numerator
    public int GetTop()
    {
        return top;
    }

    public void SetTop(int value)
    {
        top = value;
    }

    // Getter and setter methods for the denominator
    public int GetBottom()
    {
        return bottom;
    }

    public void SetBottom(int value)
    {
        bottom = value;
    }

    // Method to return a string representation of the fraction
    public string GetFractionString()
    {
        return top + "/" + bottom;
    }

    // Method to return the decimal value of the fraction
    public double GetDecimalValue()
    {
        return (double)top / bottom;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a fraction with no parameters and display its string representation and decimal value
        Fraction fraction1 = new Fraction();
        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue());

        // Create a fraction with one parameter and display its string representation and decimal value
        Fraction fraction2 = new Fraction(5);
        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction2.GetDecimalValue());

        // Create a fraction with two parameters and display its string representation and decimal value
        Fraction fraction3 = new Fraction(3, 4);
        Console.WriteLine(fraction3.GetFractionString());
        Console.WriteLine(fraction3.GetDecimalValue());

        // Create a fraction with two parameters and display its string representation and decimal value
        Fraction fraction4 = new Fraction(1, 3);
        Console.WriteLine(fraction4.GetFractionString());
        Console.WriteLine(fraction4.GetDecimalValue());

        // Change the numerator and denominator of fraction4 and display its string representation and decimal value
        fraction4.SetTop(2);
        fraction4.SetBottom(5);
        Console.WriteLine(fraction4.GetFractionString());
        Console.WriteLine(fraction4.GetDecimalValue());
    }
}
