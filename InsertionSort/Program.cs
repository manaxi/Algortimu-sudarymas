using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            const int N = 100;
            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;
            Random rand = new Random(seed);


            //Test_List(seed, N);
            //Test_List(seed, 200);
            //Test_List(seed, 300);
            //Test_List(seed, 400);
            //Test_List(seed, 500);

            Test_List(seed, N);
            Test_List(seed, 1000);
            Test_List(seed, 2000);
            Test_List(seed, 3000);
            Test_List(seed, 4000);
            Test_List(seed, 5000);
            //Test_File(seed, N);

        }
        public static void Test_List(int seed, int N)
        {

            MyDataArray myarray = new MyDataArray(N, seed);
            // Console.WriteLine("\n ARRAY \n");
            //myarray.Print(N);
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            insertion(myarray);
            stopwatch1.Stop();
            // myarray.Print(N);
            Console.WriteLine("{0} elementu {1}ms", N, stopwatch1.ElapsedMilliseconds);

            //MyDataList mylist = new MyDataList(N, seed);
            ////Console.WriteLine("\n List: \n");
            //Stopwatch stopwatch2 = new Stopwatch();
            ////mylist.Print(N);
            //stopwatch2.Start();
            //insertsortlist(mylist);
            //stopwatch2.Stop();
            //Console.WriteLine("{0} elementu {1}ms", N, stopwatch2.ElapsedMilliseconds);
            ////Console.WriteLine("\n Sorted List: \n");
            ////mylist.Print(N);


        }

        public static void Test_File(int seed, int n)
        {
            string filename;


            filename = @"mydataarray.dat";
            MyFileArray myFileArray = new MyFileArray(filename, n, seed);
            using (myFileArray.fs = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite))
            {
                Console.WriteLine("\n FILE ARRAY \n");
                myFileArray.Print(n);
                insertion(myFileArray);
                myFileArray.Print(n);
            }


                filename = @"mydatalist.dat";
            MyFileList myfilelist = new MyFileList(filename, n, seed);
            using (myfilelist.fs = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite))
            {
                Console.WriteLine("\n file List \n");
                myfilelist.Print(n);
                insertsortlistForFile(myfilelist);
                myfilelist.Print(n);
            }
        }

        // Masyvo rūsiavimas
        static void insertsortarray(int[] data, int n)
        {
            int i, j;
            for (i = 1; i < n; i++)
            {
                int item = data[i]; // isrenkamas nuo antro iki galinio kiekvienas elementas
                int ins = 0;
                for (j = i - 1; j >= 0 && ins != 1;)
                {
                    if (item < data[j]) // tikrinama su esanciais pirmesniais elementais pradedant nuo artimesnio
                    {
                        // sukeitinejamas item elementas su esanciais pirmesniai elementais tol jie bus uz ji didesni
                        data[j + 1] = data[j];
                        j--;
                        data[j + 1] = item;
                    }
                    else ins = 1; // jei neatliktas pakeitimas sekanciu artimesniu nariu iseinama is ciklo
                }
            }
        }

        public static void insertion(DataArray items)
        {
            int j;
            double prevdata, currentdata;
            for(int i = 1; i<items.Length;i++)
            {
                currentdata = items[i];
                int ins = 0;
                for (j = i - 1; j >= 0 && ins != 1;)
                {
                    if (currentdata<items[j])
                    {
                        items.Swap(j, currentdata, 0);
                        j--;
                    }
                    else ins = 1;
                }

            }
        }
        // Sąrašo rūšiavimas
        public static void insertsortlist(DataList items)
        {
            double prevdata, currentdata;

            for (int i = 1; i < items.Length; i++)
            {
                currentdata = items.Head();

                for (int k = 0; k < i; k++)
                {
                    prevdata = currentdata;
                    currentdata = items.Next();
                }
                double item = currentdata; // isrenkamas nuo antro iki galinio kiekvienas elementas

                int ins = 0;
                for (int j = i - 1; j >= 0 && ins != 1;)
                {

                    currentdata = items.Head();
                    for (int k = 0; k < j; k++)
                    {
                        prevdata = currentdata;
                        currentdata = items.Next();
                    }

                    if (item < currentdata) // tikrinama su esanciais pirmesniais elementais pradedant nuo artimesnio
                    {
                        // sukeitinejamas item elementas su esanciais pirmesniai elementais tol jie bus uz ji didesni
                        prevdata = currentdata;
                        currentdata = items.Next();
                        items.Swap(currentdata, prevdata);
                        j--;
                    }
                    else ins = 1; // jei neatliktas pakeitimas sekanciu artimesniu nariu iseinama is ciklo
                }
            }
        }
        public static void insertsortlistForFile(MyFileList items)
        {
            double prevdata, currentdata;

            for (int i = 1; i < items.Length; i++)
            {
                currentdata = items.Head();

                for (int k = 0; k < i; k++)
                {
                    prevdata = currentdata;
                    currentdata = items.Next();
                }
                double item = currentdata; // isrenkamas nuo antro iki galinio kiekvienas elementas

                int ins = 0;
                for (int j = i - 1; j >= 0 && ins != 1;)
                {

                    currentdata = items.Head();
                    for (int k = 0; k < j; k++)
                    {
                        prevdata = currentdata;
                        currentdata = items.Next();
                    }

                    if (item < currentdata) // tikrinama su esanciais pirmesniais elementais pradedant nuo artimesnio
                    {
                        // sukeitinejamas item elementas su esanciais pirmesniai elementais tol jie bus uz ji didesni
                        prevdata = currentdata;
                        currentdata = items.Next();
                        items.Swap(currentdata, prevdata);
                        j--;
                    }
                    else ins = 1; // jei neatliktas pakeitimas sekanciu artimesniu nariu iseinama is ciklo
                }
            }
        }

    }
}
