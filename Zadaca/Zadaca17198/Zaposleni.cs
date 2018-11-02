using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca17198
{
    public abstract partial class Zaposleni : IProperty
    {
        public Zaposleni(String imeZap, String prezimeZap, DateTime datumRodjenjaZap, String maticniBrojZap)
        {
            Ime = imeZap;
            Prezime = prezimeZap;
            DatumRodjenja = datumRodjenjaZap;
            MaticniBroj = maticniBrojZap;
            SifraZaposlenog = sifreZaZaposlene;
            if (!ProvjeraMaticniBroj()) throw new Exception("Neispravan unos!");
            sifreZaZaposlene++;
        }
        private bool ProvjeraMaticniBroj()
        {
            String datum = DatumRodjenja.ToString();
            if (MaticniBroj.Length != 13) return false;
            if (MaticniBroj[0] != datum[0] || MaticniBroj[1] != datum[1])
                return false;
            if (MaticniBroj[2] != datum[3] || MaticniBroj[3] != datum[4])
                return false;
            if (MaticniBroj[4] != datum[7] || MaticniBroj[5] != datum[8] || MaticniBroj[6] != datum[9])
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
        public DateTime DatumRodjenja
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
            return "Ime i prezime zaposlenog: " + Ime + " " + Prezime + ".\nDatum rodjenja zaposlenog: " + DatumRodjenja.ToShortDateString() + "\nMaticni broj zaposlenog: " + MaticniBroj + ".\nPlata: " + Plata.ToString() + ".\nSifra zaposlenog: " + SifraZaposlenog.ToString() + ".\n";
        }
    }
    public class StalniZaposleni : Zaposleni
    {
        private String infoPozicija;
        private String strucnaSprema;
        private String titula;

        public StalniZaposleni(String imeZaposlenog, String prezimeZaposlenog, DateTime datumRodjenjaZaposlenog, String maticniBrojZaposlenog, String infoPozicijaZaposlenog, String strucnaSpremaZaposlenog, String titulaZaposlenog) : base(imeZaposlenog, prezimeZaposlenog, datumRodjenjaZaposlenog, maticniBrojZaposlenog)
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
        private List<int> predmeti;

        public NastavnoOsoblje(String imeZap, String prezimeZap, DateTime datumRodjenjaZap, String maticniBrojZap, String infoPozicijaZap, String strucnaSpremaZap, String titulaZap) : base(imeZap, prezimeZap, datumRodjenjaZap, maticniBrojZap, infoPozicijaZap, strucnaSpremaZap, titulaZap) { /* Plata = PLATA_ZA_NASTAVNO_OSOBLJE * brojPredmeta;  */}
        public override string ToString()
        {
            return base.ToString() + "Zaposleni radi na poziciji " + InfoPozicija + "\nPredaje na: " + Predmeti.Count.ToString() + " predmeta.\n";
        }
        public List<int> Predmeti
        {
            get
            {
                return predmeti;
            }
            set
            {
                predmeti = value;
            }
        }
        public void DodajPredmet(Predmet predmet)
        {
            if (Predmeti.Exists( x => x == predmet.SifraPredmeta))
                throw new Exception("Predmet vec postoji!");
            Predmeti.Add(predmet.SifraPredmeta);
        }

    }
    public class NenastavnoOsoblje : StalniZaposleni
    {
        private double koeficientPlate;//nisam znao kako da ga koristim,da li da korisnik unese taj broj ili da ga nekako ja odredim?
        public NenastavnoOsoblje(String ime, String prezima, DateTime datumRodjenja, String maticniBroj, String infoPozicija, String strucnaSprema, String titula) : base(ime, prezima, datumRodjenja, maticniBroj, infoPozicija, strucnaSprema, titula) { KoeficientPlate = 1; /* Plata=? */ }
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
