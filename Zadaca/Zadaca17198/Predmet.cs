using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca17198
{
    public class Predmet
    {
        private static int sifra = 1;
        private int sifraPredmeta;
        private String nazivPredmeta;
        private String studijKojemPripadaju;
        private uint brojCasovaPredavanja;
        private uint brojCasovaVjezbi;
        private int kapacitetStudenata;
        private int bodoviECTS;
        private List<NastavnoOsoblje> nastavniAnsamblPredmeta; // prvi u ovoj listi uvijek mora biti profesor zbog pretrage u klasi fakultet
        private String kratkiOpisPredmeta;

        public String generalneInformacije()
        {
            return NazivPredmeta + " " + StudijKojemPripadaju + " " + BrojCasovaPredavanja.ToString() + " " + BrojCasovaVjezbi.ToString() + " " + BodoviECTS.ToString();
        }
        public List<NastavnoOsoblje> nastavniAnsambl()
        {
            return NastavniAnsamblPredmeta;
        }
        public uint ECTSuSate()
        {
            return BrojCasovaPredavanja + BrojCasovaVjezbi;
        }
        public Predmet(String imePredmeta, String studijKojemPredmetPripada, uint brojCasovaPredmetaPredavanja, uint brojCasovaPredmetaVjezbi, int kapacitetStudenataPredmeta, int brojECTSbodova)
        {
            NazivPredmeta = imePredmeta;
            StudijKojemPripadaju = studijKojemPredmetPripada;
            BrojCasovaPredavanja = brojCasovaPredmetaPredavanja;
            BrojCasovaVjezbi = brojCasovaPredmetaVjezbi;
            KapacitetStudenata = kapacitetStudenataPredmeta;
            BodoviECTS = brojECTSbodova;
            SifraPredmeta = sifra;
            sifra++;
        }
        public override String ToString()
        {
            return "Sifra predmeta je: " + SifraPredmeta.ToString() + "\n" + "Naziva predmeta: " + NazivPredmeta.ToString() + "\nStudij kojem pripada: " + StudijKojemPripadaju.ToString();
        }
        public int SifraPredmeta
        {
            get { return sifraPredmeta; }
            set { sifraPredmeta = value; }
        }
        public String NazivPredmeta
        {
            get { return nazivPredmeta; }
            set { nazivPredmeta = value; }
        }
        public String StudijKojemPripadaju
        {
            get { return studijKojemPripadaju; }
            set { studijKojemPripadaju = value; }
        }
        public int BodoviECTS
        {
            get { return bodoviECTS; }
            set { bodoviECTS = value; }
        }
        public uint BrojCasovaPredavanja
        {
            get { return brojCasovaPredavanja; }
            set { brojCasovaPredavanja = value; }
        }
        public uint BrojCasovaVjezbi
        {
            get { return brojCasovaVjezbi; }
            set { brojCasovaVjezbi = value; }
        }
        public int KapacitetStudenata
        {
            get { return kapacitetStudenata; }
            set { kapacitetStudenata = value; }
        }
        public String KratkiOpisPredmeta
        {
            get { return kratkiOpisPredmeta; }
            set { kratkiOpisPredmeta = value; }
        }
        public List<NastavnoOsoblje> NastavniAnsamblPredmeta
        {
            get { return nastavniAnsamblPredmeta; }
            set { nastavniAnsamblPredmeta = value; }
        }
    }
}
