using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAssessment.Algorithms
{
    public static class MySort <T>  
    {
        public delegate bool Condition(T x, T y);
        public static List<T> GetSorted(
            ICollection<T> input, 
            Condition condition)
        {
            //Note: Sorting Alogrithm used here is Bubble sort

            List<T> output = new List<T>(input);

            int n = input.Count;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (condition(output[j], output[j + 1]))
                    {
                        // Swap output[j] and output[j+1]
                        T temp = output[j];
                        output[j] = output[j + 1];
                        output[j + 1] = temp;
                    }
                }
            }

            return output;
        }
    }
}
