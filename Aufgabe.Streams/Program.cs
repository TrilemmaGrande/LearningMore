namespace Aufgabe.Streams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateFilesWithContent();
            CompareTextFiles("Text1.txt", "Text2.txt");
            CompareTextFiles("Text1.txt", "Text3.txt");
            CompareTextFiles("Text2.txt", "Text3.txt");
        }

        static void CreateFilesWithContent()
        {
            using (StreamWriter sw = File.CreateText("Text1.txt"))
            {
                sw.WriteLine("Testtext\n1\nDieserTextIstDerselbe wie in der anderen Datei");
            }
            using (StreamWriter sw = File.CreateText("Text2.txt"))
            {
                sw.WriteLine("Testtext\n1\nDieserTextIstDerselbe wie in der anderen Datei");
            }
            using (StreamWriter sw = File.CreateText("Text3.txt"))
            {
                sw.WriteLine("Testtext\n2\nDieserTextIstEinAnderer wie in den anderen Dateien");
            }
        }
        static void CompareTextFiles(string firstFile, string secondFile)
        {
            int wrongLines = 0;
            using (StreamReader srFileOne = File.OpenText(firstFile), srFileTwo = File.OpenText(secondFile))
            {
                Console.WriteLine($"Vergleiche \"{firstFile}\" mit \"{secondFile}\":");
                string line1 = "";
                string line2 = "";
                int lineCounter = 1;
               
                while ((line1 = srFileOne.ReadLine()) != null | (line2 = srFileTwo.ReadLine()) != null)
                {
                    if (line1.Equals(line2))
                    {
                        Console.WriteLine($"Die Inhalte sind gleich in Zeile: {lineCounter}");
                        lineCounter++;
                    }
                    else
                    {
                        Console.WriteLine($"Die Inhalte sind nicht gleich in Zeile: {lineCounter}");
                        wrongLines++;
                        lineCounter++;
                    }
                }
            }
            Console.WriteLine($"Anzahl falscher Zeilen: {wrongLines}");
            Console.WriteLine();

        }

    }
}
