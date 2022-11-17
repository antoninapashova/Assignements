namespace Hobby_Project
{
    public interface ICustomCollectionClass<T>
    {
        void AddEelement(T element);
        T getItem(int index);
        void setItem(T item, int index);
        void swapByIndexes(int firtsIndex, int secondIndex);
        void swapByItems(T firstItem, T secondItem);
    }
}