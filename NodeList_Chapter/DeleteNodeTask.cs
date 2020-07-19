using System;
using System.Collections.Generic;
using System.Text;

namespace NodeList_Chapter
{
    internal class DeleteNodeTask
    {
        public static void OnMain()
        {
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);
            var node4 = new ListNode(4);
            var node5 = new ListNode(5);
            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            node5.next = null;
        }

        public static void DeleteNode(ListNode node)
        {
            if (node.next == null)
            {
                node = null;
                return;
            }
            node = node.next;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int x)
        {
            val = x;
        }
    }
}