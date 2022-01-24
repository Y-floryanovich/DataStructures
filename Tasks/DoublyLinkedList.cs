using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        public int Length { get; set; }
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }

        public void Add(T e)
        {
            var node = new Node<T>(e);
            if (Tail == null)
            {
                Head = node;
            }
            else
            {
                node.Previous = Tail;
                Tail.Next = node;
            }
            Tail = node;
            Length++;
        }

        public void AddAt(int index, T e)
        {
            if (index > Length || index < 0)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            var newNode = new Node<T>(e);
            var node = GetNodeByIndex(index);
            if (node == null)
            {
                Add(e);
                return;
            }

            if (node == Head)
            {
                node.Previous = newNode;
                newNode.Next = node;
                Head = newNode;
            }
            else
            {
                newNode.Next = node;
                newNode.Previous = node.Previous;
                node.Previous.Next = newNode;
                node.Previous = newNode;
            }

            Length++;
        }

        public T ElementAt(int index)
        {
            if (index > Length - 1 || index < 0)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            return GetNodeByIndex(index).Value;
        }

        public void Remove(T item)
        {
            var node = Head;
            var iteration = 0;

            while (!node.Value.Equals(item) && iteration != Length - 1)
            {
                iteration++;
                node = node.Next;
            }

            if (node.Value.Equals(item))
            {
                if (node == Tail)
                {
                    Tail = node.Previous;
                    node.Previous.Next = null;
                }
                else if (node == Head)
                {
                    Head = node.Next;
                    node.Next.Previous = null;
                }
                else
                {
                    node.Previous.Next = node.Next;
                    node.Next.Previous = node.Previous;
                }

                Length--;
            }
        }

        public T RemoveAt(int index)
        {
            if (Length == 0 || index > Length - 1 || index < 0)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            var node = GetNodeByIndex(index);

            if (node == Tail)
            {
                Tail = node.Previous;
            }
            else
            {
                node.Next.Previous = node.Previous;
            }

            if (node == Head)
            {
                Head = node.Next;
            }
            else
            {
                node.Previous.Next = node.Next;
            }

            Length--;
            return node.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DoublyLinkedListEnumerator<T>(this);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private Node<T> GetNodeByIndex(int index)
        {
            int iteration = 0;
            var node = Head;

                while (iteration != index)
                {
                    iteration++;
                    node = node.Next;
                }

            return node;
           
        }
    }
}
