using GameObjects;
using GeometricPoints;
using System;
using System.Collections.Generic;
using System.Text;

namespace JarvisMarchAlgorithm.SeedData
{
    public static class FivePointSeed
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

        public static NPCObject[] getGameObjectSeedDataJarvis()
        {
            NPCObject[] NPCO = new NPCObject[5];
            NPCO[0] = new NPCObject();
            NPCO[0].PV.x = 100;
            NPCO[0].PV.y = 100;

            NPCO[1] = new NPCObject();
            NPCO[1].PV.x = 101;
            NPCO[1].PV.y = 300;

            NPCO[2] = new NPCObject();
            NPCO[2].PV.x = 200;
            NPCO[2].PV.y = 100;

            NPCO[3] = new NPCObject();
            NPCO[3].PV.x = 201;
            NPCO[3].PV.y = 300;

            NPCO[4] = new NPCObject();
            NPCO[4].PV.x = 150;
            NPCO[4].PV.y = 200;
            return NPCO;
        }
    }
}
