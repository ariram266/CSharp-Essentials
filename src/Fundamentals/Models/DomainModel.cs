using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Concepts.Models
{

    public record Person(string FirstName, string LastName, int Age);
    public record Rectangle(int Width, int Height);
    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
    }
    public class Shape
    {
        public string getName(string name) =>
            name switch
            {
                "circle" => "Circle",
                "square" => "Square",
                _ => "UnKnown"
            };
        private string _name;
        public Shape(string name)
        {
            _name = name;

        }
        public void print() => Console.WriteLine(getName(_name));
    }
    public class Circle : Shape
    {
        private string _name;
        public double Radius { get; set; }
        public Circle(string name) : base(name) { _name = name; }

    }
    public class Square : Shape
    {
        private string _name;
        public double Side { get; set; }
        public Square(string name) : base(name) { _name = name; }

    }
    public class Unknown : Shape
    {
        private string _name;
        public Unknown(string name) : base(name) { _name = name; }

    }
    public class PriorityQueueSort<T>
    {
        private readonly SortedDictionary<int, Queue<T>> _dict = new SortedDictionary<int, Queue<T>>();

        public void Enqueue(int priority, T item)
        {
            if (!_dict.ContainsKey(priority))
            {
                _dict[priority] = new Queue<T>();
            }
            _dict[priority].Enqueue(item);
        }

        public T Dequeue()
        {
            if (_dict.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            var pair = _dict.First();
            var item = pair.Value.Dequeue();

            if (pair.Value.Count == 0)
            {
                _dict.Remove(pair.Key);
            }

            return item;
        }
    }

}
