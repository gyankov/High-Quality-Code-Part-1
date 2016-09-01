namespace VariablesDataExpressions
{
    using System;

    public class MethodPrintStatistics
    {
        public void PrintStatistics(double[] arr, int count)
        {
            double maxValue, tmp; 
            tmp = 0;
            maxValue = 0;
            for (int i = 0; i < count; i++)
            {
                if (arr[i] > maxValue)
                {
                    maxValue = arr[i];
                }
            }

            PrintMax(maxValue);
            for (int i = 0; i < count; i++)
            {
                if (arr[i] < maxValue)
                {
                    maxValue = arr[i];
                }
            }

            PrintMin(maxValue);

            tmp = 0;
            for (int i = 0; i < count; i++)
            {
                tmp += arr[i];
            }

            PrintAvg(tmp / count);
        }

        private void PrintMax(double max)
        {
            Console.WriteLine(max);
        }

        private void PrintMin(double min)
        {
            Console.WriteLine(min);
        }

        private void PrintAvg(double avg)
        {
            Console.WriteLine(avg);
        }
    }
}
