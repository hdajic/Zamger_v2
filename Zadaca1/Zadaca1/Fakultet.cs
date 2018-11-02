using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1
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
            Studenti.Add(student);
        }
        public List<Student> Studenti
        {
            get { return studenti; }
            set { studenti = value; }
        }
        public void DodajZaposlenog(Zaposleni uposlenik)
        {
            Zaposleni.Add(uposlenik);
        }
        public List<Zaposleni> Zaposleni
        {
            get { return zaposleni; }
            set { zaposleni = value; }
        }
       public void DodajPredmet(Predmet noviPredmet)
        {
            Predmeti.Add(noviPredmet);
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
        //Pronadji po indeksu-sifri
        public Student pronadjiStudentaPoBrojuIndeksa(uint brojIndeksaTrazi)
        {
            return Studenti.Single(student => student.BrojIndeksa == brojIndeksaTrazi);
        }
        public Predmet pronadjiPredmetPoSifri(int sifra)
        {
            return Predmeti.Single(predmet => predmet.SifraPredmeta==sifra);
        }
        public Zaposleni pronadjiZaposlenogPoSifri(int sifra)
        {
            return Zaposleni.Single(radnik => radnik.SifraZaposlenog == sifra);
        }
        //Pronadji po nazivu
        public List<Student> PronadjiPoNazivuStudenta(String ime,String prezime)
        {
            return Studenti.FindAll(student => student.Ime == ime && student.Prezime==prezime);
        }
        public List<Predmet> PronadjiPoNazivuPredmeta(String imePredmeta)
        {
            return Predmeti.FindAll(predmet => predmet.NazivPredmeta == imePredmeta);
        }
        public List<Zaposleni> PronadjiPoNazivuZaposlenog(String ime,String prezime)
        {
            return Zaposleni.FindAll(radnik => radnik.Ime == ime && radnik.Prezime == prezime);
        }
        //prosjek plate
        public double ProsjekPlate()
        {
            return Zaposleni.Average(radnici => radnici.Plata);
        }
        //ispod prosjeka plate
        public void PrikaziIspodProsjekaPlate()
        {
            double prosjek = ProsjekPlate();
            foreach (var radnik in Zaposleni)
            {
                if (radnik.Plata < prosjek)
                    Console.WriteLine("{0}", radnik.ToString());
            }
        }
        //iznad prosjeka plate
        public void PrikaziIznadProsjekaPlate()
        {
            double prosjek = ProsjekPlate();
            foreach (var radnik in Zaposleni)
            {
                if (radnik.Plata > prosjek)
                    Console.WriteLine("{0}", radnik.ToString());
            }
        }
    }
}
