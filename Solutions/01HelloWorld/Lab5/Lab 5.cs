using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1_5
{
   class Program
   {
      static void Main(string[] args)
      {
         Console.WriteLine("*** Welcome to the Hi-Lo game ***");
         Console.WriteLine("Think of a number between 1 and 100");
         Console.WriteLine("I will make a guess");

         int low;
         int high;
         int guess;
         bool guessed = false;
         bool responseAccepted;
         string response;
         low = 1;
         high = 100;

         while (!guessed)
         {
            // The number must be in the range [low, high], if low > high then we know that the player cheates!
            if (low > high)
            {
               Console.WriteLine("You cheated! I quit");
               return;
            }
            guess = (low + high) / 2;
            Console.WriteLine("My guess is: {0}", guess);
            responseAccepted = false;

            while (!responseAccepted)
            {
               Console.Write("Tell me if I'm (H)igh, (L)ow or (E)qual? ");
               response = Console.ReadLine().ToUpper();
               responseAccepted = true;
               switch (response)
               {
                  case "H":
                     high = guess - 1;
                     break;
                  case "L":
                     low = guess + 1;
                     break;
                  case "E":
                     guessed = true;
                     break;
                  default:
                     Console.WriteLine("To play the game you must answar H, L or E!");
                     Console.Write("Do you want to terminate the game? [enter Y for yes, or N for no]: ");
                     string answar = Console.ReadLine().ToUpper();
                     if (answar == "Y")
                        return;
                     responseAccepted = false;
                     break;
               }
            }
         }
         Console.WriteLine("*** I GOT IT! ****");
      }
   }
}
