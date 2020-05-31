using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;

namespace Common.Broadcaster
{
    public class SafeList<T> : IProducerConsumerCollection<T>
    {
        private object m_lockObject = new object();

        private List<T> m_list;

        public SafeList()
        {
            m_list = new List<T>();
        }

        public SafeList(IEnumerable<T> collection)
        {
            m_list = new List<T>(collection);
        }

        public void Add(T item)
        {
            lock (m_lockObject) m_list.Add(item);
        }

        public void Remove(T item)
        {
            lock (m_lockObject)
            {
                m_list.Remove(item);
            }
        }

        public bool TryTake(out T item)
        {
            // No sense in trying to take random element from list, for now taking last element.
            bool result = true;
            lock (m_lockObject)
            {
                if (m_list.Count > 0)
                {
                    item = m_list.Last();
                    Remove(item);
                }
                else
                {
                    item = default;
                    result = false;
                }
            }

            return result;
        }

        public bool TryAdd(T item)
        {
            Add(item);
            return true; // Add doesn't fail
        }

        public T[] ToArray()
        {
            T[] rval = null;
            lock (m_lockObject) rval = m_list.ToArray();
            return rval;
        }

        public void CopyTo(T[] array, int index)
        {
            lock (m_lockObject) m_list.CopyTo(array, index);
        }

        public IEnumerator<T> GetEnumerator()
        {
            // The performance here will be unfortunate for large lists,
            // but thread-safety is effectively implemented.
            List<T> listCopy = null;
            lock (m_lockObject) listCopy = new List<T>(m_list);
            return listCopy.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        public bool IsSynchronized
        {
            get { return true; }
        }

        public object SyncRoot
        {
            get { return m_lockObject; }
        }

        public int Count
        {
            get
            {
                lock (m_lockObject)
                {
                    return m_list.Count;
                }
            }
        }

        public void CopyTo(Array array, int index)
        {
            lock (m_lockObject) ((ICollection)m_list).CopyTo(array, index);
        }
    }
}