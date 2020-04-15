using GeometricPoints;
using System;

namespace GeometricCirlces.CircleAlgorithms
{
    public class CircleFinder
    {
        // a given three points
        public PointVal P1 { set;  get; }
        public PointVal P2 { set;  get; }
        public PointVal P3 { set;  get; }


        // the center and first two medians of the 
        public PointVal Center { set;  get; }
        public PointVal Median1 { set;  get; }
        public PointVal Median2 { set;  get; }

        public double Slope1 { set;  get; }
        public double Slope2 { set;  get; }

        public double X1 { set;  get; }
        public double Y1 { set;  get; }

        public double Radius { set; get; }



        public CircleFinder(PointVal p1, PointVal p2, PointVal p3)
        {

            /*
             * esnure That the slopes work correctly in that the second point
             * is found to have a higher x value than the first.
             */
            if (p1.x < p2.x && p2.x < p3.x)
            {
                System.Console.WriteLine("Circle Dots 1");
                this.P2 = p1;
                this.P3 = p2;
                this.P1 = p3;
            }
            else if (p1.x > p2.x && p2.x > p3.x)
            {
                System.Console.WriteLine("Circle Dots 2");
                this.P1 = p1;
                this.P2 = p3;
                this.P3 = p3;
            }
            else if (p1.x < p2.x && p2.x > p3.x)
            {
                System.Console.WriteLine("Circle Dots 3");
                this.P2 = p1;
                this.P3 = p3;
                this.P1 = p2;
            }
            else if (p1.x > p2.x && p2.x < p3.x)
            {
                System.Console.WriteLine("Circle Dots 4");
                this.P1 = p1;
                this.P3 = p2;
                this.P2 = p3;
            }
        }

        public PointVal findCenter()
        {
            /* find middle of 2 sets of points */
            Median1 = new PointVal((P1.x + P2.x) / 2, (P1.y + P2.y) / 2);
            Median2 = new PointVal((P2.x + P3.x) / 2, (P2.y + P3.y) / 2);

            /* find slopes of normals to these two median points found above */
            Slope1 = (-1 / ((P1.y - P2.y) / (P1.x - P2.x)));
            Slope2 = (-1 / ((P2.y - P3.y) / (P2.x - P3.x)));

            /*
            * y - y1 = m (x - x1);
            * y = m (x - x1) + y1;
            * y = m*x - m*x1 + y1;
            *
            *   y = m1*x - m1*x1 + y1;
            * -(y = m2*x - m2*x2 + y2);
            *
            *   y =  m1*x - m1*x1 + y1;
            *  -y = -m2*x + m2*x2 - y2;
            *
            * 0 = m1*x - m2*x  +m2*x2 - m1*x1 + y1 - y2
            * m2*x - m1*x = m2*x2 - m1*x1 + y1 - y2
            *
            *  // Center at (x, y);
            * x = (m2*x2 - m1*x1 + y1 - y2) / (m2 - m1)
            * y = m1*x - m1*x1 + y1;
            */

            /* use point slope notation to find the intersection of the two normals, returning the center */
            X1 = (Slope2*Median2.x - Slope1*Median1.x + Median1.y - Median2.y) / (Slope2 - Slope1);
            Y1 = Slope1*X1 - Slope1*Median1.x + Median1.y;


            // set and find radius
            Radius = Math.Sqrt(Math.Pow(Math.Abs(X1 - P1.x), 2) + Math.Pow(Math.Abs(Y1 - P1.y), 2));

            return new PointVal(X1, Y1);
        }
    }
}
