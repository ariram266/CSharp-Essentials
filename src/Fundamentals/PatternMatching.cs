using System;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using CSharp_Concepts.Models;

namespace CSharp_Concepts
{
    public static class PatternMatching
    {
        public static void execute()
        {
            BasicTypePatterns(90); //Check if a variable is of a specific type and cast it if true.
            SwitchExpressions(); //C# 8.0 introduced switch expressions, which offer a more concise syntax for pattern matching
            PropertyPatterns();//Match objects based on their properties
            TuplePatterns();//Match against tuples, useful for deconstructing and matching multiple values.
            ListPatterns();//C# 11 introduced list patterns for matching against lists or arrays
            AndOrPatterns();//Combine multiple patterns using and and or logical operators
            RelationalPatterns();//Match values based on relational comparisons
            WhenClauses();//Add additional conditions to patterns using when
            DeconstructionPatterns();//Match and deconstruct complex objects in a pattern
            RecursivePatterns();//Match nested structures.
           
        }
        public static void challenges()
        {
            PositiveNegativeNumbers();
            ProcessShape();
            ClassifyPoints();
            PrintPersonInfo();
            AnalyzeListPattern();
        }

        private static void AnalyzeListPattern()
        {
          /*  Write a method AnalyzeList(List<int> numbers) that uses pattern matching to handle different list scenarios:
            •	Empty list
            •	List with a single element
            •	List with two elements
            •	List with more than two elements*/
         string AnalyzeList(List<int> numbers)
            {
                return numbers switch
                {
                    { Count: 0 } => "Empty list",
                    { Count: 1 } => $"Single element: {numbers[0]}",
                    { Count: 2 } => $"Two elements: {numbers[0]} and {numbers[1]}",
                    { Count: > 2 } => $"List with {numbers.Count} elements",
                    _ => "Unknown list"
                };
            }
            Console.WriteLine(AnalyzeList(new List<int> { 1, 2, 3, 4, 5, 6, 7 }));
        }

        private static void PrintPersonInfo()
        {
            string prinperson(Person person) =>
                person switch
                {
                    { Age: < 0 } => "invalid Age",
                    { Age: <18} => $"Child : {person.FirstName}",
                    { Age: > 18 } => $"Adult : {person.FirstName}",
                    _ => "Unknown"
                };
            Console.WriteLine(prinperson(new Person("", "", -1)));
            Console.WriteLine(prinperson(new Person("Aathvi", "Ariram", 2)));
            Console.WriteLine(prinperson(new Person("udhaya", "C", 32)));
        }

        private static void ClassifyPoints()
        {
            string classifyPoints((int x, int y) points) =>
             points switch
             {
                 (0, 0) => "Origin",
                 (var x, 0) when x > 0 => "X-axis",
                 (0, var y) when y > 0 => "Y-axis",
                 ( > 0, > 0) => "First",
                 ( < 0, > 0) => "second",
                 ( < 0, < 0) => "third",
                 ( > 0, < 0) => "fourth",
                 _ => "unknown"
             };
            Console.WriteLine(classifyPoints(( 0, 0)));
            Console.WriteLine(classifyPoints((0, 1)));
            Console.WriteLine(classifyPoints((1, 0)));
            Console.WriteLine(classifyPoints((1, 1)));
            Console.WriteLine(classifyPoints((1, -1)));
            Console.WriteLine(classifyPoints((-1, -1)));
            Console.WriteLine(classifyPoints((-1, 1)));
        }

        private static void ProcessShape()
        {
            var circle = new Circle("circle");
            var square = new Circle("square");
            var unknown = new Circle("unknown");
            circle.print();
            square.print();
            unknown.print();

            string getShapes(Shape shape) =>
                shape switch
                {
                    Circle c => $"Circle with Radius: {c.Radius}",
                    Square c => $"Square with side: {c.Side}",
                    _ => $"unknown"
                };
            Console.WriteLine(getShapes(new Circle("circle") { Radius = 10 }));
            Console.WriteLine(getShapes(new Square("square") { Side = 5 }));
            Console.WriteLine(getShapes(new Unknown("circle")));
        }

