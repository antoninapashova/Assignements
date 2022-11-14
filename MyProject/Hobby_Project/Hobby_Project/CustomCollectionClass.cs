

namespace Hobby_Project
{
    public class CustomCollectionClass<T>
    {
        int Size;
        int Capacity = 10;
        T[] Array;


        public CustomCollectionClass(int capacity)
        {
            this.Capacity = capacity;
            this.Array = new T[this.Capacity];
        }
        public CustomCollectionClass()
        {
          this.Array = new T[this.Capacity];
        }

        public void addEelement(T element)
        {
            if (Size >= Capacity)
            {
                Grow();
            }


            Array[Size] = element;
            Size++;

        }

        public T getItem(int index)
        {
            return Array[index];
        }

        public void setItem(T item, int index)
        {
            if (Size >= Capacity)
            {
                Grow();
            }

            for (int i=Size; i>index; i--)
            {
                Array[i] = Array[i - 1];
            }
            Array[index] = item;
            Size++;

        }

        public void swapByIndexes(int firtsIndex, int secondIndex)
        {
            T firstElement = Array[firtsIndex];
            T secondElement = Array[secondIndex];
            Array[firtsIndex] = secondElement;
            Array[secondIndex] = firstElement;
        }

        public void swapByItems(T firstItem, T secondItem)
        {
            int indexOfFirstItem = 0;
            int indexOfSecondItem = 0;
            for(int i=0; i<Array.Length-1; i++)
            {
                if (Array[i].Equals(firstItem))
                {
                    indexOfFirstItem = i;
                    
                }else if (Array[i].Equals(secondItem))
                {
                    indexOfSecondItem = i;
                }
            }

            Array[indexOfFirstItem] = secondItem;
            Array[indexOfSecondItem] = firstItem;
            
        }

        private void Grow()
        {
            int newCapacity = Capacity * 2;
            T[] newArray = new T[newCapacity];

            for (int i = 0; i < Size; i++)
            {
                newArray[i] = Array[i];
            }
            Capacity = newCapacity;
            Array = newArray;
        }
    }
}
