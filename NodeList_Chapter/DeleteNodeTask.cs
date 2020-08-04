using System;
using System.Collections.Generic;
using System.Text;

namespace NodeList_Chapter
{
    internal class DeleteNodeTask
    {
        public static void OnMain()
        {
            var node1 = new ListNode1(4);
            var node2 = new ListNode1(2);
            var node3 = new ListNode1(3);
            var node4 = new ListNode1(4);
            var node5 = new ListNode1(5);
            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            node5.next = null;
        }

        public static void DeleteNode(ListNode1 node)
        {
            if (node.next != null)
            {
                node.val = node.next.val;
                node.next = node.next.next;
            }
            node = null;
        }
    }

    public class ListNode1
    {
        public int val;
        public ListNode1 next;

        public ListNode1(int x)
        {
            val = x;
        }
    }
}