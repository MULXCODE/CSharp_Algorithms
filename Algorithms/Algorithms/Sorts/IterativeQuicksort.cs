using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorts
{
    public class IterativeQuickSort
    {
        public void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public int Partition(int[] arr, int l, int h)
        {
            int x = arr[h];
            int i = (l - 1);

            for (int j = l; j <= h-1; j++)
            {
                if (arr[j] <= x)
                {
                    i++;
                    // swap arr[i] and arr[j]
                    Swap(arr, i, j);
                }
            }
            // swap arr[i+1] and arr[h]
            Swap(arr, i + 1, h);
            return (i + 1);
        }

        public void Sort(int[] arr, int l, int h)
        {
            // create aux stack
            int[] stack = new int[h - l + 1];

            // init top of stack
            int top = -1;

            // push init values in stack
            stack[++top] = l;
            stack[++top] = h;

            // keep popping elements until stack is empty
            while(top >= 0)
            {
                // pop h and l
                h = stack[top--];
                l = stack[top--];

                // set pivot element at it's proper position
                int p = Partition(arr, l, h);

                // If there are elements on left side of pivot,
                // then push left side to stack
                if (p - 1 > l)
                {
                    stack[++top] = l;
                    stack[++top] = p - 1;
                }

                // If there are elements on right side of pivot,
                // then push right side to stack
                if (p + 1 < h)
                {
                    stack[++top] = p + 1;
                    stack[++top] = h;
                }
            }
        }
    }
}
