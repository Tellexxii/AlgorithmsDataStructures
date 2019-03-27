using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public static class Tests
    {
        public static void PowerSetTest()
        {
            PowerSet<int> ps1 = new PowerSet<int>();
            PowerSet<int> ps2 = new PowerSet<int>();


            ps1.Put(1);
            ps1.Put(3);
            ps1.Put(5);

            ps2.Put(2);
            ps2.Put(3);
            ps2.Put(4);


            var ps3 = ps1.Difference(ps2);
            //Console.WriteLine(ps3);
            foreach (var item in ps3.items.Keys)
            {
                Console.WriteLine(item);
            }

            //Console.WriteLine($"Size: {ps3.Size()}");


        }
        
    }
}