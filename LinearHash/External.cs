using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace LinearHash
{
    class External
    {
        //private int Seed = 10;
        private const string DataFileName = "../test.txt";

        public External()
        {
            LinearHash();
        }
        private string GenerateRandomString(Random random, int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        private void LinearHash()
        {
            File.Create(DataFileName).Close();
            LinearHashTableOfString hashTable =
                new LinearHashTableOfString(DataFileName);
            List<string> randomKeys = new List<string>();
            Random random = new Random();

            for (int i = 0; i < 500; i++)
            {
                string randomKey = GenerateRandomString(random, 20);
                randomKeys.Add(randomKey);
                hashTable.AddKeyValuePair(randomKey, (i + 1));
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < randomKeys.Count; i++)
            {
                hashTable.GetValueByKey(randomKeys[i]);
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }
    }
}
