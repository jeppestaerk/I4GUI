using System;
using System.Text;
using System.Threading;
using CalcPiAlgoritm;
using System.Threading.Tasks;

namespace Lab3
{
   public class PiUpdateEventArgs : EventArgs
   {
      string pi;
      int totalDigits;
      int digitsSoFar;

      public PiUpdateEventArgs(string api, int atotalDigits, int adigitsSoFar)
      {
         pi = api;
         totalDigits = atotalDigits;
         digitsSoFar = adigitsSoFar;
      }

      public string Pi { get { return pi; } }

      public int TotalDigits { get { return totalDigits; } }

      public int DigitsSoFar { get { return digitsSoFar; } }
   }

   class BackgroundThread
   {
      string result;
      int digits;
      DateTime startTime;
      DateTime endTime;
      TimeSpan calcTime;
      
      public event EventHandler evCompleted;
      public event EventHandler evUpdate;

      public string Pi
      {
         get
         {
            return result;
         }
      }

      public TimeSpan CalculationTime
      {
         get
         {
             return calcTime;
         }
      }

      public BackgroundThread()
      {
         result = "";
         digits = 1;
      }

      public void CalcPi(int adigits)
      {
         digits = adigits;
         Thread thread = new Thread(this.BackgroundCalcPi);
         thread.IsBackground = true;
         thread.Start();
      }

      private void BackgroundCalcPi()
      {
          startTime = DateTime.Now;
            
          StringBuilder pi = new StringBuilder("3", digits + 2);
          int numCalc = (digits + 8) / 9;
          string[] results = new string[numCalc];

          // Show progress
          evUpdate(this, new PiUpdateEventArgs(pi.ToString(), digits, 0));

          if (digits > 0)
          {
              pi.Append(".");

              Parallel.For(0, numCalc, i =>
              {
                  int nineDigits = NineDigitsOfPi.StartingAt(1 + i * 9);
                  int digitCount = Math.Min(digits - i * 9, 9);
                  string ds = string.Format("{0:D9}", nineDigits);
                  results[i] = ds.Substring(0, digitCount);
              });

              for (int i = 0; i < numCalc; i++)
              {
                  pi.Append(results[i]);
              }

              endTime = DateTime.Now;

              result = pi.ToString();
          }

          calcTime = endTime - startTime;
          evCompleted(this, new EventArgs());
      }
   }
}
