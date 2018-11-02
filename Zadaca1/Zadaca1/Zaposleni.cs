using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1
{
    public abstract partial class Zaposleni : Property
    {
        protected const int PLATA_ZA_NASTAVNO_OSOBLJE= 80;
        protected const int  PLATA_ZA_NENASTAVNO_OSOBLJE= 45;
        protected static int sifreZaZaposlene=1;
        private String ime;
        private String prezime;
        private Datum datumRodjenja;
        private String maticniBroj;
        private int sifraZaposlenog;
        private double plata;

       public Zaposleni(String imeZap,String prezimeZap,Datum datumRodjenjaZap,String maticniBrojZap)
        {
            Ime = imeZap;
            Prezime = prezimeZap;
            DatumRodjenja = datumRodjenjaZap;
            MaticniBroj = maticniBrojZap;
            SifraZaposlenog = sifreZaZaposlene;
            if (!ProvjeraMaticniBroj()) throw new Exception("Maticni broj se ne poklapa sa datumom!");
            sifreZaZaposlene++;
        } 
      private bool ProvjeraMaticniBroj()
        {
            if (maticniBroj.Length != 13) return false;
            String datum = datumRodjenja.ToString();
            for (int i = 0; i < 7; i++)
                if (maticniBroj[i] != datum[i])
                    return false;
            return true;
        }
        public int SifraZaposlenog
        {
            get { return sifraZaposlenog; }
            private set { sifraZaposlenog = value; }
        }
        public String Ime
        {
            get { return ime; }
            set { ime = value; }
        }
        public String Prezime
        {
            get { return prezime; }
            set { prezime = value; }
        }
        public String MaticniBroj
        {
            get { return maticniBroj; }
            private set { maticniBroj = value; }
        }
        public Datum DatumRodjenja
        {
            get { return datumRodjenja; }
            set { datumRodjenja = value; }
        }
        public double Plata
        {
            get { return plata; }
            set { plata = value; }
        }
        public override string ToString()
        {
            return "Ime i prezime zaposlenog: " + Ime + " " + Prezime + ".\nDatum rodjenja zaposlenog: " + DatumRodjenja.Ispisi() + "\nMaticni broj zaposlenog: " + MaticniBroj + ".\nPlata: " + Plata.ToString() + ".\nSifra zaposlenog: " + SifraZaposlenog.ToString() + ".\n"; 
        }
    }
    public class StalniZaposleni : Zaposleni
    {
        private String infoPozicija;
        private String strucnaSprema;
        private String titula;

        public StalniZaposleni(String imeZaposlenog,String prezimeZaposlenog,Datum datumRodjenjaZaposlenog,String maticniBrojZaposlenog,String infoPozicijaZaposlenog,String strucnaSpremaZaposlenog,String titulaZaposlenog):base(imeZaposlenog,prezimeZaposlenog,datumRodjenjaZaposlenog,maticniBrojZaposlenog)
        {
            InfoPozicija = infoPozicijaZaposlenog;
            StrucnaSprema = strucnaSpremaZaposlenog;
            Titula = titulaZaposlenog;
        }
        public String InfoPozicija
        {
            get { return infoPozicija; }
            set { infoPozicija = value; }
        }
        public String StrucnaSprema
        {
            get { return strucnaSprema; }
            set { strucnaSprema = value; }
        }
        public String Titula
        {
            get { return titula; }
            set { titula = value; }
        }
    }
    public class NastavnoOsoblje : StalniZaposleni
    {
        private int brojPredmeta;

        public NastavnoOsoblje(String imeZap, String prezimeZap, Datum datumRodjenjaZap, String maticniBrojZap, String infoPozicijaZap, String strucnaSpremaZap, String titulaZap,int brojPred) : base(imeZap, prezimeZap, datumRodjenjaZap, maticniBrojZap, infoPozicijaZap, strucnaSpremaZap, titulaZap) { BrojPredmeta = brojPred; Plata = PLATA_ZA_NASTAVNO_OSOBLJE * brojPredmeta; }
        public override string ToString()
        {
            return base.ToString() + "Zaposleni radi na poziciji " +InfoPozicija + "\nPredaje na: " + brojPredmeta.ToString() + " predmeta.\n";
        }
        public int BrojPredmeta
        {
            get { return brojPredmeta; }
            set { brojPredmeta = value; Plata = brojPredmeta * PLATA_ZA_NASTAVNO_OSOBLJE; }
        }
    }
    public class NenastavnoOsoblje : StalniZaposleni
    {
        private double koeficientPlate;//nisam znao kako da ga koristim,da li da korisnik unese taj broj ili da ga nekako ja odredim?
        public NenastavnoOsoblje(String ime, String prezima, Datum datumRodjenja, String maticniBroj, String infoPozicija, String strucnaSprema, String titula) : base(ime, prezima, datumRodjenja, maticniBroj, infoPozicija, strucnaSprema, titula) { KoeficientPlate = 1; /* Plata=? */ }
        public override string ToString()
        {
            return base.ToString() + "\nZaposleni radi na poziciji " + InfoPozicija + ".\n";
        }
        public double KoeficientPlate
        {
            get { return koeficientPlate; }
            set { koeficientPlate = value; }
        }

    }
}
