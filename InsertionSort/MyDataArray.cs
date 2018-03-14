﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort
{
    class MyDataArray : DataArray
    {
        double[] data;
        public MyDataArray(int n, int seed)
        {
            data = new double[n];
            length = n;
            Random rand = new Random(seed);

            for (int i = 0; i < length; i++)
            {
                data[i] = rand.NextDouble();

            }

        }
        public override double this[int index]
        {
            get { return data[index]; }

        }
        public override void Swap(int j, double a, double b)

        {

            data[j + 1] = data[j];
            j--;
            data[j + 1] = a;
        }

    }
}