using System;
using System.Collections.Generic;
using System.Linq;

namespace CombinationApp
{
    class Program
    {
        static void Main()
        {
            var lists = new []
            {
                new List<int> {1, 2, 3},
                new List<int> {4, 5},
                new List<int> {6, 7},
                new List<int> {8, 9}
            };
            var combinatonsOfLists = AllCombinationsOf(lists);
            var message = combinatonsOfLists.Aggregate("", (current, str) => current + ("{" + string.Join(",", str.Select(y => y.ToString())) + "}"));
            Console.WriteLine(message);
        }

        private static List<List<T>> AllCombinationsOf<T>(params List<T>[] sets)
            {
                // need array bounds checking etc for production
                var combinations = new List<List<T>>();

                // prime the data
                foreach (var value in sets[0])
                    combinations.Add(new List<T> { value });

                foreach (var set in sets.Skip(1))
                    combinations = AddExtraSet(combinations, set);

                return combinations;
            }

            private static List<List<T>> AddExtraSet<T>
                (List<List<T>> combinations, List<T> set)
            {
                var newCombinations = from value in set
                    from combination in combinations
                    select new List<T>(combination) { value };

                return newCombinations.ToList();
            }
    }
}