using GeometricPoints;
using System;
using System.Collections.Generic;
using System.Text;

namespace JarvisMarchAlgorithm.SeedData
{
    class FivePointSeed
    {
        public static PointVal[] getSeedDataJarvis()
        {
            PointVal[] pv = new PointVal[5];
            pv[0] = new PointVal(100, 100);
            pv[1] = new PointVal(101, 300);
            pv[2] = new PointVal(200, 100);
            pv[3] = new PointVal(201, 300);
            pv[4] = new PointVal(150, 200);
            return pv;
        }
    }
}