        private static void PositiveNegativeNumbers()
        {
            string DescribeNumber(int n) =>
                n switch
                {
                    //var x when x> 0 && x% 2 == 0 => "Postivie Even Numbers",
                    //var x when x < 0 && x % 2 == 0 => "Negative Even Numbers",
                    //var x when x > 0 && x % 2 != 0 => "Postivie Add Numbers",
                    //var x when x < 0 && x % 2 != 0 => "Negative Add Numbers",
                    > 0 when n % 2 == 0 => "Postivie Even Numbers",
                    < 0 when n % 2 == 0 => "Negative Even Numbers",
                    > 0 when n % 2 != 0 => "Postivie Add Numbers",
                    < 0 when n % 2 != 0 => "Negative Add Numbers",
                    0 => "Zero"
                };
            Console.WriteLine(DescribeNumber(0)); //Zero
            Console.WriteLine(DescribeNumber(2)); //Postivie Even Numbers
            Console.WriteLine(DescribeNumber(-2)); //Negative Even Numbers
            Console.WriteLine(DescribeNumber(1)); //Postivie Add Numbers
            Console.WriteLine(DescribeNumber(-1)); //Negative Add Numbers

        }

        private static void RecursivePatterns()
    {
       string DescribeTree(TreeNode node) =>
         node switch
         {
             //null => "Empty tree",
             { Left: null, Right: null, Value: var v } => $"Leaf node with value {v}",
             { Left: var left, Right: var right } => $"Internal node with left child {DescribeTree(left)} and right child {DescribeTree(right)}",
             _ => "Unknown tree structure"
         };

        }
        private static void DeconstructionPatterns()
        {
          string DescribeCoordinates((int X, int Y) point) =>
     point switch
     {
         var (X, Y) when X == 0 && Y == 0 => "Origin",
         var (X, Y) when X == 0 => "On Y axis",
         var (X, Y) when Y == 0 => "On X axis",
         _ => "General point"
     };

        }

        private static void WhenClauses()
        {
            string DescribeRectangle(Models.Rectangle rect) =>
    rect switch
    {
        { Width: var w, Height: var h } when w == h => "Square",
        { Width: > 0, Height: > 0 } => "Rectangle",
        _ => "Invalid rectangle"
    };

        }

        private static void RelationalPatterns()
        {
           string GetTemperatureDescription(int temperature) =>
    temperature switch
    {
        < 0 => "Freezing",
        0 => "Cold",
        <= 20 => "Cool",
        <= 30 => "Warm",
        _ => "Hot"
    };

        }

        private static void AndOrPatterns()
        {
            string DescribeNumber(int number) =>
                number switch
                {
                    > 0 and < 10 => "Single digit positive",
                    > 9 and < 100 => "Double digit positive",
                    101 or >= 102 => "three digit",
                    < 0 => "Negative number",
                    _ => "Other"
                };
            Console.WriteLine(DescribeNumber(45));
        }

        private static void ListPatterns()
        {
           /* Basic List Pattern Matching
                Description: You can use list patterns to match arrays or lists with specific patterns, such as checking if a list contains certain elements or fits a particular structure.
           */
            string DescribeList(IList<int> numbers) =>
                numbers switch
                {
                [1, 2, 3] => "List contains 1, 2, and 3",
                [1, .., 3] => "List starts with 1 and ends with 3",
                [.., 1, 2] => "List ends with 1 and 2",
                [var first, .., var last] => $"List starts with {first} and ends with {last}",
                    _ => "Other list"
                };

                var list1 = new List<int> { 1, 2, 3 };
                var list2 = new List<int> { 1, 4, 5, 3 };
                var list3 = new List<int> { 4, 5, 1, 2 };
                var list4 = new List<int> { 7, 8, 9 };

                Console.WriteLine(DescribeList(list1)); // Output: List contains 1, 2, and 3
                Console.WriteLine(DescribeList(list2)); // Output: List starts with 1 and ends with 3
                Console.WriteLine(DescribeList(list3)); // Output: List ends with 1 and 2
                Console.WriteLine(DescribeList(list4)); // Output: List starts with 7 and ends with 9
           
            /*Matching with Slices
            Description: You can use slice patterns to match and extract parts of a list or array, such as matching the beginning or end of a sequence.
            */
            string AnalyzeSlice(IList<int> numbers) =>
                numbers switch
                {
                   // [1, 2, .., var rest] => $"Starts with 1, 2, followed by {rest} more elements",
                    [.., 3, 4] => $"Ends with 3, 4",
                  //  [.., ..var last] when last.count > 2 => $"Ends with a list of length greater than 2",
                        _ => "Does not match any pattern"
                    };

                list1 = new List<int> { 1, 2, 3, 4, 5 };
                 list2 = new List<int> { 7, 8, 3, 4 };
                 list3 = new List<int> { 1, 2, 3 };
                 list4 = new List<int> { 5, 6, 7, 8, 9 };

                Console.WriteLine(AnalyzeSlice(list1)); // Output: Starts with 1, 2, followed by 3 more elements
                Console.WriteLine(AnalyzeSlice(list2)); // Output: Ends with 3, 4
                Console.WriteLine(AnalyzeSlice(list3)); // Output: Does not match any pattern
                Console.WriteLine(AnalyzeSlice(list4)); // Output: Ends with a list of length greater than 2
           
            /*Combining Patterns
                Description: You can combine list patterns with other patterns to create more complex matching logic.
            */
            string CombinedPatterns(IList<int> numbers) =>
                    numbers switch
                    {
                   // [1, var middle, 5] when middle > 1 => $"Starts with 1 and ends with 5 with {middle.Count} elements in the middle",
                    //[.., 2, 3, ..] => "Contains 2 followed by 3 somewhere in the middle",
                  // [var first, ..] when first.Count == 1 => $"Starts with a single element: {first[0]}",
                        _ => "No match"
                };

             list1 = new List<int> { 1, 3, 4, 5 };
                 list2 = new List<int> { 7, 2, 3, 8 };
                 list3 = new List<int> { 9 };
                 list4 = new List<int> { 4, 5, 6 };

                Console.WriteLine(CombinedPatterns(list1)); // Output: Starts with 1 and ends with 5 with 2 elements in the middle
                Console.WriteLine(CombinedPatterns(list2)); // Output: Contains 2 followed by 3 somewhere in the middle
                Console.WriteLine(CombinedPatterns(list3)); // Output: Starts with a single element: 9
                Console.WriteLine(CombinedPatterns(list4)); // Output: No match
           


        }

