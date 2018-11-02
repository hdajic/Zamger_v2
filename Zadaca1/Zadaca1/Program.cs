using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1
{
    class Program
    {
        //delegati za studente
        delegate Student DelegatZaStudente(uint brojIndeksa);
        delegate List<Student> DelegatZaStudenteImePrezime(String ime, String prezime);
        //delegati za predmete
        delegate Predmet DelegatZaPredmete(int sifraPredmeta);
        delegate List<Predmet> DelegatZaPredmeteNaziv(String nazivPredmeta);
        //delegati za zaposlene
        delegate Zaposleni DelegatZaZaposlene(int sifraZaposlenog);
        delegate List<Zaposleni> DelegatiZaZaposleneImePrezime(String ime, String prezime);

        static void Main(string[] args)
        {
              Console.Write("Unesite ime fakulteta: ");
              String ime = Console.ReadLine();
              Fakultet fakultet = new Fakultet(ime);
              int broj = 0;
            do
            {
                broj = 0;  
                Console.WriteLine("Dobro dosli na >> {0} <<!\nOdaberite jednu od opcija:\n1.Registruj/Brisi studenta\n2.Registruj/Brisi predmet\n3.Registruj/Brisi uposlenog\n4.Pretraga\n5.Analiza sadrzaja\n6.Izlaz", ime);
                ProvjeraUnosa6Broja(ref broj);
                if (broj == 1)
                {
                    int noviBroj = 0;
                    Console.Write("1-za registrovanje\n2-za brisanje\nUnesite: ");
                    ProvjeraUnosa(ref noviBroj);
                    if (noviBroj == 1)
                    {
                        int josJedanBroj = 0;
                        Student student = new Student();
                        Console.Write("1-za bachelor studenta\n2-za dodavanje mastar studenta\n3-za dodavanje studenta master studija sa drugog fakulteta\nUnesite: ");
                        ProvjeraUnosa3Broja(ref josJedanBroj);
                        if (josJedanBroj == 1)
                        {
                            try
                            {
                                student = UnosStudenta();
                                fakultet.DodajStudenta(student);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message + "\nMolimo pokusajte ponovno!\n");
                            }
                        }
                        else if (josJedanBroj == 2)
                        {
                            Console.Write("Unesite ime studenta za master studij: ");
                            String imeStudenta = Console.ReadLine();
                            Console.Write("Unesite prezime studenta: ");
                            String prezimeStudenta = Console.ReadLine();
                            Console.Write("Unesite maticni broj studenta: ");
                            String maticniBroj = Console.ReadLine();
                            List<Student> master = fakultet.PronadjiPoNazivuStudenta(imeStudenta, prezimeStudenta);
                            Student pronadjeniStudent = master.Single(element => element.MaticniBroj == maticniBroj);
                            student = new MasterStudent(pronadjeniStudent);
                            fakultet.Studenti[fakultet.Studenti.FindIndex(stud => stud.Ime == imeStudenta && stud.Prezime == prezimeStudenta && stud.MaticniBroj == maticniBroj)] = student;
                        }
                        else if (josJedanBroj == 3)
                        {
                            try
                            {
                                student = UnosMasterStudenta();
                                fakultet.Studenti.Add(student);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("{0}\n", e.Message);
                            }
                        }
                    }
                    else if (noviBroj == 2)
                    {
                        Console.Write("Unesite ime studenta za brisanje: ");
                        String imeStudenta = Console.ReadLine();
                        Console.Write("Unesite prezime studenta: ");
                        String prezimeStudenta = Console.ReadLine();
                        Console.Write("Unesite maticni broj studenta: ");
                        String maticniBroj = Console.ReadLine();
                        try
                        {
                            Student brisi = fakultet.Studenti.Single(element => element.Ime == imeStudenta && element.Prezime == prezimeStudenta && element.MaticniBroj == maticniBroj);
                            fakultet.Studenti.Remove(brisi);
                        }
                        catch
                        {
                            Console.WriteLine("Nema studenta pod datim imenom za brisanje!\n");
                        }
                    }

                }
                else if (broj == 2)
                {
                    int noviBroj = 0;
                    Console.Write("1-za registrovanje\n2-za brisanje\nUnesite: ");
                    ProvjeraUnosa(ref noviBroj);
                    if (noviBroj == 1)
                    {
                        try
                        {
                            Predmet noviPredmet = DodajPredmet();
                            fakultet.Predmeti.Add(noviPredmet);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("{0}\nMolimo pokusajte ponovno!\n", e.Message);
                        }
                    }
                    else
                    {
                        Console.Write("Unesite naziv predmeta kojeg zelite izbrisati: ");
                        String nazivPredmeta = Console.ReadLine();
                        Console.Write("Unesite studij kojem pripadaju: ");
                        String studijKojemPripadaju = Console.ReadLine();
                        try
                        {
                            Predmet brisi = fakultet.Predmeti.Single(element => element.NazivPredmeta == nazivPredmeta && element.StudijKojemPripadaju == studijKojemPripadaju);
                            fakultet.Predmeti.Remove(brisi);
                        }
                        catch
                        {
                            Console.WriteLine("Ne postoji predmet pod datim nazivom za brisanje!\n");
                        }
                    }
                }
                else if (broj == 3)
                {
                    int noviBroj = 0;
                    Console.Write("1-za registrovanje\n2-za brisanje\nUnesite: ");
                    ProvjeraUnosa(ref noviBroj);
                    if (noviBroj == 1)
                    {
                        int josJedanBroj = 0;
                        Console.Write("1-za unos stalnog radnika\n2-za unos radnika na odredjeno\nUnesite: ");
                        ProvjeraUnosa(ref josJedanBroj);
                        int ovoJeVecPrevise = 0;
                        if (josJedanBroj == 1)
                        {
                            Console.Write("1-za unos nastavnog osobolja\n2-za unos nenastavnog osoblja\nUnesite: ");
                            ProvjeraUnosa(ref ovoJeVecPrevise);
                        }
                        Console.Write("Unesite ime radnika: ");
                        String imeRadnika = Console.ReadLine();
                        Console.Write("Unesite prezime radnika: ");
                        String prezimeRadnika = Console.ReadLine();
                        Console.WriteLine("Unesite datum rodjenja radnika.");
                        Datum datRodj = new Datum(0, 0, 0);
                        datRodj.UnosDatuma();
                        Console.Write("Unesite maticni broj: ");
                        String matBroj = Console.ReadLine();
                        if (josJedanBroj == 1)
                        {

                            Console.Write("Unesite poziciju zaposlenog: ");
                            String pozicija = Console.ReadLine();
                            Console.Write("Unesite strucnu spremu zaposlenog: ");
                            String strucnaSprema = Console.ReadLine();
                            Console.Write("Unesite titulu zaposlenog: ");
                            String titula = Console.ReadLine();
                            if (ovoJeVecPrevise == 1)
                            {
                                Console.Write("Unesite broj predmeta zaposlenog: ");
                                String brojPred = Console.ReadLine();
                                int brojPredmeta;
                                Int32.TryParse(brojPred, out brojPredmeta);
                                try
                                {
                                    Zaposleni radnik = new NastavnoOsoblje(imeRadnika, prezimeRadnika, datRodj, matBroj, pozicija, strucnaSprema, titula, brojPredmeta);
                                    fakultet.Zaposleni.Add(radnik);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("{0}\nMolim pokusajte ponovo!\n", e.Message);
                                }
                            }
                            else
                            {
                                try
                                {
                                    Zaposleni radnik = new NenastavnoOsoblje(imeRadnika, prezimeRadnika, datRodj, matBroj, pozicija, strucnaSprema, titula);
                                    fakultet.Zaposleni.Add(radnik);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("{0}\nMolimo pokusajte ponovno!\n", e.Message);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Unesite datum pocetka ugovora: ");
                            Datum pocetak = new Datum(0, 0, 0);
                            pocetak.UnosDatuma();
                            Console.WriteLine("Unesite datum kraja ugovora: ");
                            Datum kraj = new Datum(0, 0, 0);
                            kraj.UnosDatuma();
                            try
                            {
                                Zaposleni radnik = new PrivremenoZaposleni(imeRadnika, prezimeRadnika, datRodj, matBroj, pocetak, kraj);
                                fakultet.Zaposleni.Add(radnik);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message + "\nMolimo pokusajte ponovo!\n");
                            }
                        }

                    }
                    else
                    {
                        Console.Write("Unesite ime zaposlenog za brisanje: ");
                        String imeRadnika = Console.ReadLine();
                        Console.Write("Unesite prezime: ");
                        String prezime = Console.ReadLine();
                        Console.Write("Unesite maticni broj: ");
                        String maticniBroj = Console.ReadLine();
                        try
                        {
                            var prviNadjeni = fakultet.Zaposleni.Single(radnik => radnik.Ime == imeRadnika && radnik.Prezime == prezime && radnik.MaticniBroj == maticniBroj);
                            fakultet.Zaposleni.Remove(prviNadjeni);
                        }
                        catch
                        {
                            Console.WriteLine("Radnik sa unesenim podacima ne radi na ovom fakultetu!\n");
                        }
                    }
                }
                else if (broj == 4)
                {
                    Console.Write("1-po sifri/broju indeksa\n2-po nazivu\nUnesite koju pretragu zelite: ");
                    int josJedanBroj = 0;
                    ProvjeraUnosa(ref josJedanBroj);
                    if (josJedanBroj == 1)
                    {
                        Console.Write("1-studente\n2-predmete\n3-zaposlene\nUnesite sta pretrazujete: ");
                        int OvoJeVecPrevise = 0;
                        ProvjeraUnosa3Broja(ref OvoJeVecPrevise);
                        if (OvoJeVecPrevise == 1)
                        {
                            Console.Write("Unesite broj indeksa: ");
                            String indeks = Console.ReadLine();
                            uint brojIndeksa = 0;
                            UInt32.TryParse(indeks, out brojIndeksa);
                            DelegatZaStudente nadjiStudenta;
                            nadjiStudenta = new DelegatZaStudente(fakultet.pronadjiStudentaPoBrojuIndeksa);
                            try
                            {
                                Console.WriteLine();
                                Console.WriteLine("{0}", nadjiStudenta(brojIndeksa).ToString());
                                Console.WriteLine();
                            }
                            catch
                            {
                                Console.WriteLine("Ne postoji strudent sa unesenim indeksom!\n");
                            }
                        }
                        else if (OvoJeVecPrevise == 2)
                        {
                            Console.Write("Unesite sifru predmeta: ");
                            String sifraPred = Console.ReadLine();
                            int sifraPredmeta = 0;
                            Int32.TryParse(sifraPred, out sifraPredmeta);
                            DelegatZaPredmete nadjiPredmet;
                            nadjiPredmet = new DelegatZaPredmete(fakultet.pronadjiPredmetPoSifri);
                            try
                            {
                                Console.WriteLine();
                                Console.WriteLine("{0}", nadjiPredmet(sifraPredmeta).ToString());
                                Console.WriteLine();
                            }
                            catch
                            {
                                Console.WriteLine("Ne postoji predmet sa datom sifrom!\n");
                            }
                        }
                        else
                        {
                            Console.Write("Unesite sifru zaposlenog: ");
                            String sifraZap = Console.ReadLine();
                            int sifraZaposlenog = 0;
                            Int32.TryParse(sifraZap, out sifraZaposlenog);
                            DelegatZaZaposlene nadjiZaposlenog;
                            nadjiZaposlenog = new DelegatZaZaposlene(fakultet.pronadjiZaposlenogPoSifri);
                            try
                            {
                                Console.WriteLine();
                                Console.WriteLine("{0}", nadjiZaposlenog(sifraZaposlenog).ToString());
                                Console.WriteLine();
                            }
                            catch
                            {
                                Console.WriteLine("Ne postoji zaposleni sa datom sifrom!\n");
                            }
                        }
                    }
                    else
                    {
                        Console.Write("1-studente\n2-predmete\n3-zaposlene\nUnesite sta pretrazujete: ");
                        int OvoJeVecPrevise = 0;
                        ProvjeraUnosa3Broja(ref OvoJeVecPrevise);
                        if (OvoJeVecPrevise == 1)
                        {
                            Console.Write("Unesite ime studenta za pretrazivanje: ");
                            String imeStud = Console.ReadLine();
                            Console.Write("Unesite prezime studenta: ");
                            String prezimeStud = Console.ReadLine();
                            DelegatZaStudenteImePrezime funkcijaPretrazi;
                            funkcijaPretrazi = new DelegatZaStudenteImePrezime(fakultet.PronadjiPoNazivuStudenta);
                            try
                            {
                                List<Student> nadjeni = funkcijaPretrazi(imeStud, prezimeStud);
                                Console.WriteLine();
                                foreach (var stud in nadjeni)
                                {
                                    Console.WriteLine("{0}", stud.ToString());
                                    Console.WriteLine();
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Ne postoji nijedan student sa datim imenom i prezimenom!\n");
                            }
                        }
                        else if (OvoJeVecPrevise == 2)
                        {
                            Console.Write("Unesite naziv predmeta za pretrazivanje: ");
                            String nazivPred = Console.ReadLine();
                            DelegatZaPredmeteNaziv nadjiPredmet;
                            nadjiPredmet = new DelegatZaPredmeteNaziv(fakultet.PronadjiPoNazivuPredmeta);
                            try
                            {
                                List<Predmet> nadjeni = nadjiPredmet(nazivPred);
                                Console.WriteLine();
                                foreach (var predmet in nadjeni)
                                {
                                    Console.WriteLine("{0}", predmet.ToString());
                                    Console.WriteLine();
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Ne postoji predmet sa datim nazivom!\n");
                            }
                        }
                        else
                        {
                            Console.Write("Unesite ime zaposlenog za pretrazivanje: ");
                            String imeZap = Console.ReadLine();
                            Console.Write("Unesite prezime zaposlenog: ");
                            String prezimeZap = Console.ReadLine();
                            DelegatiZaZaposleneImePrezime nadjiZaposlenog;
                            nadjiZaposlenog = new DelegatiZaZaposleneImePrezime(fakultet.PronadjiPoNazivuZaposlenog);
                            try
                            {
                                List<Zaposleni> nadjeni = nadjiZaposlenog(imeZap, prezimeZap);
                                Console.WriteLine();
                                foreach (var zaposleni in nadjeni)
                                {
                                    Console.WriteLine("{0}", zaposleni.ToString());
                                    Console.WriteLine();
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Ne postoji radnik sa datim imenom i prezimenom!\n");
                            }
                        }
                    }
                }
                else if (broj == 5)
                {
                    int i = 0;

                    foreach (var studenti in fakultet.Studenti)
                    {
                        if (i == 0)
                            Console.WriteLine("Spisak studenata: ");
                        Console.WriteLine("{0}", studenti.ToString());
                        Console.WriteLine();
                        i++;
                    }
                    i = 0;
                    foreach (var predmet in fakultet.Predmeti)
                    {
                        if (i == 0)
                            Console.WriteLine("Spisak predmeta: ");
                        Console.WriteLine("{0}", predmet.ToString());
                        Console.WriteLine();
                        i++;
                    }
                    i = 0;
                    foreach (var radnici in fakultet.Zaposleni)
                    {
                        if (i == 0) Console.WriteLine("Spisak radnog osoblja: ");
                        Console.WriteLine("{0}", radnici.ToString());
                        Console.WriteLine();
                        i++;
                    }
                }
                else
                {
                    Console.WriteLine("Drago nam je sto ste korsitili nase usluge.\nPrijatno!");
                }
            } while (broj != 6);
          }
          public static void ProvjeraUnosa(ref int  broj)
          {
              while (broj != 1 && broj != 2)
              {
                  String unos = Console.ReadLine();
                  Int32.TryParse(unos, out broj);
                  if (broj != 1 && broj != 2) Console.WriteLine("Pogresan unos.Molimo odaberite ponovo!");
              }

          }
          public static void ProvjeraUnosa3Broja(ref int broj)
          {
              while(broj!=1 && broj!=2 && broj!=3)
              {
                  String unos = Console.ReadLine();
                  Int32.TryParse(unos, out broj);
                  if (broj != 1 && broj != 2 && broj!=3) Console.WriteLine("Pogresan unos.Molimo odaberite ponovo!");
              }
          }
          public static void ProvjeraUnosa6Broja(ref int broj)
          {
              while (broj != 1 && broj != 2 && broj != 3 && broj!=4 && broj!=5 && broj!=6)
              {
                  String unos = Console.ReadLine();
                  Int32.TryParse(unos, out broj);
                  if (broj != 1 && broj != 2 && broj != 3 && broj!=4 && broj!=5 && broj!=6) Console.WriteLine("Pogresan unos.Molimo odaberite ponovo!");
              }
          }
          public static Student UnosStudenta()
          {
              String ime = "";
              String prezime ="";
              Datum datumRodjenja = new Datum(0, 0, 0);
              Datum predZavObr=new Datum(0,0,0);
              Console.Write("Unesite ime studenta: ");
              ime = Console.ReadLine();
              Console.Write("Unesite prezime studenta: ");
              prezime = Console.ReadLine();
              Console.WriteLine("Unesite datum rodjenja.");
              datumRodjenja.UnosDatuma();
              Console.Write("Unesite maticni broj: ");
              String maticniBroj = Console.ReadLine();
              Console.WriteLine("Unesite datum prethodno zavrsenog obrazovanja.");
              predZavObr.UnosDatuma();
              return new Student(ime, prezime, datumRodjenja, maticniBroj,predZavObr);
          }
          public static MasterStudent UnosMasterStudenta()
          {
            String ime = "";
            String prezime = "";
            Datum datumRodjenja = new Datum(0, 0, 0);
            Datum pretZavObr = new Datum(0, 0, 0);
            Console.Write("Unesite ime studenta: ");
            ime = Console.ReadLine();
            Console.Write("Unesite prezime studenta: ");
            prezime = Console.ReadLine();
            Console.WriteLine("Unesite datum rodjenja.");
            datumRodjenja.UnosDatuma();
            Console.Write("Unesite maticni broj: ");
            String maticniBroj = Console.ReadLine();
            Console.WriteLine("Unesite datum prethodno zavrsenog obrazovanja.");
            pretZavObr.UnosDatuma();
            Datum datZav=new Datum(0,0,0);
            Console.WriteLine("Unesite datum zavrsenja bachelor studija.");
            datZav.UnosDatuma();
            MasterStudent masterStudent = new MasterStudent(ime, prezime, datumRodjenja, maticniBroj,pretZavObr, datZav);
            return masterStudent;
          }
          public static Predmet DodajPredmet()
          {
              Console.Write("Unesite naziv predmeta: ");
              String nazivPredmeta = Console.ReadLine();
              Console.Write("Unesite kojem studiju pripadaju: ");
              String studijKojemPripadaju = Console.ReadLine();
              Console.Write("Unesite broj casova predavanja: ");
              String broj = Console.ReadLine();
              uint brojCasova;
              UInt32.TryParse(broj, out brojCasova);
              Console.Write("Unesite broj casova vjezbi: ");
              broj = Console.ReadLine();
              uint brojVjezbi;
              UInt32.TryParse(broj, out brojVjezbi);
              Console.Write("Unesite kapacitet studenata na predmetu: ");
              broj = Console.ReadLine();
              int kapacitetStudenata;
              Int32.TryParse(broj, out kapacitetStudenata);
              Console.Write("Unesite broj ECTS bodova: ");
              broj = Console.ReadLine();
              int brojECTS;
              Int32.TryParse(broj, out brojECTS);
              return new Predmet(nazivPredmeta, studijKojemPripadaju, brojCasova, brojVjezbi, kapacitetStudenata, brojECTS);
         } 
        }
}
