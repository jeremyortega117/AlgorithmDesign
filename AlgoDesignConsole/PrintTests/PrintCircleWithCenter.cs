using System;
using GeometricCirlces.Models;
using GeometricPoints;

namespace AlgoDesignConsole.PrintTests
{
    public static class PrintCircleWithCenter
    {
        public static void printText(PointVal[] seedPoints, Circle circle)
        {
            Console.WriteLine("Point1: x:{0}  y:{1}", seedPoints[0].x, seedPoints[0].y);
            Console.WriteLine("Point2: x:{0}  y:{1}", seedPoints[1].x, seedPoints[1].y);
            Console.WriteLine("Point3: x:{0}  y:{1}", seedPoints[2].x, seedPoints[2].y);

            Console.WriteLine("the Center of the circle of the three points:\nx: {0}\ny: {1}\nRadius: {2}", circle.getX, circle.getY, circle.rad );

        }
    }
}
