using System;
using System.Collections.Generic;

namespace Lab4
{
    public class Program
    {
        static void Main(string[] args)
        {
            // 1. Create a list of Person
            List<Person> people = new List<Person>
                {
                    new Person { Name = "Alice", Age = 30 },
                    new Person { Name = "Bob", Age = 25 },
                    new Person { Name = "Charlie", Age = 35 },
                    new Person { Name = "David", Age = 20 }
                };

            // 2. Compare by Age (ascending)
            ComparisonDelegate ageComparison = (p1, p2) => p1.Age.CompareTo(p2.Age);
            Sorter.SortPeople(people, ageComparison);

            Console.WriteLine("Sort by Age (ascending):");
            foreach (var p in people)
            {
                Console.WriteLine($"Name: {p.Name}, Age: {p.Age}");
            }

            Console.WriteLine();

            // 3. Compare by Name (descending) using anonymous method
            ComparisonDelegate nameComparisonDesc = delegate (Person p1, Person p2)
            {
                return p2.Name.CompareTo(p1.Name); // descending
            };

            Sorter.SortPeople(people, nameComparisonDesc);

            Console.WriteLine("Sort by Name (descending):");
            foreach (var p in people)
            {
                Console.WriteLine($"Name: {p.Name}, Age: {p.Age}");
            }
        }
    }

    // Comparison delegate
    public delegate int ComparisonDelegate(Person p1, Person p2);

    // Sorter class
    public class Sorter
    {
        public static void SortPeople(List<Person> people, ComparisonDelegate comparison)
        {
            for (int i = 0; i < people.Count - 1; i++)
            {
                for (int j = i + 1; j < people.Count; j++)
                {
                    if (comparison(people[i], people[j]) > 0)
                    {
                        Person temp = people[i];
                        people[i] = people[j];
                        people[j] = temp;
                    }
                }
            }
        }
    }
}
