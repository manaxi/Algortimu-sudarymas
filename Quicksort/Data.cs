using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quicksort
{
    abstract class DataList
    {
        protected int length;
        public int Length { get { return length; } }
        public abstract IComparable Head();
        public abstract IComparable Next();
        //public abstract void Swap(IComparable a, IComparable b);
        public abstract void Write(IComparable a);
        public void Print(int n)
        {
            Console.Write(Head() + " ");
            for (int i = 1; i < n; i++)
                Console.Write(Next() + " ");
            Console.WriteLine();
        }
    }
    class MyDataList : DataList
    {
        class MyLinkedListNode
        {
            public MyLinkedListNode nextNode { get; set; }
            public IComparable data { get; set; }
            public MyLinkedListNode(IComparable data)
            {
                this.data = data;
            }
        }
        MyLinkedListNode headNode;
        MyLinkedListNode prevNode;
        MyLinkedListNode currentNode;
        public MyDataList(int n, int seed)
        {
            string s;
            length = n;
            Random rand = new Random(seed);
            s = Convert.ToString(Convert.ToInt32(rand.NextDouble() * 100));
            if (s.Length == 1) s = " " + s;

            headNode = new MyLinkedListNode(s);
            currentNode = headNode;
            for (int i = 1; i < length; i++)
            {
                prevNode = currentNode;
                s = Convert.ToString(Convert.ToInt32(rand.NextDouble() * 100));
                if (s.Length == 1) s = " " + s;
                currentNode.nextNode = new MyLinkedListNode(s);
                currentNode = currentNode.nextNode;
            }
            currentNode.nextNode = null;
        }
        public override IComparable Head()
        {
            currentNode = headNode;
            prevNode = null;
            return currentNode.data;
        }
        public override IComparable Next()
        {
            prevNode = currentNode;
            currentNode = currentNode.nextNode;
            return currentNode.data;
        }
        /*
                public override void Swap(IComparable a, IComparable b)
                {
                    prevNode.data = a;
                    currentNode.data = b;
                }
         */
        public override void Write(IComparable a)
        {
            //prevNode.data = a;
            currentNode.data = a;
        }

    }
}
