using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin5DomaciPrvenstvo.src.Utils
{
    class IOPomocnaKlasa
    {
        public static int OcitajCeoBroj()
        {
            int broj;
            while (Int32.TryParse(Console.ReadLine(), out broj) == false)
            {
                Console.Write("GRESKA - Pogresno unsesena vrednost, pokusajte ponovo: ");
            }
            return broj;
        }

        public static string OcitajTekst()
        {
            string tekst = "";
            while (tekst == null || tekst.Equals(""))
            {
                tekst = Console.ReadLine();
            }
            return tekst;
        }

    }
}

