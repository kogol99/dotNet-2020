using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Zad2
{
    class ListOfArrayList<T> : IEnumerable<T>, IList<T>
    {
        private readonly int MAX_ARRAY_LENGTH;
        private readonly List<T[]> Arrays;
        private int MaxIndex;

        public ListOfArrayList(int maxArrayLenght)
        {
            if (maxArrayLenght < 1)
            {
                throw new ArgumentException();
            }

            MAX_ARRAY_LENGTH = maxArrayLenght;
            Arrays = new List<T[]>();
            Arrays.Add(new T[maxArrayLenght]);
            MaxIndex = -1;
        }

        public T this[int index]
        {
            get
            {
                if (index < MaxIndex)
                {
                    return Arrays[getArrayIndex(index)][index % MAX_ARRAY_LENGTH];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (index < MaxIndex)
                {
                    Arrays[getArrayIndex(index)][index % MAX_ARRAY_LENGTH] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public int Count => MaxIndex + 1;

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T item)
        {
            int currentIndex = MaxIndex + 1;
            bool added = false;

            foreach (T[] array in Arrays)
            {
                if (currentIndex < array.Length)
                {
                    array[currentIndex] = item;
                    MaxIndex += 1;
                    added = true;
                }
                else
                {
                    currentIndex -= array.Length;
                }
            }

            if (!added)
            {
                Arrays.Add(new T[MAX_ARRAY_LENGTH]);
                Arrays[Arrays.Count - 1][0] = item;
                MaxIndex += 1;
            }
        }

        public void Clear()
        {
            MaxIndex = -1;
            Arrays.Clear();
            Arrays.Add(new T[MAX_ARRAY_LENGTH]);
        }

        public bool Contains(T item)
        {
            foreach (T[] array in Arrays)
            {
                foreach (T elem in array)
                {
                    if (elem != null)
                    {
                        if (elem.Equals(item) == true) return true;
                    }
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            int index = 0;
            for (int i = 0; i < Arrays.Count && index <= MaxIndex; i++)
            {
                for (int j = 0; j < Arrays[i].Length && index <= MaxIndex; j++)
                {
                    index++;
                    yield return Arrays[i][j];
                }
            }
        }

        public int IndexOf(T item)
        {
            int retIndex = 0;
            foreach (T[] array in Arrays)
            {
                foreach (T elem in array)
                {
                    if (elem != null && elem.Equals(item) == true) return retIndex;
                    else retIndex += 1;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            int itemIndex = IndexOf(item);
            if (itemIndex != -1)
            {
                RemoveAt(itemIndex);
            }
            return itemIndex != -1;
        }

        public void RemoveAt(int index)
        {
            int tableIndex = getArrayIndex(index);
            int currentIndex = index;
            if (tableIndex != -1)
            {
                for (int i = tableIndex; i < Arrays.Count; i++)
                {
                    for (int j = currentIndex % MAX_ARRAY_LENGTH; j < Arrays[i].Length; j++)
                    {
                        currentIndex = currentIndex % MAX_ARRAY_LENGTH;
                        if (currentIndex + 1 < Arrays[i].Length) Arrays[i][currentIndex] = Arrays[i][currentIndex + 1];
                        else if (i + 1 < Arrays.Count) Arrays[i][currentIndex] = Arrays[i + 1][0];

                        currentIndex += 1;
                    }
                    tableIndex += 1;
                }
                Arrays[tableIndex - 1][currentIndex - 1] = default;
                MaxIndex -= 1;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Trim()
        {
            int index = 0;
            bool foundLastFilledTable = false;
            for (int i = 0; i < Arrays.Count; i++)
            {
                if (!foundLastFilledTable)
                {
                    for (int j = 0; j < Arrays[i].Length; j++)
                    {
                        if (index == MaxIndex)
                        {
                            foundLastFilledTable = true;
                            break;
                        }
                        index++;
                    }
                }
                else
                {
                    Arrays.RemoveAt(i);
                }
            }
        }

        override public string ToString()
        {
            StringBuilder listRepresentation = new StringBuilder();
            int index = 0;
            for (int i = 0; i < Arrays.Count; i++)
            {
                for (int j = 0; j < Arrays[i].Length; j++)
                {
                    if (index <= MaxIndex)
                    {
                        listRepresentation.Append("|" + Arrays[i][j].ToString());
                    }
                    else
                    {
                        listRepresentation.Append("| ");
                    }
                    index++;
                }
                listRepresentation.Append("|");
                if (i != Arrays.Count - 1)
                {
                    listRepresentation.Append(" -> ");
                }
            }

            return listRepresentation.ToString();
        }

        private int getArrayIndex(int index)
        {
            int currentIndex = 0;
            int tableindex = 0;
            foreach (T[] array in Arrays)
            {
                foreach (T elem in array)
                {
                    if (currentIndex == index)
                    {
                        return tableindex;
                    }
                    currentIndex += 1;
                }
                tableindex += 1;
            }
            return -1;
        }

        public static ListOfArrayList<T> operator +(ListOfArrayList<T> list, IEnumerable<T> secondEnumerable)
        {
            foreach (T element in secondEnumerable)
            {
                list.Add(element);
            }
            return list;
        }
    }
}
