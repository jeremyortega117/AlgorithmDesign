using System;
using System.Collections.Generic;
using System.Text;
using GeometricPoints;

namespace GeometricCirlces.SeedData
{
    public static class Basic
    {

        public static PointVal[] getSeedDataCircles()
        {
            PointVal[] pv = new PointVal[3];
            pv[0] = new PointVal(250, 250);
            pv[1] = new PointVal(300, 200);
            pv[2] = new PointVal(260, 270);
            return pv;
        }
    }
}
