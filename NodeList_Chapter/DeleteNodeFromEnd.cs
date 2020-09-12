using System;
using System.Collections.Generic;
using System.Text;

namespace NodeList_Chapter
{
    public class DeleteNodeFromEnd
    {
        public static void OnMain()
        {
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);
            var node4 = new ListNode(4);
            var node5 = new ListNode(5);
            var node6 = new ListNode(6);

            var node7 = new ListNode(7);
            var node8 = new ListNode(8);

            node1.next = node2;
            node2.next = node3;
            node3.next = null;

            node4.next = node5;
            node5.next = node6;
            node6.next = node7;

            node7.next = node8;
            node8.next = node2;

            // var l = RemoveNthFromEnd(node1, 2);
            //var l1 = ReverseList(node1);
            // var ans = IsPalindrome(node1);

            Console.WriteLine(HasCycle(node1));
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

        public static ListNode ReverseListBetter(ListNode head)
        {
            ListNode prev = null;
            while (head != null)
            {
                var next = head.next;
                head.next = prev;
                prev = head;
                head = next;
            }
            return prev;
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

        public static bool IsPalindrome(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return true;
            }

            var dum_head = new ListNode(0);
            dum_head.next = head;

            int distance = 0;
            int counter = 0;

            var firstPointer = dum_head.next;
            var secondPointer = dum_head.next;

            while (secondPointer.next != null)
            {
                secondPointer = secondPointer.next;
                counter++;
            }
            if (firstPointer.val != secondPointer.val)
            {
                return false;
            }

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

                if (firstPointer.val != secondPointer.val)
                {
                    return false;
                }
                firstPointer = firstPointer.next;
                secondPointer = firstPointer;
                distance += 2;
            }

            return true;
        }

        public static bool IsPalindromeBetter(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return true;
            }

            var dum_head = new ListNode(0);
            dum_head.next = head;

            var firstPointer = dum_head.next;
            var secondPointer = dum_head.next;

            while (secondPointer != null && secondPointer.next != null)
            {
                secondPointer = secondPointer.next.next;
                firstPointer = firstPointer.next;
            }
            firstPointer = ReverseListBetter(firstPointer);
            secondPointer = dum_head.next;
            while (firstPointer != null)
            {
                if (firstPointer.val != secondPointer.val)
                {
                    return false;
                }
                firstPointer = firstPointer.next;
                secondPointer = secondPointer.next;
            }
            return true;
        }

        public static bool HasCycle(ListNode head)
        {
            HashSet<ListNode> nodes = new HashSet<ListNode>();
            var dumHead = new ListNode();
            dumHead.next = head;

            while (dumHead.next != null)
            {
                if (nodes.Contains(dumHead.next))
                {
                    return true;
                }
                nodes.Add(dumHead.next);
                dumHead = dumHead.next;
            }
            Console.WriteLine();
            return false;
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