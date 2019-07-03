using System;
using System.Collections.Generic;

namespace LinkedListMiddle
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = @"2
5
1 2 3 4 5
6
2 4 6 7 5 1";

            input = input.Replace("\r","");
            Test[] tests = parseInput(input);
            foreach(Test t in tests)
            {
                Console.WriteLine(t.getMiddle(t.getFirstNode()));
            }
        }

        static Test[] parseInput(string input)
        {
            string[] inputs = input.Split("\n");
            Test[] tests = new Test[Int32.Parse(inputs[0])];
            int testPos = 0;
            for(int i = 1; i < inputs.Length; i++)
            {
                if(i%2 == 0)
                {
                    string[] list = inputs[i].Split(" ");
                    LinkedList<int> linkedList = new LinkedList<int>();
                    for (int j = 0; j < list.Length; j++)
                    {
                        int value = Int32.Parse(list[j]);
                        linkedList.AddLast(value);
                    }
                    Test t = new Test(linkedList);
                    tests[testPos] = t;
                    testPos++;
                }
                
            }
            return tests;
        }
    }
    class Test
    {
        LinkedList<int> list;

        public Test(LinkedList<int> t)
        {
            list = t;
        }

        public LinkedListNode<int> getFirstNode()
        {
            return list.First;
        }

        public int getMiddle()
        {
            int length = 1;
            LinkedListNode<int> cNode = list.First;
            LinkedListNode<int> mNode = null;

            while (cNode.Next != null)
            {
                cNode = cNode.Next;
                length++;
            }

            cNode = list.First;

            double d = length / 2;
            int middle = (int)Math.Ceiling(d);

            for (int i = 0; i < middle; i++)
            {
                cNode = cNode.Next;
                mNode = cNode;
            }

            return mNode.Value;
        }

        public int getMiddle(LinkedListNode<int> node)
        {
            int length = 1;
            LinkedListNode<int> cNode = node;
            LinkedListNode<int> mNode = null;

            while (cNode.Next != null)
            {
                cNode = cNode.Next;
                length++;
            }

            cNode = node;

            double d = length / 2;
            int middle = (int)Math.Ceiling(d);

            for(int i = 0; i < middle; i++)
            {
                cNode = cNode.Next;
                mNode = cNode;
            }

            return mNode.Value;
        }
    }
}
