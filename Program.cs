using KempingFoglalas;
List<Foglalas> Adatok=new List<Foglalas>();
foreach(string sor in File.ReadAllLines("kemping.txt"))
{
    Adatok.Add(new Foglalas(sor));
}
