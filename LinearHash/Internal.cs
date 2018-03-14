using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearHash
{
    class Internal
    {
       

        public Internal()
        {
            Random random = new Random();
            LinearList(random);
        }

        private string GenerateRandomString(Random random, int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void LinearList(Random random)
        {
            LinearHashTable<string, string> studentTable = new LinearHashTable<string, string>();
            List<string> randomKeys = new List<string>();
            for (int i = 0; i < 500000; i++)
            {
                string randomKey = GenerateRandomString(random, 20);
                randomKeys.Add(randomKey);
                studentTable.Add(randomKey, GenerateRandomString(random, 20));    
            }
            long currentTime = DateTime.Now.ToFileTime();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (string key in randomKeys)
            {
                int iterationAmount;
                string value;
                studentTable.TryGetValue(key, out value, out iterationAmount);
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }
    }
}
