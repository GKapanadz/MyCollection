using System.Collections;
using System.Collections.Generic;
namespace MyCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyStack mystack = new MyStack();

            MyList mylist = new MyList();

            MyQueue myQueue = new MyQueue();


        }
    }
    public class MyStack : MyCollections , IPeek
    {   
        public void Push(object? item)
        {
           AddObject(item);
        } 

        public object Pop()
        {
           object last = Peek();
            
            _items[Count - 1] = null!;
            Count--;
            return last;
        }

        public object Peek()
        {   
            if(Count == 0)
            {
                throw new ArgumentException("Stack is empthy");
            }

            return _items[Count - 1];
        }
        public override void TrimToSize()
        {
            Resize(ref _items , Count);
        }
    }
    public class MyQueue : MyCollections ,IPeek
    {
        public void Enqueue(object item)
        {
            AddObject(item);
        }
        public object Dequeue()
        {    
            object temp = Peek();
            _items[0] = null!;
            for(int i = 0; i < Count; i++)
            {
                _items[i] = _items[i + 1];
            }
            --Count;
            
            return temp;
        }
        public object Peek()
        {
            if(Count == 0)
            {
                throw new ArgumentException("Queue is empthy");
            }
            return _items[0];
        }
        public override void TrimToSize()
        {
            Resize(ref _items, Count);
        }
    }
    public class MyList : MyCollections , IList
    {
        public object? GetElement(int index)
        {
            return _items[index];
        }

        public void SetElement(int index, object value)
        {
            _items[index] = value;
        }
        public int Add(object? value)
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }

           AddObject(value);

            return Count - 1;
        }

        public void Insert(int index, object? value)
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }
            if (_items.Length == Count)
            {
                Resize(ref _items , _items.Length + 1);
            }

            for (int i = _items.Length - 1; i > index; i--)
            {
                _items[i] = _items[i - 1];
            }

            Count++;
            _items[index] = value;

        }

        public void Remove(object? value)
        {
            int index = IndexOf(value);

            if (index >= 0)
            {
                RemoveAt(index);
            }
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }
            Count--;

        }

        public void Clear()
        {
            for (int i = 0; i < Count; i++)
            {
                _items[i] = null!;
            }
            Count = 0;
        }

        public bool Contains(object? value)
        {
            for (int i = 0; i < Count - 1; i++)
            {
                if (_items[i] == value)
                {
                    return true;
                }
            }
            return false;
        }

        public int IndexOf(object? value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_items[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }

        public int IndexOf(object? value, int startIndex)
        {
            for (int i = startIndex; i < Count; i++)
            {
                if (_items[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }

        public override void TrimToSize()
        {
            Resize(ref _items, Count);
        }
        public object? this[int index]
        {
            get
            {
                return _items[index];
            }
            set
            {

            }
        }

        public bool IsFixedSize => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        //public int Count { get; private set; }

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();


        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    public abstract class MyCollections
    {    
        protected object[] _items = new object[4];

        public int Count { get; set; } = 0;

         
        protected static void Resize(ref object[] array, int newsize)
        {
            object[] temp = new object[newsize];

            for (int i = 0; i < newsize && i < array.Length; i++)
            {
                temp[i] = array[i];
            }
            array = temp;
        }

        protected void AddObject(object? item)
        {
            if (_items.Length == Count)
            {
                Resize(ref _items, _items.Length * 2);
            }

            Count++;
            _items[Count - 1] = item!;
        }

        public abstract void TrimToSize();
    }

    interface IPeek
    {
        public object? Peek();
    }
}
