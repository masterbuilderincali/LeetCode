/*
Author: Jingqing Shao
*/

using System;

namespace AddTwoInt
{
    public class ListNode {
        public int val;
        public ListNode next = null;
        public ListNode(int x) { val = x; }
    }
    public class Program
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
            int carryover = 0;
            ListNode result = new ListNode(l1.val+l2.val);
            if(l1.val+l2.val>=10){
                carryover = 1;
                result.val = result.val%10;
            }
            ListNode head = result;
            while(l1.next != null || l2.next != null || carryover == 1){
                if(l1.next != null) l1 = l1.next;
                else l1.val = 0;
                if(l2.next != null) l2 = l2.next;
                else l2.val = 0;
                result.next = new ListNode(l1.val+l2.val+carryover);
                if(l1.val+l2.val+carryover >= 10) {
                    carryover = 1;
                    result.next.val = result.next.val%10;
                }
                else{
                    carryover = 0;
                }
                result = result.next;
            }
            return head;
        }

        void printLN(ListNode node) {
            string str = "[";
            while(node.next != null){
                str += node.val.ToString() + ',';
                node = node.next;
            }
            if(node.next == null) {
                str+= node.val.ToString() + ']';
            }
            Console.WriteLine(str);
        }
    
        static void Main(string[] args)
        {
            Program test = new Program();
            ListNode node1 = new ListNode(2);
            node1.next = new ListNode(4);
            node1.next.next = new ListNode(3);

            ListNode node2 = new ListNode(5);
            node2.next = new ListNode(6);
            node2.next.next = new ListNode(4);

            ListNode result = test.AddTwoNumbers(node1, node2);
            test.printLN(result);
        }
    }
}
