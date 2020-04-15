using System;

namespace GeometricCirlces.Models
{
    public class Circle
    {
        public double getX;
        public double getY;
        public double rad;

        public Circle(double y, double x, double radius)
        {
            this.getY = y;
            this.getX = x;
            this.rad = radius;
        }
    }
}
