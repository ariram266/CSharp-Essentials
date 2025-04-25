using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Concepts
{ 
    public static class EventsAndDelegates
    {
        public delegate void manipulationHandler(int x, int y);
        // Define an event based on that delegate
        public static event manipulationHandler manipulate;
        public static void execute()
        {
            manipulate += add;
            manipulate += subtract;

            startManipulate(1,2);
        }
        // Method that triggers the event
        static void startManipulate(int x,int y)
        {
            // Raise the event
            manipulate?.Invoke(x,y);
        }
        private static void subtract(int v1, int v2)
        {
            Console.WriteLine($"{v1}-{v2}={v1 - v2}");
        }

        private static void add(int v1, int v2)
        {
            Console.WriteLine($"{v1}+{v2}={v1 + v2}");
        }
    }
}
