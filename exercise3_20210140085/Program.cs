using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise3_20210140085
{
    class Node
    {
        public int rollNumber;
        public string name;
        public Node next;
    }
    class CircularList
    {
        Node LAST;

        public CircularList()
        {
            LAST = null;
        }
        public void addNode()
        {
            int rollNo;
            string nm;

            Console.Write("enter the roll number: ");
            rollNo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter the name of the students: ");
            nm = Console.ReadLine();

            Node newNode = new Node();

            newNode.name = nm;
            newNode.rollNumber = rollNo;

            if (LAST == null || rollNo <= LAST.rollNumber)
            {
                if ((LAST != null) && (rollNo == LAST.rollNumber))
                {
                    Console.WriteLine("Duplicate roll number not allowed");
                    return;
                }
                newNode.next = LAST;
                LAST = newNode;
                return;
            }
            Node previous, current;
            previous = LAST;
            current = LAST;

            while ((current != null) && (rollNo >= current.rollNumber))
            {
                if (rollNo == current.rollNumber)
                {
                    Console.WriteLine("Duplicate roll number not allowed");
                    return;
                }
                previous = current;
                current = current.next;
            }
            newNode.next = current;
            previous.next = newNode;
        }
        public bool Search(int rollNo, ref Node previous, ref Node current)
        {
            for (previous = current = LAST.next; current != LAST;
                previous = current, current = current.next)
            {
                if (rollNo == current.rollNumber)
                    return (true);
            }
            if (rollNo == LAST.rollNumber)
                return true;
            else
                return (false);
        }
        public bool delNode(int rollNo)
        {
            Node previous, current;
            previous = current = null;
            if (Search(rollNo, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if (current == LAST)
            {
                LAST = LAST.next;
            }
            return true;
        }
        public bool listEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecords in the list are: \n");
                Node currentNode;
                currentNode = LAST.next;
                while (currentNode != LAST)
                {
                    Console.Write(currentNode.rollNumber + " " +
                        currentNode.name + "\n");
                    currentNode = currentNode.next;
                }
                Console.Write(LAST.rollNumber + " " + LAST.name + "\n");
            }
        }
        public void firstNode()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
                Console.WriteLine("\nThe first record in the list is:\n\n" +
                    LAST.next.rollNumber + " " + LAST.next.name);
        }
        static void Main(string[] args)
        {
            CircularList obj = new CircularList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. View all the records in the list");
                    Console.WriteLine("2. Search for a record in the list");
                    Console.WriteLine("3. Display the first record in the list");
                    Console.WriteLine("4. Add data in the list");
                    Console.WriteLine("5. Delete data in the list");
                    Console.WriteLine("6. Exit");
                    Console.WriteLine("\nEnter your choice (1-5): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.traverse();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nEnter the roll number of the students whose records is to be searched: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nRoll number: " + curr.rollNumber);
                                    Console.WriteLine("\nName: " + curr.name);
                                }
                            }
                            break;
                        case '3':
                            {
                                obj.firstNode();
                            }
                            break;
                        case '4':
                            {
                                obj.addNode();
                            }
                            break;
                        case '5':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("list empty");
                                }
                                Console.WriteLine("enter the roll number of" + "the name whose record to be deleted: ");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.delNode(rollNo) == false)
                                    Console.WriteLine("record not found");
                                else
                                    Console.WriteLine("record with rollnumber" + rollNo + "deleted");
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("Invalid option");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
