using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca17198
{
    public sealed class Fakultet
    {
        private String imeFakulteta;
        private List<Student> studenti;
        private List<Zaposleni> zaposleni;
        private List<Predmet> predmeti;

        public Fakultet(String ime)
        {
            ImeFakulteta = ime;
            Studenti = new List<Student>();
            Zaposleni = new List<Zaposleni>();
            Predmeti = new List<Predmet>();
        }
        public void DodajStudenta(Student student)
        {
            if (!Studenti.Exists(s => s.BrojIndeksa == student.BrojIndeksa))
                Studenti.Add(student);
            else
                throw new Exception("Student je vec upisan!");
        }
        public List<Student> Studenti
        {
            get { return studenti; }
            set { studenti = value; }
        }
        public void DodajZaposlenog(Zaposleni uposlenik)
        {
            if (!Zaposleni.Exists(z => z.SifraZaposlenog == uposlenik.SifraZaposlenog))
                Zaposleni.Add(uposlenik);
            else
                throw new Exception("Dati zaposlenik vec radi u ovoj ustanovi!");
        }
        public List<Zaposleni> Zaposleni
        {
            get { return zaposleni; }
            set { zaposleni = value; }
        }
        public void DodajPredmet(Predmet noviPredmet)
        {
            if(!Predmeti.Exists(p => p.SifraPredmeta == noviPredmet.SifraPredmeta))
                Predmeti.Add(noviPredmet);
            else
                throw new Exception("Predmet vec unesen!");
        }
        public List<Predmet> Predmeti
        {
            get { return predmeti; }
            set { predmeti = value; }
        }
        public String ImeFakulteta
        {
            get { return imeFakulteta; }
            set { imeFakulteta = value; }
        }

        //funkcija vraca sve polozene predmete nekog studenta koji se proslijedi kao parametar funkciji
        public List<Predmet> PolozeniPredmeti(Student student)
        {
            List<Predmet> polozeni = new List<Predmet>();
            foreach (var sifra in student.PolozeniPredmeti)
            {
                polozeni.Add(Predmeti.Single(predmet => predmet.SifraPredmeta == sifra));
            }
            return polozeni;
        }

        //Pronadji po indeksu-sifri
        public Student pronadjiStudentaPoBrojuIndeksa(uint brojIndeksaTrazi)
        {   //provjerit da li ikako ima student
            //da nece bacit izuzetak
            return Studenti.Single(student => student.BrojIndeksa == brojIndeksaTrazi);
        }
        public Predmet pronadjiPredmetPoSifri(int sifra)
        {
            return Predmeti.Single(predmet => predmet.SifraPredmeta == sifra);
        }
        public Zaposleni pronadjiZaposlenogPoSifri(int sifra)
        {
            return Zaposleni.Single(radnik => radnik.SifraZaposlenog == sifra);
        }
        //Pronadji po nazivu
        public List<Student> PronadjiPoNazivuStudenta(String ime, String prezime)
        {
            return Studenti.FindAll(student => student.Ime == ime && student.Prezime == prezime);
        }
        public List<Predmet> PronadjiPoNazivuPredmeta(String imePredmeta)
        {
            return Predmeti.FindAll(predmet => predmet.NazivPredmeta == imePredmeta);
        }
        public List<Zaposleni> PronadjiPoNazivuZaposlenog(String ime, String prezime)
        {
            return Zaposleni.FindAll(radnik => radnik.Ime == ime && radnik.Prezime == prezime);
        }
        public List<Predmet> PronadjiPredmetPoKljucnojRijeci(String kljucnaRijec)
        {
            return Predmeti.FindAll(p => p.NazivPredmeta == kljucnaRijec || p.StudijKojemPripadaju == kljucnaRijec || p.NastavniAnsamblPredmeta[0].Ime == kljucnaRijec || p.NastavniAnsamblPredmeta[0].Prezime == kljucnaRijec);
        }
        public List<Student> PronadjiStudentaPoKljucnojRijeci(String kljucnaRijec)
        {
            return Studenti.FindAll(s => s.Ime == kljucnaRijec || s.Prezime == kljucnaRijec || s.MaticniBroj == kljucnaRijec);
        }
        public List<Zaposleni> PronadjiZaposlenogPoKljucnojRijeci(String kljucnaRijec)
        {
            return Zaposleni.FindAll(z => z.Ime == kljucnaRijec || z.Prezime == kljucnaRijec || z.MaticniBroj == kljucnaRijec || (z as NastavnoOsoblje).Predmeti.Exists(p => Predmeti.Exists(t => t.SifraPredmeta == p && t.NazivPredmeta == kljucnaRijec)));
        }
        //prosjek plate
        public double ProsjekPlate()
        {
            return Zaposleni.Average(radnici => radnici.Plata);
        }
        //ispod prosjeka plate
        public List<Zaposleni> IspodProsjekaPlate()
        {
            double prosjek = ProsjekPlate();
            List<Zaposleni> povratni = new List<Zaposleni>();
            foreach (var radnik in Zaposleni)
            {
                if (radnik.Plata < prosjek)
                    povratni.Add(radnik);
            }
            return povratni;
        }
        //iznad prosjeka plate
        public List<Zaposleni> IznadProsjekaPlate()
        {
            double prosjek = ProsjekPlate();
            List<Zaposleni> povratni = new List<Zaposleni>();
            foreach (var radnik in Zaposleni)
            {
                if (radnik.Plata > prosjek)
                    povratni.Add(radnik);
            }
            return povratni;
        }
        //dodavanje novog predmeta nekom studentu
        public void DodajPredmetStudentu(Student student,Predmet predmet)
        {
            //provjeriti sa asistentom ispravnost ili eventualne ispravke i poboljsanja
            if (!Predmeti.Exists(p => p.SifraPredmeta == predmet.SifraPredmeta))
                throw new Exception("Ne postoji dati predmet!");
            else if (!Studenti.Exists(s => s.BrojIndeksa==student.BrojIndeksa))
                throw new Exception("Student se ne nalazi na ovom fakultetu!");

            int i = Studenti.IndexOf(Studenti.Single(s => s.BrojIndeksa==student.BrojIndeksa));

            if (Studenti[i].TrenutniPredmeti.Exists(p => p == predmet.SifraPredmeta) || Studenti[i].PolozeniPredmeti.Exists(p => p == predmet.SifraPredmeta)) // provjerit ovaj uslov
                    throw new Exception("Student je vec upisan na ovaj predmet!");

            Studenti[i].DodajPredmet(predmet.SifraPredmeta); 
        }
        //dodavanje novog predmeta profesoru
        public void DodajPredmetProfesoru(NastavnoOsoblje prof,Predmet predmet)
        {
            if(!Predmeti.Exists(p => p.SifraPredmeta == predmet.SifraPredmeta))
            {
                Predmeti.Add(predmet);
            }
            try
            {   //provjeriti da li je ispravna dodjela,iz razloga sto je Zaposleni tip Zaposleni
                int i = Zaposleni.IndexOf(Zaposleni.Single(p => p.SifraZaposlenog == prof.SifraZaposlenog));
                NastavnoOsoblje pomocni = Zaposleni[i] as NastavnoOsoblje;
                pomocni.DodajPredmet(predmet);
                Zaposleni[i] = pomocni;
                int j = Predmeti.IndexOf(Predmeti.Single(p => p.SifraPredmeta == predmet.SifraPredmeta));
                Predmeti[j].NastavniAnsamblPredmeta[0] = Zaposleni[i] as NastavnoOsoblje;
            }
            catch
            {
                throw new Exception("Dati zaposleni ne radi u zadanoj ustanovi!");
            }
            
        }
    }
}
