using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termin5DomaciPrvenstvo.src.UI;

namespace Termin5DomaciPrvenstvo.src.Model
{
    class SvetskoPrvenstvo
    {

        public static int BrojacId { get; set; }
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int GodinaOdrzavanja { get; set; }
        public Drzava DrzavaDomacin { get; set; }

        //KONSTRUKTORI

        //staticki konstruktor
        static SvetskoPrvenstvo()
        {
            BrojacId = 0;

        }

        public SvetskoPrvenstvo()
        {

        }

        public SvetskoPrvenstvo( string naziv, int godinaOdrzavanja, Drzava drzavaDomacin, int id = -1)
        {
            if(id == -1)
            {
                this.Id = BrojacId++;

            }else if(id >= BrojacId)
            {
                this.Id = id;
                BrojacId = ++id;
            }
            this.Naziv = naziv;
            this.GodinaOdrzavanja = godinaOdrzavanja;
            this.DrzavaDomacin = drzavaDomacin;

        }

        //motode

        public static SvetskoPrvenstvo FromFileToObject(string tekst)
        {
            string[] tokeni = tekst.Split(',');


            if (tokeni.Length != 4)
            {
                Console.WriteLine("Greska pri ocitavanju nastavnika " + tekst);
                //izlazak iz aplikacije
                Environment.Exit(0);
            }

            int idParam = Int32.Parse(tokeni[0]);
            string naziv = tokeni[1];
            int godinaOdrzavanja = Int32.Parse(tokeni[2]);
            int idDrzavaDomacin = Int32.Parse(tokeni[3]);

            //UBACI METODU PRONADJI DRZAVU PO ID
            Drzava d = DrzavaUI.PronadjiDrzavuPoId(idDrzavaDomacin);
            return new SvetskoPrvenstvo(naziv, godinaOdrzavanja, d,idParam);
        }

        public override string ToString()
        {
            return  Naziv + "-" + GodinaOdrzavanja + ", " + DrzavaDomacin;
        }

        public string ToFileString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Id + ", " + Naziv + ", " + GodinaOdrzavanja + ", "+ DrzavaDomacin.Id);
            return sb.ToString();
        }


        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is SvetskoPrvenstvo))

                return false;
            SvetskoPrvenstvo sp = (SvetskoPrvenstvo)obj;
            return this.Id == sp.Id;



        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ Naziv.GetHashCode();
        }
    }
}