        private static void TuplePatterns()
        {
            string DescribePoint((int x, int y) point) =>
                     point switch
                     {
                         (0, 0) => "Origin",
                         (var x, 0) when x > 0 => "Positive x-axis",
                         (0, var y) when y > 0 => "Positive y-axis",
                         (var x, var y) when x > 0 && y > 0 => "First quadrant",
                         (var x, var y) when x < 0 && y > 0 => "Second quadrant",
                         (var x, var y) when x < 0 && y < 0 => "Third quadrant",
                         (var x, var y) when x > 0 && y < 0 => "Fourth quadrant",
                         _ => "Unknown location"
                     };
            Console.WriteLine(DescribePoint((0,0))); //"Origin"
            Console.WriteLine(DescribePoint((1, 0))); //Positive x-axis
            Console.WriteLine(DescribePoint((-1, 0))); //Unknown
            Console.WriteLine(DescribePoint((0, 1))); //Positive Y-axis
            Console.WriteLine(DescribePoint((0,-1))); //Unknown
            Console.WriteLine(DescribePoint((1, 1))); // first quadrant
            Console.WriteLine(DescribePoint((-1, 1))); // second quadrant
            Console.WriteLine(DescribePoint((-1, -1))); //third quadrant
            Console.WriteLine(DescribePoint((1, -1))); //fourth quadrant
        }

        private static void PropertyPatterns()
        {
            string DescribePerson(Person person) =>
                person switch
                {
                    
                    { Age: < 18 } => "Minor",
                    { Age: >= 18 and < 65 } => "Adult",
                    { Age: >= 65 } => "Senior",
                    _ => "Unknown"
                };
            var person = new Person("Ariram","Bhath", 18);
            Console.WriteLine(DescribePerson(person)); //Adult
            Console.WriteLine(DescribePerson(new Person ("Ariram", "Bhath",17))); //Minor
            Console.WriteLine(DescribePerson(new Person("Ariram", "Bhath", 65))); //Senior
            Console.WriteLine(DescribePerson( null )); //Unknown
        }

        private static void SwitchExpressions()
        {
            string GetDayName(int dayNumber) =>
            dayNumber switch
            {
                1 => "Monday",
                2 => "Tuesday",
                3 => "Wednesday",
                4 => "Thursday",
                5 => "Friday",
                6 => "Saturday",
                7 => "Sunday",
                _ => "Invalid day"
            };
            for (int i = 1; i <= 9; i++) {
                Console.WriteLine(GetDayName(i));
                }

        }

        private static void BasicTypePatterns(object obj)
        {
            if (obj is string s)
            {
                Console.WriteLine($"String: {s}");
            }
            else if (obj is int i)
            {
                Console.WriteLine($"Integer: {i}");
            }
            else
            {
                Console.WriteLine("Unknown type");
            }

        }
    }
}
