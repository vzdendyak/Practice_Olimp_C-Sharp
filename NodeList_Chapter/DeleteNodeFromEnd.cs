using System;
using System.Collections.Generic;
using System.Text;

namespace NodeList_Chapter
{
    public class DeleteNodeFromEnd
    {
        public static void OnMain()
        {
            /*var node1 = new ListNode(3);
            var node2 = new ListNode(1);
            var node3 = new ListNode(3);
            var node4 = new ListNode(4);
            var node5 = new ListNode(1);
            var node6 = new ListNode(4);
            var node7 = new ListNode(-1);
            var node8 = new ListNode(1);

            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            node5.next = node6;
            node6.next = node7;
            node7.next = null;
            node8.next = null;*/

            // var l = RemoveNthFromEnd(node1, 2);
            //var l1 = ReverseList(node1);
            Console.WriteLine();
        }

        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var dumHead = new ListNode(0);
            dumHead.next = head;

            var firstPointer = dumHead;
            var secondPointer = dumHead;

            while (n != -1)
            {
                secondPointer = secondPointer.next;
                n--;
            }

            while (secondPointer != null)
            {
                firstPointer = firstPointer.next;
                secondPointer = secondPointer.next;
            }

            firstPointer.next = firstPointer.next.next;

            return dumHead.next;
        }

        public static ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            var dum_head = new ListNode(0);
            dum_head.next = head;

            int lastValue = 0;
            int distance = 0;
            int counter = 0;

            var firstPointer = dum_head.next;
            var secondPointer = dum_head.next;

            while (secondPointer.next != null)
            {
                secondPointer = secondPointer.next;
                counter++;
            }
            lastValue = firstPointer.val;
            firstPointer.val = secondPointer.val;
            secondPointer.val = lastValue;

            distance += 2;

            firstPointer = firstPointer.next;
            secondPointer = firstPointer;
            for (int i = 0; i < counter / 2; i++)
            {
                if (secondPointer.next == null)
                {
                    continue;
                }
                int j = 0;
                while (j != counter - distance)
                {
                    secondPointer = secondPointer.next;
                    j++;
                }

                lastValue = firstPointer.val;
                firstPointer.val = secondPointer.val;
                secondPointer.val = lastValue;

                firstPointer = firstPointer.next;
                secondPointer = firstPointer;
                distance += 2;
            }

            return dum_head.next;
        }

        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            var newHead = new ListNode(0);
            var cur_node = newHead;
            while (l1 != null && l2 != null)
            {
                if (l1.val > l2.val)
                {
                    cur_node.next = l2;
                    l2 = l2.next;
                }
                else
                {
                    cur_node.next = l1;
                    l1 = l1.next;
                }
                cur_node = cur_node.next;
            }
            if (l1 != null)
            {
                cur_node.next = l1;
                l1 = l1.next;
            }
            else if (l2 != null)
            {
                cur_node.next = l2;
                l2 = l2.next;
            }

            return newHead.next;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}