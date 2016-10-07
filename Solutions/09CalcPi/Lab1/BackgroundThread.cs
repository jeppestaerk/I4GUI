using System;
using System.Text;
using System.Threading;
using CalcPiAlgoritm;

namespace Lab1
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
      
      public event EventHandler evCompleted;
      public event EventHandler evUpdate;

      public string Pi
      {
         get
         {
            return result;
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
         StringBuilder pi = new StringBuilder("3,", digits + 2);
         string ds;

         // Show progress
         // ShowProgress(pi.ToString(), digits, 0);
         evUpdate(this, new PiUpdateEventArgs(pi.ToString(), digits, 0));

         if (digits > 0)
         {
            pi.Append(".");

            for (int i = 0; i < digits; i += 9)
            {
               int nineDigits = NineDigitsOfPi.StartingAt(i + 1);
               int digitCount = Math.Min(digits - i, 9);
               ds = string.Format("{0:D9}", nineDigits);
               pi.Append(ds.Substring(0, digitCount));

               // Show progress
               //ShowProgress(pi.ToString(), digits, i + digitCount);
               evUpdate(this, new PiUpdateEventArgs(ds, digits, i + digitCount));
            }
         }
         result = pi.ToString();
         evCompleted(this, new EventArgs());
      }
   }
}
