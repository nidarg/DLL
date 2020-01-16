using System;

namespace ArrayCRUD
{
    public class Program
    {
        static void Main()
        {
            const int removeAt = 2;
            const int a = 5;
            const int ind = 4;
            const int d = 10;
            var sut = new ListCollection<int>();
            for (int i = 0; i < d; i++)
            {
                sut.Add(i);
            }

            sut.Insert(ind, a);
            sut.PrintList();
            Console.WriteLine("----");
            sut.RemoveAt(removeAt);
            sut.PrintList();
            Console.WriteLine("----");
            var sutObject = new ObjectArrayCollection();
            for (int i = 0; i < d; i++)
            {
                sutObject.Add(i);
            }

            sutObject.Insert(ind, a);
            sutObject.RemoveAt(removeAt);
            sutObject.PrintArray();
            Console.Read();
        }
    }
}
