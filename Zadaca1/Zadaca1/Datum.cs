using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1
{
    //Klasa datum,posjeduje konstruktor,operatore poredjenja
    //u konstruktoru nismo provjeravali da li su uneseni brojevi ispravni
    //u klasi su implementirane metode ==,!=,<,>
   public class Datum
    {
        private int dan;
        private int mjesec;
        private int godina;
        public Datum(int noviDan,int noviMjesec,int novaGodina)
        {
            if (noviDan < 0 || noviDan > 31 || noviMjesec < 0 || noviMjesec > 12 || godina < 0)
                throw new Exception("Neispravan datum");
            dan = noviDan;
            mjesec = noviMjesec;
            godina = novaGodina;
        }
        public static bool operator>(Datum datum1,Datum datum2)
        {
            if (datum1.godina < datum2.godina)
                return true;
            else if(datum1.godina==datum2.godina)
            {
                if (datum1.mjesec < datum2.mjesec)
                    return true;
                else if(datum1.mjesec==datum2.mjesec)
                {
                    if (datum1.dan < datum2.dan)
                        return true;
                }
            }
            return false;
        }
        public static bool operator<(Datum datum1,Datum datum2)
        {
            return !(datum1 > datum2) && datum1!=datum2;
        }
        public static bool operator==(Datum datum1,Datum datum2)
        {
            if (datum1.godina == datum2.godina && datum1.mjesec == datum2.mjesec && datum1.dan == datum2.dan)
                return true;
            return false;
        }
        public static  bool operator!=(Datum datum1,Datum datum2)
        {
            return !(datum1 == datum2);
        }
        public int Dan
        {
            get;
            private set;
        }
        public int Mjesec
        {
            get;
            private set;
        }
        public int Godinu
        {
            get;
            private set;
        }
        //uradjena zbog provjere maticnog broja
        public override string ToString()
        {
            String datumUString="";
            if (dan < 10)
                datumUString += "0" + dan.ToString();
            else datumUString += dan.ToString();
            if (mjesec < 10)
                datumUString += "0" + mjesec.ToString();
            else datumUString += mjesec.ToString();
            int broj = godina % 1000;
            if (broj < 100 && broj > 10)
                datumUString += "0";
            else if (broj < 10)
                datumUString += "00";
            datumUString += broj.ToString();
            return datumUString;
        }
        public String Ispisi()
        {
            return dan.ToString() + "/" + mjesec.ToString() + "/" + godina.ToString();
        } 
        public static Datum DajTrenutnoVrijeme()
        {
            DateTime trenutno = DateTime.Now;
            Datum novo= new Datum(trenutno.Day,trenutno.Month,trenutno.Year);
            return novo;
        }
        public void UnosDatuma()
        {
            Console.Write("Unesite dan: ");
            String broj=Console.ReadLine();
            Int32.TryParse(broj, out dan);
            Console.Write("Unesite mjesec: ");
            broj = Console.ReadLine();
            Int32.TryParse(broj, out mjesec);
            Console.Write("Unesite godinu: ");
            broj = Console.ReadLine();
            Int32.TryParse(broj, out godina);
        }
    }
}
