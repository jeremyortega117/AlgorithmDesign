using GameObjects;
using System;

namespace DataStructures
{
    public class DblLinkedList
    {

        public DblLinkedList next { get; set; }
        public DblLinkedList prev { get; set; }
        public NPCObject NPC { get; set; }

        public DblLinkedList(NPCObject npc)
        {
            NPC = npc;
        }
    }
}
