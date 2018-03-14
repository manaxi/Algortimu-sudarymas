using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quicksort
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sukuriamas nesurusiuotas masyvas int ir konvertuojamas i string elementus
            const int N = 5000;
            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;
            Random rand = new Random(seed);

            int[] arr = new int[N];
            string[] arrs = new string[N];
            int i;
            for (i = 0; i < N; i++)
            {
                arr[i] = Convert.ToInt32(rand.NextDouble() * 100);
                arrs[i] = Convert.ToString(arr[i]);
                if (arrs[i].Length == 1) arrs[i] = " " + arrs[i]; 
            }

            // Spausdina nesurusiuota masyva
            //Console.WriteLine(" Array:\n");
            //for (i = 0; i < arrs.Length; i++)
            //{
            //    Console.Write(arrs[i] + " ");
            //}
            //Console.WriteLine(); 

            // Masyvo rusiavimas
            //Stopwatch stopwatch1 = new Stopwatch();
            //stopwatch1.Start();
            //QuicksortArray(arrs, 0, arrs.Length - 1);
            //stopwatch1.Stop();
            //Console.WriteLine("{0} elementu {1}ms", N, stopwatch1.ElapsedMilliseconds);

            // Spausdina surusiuota masyva
            //Console.WriteLine("\n Sorted Array: \n");
            //for (i = 0; i < arrs.Length; i++)
            //{
            //    Console.Write(arrs[i] + " ");
            //}
            //Console.WriteLine();

            MyDataList mylist = new MyDataList(N, seed);

            //Console.WriteLine("\n List: \n");
            //mylist.Print(N);

            // Surusiuoja Lista
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            QuicksortList(mylist, 0, mylist.Length - 1);
            stopwatch2.Stop();
            Console.WriteLine("{0} elementu {1}ms", N, stopwatch2.ElapsedMilliseconds);
            //Console.WriteLine("\n Sorted List: \n");
            //mylist.Print(N);

            Console.ReadLine();
        }

        public static void QuicksortArray(IComparable[] elements, int left, int right)
        {
            int i = left, j = right;
            IComparable pivot = elements[(left + right) / 2]; // nustatome centrini elementa

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0) // lyginame kaire puse su centrine, tol kol < 0
                {
                    i++; 
                }

                while (elements[j].CompareTo(pivot) > 0) // lyginame desine puse su centrine, tol kol > 0
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap Sukeičiame rastus kairiji ir desini elementus
                    IComparable tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls einame gilyn ir kartojame proceduras
            if (left < j)
            {
                QuicksortArray(elements, left, j);
            }

            if (i < right)
            {
                QuicksortArray(elements, i, right);
            }
        }

        public static void QuicksortList(DataList items, int left, int right)
        {
            int i = left, j = right;
            IComparable currentdata, currentdata1, currentdata2;

            currentdata = items.Head(); // nustatome centrini elementa
            for (int k = 0; k < ((left + right) / 2); k++)
            {
                currentdata = items.Next(); // pastatome rodykle ties centriniu elementu
            }
            //Console.WriteLine(currentdata);
            IComparable pivot = currentdata; 
            
            while (i <= j)
            {
                currentdata = items.Head();
                for (int k = 0; k < i; k++)
                {
                    currentdata = items.Next(); // pastatome rodykle ties i-ju elementu
                }
                while (currentdata.CompareTo(pivot) < 0) // lyginame kaire puse su centrine, tol kol < 0
                {
                    i++;
                    currentdata = items.Next(); // pastatome rodykle ties 1 elementu
                }
                currentdata1 = currentdata; // issaugome 1 elemento reiksme

                currentdata = items.Head();
                for (int k = 0; k < j; k++)
                {
                    currentdata = items.Next(); // pastatome rodykle ties k-ju elementu
                }
                while (currentdata.CompareTo(pivot) > 0) // lyginame desine puse su centrine, tol kol > 0
                {
                    j--;
                    currentdata = items.Head();
                    for (int k = 0; k < j; k++)
                    {
                        currentdata = items.Next(); // pastatome rodykle ties 2 elementu
                    } 
                }
                currentdata2 = currentdata; // issaugome 2 elemento reiksme

                if (i <= j)
                {
                    // Swap Sukeičiame rastus kairiji ir desini elementus
                    items.Write(currentdata1); // irasome 1 elemento reiksme 2-jam

                    currentdata = items.Head(); // pastatome rodykle ties 1 elementu
                    for (int k = 0; k < i; k++)
                    {
                        currentdata = items.Next();
                    }
                    items.Write(currentdata2); // irasome 2 elemento reiksme 1-jam

                    i++;
                    j--;
                }
                //items.Print(items.Length);
            }

            // Recursive calls einame gilyn ir kartojame proceduras
            if (left < j)
            {
                QuicksortList(items, left, j);
            }

            if (i < right)
            {
                QuicksortList(items, i, right);
            }
        }


    }



}
