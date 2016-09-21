// WIN1
// Solution to problem Hello World - 4
using System;

namespace Lab1_4
{
   class Program
   {
      static void Main(string[] args)
      {
         Console.WriteLine("*** Welcome to the Hi-Lo game ***");
			Console.WriteLine("The computer choose a number between 1 and 100, you guess it");
		
			Random rndGen = new Random();
			int myChosenNumber = rndGen.Next(100);
			int guess;
			bool guessed = false;

			while (!guessed)
			{
				Console.Write("Enter your guess: ");
				try 
				{
					guess = int.Parse(Console.ReadLine());
					if (guess < myChosenNumber)
						Console.WriteLine("Your guess is to low.");
					else if (guess > myChosenNumber)
						Console.WriteLine("Your guess is to high.");
					else
						guessed = true;
				}
				catch (FormatException)
				{
					Console.WriteLine("To play the game you must enter a number between 1 and 100");
					Console.Write("Do you want to terminate the game? [enter Y for yes, or N for no]: ");
					string answar = Console.ReadLine().ToUpper();
					if (answar == "Y")
						return;
				}
			}
			Console.WriteLine("*** YOU GOT IT! ****");
      }
   }
}
