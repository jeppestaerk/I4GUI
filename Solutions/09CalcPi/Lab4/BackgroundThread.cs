using System;
using System.Text;
using System.Threading;
using CalcPiAlgoritm;

namespace Lab4
{
    class CalcPiEventArgs : EventArgs
    {
        int index;
        string result;

        public int Index
        {
            get
            {
                return index;
            }
        }

        public string Result
        {
            get
            {
                return result;
            }
        }

        public CalcPiEventArgs(int aIndex, string aResult)
        {
            index = aIndex;
            result = aResult;
        }
    }

    class BackgroundThread
    {
        private int index;
        private string result;
        private int digits;
        private int startDec;
        private int endDec;
        private StringBuilder pi;
        private Thread thread;
        private bool isCompleted;

        public event EventHandler<CalcPiEventArgs> evCompleted;

        public string Pi
        {
            get
            {
                return result;
            }
        }

        public bool IsCompleted
        {
            get
            {
                lock (this)
                    return isCompleted;
            }
            set
            {
                lock (this)
                    isCompleted = value;
            }
        }
        public BackgroundThread(int aIndex)
        {
            isCompleted = false;
            index = aIndex;
            result = "";
        }

        public void CalcPi(int aStartDec, int aEndDec)
        {
            result = "";
            startDec = aStartDec;
            endDec = aEndDec;
            digits = endDec - startDec;
            pi = new StringBuilder(digits + 9);
            thread = new Thread(this.BackgroundCalcPi);
            //thread.Priority = ThreadPriority.Highest;
            thread.IsBackground = true;
            thread.Start();
        }

        private void BackgroundCalcPi()
        {
            for (int i = startDec; i < endDec; i += 9)
            {
                int nineDigits = NineDigitsOfPi.StartingAt(i + 1);
                int digitCount = Math.Min(endDec - i, 9);
                string ds = string.Format("{0:D9}", nineDigits);
                pi.Append(ds.Substring(0, digitCount));

                // Don't Show progress
                // ShowProgress(pi.ToString(), digits, i + digitCount);
            }
            result = pi.ToString();
            IsCompleted = true;
            if (evCompleted != null)
                evCompleted(this, new CalcPiEventArgs(index, result));
        }
    }
}