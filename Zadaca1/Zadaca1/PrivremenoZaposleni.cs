using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1
{
    //pitati da li sam dobro shvatio ili i ova klasa takodjer treba dodatne informacije poput titula itd
    public  class PrivremenoZaposleni : Zaposleni
    {
        private Datum pocetakUgovora;
        private Datum krajUgovora;

        public PrivremenoZaposleni(String ime,String prezime,Datum datumRodjenja,String maticniBroj,Datum pocetakUgovoraZaposlenog,Datum krajUgovoraZaposlenog):base(ime,prezime,datumRodjenja,maticniBroj)
        {
            PocetakUgovora = pocetakUgovoraZaposlenog;
            KrajUgovora = krajUgovoraZaposlenog;
            //Plata =?; 
            if (pocetakUgovora < krajUgovora) throw new Exception("Neispravni datumi za pocetak i kraj ugovora!");
        }
        public override string ToString()
        {
            return base.ToString() + "\nPocetak Ugovora: " + PocetakUgovora.Ispisi() + "\nKraj ugovora: " + KrajUgovora.Ispisi() + "\n";
        }
        public Datum PocetakUgovora
        {
            get { return pocetakUgovora; }
            set { pocetakUgovora = value; }
        }
        public Datum KrajUgovora
        {
            get { return krajUgovora; }
            set { krajUgovora = value; }
        }
    }
}
