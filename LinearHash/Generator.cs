using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearHash
{
    class Generator
    {
        private static List<string> studentNames = new List<string>()
            {
                "Mantas",
                "Vytautas",
                "Egidijus",
                "Klaudijus",
                "Gediminas",
                "Tomas",
                "Lukas",
                "Kostas",
                "Edvinas",
                "Marius",
                "Nerijus"

            };
        private static List<string> studentSurnames = new List<string>()
            {
                "Kristuoas",
                "Pavardenis",
                "Petkevicius",
                "Garsva",
                "Doneliunas",
                "Markatavicius",
                "Lukksisk",
                "Urbonavicius",
                "Sipavicius",
                "Antanaitis",
                "Marinaitis"
            };

        public static List<string> GenerateRandomKeys()
        {
            List<string> keys = new List<string>();
            foreach (string name in studentNames)
            {
                foreach (string surname in studentSurnames)
                {
                    string generatedValue = name[0].ToString() + surname[0].ToString();
                    if (!keys.Contains(generatedValue))
                    {
                        keys.Add(name[0].ToString() + surname[0].ToString());
                    }
                }
            }
            return keys;
        }

        public static List<string> GenerateRandomValues()
        {
            List<string> credentials = new List<string>();
            foreach (string name in studentNames)
            {
                foreach (string surname in studentSurnames)
                {
                    credentials.Add(name + ' ' + surname);
                }
            }
            return credentials;
        }

    }
}