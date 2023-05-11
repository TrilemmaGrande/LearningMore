using System.Runtime.Serialization.Formatters.Binary;

namespace Beispiel.SerializerBinaryFormatter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hero batman = new Hero("Batman", 42);
            batman.Stuff = "Batmobile, Bat-Ladder";
            Hero robin = new Hero("Robin", 24);
            robin.Stuff = "Make-up-Tasche";

            batman.Partner = robin;
            robin.Partner = batman;

            Hero[] heroes = new Hero[2];
            heroes[0] = batman;
            heroes[1] = robin;

            BinaryFormatter binform = new BinaryFormatter();

            // Serialisierung
            using (FileStream fs = File.Create("Batman.dat"))
            {
                binform.Serialize(fs, heroes);
            }

            // Deserialisierung
            Hero batmancopy;
            Hero[] heroesCopies;

            using (FileStream fs = File.OpenRead("Batman.dat"))
            {
                heroesCopies = binform.Deserialize(fs) as Hero[];
            }
            batmancopy = heroesCopies[0];
            // Prüfung
            Console.WriteLine($"Batman: {batman.Name}, {batman.GetAge()}, {batman.Stuff}, {batman.Partner.Name}, {batman.Partner.Partner.Name}");
            Console.WriteLine($"Kopie: {batmancopy.Name}, {batmancopy.GetAge()}, {batmancopy.Stuff}, {batmancopy.Partner.Name}, {batmancopy.Partner.Partner.Name}");
        }
    }
    [Serializable]
    class Hero
    {
        public string Name { get; }
        public Hero Partner { get; set; }
        private int age;
        [NonSerialized]
        public string Stuff;
        public Hero(string name, int age)
        {
            Name = name;
            this.age = age;
        }
        public int GetAge()
        {
            return age;
        }
    }
}