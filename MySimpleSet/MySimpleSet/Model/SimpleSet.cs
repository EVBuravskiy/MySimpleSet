using System.Collections;

namespace MySimpleSet.Model
{
    public class SimpleSet<T> : IEnumerable
    {
        private List<T> items;

        public int Count => items.Count;
        public SimpleSet()
        {
            items = new List<T>();
        }

        public SimpleSet(T item) : this()
        {
            if (item == null)
            {
                throw new ArgumentNullException("item is null", nameof(item));
            }
            items.Add(item);
        }
        //переопределенный конструктор для использования Linq методов
        public SimpleSet(IEnumerable<T> items) : this()
        {
            foreach (T item in items)
            {
                this.items.Add(item);
            }
        }
        //Операция добавления элемента
        public void Add(T item)
        {
            if (items.Contains(item))
            {
                return;
            }
            items.Add(item);
        }
        //Операция удаления элемента
        public void Remove(T item)
        {
            items.Remove(item);
        }
        //Операция объединения
        public SimpleSet<T> UnionWith(SimpleSet<T> other)
        {
            //Реализация объединения при помощи Linq
            SimpleSet<T> unionSet = new SimpleSet<T>(items.Union(other.items));
            return unionSet;

            //Обычная реализация объединения неоптимальная
            //SimpleSet<T> unionSet = new SimpleSet<T>();
            //SimpleSet<T> bigSet;
            //SimpleSet<T> smallSet;
            //if (Count >= other.Count)
            //{
            //    bigSet = this;
            //    smallSet = other;
            //}
            //else
            //{
            //    bigSet = other;
            //    smallSet = this;
            //}
            //foreach (var i in bigSet.items)
            //{
            //    unionSet.Add(i);
            //}
            //foreach (var i in smallSet.items)
            //{
            //    unionSet.Add(i);
            //}
            //return unionSet;
        }
        //Операция пересечения
        public SimpleSet<T> IntersectionWith(SimpleSet<T> other)
        {
            //Реализация пересечения при помощи Linq
            SimpleSet<T> intersectionSet = new SimpleSet<T>(items.Intersect(other.items));
            return intersectionSet;

            //Обычная реализация пересечения неоптимальная
            //SimpleSet<T> intersectionSet = new SimpleSet<T>();
            //SimpleSet<T> bigSet;
            //SimpleSet<T> smallSet;
            //if(Count >= other.Count)
            //{
            //    bigSet = this;
            //    smallSet = other;
            //}
            //else
            //{
            //    bigSet = other;
            //    smallSet = this;
            //}

            //foreach (T item1 in smallSet.items)
            //{
            //    foreach (T item2 in bigSet.items)
            //    {
            //        if (item1.Equals(item2))
            //        {
            //            intersectionSet.Add(item2);
            //            break;
            //        }
            //    }
            //}
            //return intersectionSet;
        }
        //Операция вычитания
        public SimpleSet<T> DifferenceWith(SimpleSet<T> other)
        {
            //Реализация вычитания при помощи Linq
            SimpleSet<T> differenceSet = new SimpleSet<T>(items.Except(other.items));
            return differenceSet;

            //Обычная реализация вычитания 
            //SimpleSet<T> differenceSet = new SimpleSet<T>(items);
            //foreach (T item in other.items)
            //{
            //    differenceSet.items.Remove(item);
            //}
            //return differenceSet;
        }
        //Операция подмножества
        public bool SubsetIn(SimpleSet<T> other)
        {
            //Реализация подмножества при помощи Linq
            return other.items.All(i => items.Contains(i));

            //Обычная реализация подмножества
            //foreach (T item in other.items)
            //{
            //    if (!items.Contains(item))
            //    {
            //        return false;
            //    }
            //}
            //return true;
        }
        //Операция симметричной разности множеств
        public SimpleSet<T> SymmetricalDifference(SimpleSet<T> other)
        {
            //Реализация симметричной разности множеств при помощи Linq
            SimpleSet<T> symDifSet = new SimpleSet<T>(items.Except(other.items).Union(other.items.Except(items)));
            return symDifSet;

            //Обычная реализация симметричной разности множеств
            //SimpleSet<T> symDifSet = new SimpleSet<T>(items);
            //foreach (T item in other.items)
            //{
            //    if (symDifSet.items.Contains(item))
            //    {
            //        symDifSet.Remove(item);
            //        continue;
            //    }
            //    symDifSet.Add(item);
            //}
            //return symDifSet;
        }

        public IEnumerator GetEnumerator()
        {
            return items.GetEnumerator();
        }

        public override string ToString()
        {
            string view = string.Empty;
            foreach (var item in items)
            {
                view += item + " ";
            }
            return view;
        }
    }

}
