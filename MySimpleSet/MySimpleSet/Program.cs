using MySimpleSet.Model;

namespace MySimpleSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SimpleSet<int> firstSet = new SimpleSet<int>() { 1, 2, 3 };
            //firstSet.Add(1);
            //firstSet.Add(2);
            //firstSet.Add(3);
            Console.WriteLine("First Set: ");
            Console.WriteLine(firstSet);

            SimpleSet<int> secondSet = new SimpleSet<int>() { 2, 3, 4 };
            //secondSet.Add(1);
            //secondSet.Add(4);
            //secondSet.Add(5);
            Console.WriteLine("Second Set: ");
            Console.WriteLine(secondSet);

            SimpleSet<int> unionSet = firstSet.UnionWith(secondSet);
            Console.WriteLine("Union First and Second sets: ");
            Console.WriteLine(unionSet.ToString());

            SimpleSet<int> intersectionSet = firstSet.IntersectionWith(secondSet);
            Console.WriteLine("Intersection First and Second sets:");
            Console.WriteLine(intersectionSet.ToString());

            SimpleSet<int> differenceSet = firstSet.DifferenceWith(secondSet);
            Console.WriteLine("Difference First \\ Second: ");
            Console.WriteLine(differenceSet.ToString());

            bool fl1 = firstSet.SubsetIn(secondSet);
            Console.WriteLine("Subset Second in First: ");
            Console.WriteLine(fl1);

            bool fl2 = unionSet.SubsetIn(secondSet);
            Console.WriteLine("Subset Second in Union set: ");
            Console.WriteLine(fl2);

            SimpleSet<int> symDifSet = firstSet.SymmetricalDifference(secondSet);
            Console.WriteLine("Symmetrical difference First and Second sets: ");
            Console.WriteLine(symDifSet.ToString());
            Console.ReadLine();
        }
    }
}