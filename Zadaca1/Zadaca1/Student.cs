using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1
{
    public class Student : Property
    {
        protected static uint redniBrojIndeksa = 1;
        private String ime;
        private String prezime;
        private Datum datumRodjenja;
        private String maticniBroj;
        private Datum datumZavrsenjaPrethodnogObrazovanja;
        private uint brojIndeksa;
        protected List<Predmet> polozeniPredmeti;

        public Student(){}
        public Student(String ime,String prezime,Datum datRod,String matBroj,Datum datZavPretObr)
        {
            Ime = ime;
            Prezime = prezime;
            DatumRodjenja = datRod;
            MaticniBroj = matBroj;
            if (datZavPretObr < Datum.DajTrenutnoVrijeme()) throw new Exception("Datum zavrsenog prethodnog obrazovanja nije validan");
            DatumZavrsenjaPrethodnogObrazovanja = datZavPretObr;
            BrojIndeksa = redniBrojIndeksa;
            if (!ProvjeraMaticniBroj()) throw new Exception("Maticni broj se ne poklapa sa datumom!");
            redniBrojIndeksa++;
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
        public uint BrojIndeksa
        {
            get { return brojIndeksa; }
            protected set { brojIndeksa = value; }
        }
        public override string ToString()
        {
            String povratni="";
            povratni += "Broj indeksa je: " + VratiIndeksUString() + "\nIme i prezime studenta: " + Ime + " " + Prezime + ".\nDatum rodjenja studenta je: " + DatumRodjenja.Ispisi() + ".\nNjegov maticni broj je: " + MaticniBroj + ".\n";
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
        public Datum DatumRodjenja
        {
            get { return datumRodjenja; }
            set { datumRodjenja = value; }
        }
        public String MaticniBroj
        {
            get { return maticniBroj; }
            set { maticniBroj = value; }
        }
        public Datum DatumZavrsenjaPrethodnogObrazovanja
        {
            get { return datumZavrsenjaPrethodnogObrazovanja; }
            set { datumZavrsenjaPrethodnogObrazovanja = value; }
        }

    }
    public sealed class MasterStudent : Student
    {
        private static uint redniBrojMasterIndeks = 100;
        private Datum prethodnogVisokogObrazovanja;
        private uint brojIndeksaMaster;
        public MasterStudent(String ime,String prezime,Datum datRod, String matBroj, Datum datZavPretObr,Datum pretVisObr) : base(ime,prezime,datRod, matBroj, datZavPretObr)
        {
            if (pretVisObr < Datum.DajTrenutnoVrijeme()) throw new Exception("Datum prethodno zavrsenog studija nije validan!");
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
            prethodnogVisokogObrazovanja = Datum.DajTrenutnoVrijeme();
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
        public Datum PrethodnogVisokogObrazovanja
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
