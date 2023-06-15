using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ID, Vorname, Nachname, PLZ, Geschlecht, Alter, Zugehörigkeit
// zu einer gesellschaftlichen Schicht, Zugehörigkeit zu einem politischen Lager sowie eine Be-
// einflussbarkeit

public enum Influenceable
{
    EASY,
    MIDDLE,
    HARD
}
public enum Age
{
    FirstTimer,
    TO30,
    TO40,
    TO50,
    TO60,
    OTHER
}
public enum Sex
{
    MALE,
    FEMALE,
    OTHER
}
public enum SocialClass
{
    LOWER,
    LOWERMIDDLE,
    HIGHERMIDDLE,
    UPPER
}
public enum PoliticalCamp
{
    DEMOCRATS,
    REPUBLICAN
}

namespace Aufgabe.UsWahl
{
    internal class Person
    {
        public int ID { get; set; }
        private static int nextID { get; set; } = 0;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PLZ { get; set; }
        public Sex Sex { get; set; }
        public Age Age { get; set; }
        public SocialClass SocialClass { get; set; }
        public PoliticalCamp PoliticalCamp { get; set; }
        public Influenceable Influenceable { get; set; }

        public Person()
        {
            this.ID = nextID;
            nextID++;
        }
    }
}
