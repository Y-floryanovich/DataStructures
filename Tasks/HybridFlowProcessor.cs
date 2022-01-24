using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        const int StartIndex = 0;
        private readonly IDoublyLinkedList<T> list;

        public HybridFlowProcessor()
        {
            list = new DoublyLinkedList<T>();
        }

        public T Dequeue()
        {
            if (list.Length == 0)
            {
                throw new InvalidOperationException("Item list doesn't contain items");
            }
                
            return list.RemoveAt(StartIndex);
        }

        public void Enqueue(T item)
        {
            list.Add(item);
        }

        public T Pop()
        {
            if (list.Length == 0)
            {
                throw new InvalidOperationException("Item list doesn't contain items");
            }

            return list.RemoveAt(StartIndex);
        }

        public void Push(T item)
        {
           list.AddAt(StartIndex, item);
        }
    }
}
