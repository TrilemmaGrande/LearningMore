using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// Lassen Sie im Hauptprogramm ein Wahlvolk von 1.000 Wählern erzeugen und speichern Sie
// dieses in einer Liste. Ermitteln Sie nun mit geeigneten LINQ-Ausdrücken die folgenden Wähler-
// gruppen und geben Sie diese auf der Konsole aus:
// • Weibliche Erstwähler im PLZ-Bereich 3xxxx aus der oberen Mittelschicht die vermutlich die
// Republikaner wählen werden.
// • Wähler über 50 die den Demokraten zugetan sind aber sehr leicht beeinflussbar sind.
// • Wähler aus der Oberschicht, die sich nicht beeinflussen lassen und sich den Republikanern
// zurechnen.
// • Diverse Wähler unter 30 aus der Oberschicht, die offensichtlich die Republikaner wählen
// wolle

namespace Aufgabe.UsWahl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Model.GenerateValues(1000);
            IEnumerable<Person> FirstList = Model.GetVoters()
                                                .Where(s => s.Sex == Sex.FEMALE)
                                                .Where(a => a.Age == Age.FirstTimer)
                                                .Where(p => p.PLZ.StartsWith('3') && p.PLZ.Length == 5)
                                                .Where(c => c.SocialClass == SocialClass.HIGHERMIDDLE)
                                                .Where(pc => pc.PoliticalCamp == PoliticalCamp.REPUBLICAN)
                                                .OrderBy(id => id.ID);


            IEnumerable<Person> SecondList = Model.GetVoters()
                                                .Where(a => a.Age == Age.TO60)
                                                .Where(pc => pc.PoliticalCamp == PoliticalCamp.DEMOCRATS)
                                                .Where(i => i.Influenceable == Influenceable.EASY)
                                                .OrderBy(id => id.ID);

            IEnumerable<Person> ThirdList = Model.GetVoters()
                                                .Where(c => c.SocialClass == SocialClass.HIGHERMIDDLE)
                                                .Where(i => i.Influenceable == Influenceable.HARD)
                                                .Where(pc => pc.PoliticalCamp == PoliticalCamp.REPUBLICAN)
                                                .OrderBy(id => id.ID);

            IEnumerable<Person> FourthList = Model.GetVoters()
                                                .Where(s => s.Sex == Sex.OTHER)
                                                .Where(a => a.Age == Age.TO30)
                                                .Where(pc => pc.PoliticalCamp == PoliticalCamp.REPUBLICAN)
                                                .OrderBy(id => id.ID);

            static void PrintGroup(IEnumerable group)
            {
                foreach (Person Person in group)
                {
                    Console.Write(Person.ID + "\t\t" + Person.FirstName + ' ' + Person.LastName);
                    Console.WriteLine();
                }
            }

            Console.WriteLine("---------------------------------------------------------- FIRST LIST");
            PrintGroup(FirstList);
            Console.WriteLine("---------------------------------------------------------- SECOND LIST");
            PrintGroup(SecondList);
            Console.WriteLine("---------------------------------------------------------- THIRD LIST");
            PrintGroup(ThirdList);
            Console.WriteLine("---------------------------------------------------------- FOURTH LIST");
            PrintGroup(FourthList);
        }
    }
}
