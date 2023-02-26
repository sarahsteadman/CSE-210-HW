using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> lester = new List<Shape>();

        Square bob = new Square(8);

        Rectangle shareen = new Rectangle(12,13);

        Circle obert = new Circle(5);

        lester.Add(bob);
        lester.Add(shareen);
        lester.Add(obert);

        foreach (Shape monster in lester)
        {
            Console.WriteLine(monster.GetArea());
        }
    }

    public abstract class Shape
    {
        protected string _color;

        public string GetColor()
        {
            return _color;
        }
        public void SetColor(string color)
        {
            _color = color;
        }
        public abstract double GetArea();
    }

    public class Square : Shape
    {
        private double _side;

        public Square(double side)
        {
            _side = side;
        }
        public override double GetArea()
        {
            return _side * _side;
        }
    }
    public class Rectangle : Shape
    {
        private double _length;
        private double _width;

        public Rectangle(double length,double width)
        {
            _length = length;
            _width = width;
        }

        public override double GetArea()
        {
            return _length * _width;
        }
    }

    public class Circle : Shape
    {
        private double _radius;

        public Circle(double radius)
        {
            _radius = radius;
        }
        public override double GetArea()
        {
            return Math.Pow(_radius * 3.15, 2);
        }
    }
}