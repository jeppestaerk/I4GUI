using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Win1Lab01_1
{
   class Program
   {
      static void Main(string[] args)
      {
         int tal1;
         int tal2;
         int sum;

         Console.Write("Enter 1st number: ");
         tal1 = int.Parse(Console.ReadLine());
         Console.Write("Enter 2nd number: ");
         tal2 = int.Parse(Console.ReadLine());

         sum = tal1 + tal2;
         Console.WriteLine("The sum of {0} and {1} is {2}.", tal1, tal2, sum);
      }
   }
}
