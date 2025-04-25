using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using CSharp_Concepts.Models;
using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace CSharp_Concepts
{
    public static class CollectionManipulation
    {
        public static void challenges()
        {
            findUniqueElement();
            unionOfCollections();
            groupingAndAggregation();
            mergeAndSortLists();
            findMissingNumber();
            RearangeElements();
            FindCommonElements();
            RemoveDuplicates();
            FindMaximumSubarraySum();
            ImplementaPriorityQueue();
            FindtheIntersectionofTwoArrays();
            TopNFrequentElements();
            FlattenNestedCollections();
            GroupandCountItems();
            GroupAnagrams();


        }

        private static void GroupAnagrams()
        {
            /*Write a method GroupAnagrams(string[] strs) that groups anagrams from a list of strings. Anagrams are words that have the same characters but in different orders*/
            string str1 = "Listen";
            string str2 = "silent";
            var newStr1 = new string( str1
                .Replace(" ", "")
                .ToLower()
                .OrderBy(x => x)
                .ToArray());
            var newStr2 =new string(str2
               .Replace(" ", "")
               .ToLower()
               .OrderBy(x => x)
               .ToArray());
            Console.WriteLine($"{newStr1}:{newStr2} :{ newStr1.Equals(newStr2)}");
        }

         private static void GroupandCountItems()
         {
         /*Problem: Group a list of strings by their length and count the number of strings in each group*/
            var list =new List<string> { "123","1234","123","456"};
            var result= list
                .GroupBy(x=>x.Length)
                .Select(g=>new {name=g.Key,count=g.Count()})
                .ToList();
            Console.WriteLine(string.Join(", ", result));
        }

        private static void FlattenNestedCollections()
        {
            /*Problem: Flatten a nested collection of lists into a single list*/
            var nestedList = new List<List<int>>
            {
                new List<int> { 1, 2 },
                new List<int> { 3, 4 },
                new List<int> { 5, 6 }
            };

            var flattened = nestedList.SelectMany(sublist => sublist).ToList();

            Console.WriteLine(string.Join(", ", flattened));

        }

        private static void TopNFrequentElements()
        {
            /*Problem: Given a list of integers, find the top N most frequent elements.*/
            var list = new List<int>{ 1, 3, 5, 6, 7,6, 4, 4 };
            var topN = 1;
            //int.TryParse(Console.ReadLine(),out topN);
            var result = list
            .GroupBy(x => x) // Group elements by their value
            .Select(group => new { Value = group.Key, Count = group.Count() ,sum=group.Sum()}) // Project to anonymous type with value and count
            .OrderByDescending(x => x.Count) // Order by count descending
            .ThenBy(x => x.Value) // For tie-breaking, order by value ascending (optional)
            .Take(topN) // Take the top N elements
            .Select(x => x.Value) // Select only the value part
            .ToList(); // Convert to a list
            Console.WriteLine(string.Join(", ", result));
        }

        private static void FindtheIntersectionofTwoArrays()
        {
            /* Problem: Find the intersection of two arrays without duplicates. */
            var array = new int[] { 1, 3, 4,4, 5, 6, 7 };
            var array2= new int[] { 1, 3, 4, };
            Console.WriteLine(string.Join(", ", array.Intersect(array2)));        
        }

        private static void ImplementaPriorityQueue()
        {
        /*Problem: Implement a simple priority queue using SortedDictionary where elements are dequeued in priority order.*/
        
            // Create a new PriorityQueue
            var priorityQueue = new PriorityQueue<string, int>();

            // Enqueue elements with their priorities
            priorityQueue.Enqueue("Task 1", 2); // Priority 2
            priorityQueue.Enqueue("Task 2", 1); // Priority 1
            priorityQueue.Enqueue("Task 3", 3); // Priority 3

            // Dequeue elements and process them
            while (priorityQueue.Count > 0)
            {
                var item = priorityQueue.Dequeue();
                Console.WriteLine(item);
            }
            /* implemented manual sortedDictionary */
            var queuesort = new PriorityQueueSort<string>();
            queuesort.Enqueue(2, "Task 2");
            queuesort.Enqueue(1, "Task 1");
            queuesort.Enqueue(3, "Task 3");

            Console.WriteLine(queuesort.Dequeue()); // Task 1
            Console.WriteLine(queuesort.Dequeue()); // Task 2
            Console.WriteLine(queuesort.Dequeue()); // Task 3


        }

        private static void FindMaximumSubarraySum()
        {
            /*Problem: Implement Kadane’s algorithm to find the maximum sum of a contiguous subarray within a one-dimensional array of numbers*/
            int[] array = { 1, 2, 1, 5,-5, -3, 4 };
            var maxSub = new List<int>();
            var currentMaxSub = new List<int>();
            // Initialize variables
            int currentMax = array[0];
            int globalMax = array[0];
            maxSub.Add(array[0]);
            currentMaxSub.Add(array[0]);
            // Iterate through the array
            for (int i = 1; i < array.Length; i++)
            {
                currentMax = Math.Max(array[i], currentMax + array[i]);
                if (currentMax > globalMax)
                {
                    globalMax = Math.Max(globalMax, currentMax);
                    currentMaxSub.Add(array[i]);
                    

                }
                else
                {
                    if(currentMaxSub.Sum()>maxSub.Sum())
                     maxSub = currentMaxSub;
                    currentMaxSub = new List<int>();

                }

                    
            }
            Console.WriteLine(string.Join(", ", maxSub.ToArray()));
            Console.WriteLine(globalMax);


        }

        private static void RemoveDuplicates()
        {
            /*Problem: Remove duplicate elements from a list while preserving the order of the first occurrence.*/
            var list1 = new List<int> { 1, 2,1,5,5, 3, 4 };
            Console.WriteLine(string.Join(" ", list1.ToHashSet()));

            var uniqueList = list1.Distinct().ToList();
            Console.WriteLine(string.Join(", ", uniqueList));

        }

        private static void FindCommonElements()
         {
             /* Problem: Given two lists, find the common elements between them.*/
            var list1 = new List<int> { 1, 2, 3, 4 };
            var list2 = new List<int> { 1,  4 };
            Console.WriteLine(string.Join(" ", list1.Intersect(list2)));
        }

         private static void RearangeElements()
         {
             /*Problem: Rearrange the elements of a list so that all even numbers come before all odd numbers, while preserving the relative order within each group.*/
            var numbers = new List<int> { 1, 2, 3, 4, };
            var evenNumbers = numbers.Where(n => n % 2 == 0);
            var oddNumbers = numbers.Where(n => n % 2 != 0);
            var rearrange = evenNumbers.Concat(oddNumbers);
            Console.WriteLine(string.Join(" ", rearrange));

            var rearranged = numbers
            .OrderBy(n => n % 2) // Even numbers (0) come before odd numbers (1)
            .ToList();

            Console.WriteLine(string.Join(", ", rearranged));

        }

        private static void findMissingNumber()
        {
            /*Problem: Given an array of integers from 1 to n with one number missing, find the missing number. Assume there are no duplicates.
             Formula:   Sum of natural numbers => n(n+1)/2
                        Sum of N even number => n(n+1)
                        Sum of N Odd number => n*n
                        nth even number 2n
                        x! = x * (x-1) * (x-2) ...1.
                        Consective Prime Numbers => 6n-1 ; 6n+1
                        
             */
            var array = new int[] { 1, 3, 4, 5, 6, 7 };
            for(var i=0;i<array.Length; i++)
            {
                var j = i + 1;
                Console.WriteLine($"array:{array[i]}index{j}");
                if (array[i] != j)
                {
                    Console.WriteLine($"Missing:{i+1}");
                }
                int n = array.Length + 1;
                int expectedSum = n * (n + 1) / 2;
                int actualSum = array.Sum();

                int missingNumber = expectedSum - actualSum;
                Console.WriteLine($"Missing number: {missingNumber}");

            }
        }

        private static void mergeAndSortLists()
        {
            /* Problem: Merge two sorted lists of integers into a single sorted list.*/
            var list = new List<int> {1,2,3 };
            var list2 = new List<int> { 1,3,5,6 };
            var list3 = list.Union(list2);
            Console.WriteLine(string.Join(" ",list3));

            var mergedSortedList = list.Concat(list2).OrderBy(x => x).ToList();

            Console.WriteLine(string.Join(", ", mergedSortedList));

        }

        private static void groupingAndAggregation()
        {
        /*Problem: Given a list of Person objects, group them by their age and calculate the average age for each group.*/

            var personList = new List<Person>
            {
                new Person("x","y",5),
                new Person("xx","xy",55),
                new Person("x","y",55),
                new Person("xx","xy",65)
            };
            var avgAge = personList
                .GroupBy(person => person.Age)
                .Select(g => new { Age = g.Key, Average = g.Average(p => p.Age) })
                .ToList();
            Console.WriteLine(string.Join(", ", avgAge));

            var groupedByAge = personList
    .GroupBy(p => p.FirstName)
    .Select(g => new { Name = g.Key, AverageAge = g.Average(p => p.Age).ToString() });
            foreach (var group in groupedByAge)
            {
                Console.WriteLine($"Age: {group.Name}, Average Age: {group.AverageAge}");
            }

        }

        private static void unionOfCollections()
        {
            /*Challenge: Find the union of two lists, which combines elements from both lists while removing duplicates*/
            var list1 = new List<string> { "hi", "hello", "hi", "how r u", "hello" };
            var list2 = new List<string> { "hi", "hello", "hi", "welcome", "hello" };
            var combinelist = list1.Union(list2);
            Console.WriteLine(string.Join(" ", combinelist));

            var list3 = new List<int> { 1, 2, 3, 4 };
            var list4 = new List<int> { 3, 4, 5, 6 };

            var union = list3.Union(list4).ToList();

            Console.WriteLine(string.Join(", ", union));

        }

        private static void findUniqueElement()
        {
        /*Challenge: Find unique elements in a list while preserving the order of their first appearance.*/
            var list = new List<string> { "hi","hello","hi","how r u","hello"};
            var result = new List<string>();
            foreach (var item in list)
            {
                if (!result.Contains(item))
                    result.Add(item);
            
            }
            Console.WriteLine(string.Join(" ",result));

            var uniqueorderedString =list
                .GroupBy(x=>x)
                .Select(x => x.Key)
                .ToList();
            Console.WriteLine(string.Join(" ", uniqueorderedString));

            var numbers = new List<int> { 1, 2, 5,3, 2, 4, 5, 1 };

            var uniqueOrderedNumbers = numbers
                .GroupBy(x => x)
                .Select(g => g.First())
                .ToList();

            Console.WriteLine(string.Join(", ", uniqueOrderedNumbers));

        }
    }
}
