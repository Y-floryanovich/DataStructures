using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    public class DoublyLinkedListEnumerator<T> : IEnumerator<T>
    {
        private readonly DoublyLinkedList<T> _list;
        private Node<T> current;

        public DoublyLinkedListEnumerator(DoublyLinkedList<T> list)
        {
            _list = list;
            current = null;
        }

        public bool MoveNext()
        {
            if (current == null)
            {
                current = _list.Head;
            }
            else
            {
                current = current.Next;
            }
            return current != null;
        }

        public void Reset()
        {
            current = _list.Head;
        }

        public T Current => current.Value;

        object? IEnumerator.Current => Current;

        public void Dispose()
        {

        }
    }
}
