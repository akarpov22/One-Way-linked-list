using NPOI.SS.Formula.PTG;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public class OneWayList
    {
        public int Length = 0;
        public Node FirstNode;
        Node LastNode;
        public void Remove(int index)
        {
            if(index==0)
            {
                LastNode.NextNode = FirstNode.NextNode;
                FirstNode = FirstNode.NextNode;
                Length--;
            }else if(index==this.Length - 1)
            {
                Node current = FirstNode;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.NextNode;
                }
                current.NextNode = FirstNode;
                LastNode = current;
                Length--;
            }
            else if (Length > 1)
            {
                Node current = FirstNode;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.NextNode;
                }
                current.NextNode = current.NextNode.NextNode;
                Length--;
            }
            else
            {
                FirstNode = LastNode = null;
            }
        }
        public void Add(int data)
        {
            Node tnode = new Node(data);
            if (this.Length == 0) this.FirstNode = this.LastNode = tnode;
            else
            {
                this.LastNode.NextNode = tnode;
                this.LastNode = tnode;
                this.LastNode.NextNode = this.FirstNode;
            }

            this.Length++;
        }
        public void Show()
        {
            Node current = FirstNode;
            for (int i=0;i<this.Length;i++)
            {
                Console.Write(current.Data + "| ");
                current = current.NextNode;
            }
            Console.WriteLine();
        }
        public int Get(int index)
        {
            Node current = FirstNode;
            for (int i = 0; i < index; i++) 
            {
                current = current.NextNode;
            }
            return current.Data;
        }

        public class Node
        {
            internal int Data;
            internal Node NextNode;//pointer

            public Node(int data)
            {
                this.Data = data;
            }
        }
    }
}
