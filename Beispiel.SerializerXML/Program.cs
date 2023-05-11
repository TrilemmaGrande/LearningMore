using System.Xml.Serialization;

namespace Beispiel.SerializerXML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hero batman = new Hero("Batman", 42);
            batman.Stuff = "Batmobile, Bat-Ladder";
            batman.Gadgets = new List<string>() { "Batcave", "Batsuit", "Batarang" };

            XmlSerializer xml = new XmlSerializer(typeof(Hero));

            // Serialisierung
            using (FileStream fs = File.Create("Batman.xml"))
            {
                xml.Serialize(fs, batman);
            }
        }
    }
    public class Hero
    {
        [XmlElement("HeroName")]
        public string Name { get; set; }
        private int age;
        [XmlIgnore]
        public string Stuff { get; set; }
        [XmlArray("ListOfGadget")]
        [XmlArrayItem("Gadget")]
        public List<string> Gadgets;
        public Hero() { }
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