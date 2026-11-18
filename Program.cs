using KempingFoglalas;
List<Foglalas> Adatok=new List<Foglalas>();
Console.WriteLine("Adatok beolvasása a kemping.txt fájlból...\n");
foreach(string sor in File.ReadAllLines("kemping.txt").Skip(1))
{
    Adatok.Add(new Foglalas(sor));
}
Console.WriteLine("Rögzített kempingfoglalások:");
foreach(Foglalas aktualis in Adatok)
{
    Console.WriteLine(aktualis);
}
Console.WriteLine("\nÖsszesített statisztika:");
Console.WriteLine($"Kemping teljes bevétele: {Adatok.Sum(x=>x.FizetendoOsszeg())} Ft");
Console.WriteLine($"Összes vendég létszáma: {Adatok.Sum(x=>x.FelnottFo)+Adatok.Sum(x=>x.GyerekFo)} fő");
Console.WriteLine($"Átlagos tartózkodási idő: {(((Adatok.Sum(x=>x.EjszakakSzama))/Adatok.Count))} éjszaka");
Foglalas legjobb = Adatok.MaxBy(x => x.FizetendoOsszeg());
Console.WriteLine($"Legtöbbet fizető vendég: {legjobb.VendegNev} ({legjobb.FizetendoOsszeg()} Ft)");
int gyerekesKomfortDb = Adatok.Count(x => x.ParcellaTipus == "KOMFORT" && x.GyerekFo >= 1);
Console.WriteLine($"Gyerekes KOMFORT foglalások száma: {gyerekesKomfortDb} db");
Console.WriteLine($"\nKedvezményre jogosult vendégek (legalább 5 éjszaka):");
foreach (Foglalas kedvezett in Adatok)
{
    if (kedvezett.EjszakakSzama >= 5)
    {
        Console.WriteLine($"{kedvezett.VendegNev} ({kedvezett.EjszakakSzama} éjszaka)");
    }
}