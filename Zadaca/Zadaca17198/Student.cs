using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca17198
{
    public class Student : IProperty
    {
        protected static uint redniBrojIndeksa = 1;
        private String ime;
        private String prezime;
        private DateTime datumRodjenja;
        private String maticniBroj;
        private DateTime datumZavrsenjaPrethodnogObrazovanja;
        private uint brojIndeksa;
        protected List<int> polozeniPredmeti;
        protected List<int> trenutniPredmeti; //predmeti koji se trenutno slusaju

        public Student() { }
        public Student(String ime, String prezime, DateTime datRod, String matBroj, DateTime datZavPretObr)
        {
            Ime = ime;
            Prezime = prezime;
            DatumRodjenja = datRod;
            MaticniBroj = matBroj;
            if (datZavPretObr < DateTime.Now) throw new Exception("Datum zavrsenog prethodnog obrazovanja nije validan");
            DatumZavrsenjaPrethodnogObrazovanja = datZavPretObr;
            BrojIndeksa = redniBrojIndeksa;
            if (!ProvjeraMaticniBroj()) throw new Exception("Neispravan unos!");
            redniBrojIndeksa++;
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
        public uint BrojIndeksa
        {
            get { return brojIndeksa; }
            protected set { brojIndeksa = value; }
        }
        public override string ToString()
        {
            String povratni = "";
            povratni += "Broj indeksa je: " + VratiIndeksUString() + "\nIme i prezime studenta: " + Ime + " " + Prezime + ".\nDatum rodjenja studenta je: " + DatumRodjenja.ToShortDateString() + ".\nNjegov maticni broj je: " + MaticniBroj + ".\n";
            return povratni;
        }
        public virtual String VratiIndeksUString()
        {
            return brojIndeksa.ToString();
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
        public DateTime DatumRodjenja
        {
            get { return datumRodjenja; }
            set { datumRodjenja = value; }
        }
        public String MaticniBroj
        {
            get { return maticniBroj; }
            set { maticniBroj = value; }
        }
        public DateTime DatumZavrsenjaPrethodnogObrazovanja
        {
            get { return datumZavrsenjaPrethodnogObrazovanja; }
            set { datumZavrsenjaPrethodnogObrazovanja = value; }
        }
        public List<int> PolozeniPredmeti
        {
            get { return polozeniPredmeti; }
            set { polozeniPredmeti = value; }
        }
        public List<int> TrenutniPredmeti
        {
            get
            {
                return trenutniPredmeti;
            }
            set
            {
                trenutniPredmeti = value;
            }
        }
        //cuvam polozene predmete tako sto imam samo njihovu sifru
        public void DodajPolozeniPredmet(int polozeni)
        {
            if (!TrenutniPredmeti.Exists(i => i == polozeni))
                throw new Exception("Student nije ni slusao dati predmet!");
            else TrenutniPredmeti.Remove(polozeni);
            polozeniPredmeti.Add(polozeni);
        }
        public void DodajPredmet(int predmet)
        {
            if (TrenutniPredmeti.Exists(x => x == predmet))
                throw new Exception("Predmet vec postoji!");
            TrenutniPredmeti.Add(predmet);
        }
    }
    public sealed class MasterStudent : Student
    {
        private static uint redniBrojMasterIndeks = 100;
        private DateTime prethodnogVisokogObrazovanja;
        private uint brojIndeksaMaster;
        public MasterStudent(String ime, String prezime, DateTime datRod, String matBroj, DateTime datZavPretObr, DateTime pretVisObr) : base(ime, prezime, datRod, matBroj, datZavPretObr)
        {
            if (pretVisObr < DateTime.Now) throw new Exception("Datum prethodno zavrsenog studija nije validan!");
            if (pretVisObr > DatumZavrsenjaPrethodnogObrazovanja) throw new Exception("Datumi nije ispravan u odnosu na prethodne!");
            prethodnogVisokogObrazovanja = pretVisObr;
            brojIndeksaMaster = redniBrojMasterIndeks;
            ProvjeriMasterIndeks();
        }
        public MasterStudent(Student student)
        {
            Ime = student.Ime;
            Prezime = student.Prezime;
            DatumRodjenja = student.DatumRodjenja;
            MaticniBroj = student.MaticniBroj;
            DatumZavrsenjaPrethodnogObrazovanja = student.DatumZavrsenjaPrethodnogObrazovanja;
            BrojIndeksa = student.BrojIndeksa;
            brojIndeksaMaster = redniBrojMasterIndeks;
            prethodnogVisokogObrazovanja = DateTime.Now;
            redniBrojMasterIndeks++;
        }
        private void ProvjeriMasterIndeks()//kako bi prvi broj master indeksa uvijek bio trocifren
        {
            if (++redniBrojMasterIndeks >= 999) redniBrojMasterIndeks = 100;
        }
        public override String VratiIndeksUString()
        {
            return brojIndeksaMaster.ToString() + "/" + BrojIndeksa.ToString();
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public DateTime PrethodnogVisokogObrazovanja
        {
            get { return prethodnogVisokogObrazovanja; }
            set { prethodnogVisokogObrazovanja = value; }
        }
        public uint BrojIndeksMaster
        {
            get { return brojIndeksaMaster; }
            private set { brojIndeksaMaster = value; }
        }
    }
}
