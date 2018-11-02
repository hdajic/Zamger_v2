using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca17198
{
    public abstract partial class Zaposleni
    {
        protected const int PLATA_ZA_NASTAVNO_OSOBLJE = 80;
        protected const int PLATA_ZA_NENASTAVNO_OSOBLJE = 45;
        protected static int sifreZaZaposlene = 1;
        private String ime;
        private String prezime;
        private DateTime datumRodjenja;
        private String maticniBroj;
        private int sifraZaposlenog;
        private double plata;
    }
    public class PrivremenoZaposleni : Zaposleni
    {
        private DateTime pocetakUgovora;
        private DateTime krajUgovora;

        public PrivremenoZaposleni(String ime, String prezime, DateTime datumRodjenja, String maticniBroj, DateTime pocetakUgovoraZaposlenog, DateTime krajUgovoraZaposlenog) : base(ime, prezime, datumRodjenja, maticniBroj)
        {
            PocetakUgovora = pocetakUgovoraZaposlenog;
            KrajUgovora = krajUgovoraZaposlenog;
            //Plata =?; 
            if (pocetakUgovora < krajUgovora) throw new Exception("Neispravni datumi za pocetak i kraj ugovora!");
        }
        public override string ToString()
        {
            return base.ToString() + "\nPocetak Ugovora: " + PocetakUgovora.ToShortDateString() + "\nKraj ugovora: " + KrajUgovora.ToShortDateString() + "\n";
        }
        public DateTime PocetakUgovora
        {
            get { return pocetakUgovora; }
            set { pocetakUgovora = value; }
        }
        public DateTime KrajUgovora
        {
            get { return krajUgovora; }
            set { krajUgovora = value; }
        }
    }
}
