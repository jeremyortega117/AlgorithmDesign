using DataStructures;
using GameObjects;
using System;

namespace JarvisMarchAlgorithm
{
    public class JarvisMarch
    {
		private DblLinkedList head;
		private DblLinkedList curr;
		private DblLinkedList prev;
		private DblLinkedList topEnd;
		private int size;

		// Gathers and runs the algorithm for the jarvise's march
		public JarvisMarch(int size)
		{
			this.size = size;
		}

		public DblLinkedList getHead()
		{
			return head;
		}
		public DblLinkedList getTopEnd()
		{
			return topEnd;
		}


		public void algoTop(NPCObject[] NPC)
		{
			// check if we need to perform a convex hull algorithm.
			if (lessThanTwoCheck(NPC))
				return;

			// Go through all but the first and last index's
			for (int trav = 2; trav < size; trav++)
			{

				// find out if the current point is part of the convex hull or not.
				double hCheck = hullCheck(NPC, prev, curr, trav);
				DblLinkedList DLL = new DblLinkedList(NPC[trav]);

				/*
				 * Check if the convex Hull should be outside of the current node
				 */
				if (hCheck < curr.NPC.PV.y)
				{

					/*
					 * Check each previous node on the convex hull until up until we are sure no current
					 * node will be fully contained in the new convex hull.
					 */
					while (prev != head)
					{
						/*
						 * Check each new convex hull compared to the previous node.
						 */
						double newHullCheck = hullCheck(NPC, prev.prev, prev, trav);
						if (newHullCheck < prev.NPC.PV.y)
						{
							prev = prev.prev;
							prev.next = DLL;
						}
						/*
						 * once we verify that we've found a previous convex hull node that won't change from the
						 * current new node, we quit.
						 */
						else
						{
							break;
						}
					}
					/*
					 * This handles the same situation as directly above but takes care not to go past the
					 * head.
					 */
					if (prev == head)
					{
						double newHullCheck = hullCheck(NPC, prev, prev.next, trav);
						if (newHullCheck < prev.NPC.PV.y)
						{
							prev.next = DLL;
						}
					}
					/*
					 * update the connection between the new next convex hull node and the last verified node
					 * on the convex hull.
					 */
					DLL.prev = prev;
					prev.next = DLL;
				}

				/*
				 * If the Current Node is Outside the convex hull Then it becomes a part of the new
				 * convex hull
				 */
				else
				{
					curr.next = DLL;
					DLL.prev = curr;
					prev = curr;
				}
				/*
				 * update the current node along the convex hull.
				 */
				curr = DLL;
				// printCurrList();
			}
			topEnd = curr;
			algoBottom(NPC);
		}

		/**
		 * Same as above however swapped the LESS with GREATER signs when checking if vertex are
		 * apart of the convex hull.
		 * @param NPC
		 */
		public void algoBottom(NPCObject[] NPC)
		{

			DblLinkedList DLL_1 = new DblLinkedList(NPC[size - 1]);
			DLL_1.prev = topEnd;
			topEnd.next = DLL_1;

			prev = topEnd;
			curr = DLL_1;

			// Go through all but the first and last index's
			for (int trav = size - 2; trav > -1; trav--)
			{

				// find out if the current point is part of the convex hull or not.
				// double hullCheck = hullCheck(NPC, prev, curr, trav);
				double hCheck = hullCheckBottom(NPC, prev, curr, trav);
				DblLinkedList DLL = new DblLinkedList(NPC[trav]);

				/*
				 * Check if the convex Hull should be outside of the current node
				 */
				if (hCheck > curr.NPC.PV.y)
				{

					/*
					 * Check each previous node on the convex hull until up until we are sure no current
					 * node will be fully contained in the new convex hull.
					 */
					while (prev != topEnd)
					{
						/*
						 * Check each new convex hull compared to the previous node.
						 */
						double newHullCheck = hullCheckBottom(NPC, prev.prev, prev, trav);
						if (newHullCheck > prev.NPC.PV.y)
						{
							prev = prev.prev;
							prev.next = DLL;
						}
						/*
						 * once we verify that we've found a previous convex hull node that won't change from the
						 * current new node, we quit.
						 */
						else
						{
							break;
						}
					}
					/*
					 * This handles the same situation as directly above but takes care not to go past the
					 * head.
					 */
					if (prev == topEnd)
					{
						double newHullCheck = hullCheckBottom(NPC, prev, prev.next, trav);
						if (newHullCheck > prev.NPC.PV.y)
						{
							prev.next = DLL;
						}
					}
					/*
					 * update the connection between the new next convex hull node and the last verified node
					 * on the convex hull.
					 */
					DLL.prev = prev;
					prev.next = DLL;
				}

				/*
				 * If the Current Node is Outside the convex hull Then it becomes a part of the new
				 * convex hull
				 */
				else
				{
					curr.next = DLL;
					DLL.prev = curr;
					prev = curr;
				}
				/*
				 * update the current node along the convex hull.
				 */
				curr = DLL;
			}
			topEnd = curr;
			//printCurrList();
		}


