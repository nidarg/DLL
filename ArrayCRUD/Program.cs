using System;
using System.Collections.Generic;

namespace ArrayCRUD
{
    public class Program
    {
        static void Main()
        {
            string[] words = { "the", "fox", "jumps", "over", "the", "dog" };
            CircularDoubleLinkedListCollection<string> listTest = new CircularDoubleLinkedListCollection<string>(words);
            foreach (string s in listTest.GetReverseEnumerator())
            {
                Console.WriteLine(s);
            }

            Console.Read();
        }
    }
}
