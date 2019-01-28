using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Program
    {
        static int[] BubbleSort(int[] mas){
           int temp;
           for (int i = 0; i < mas.Length; i++){
              for (int j = i + 1; j < mas.Length; j++){
                 if (mas[i] > mas[j]){
                     temp = mas[i];
                     mas[i] = mas[j];
                     mas[j] = temp;
                 }
              }
           }
            return mas;
        }
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[n];
            string[] s = new string[256];
            int[] b = new int[n * 2];
            s = Console.ReadLine().Split();
            for ( int i = 0; i < n; i++)
            {
                a[i] = int.Parse(s[i]);
            }
            Array.Copy(a, b, (n));
            int[] c = a.Concat(b).ToArray();

            for ( int i = 0; i < (2*n); i++)
            {
                BubbleSort(c);

            }
            for (int i = 3; i < (2*n) + 3; i++)
            {
                Console.Write(c[i] + " ");
            }
            Console.ReadKey();
        }
    }
}