		/**
		 * Check if the number of NPC's in an area are 2 or less.
		 * @param NPC
		 * @return
		 */
		private Boolean lessThanTwoCheck(NPCObject[] NPC)
		{
			// NPCs are zero
			if (NPC.Length == 0)
			{
				return true;
			}
			// create first linked list node.
			head = new DblLinkedList(NPC[0]);
			prev = head;
			if (NPC.Length == 1)
			{
				return true;
			}
			// Else prepare the second linked list.
			DblLinkedList DLL_Two = new DblLinkedList(NPC[1]);
			head.next = DLL_Two;
			DLL_Two.prev = head;
			curr = DLL_Two;
			if (NPC.Length == 2)
			{
				return true;
			}
			return false;
		}

		/**
		 * return the knowledge of whether or not a new point along the convex hull has been found.
		 * @param NPC
		 * @param pre
		 * @param trav
		 * @return
		 */
		public double hullCheck(NPCObject[] NPC, DblLinkedList prev, DblLinkedList currCheck, int trav)
		{

			double nextX = NPC[trav].PV.x;
			double nextY = NPC[trav].PV.y;

			double prevX = prev.NPC.PV.x;
			double prevY = prev.NPC.PV.y;

			double thisX = currCheck.NPC.PV.x;


			// (3, 2) and (6, 3) // y = mx + b
			double slope = (nextY - prevY) / (nextX - prevX);  // m
			double yInt = prevY - (slope * prevX);  // b

			// If this is lower than current point, the current point is no longer
			// a part of the hull.

			return slope * thisX + yInt;
		}
		/**
		 * Same as above but swapped the prev and next X and Y values so the slope intercept formula still works.
		 * @param NPC
		 * @param prev
		 * @param currCheck
		 * @param trav
		 * @return
		 */
		public double hullCheckBottom(NPCObject[] NPC, DblLinkedList prev, DblLinkedList currCheck, int trav)
		{

			double prevX = NPC[trav].PV.x;
			double prevY = NPC[trav].PV.y;

			double nextX = prev.NPC.PV.x;
			double nextY = prev.NPC.PV.y;

			double thisX = currCheck.NPC.PV.x;


			// (3, 2) and (6, 3) // y = mx + b
			double slope = (nextY - prevY) / (nextX - prevX);  // m
			double yInt = prevY - (slope * prevX);  // b

			// If this is lower than current point, the current point is no longer
			// a part of the hull.

			return slope * thisX + yInt;
		}

		//public void printCurrList()
		//{
		//	DblLinkedList Dbl = head;
		//	while (Dbl.next != null)
		//	{
		//		Console.WriteLine("" + Dbl.NPC.getId() + ", ");
		//		Dbl = Dbl.next;
		//	}
		//	Console.WriteLine("" + Dbl.getNPC().getId());
		//}
	}
}
