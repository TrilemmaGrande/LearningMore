using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

    // Zum Testen Ihrer späteren Analyse-Software soll nun eine statische Klasse Model entwickelt
    // werden, in der in einer List<Person> die Wähler gespeichert werden können. Die Klasse soll
    // über eine Methode GenerateValues(int anzahl) verfügen, die eine definierte Anzahl von
    // sPerson-Objekten mit zufälligen Werten erzeugt und in die Liste schreibt.

namespace Aufgabe.UsWahl
{
    static class Model
    {
        private static Random rnd = new Random();
        private static List<Person> Persons = new List<Person>();
        private static ICollection<string> FirstNamesW = File.ReadAllLines(Directory.GetCurrentDirectory() + "/vornamen_w.txt");
        private static ICollection<string> FirstNamesM = File.ReadAllLines(Directory.GetCurrentDirectory() + "/vornamen_m.txt");
        private static ICollection<string> LastNames = File.ReadAllLines(Directory.GetCurrentDirectory() + "/nachnamen.txt");

        public static void GenerateValues(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Person p = new Person();
                p.PLZ = rnd.Next(10000, 100000).ToString();
                p.Age = (Age)rnd.Next(Enum.GetValues(typeof(Age)).Length);
                p.Sex = (Sex)rnd.Next(Enum.GetValues(typeof(Sex)).Length);
                p.SocialClass = (SocialClass)rnd.Next(Enum.GetValues(typeof(SocialClass)).Length);
                p.PoliticalCamp = (PoliticalCamp)rnd.Next(Enum.GetValues(typeof(PoliticalCamp)).Length);
                p.Influenceable = (Influenceable)rnd.Next(Enum.GetValues(typeof(Influenceable)).Length);
                p.LastName = LastNames.ElementAtOrDefault(rnd.Next(LastNames.Count()));

                if (p.Sex == Sex.FEMALE)
                {
                    p.FirstName = FirstNamesW.ElementAtOrDefault(rnd.Next(FirstNamesW.Count()));
                }
                else if (p.Sex == Sex.MALE)
                {
                    p.FirstName = FirstNamesM.ElementAtOrDefault(rnd.Next(FirstNamesM.Count()));
                }
                else
                {
                    int otherGender = rnd.Next(2);
                    if (otherGender == 0)
                    {
                        p.FirstName = FirstNamesW.ElementAtOrDefault(rnd.Next(FirstNamesW.Count()));
                    }
                    else
                    {
                        p.FirstName = FirstNamesM.ElementAtOrDefault(rnd.Next(FirstNamesM.Count()));
                    }
                }
                Persons.Add(p);
            }
        }
        public static List<Person> GetVoters()
        {
            return Persons;
        }
    }
}
