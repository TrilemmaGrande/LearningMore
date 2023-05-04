using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beispiel.LINQ
{
    class Hero
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HeroName { get; set; }
        public string Gang { get; set; }
        private DateTime DateOfBirth;

        public void SetDateOfBirth(DateTime d)
        {
            this.DateOfBirth = d;
        }

        public int GetAge()
        {
            if (DateOfBirth >= DateTime.Today)
            {
                return 0;
            }
            int age = DateTime.Today.Year - DateOfBirth.Year;
            if (DateOfBirth.AddYears(age) > DateTime.Today)
            {
                age--;
            }
            return age;
        }

        public static List<Hero> GetHeroes(int cnt)
        {
            Random rnd = new Random();

            List<Hero> heroes = new List<Hero>() {
                new Hero() { HeroName = "Batman", FirstName = "Bruce", LastName = "Wayne", Gang = "Justice League" },
                new Hero() { HeroName = "Superman", FirstName = "Clark", LastName = "Kent", Gang = "Justice League" },
                new Hero() { HeroName = "Hulk", FirstName = "Bruce", LastName = "Banner", Gang = "Avengers" },
                new Hero() { HeroName = "Iron Man", FirstName = "Tony", LastName = "Stark", Gang = "Avengers" },
                new Hero() { HeroName = "Black Widow", FirstName = "Natasha", LastName = "Romanoff", Gang = "Avengers" },
                new Hero() { HeroName = "Captain Marvel", FirstName = "Carol", LastName = "Danvers", Gang = "Avengers" },
                new Hero() { HeroName = "Wonder Woman", FirstName = "Diana", LastName = "Prince", Gang = "Justice League" },
                new Hero() { HeroName = "Captain America", FirstName = "Steve", LastName = "Rogers", Gang = "Avengers" },
                new Hero() { HeroName = "Wolverine", FirstName = "James", LastName = "Howlett", Gang = "X-Men" },
                new Hero() { HeroName = "Magneto", FirstName = "Max", LastName = "Eisenhardt", Gang = "X-Men" }
            };

            return heroes
                .OrderBy(h => rnd.Next(1000))
                .Take(cnt)
                .ToList();
        }
    }
}
