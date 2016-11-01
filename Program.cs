using System;
using System.IO;
using System.Xml.Linq;
using System.Collections.Generic;
using Exercise.Repository;
using Exercise.Service;
using System.Numerics;

namespace Exercise {
    public class Program {
        static void Main(string[] args)
        {
            int numberInt = int.Parse(Console.ReadLine());
            BigInteger result = numberInt;

            for (int i = 1; i < numberInt; i++)
            {
                result = result * i;
            }

            Console.WriteLine(result);
        }

    }
}