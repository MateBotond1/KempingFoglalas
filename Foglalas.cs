using System;
using System.Collections.Generic;
using System.Text;

namespace KempingFoglalas
{
    public class Foglalas
    {
        public string VendegNev {  get; set; }
        public string ParcellaTipus { get; set; }
        public int EjszakakSzama { get; set; }
        public int FelnottFo { get; set; }
        public int GyerekFo { get; set; }

        public Foglalas(string sor)
        {
            string[] darabol=sor.Split(';');
            VendegNev=darabol[0];
            ParcellaTipus=darabol[1];
            EjszakakSzama=int.Parse(darabol[2]);
            FelnottFo=int.Parse(darabol[3]);
            GyerekFo=int.Parse(darabol[4]);
        }
        public double FizetendoOsszeg()
        {
            int ParcellaAr = 0;
            if (ParcellaTipus == "ALAP") {  ParcellaAr = 6000*EjszakakSzama; }
            else { ParcellaAr = 9500*EjszakakSzama; }
            double kedvezmeny = 1;
            if (EjszakakSzama >= 5) { kedvezmeny = 0.9; }
            return ParcellaAr + ((FelnottFo * 500) * EjszakakSzama + (GyerekFo * 1500) * EjszakakSzama) * kedvezmeny;
        }
        public override string ToString()
        {
            return $"{VendegNev} ({ParcellaTipus}): {EjszakakSzama} éjszaka, {FelnottFo} felnőtt, {GyerekFo} gyerek - Fizetendő: {FizetendoOsszeg()} Ft";
        }
    }
}
