namespace Aufgabe.LINQ2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kunde[] kunden = Kunde.GetKundenListe();
            Produkt[] produkte = Produkt.GetProduktListe();

            var kundenOrt = kunden
                .Select(k => new { k.Name, k.Ort });

            var produktNamen = produkte
                .Select(p => p.Name);

            var bestellungenDeutschland = kunden
                .Where(k => k.Land == Länder.Germany)
                .SelectMany(k => k.Bestellungen);

            var ungeradeKunden = kunden
                .Where((k, i) => i % 2 == 0)
                .Select(k => k.Name);

            var namePreisProdukteDesc = produkte
                .Where(p => p.Preis <= 20)
                .Select(p => new { p.Name, p.Preis })
                .OrderByDescending(p => p.Preis);

            var nameLandKunden = kunden
                .Select(k => new { k.Name, k.Land })
                .OrderBy(k => k.Land.ToString())
                .ThenBy(k => k.Name);

            var kundeByLand = kunden
                .GroupBy(kunden => kunden.Land.ToString());

            var produktByName = produkte
                .GroupBy(produkte => produkte.Name.First(), p => p.Name);

            var joinProduktBestellungen = produkte
                .Join(kunden.SelectMany(k => k.Bestellungen), produkte => produkte.ProduktNr, bestellungen => bestellungen.ProduktNr,
                (p, b) => new { b.Monat, b.ProduktNr, p.Name, p.Preis, b.Versendet })
                .OrderBy(p => p.Preis);

            var kundeNameOrtBestellung = kunden
                .Select(k => new { k.Name, k.Ort, Anzahl = k.Bestellungen.Count() });

            var sumPreise = produkte
                .Select(p => p.Preis)
                .Sum(p => p);

            var kundenNameGesamtpreis = kunden
                .SelectMany(k => k.Bestellungen, (k, b) => new { k.Name, Bestellungen = b })
                .Join(produkte,
                b => b.Bestellungen.ProduktNr,
                p => p.ProduktNr,
                (b, p) => new { b.Name, Bestellwert = b.Bestellungen.Anzahl * p.Preis })
                .GroupBy(bp => bp.Name)
                .Select(g => new { Name = g.Key, Betrag = g.Sum(b => b.Bestellwert) });



            Ausgeben(kundenOrt);
            Console.WriteLine();
            Ausgeben(produktNamen);
            Console.WriteLine();
            Ausgeben(bestellungenDeutschland);
            Console.WriteLine();
            Ausgeben(ungeradeKunden);
            Console.WriteLine();
            Ausgeben(namePreisProdukteDesc);
            Console.WriteLine();
            Ausgeben(nameLandKunden);
            Console.WriteLine();
            foreach (var item in kundeByLand)
            {
                Console.WriteLine(item.Key + ":");
                Ausgeben(item);
            }
            Console.WriteLine();
            foreach (var item in produktByName)
            {
                Console.WriteLine(item.Key + ":");
                Ausgeben(item);
            }
            Console.WriteLine();
            Ausgeben(joinProduktBestellungen);
            Console.WriteLine();
            foreach (var item in kundeNameOrtBestellung)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine(sumPreise);
            Console.WriteLine();
            Ausgeben(kundenNameGesamtpreis);
        }
        static void Ausgeben<T>(IEnumerable<T> o)
        {
            foreach (var item in o)
            {
                Console.WriteLine(item);
            }
        }
    }
}