using System;
using GeometricCirlces.SeedData;
using GeometricCirlces.CircleAlgorithms;
using GeometricPoints;
using GeometricCirlces.Models;
using JarvisMarchAlgorithm;
using JarvisMarchAlgorithm.SeedData;
using SortingAlgorithm;
using DataStructures;
using GameObjects;

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

            JarvisMarch JMA = new JarvisMarch(5);

            MergeSort SA = new MergeSort();

            NPCObject[] NPCO = SA.sort(FivePointSeed.getGameObjectSeedDataJarvis() , 0, 4);

            DblLinkedList DLL = JMA.getConvexHull(NPCO);

            while (DLL != null)
            {
                Console.Write(DLL.NPC.PV.x);
                Console.WriteLine(" "+ DLL.NPC.PV.y);
                DLL = DLL.next;
            }

            //NPCO[0].PV.x = pv[0].x;
            //NPCO[0].PV.y = pv[0].y;
            //DblLinkedList DLLHead = new DblLinkedList(NPCO[0]);

            //NPCO[1].PV.x = pv[1].x;
            //NPCO[1].PV.y = pv[1].y;
            //DblLinkedList DLL = new DblLinkedList(NPCO[1]);
            //DLLHead.next = DLL;
            //DLL.prev = DLLHead;

            //for (int i = 2; i < 5; i++)
            //{
            //    NPCO[i].PV.x = pv[i].x;
            //    NPCO[i].PV.y = pv[i].y;
            //    DblLinkedList DL = new DblLinkedList(NPCO[i]);
            //    DLL.next = DL;
            //    DL.prev = DLL;
            //    DLL = DL;
            //}


        }
    }
}
