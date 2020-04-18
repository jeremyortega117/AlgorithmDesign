using GeometricPoints;
using System;

namespace GameObjects
{
    public class NPCObject : INPCObject
    {
        public PointVal PV { get; set; }
        public NPCObject()
        {
            this.PV = new PointVal(0, 0);
        }
    }
}
