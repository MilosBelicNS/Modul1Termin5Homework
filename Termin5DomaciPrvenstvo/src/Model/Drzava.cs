using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin5DomaciPrvenstvo.src.Model
{
    class Drzava
    {

        public static int BrojacId { get; set; }
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string GlavniGrad { get; set; }


        public Dictionary<int, SvetskoPrvenstvo> SvetskaPrvenstva { get; set; }


        //staticki konstruktor
        static Drzava()
        {
            BrojacId = 0;
        }
        //konstruktor bez parametara
        public Drzava()
        {
            SvetskaPrvenstva = new Dictionary<int, SvetskoPrvenstvo>();
        }

        //konstruktor sa parametrima
        public Drzava(string naziv, string glavniGrad, int id= -1):this()
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
            this.GlavniGrad = glavniGrad;
            
        }

        //metoda koja kreira klasu na osnovu tekstualne reprezentacije iz datoteke
        public static Drzava FromFileToObject(string tekst)
        {
            string[] tokeni = tekst.Split(',');

            if(tokeni.Length !=3)
            {
                Console.WriteLine("Greska pri ocitavanju drzava " + tekst);
                Environment.Exit(0);
            }
            int idParam = Int32.Parse(tokeni[0]);
            string nazivParam = tokeni[1];
            string glavniGradParam = tokeni[2];
            return new Drzava(nazivParam, glavniGradParam, idParam);
        }

        public override string ToString()
        {
            return   Naziv + "-" + GlavniGrad;
        }

        public string ToFileString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Id + ", " + Naziv + ", " + GlavniGrad);
                return sb.ToString();
        }

       

         public override bool Equals(object obj)
        {
           if(obj == null || !(obj is Drzava))
            
                return false;
                Drzava d = (Drzava)obj;
                return this.Id == d.Id;
            


        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ Naziv.GetHashCode();
        }


    }
}
