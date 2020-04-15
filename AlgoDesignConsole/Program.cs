using System;
using GeometricCirlces.SeedData;
using GeometricCirlces.CircleAlgorithms;
using GeometricPoints;
using GeometricCirlces.Models;

namespace AlgoDesignConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Circle test
            CircleConsoleTest();

            // ConvexHull Test
            ConvexHullTest();
        }


        /// <summary>
        /// This method demonstrates testing of finding the circle whose circumfrence 
        /// connects a set of three 2D coordinates
        /// </summary>
        public static void CircleConsoleTest()
        {
            Console.WriteLine("Creating Cirlce");

            // create seed data for testing purposes
            PointVal[] seedPoints = Basic.getSeedDataCircles();

            // circle object that stores the circle data
            CircleFinder circCenter = new CircleFinder(seedPoints[0], seedPoints[1], seedPoints[2]);

            // perform the calculation to find the center of the circle
            PointVal centerPoint = circCenter.findCenter();

            // create a circle model object. This ieasier to send the circle data across HTTP for example
            Circle circle = new Circle(centerPoint.x, centerPoint.y, circCenter.Radius);

            PrintTests.PrintCircleWithCenter.printText(seedPoints, circle);
        }


        public static void ConvexHullTest()
        {
            Console.WriteLine("Creating Convex Hull");
        }
    }
}
