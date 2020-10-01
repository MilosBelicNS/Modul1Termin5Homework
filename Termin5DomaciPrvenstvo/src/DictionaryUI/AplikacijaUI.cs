using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termin5DomaciPrvenstvo.src.Model;
using Termin5DomaciPrvenstvo.src.Utils;

namespace Termin5DomaciPrvenstvo.src.DictionaryUI
{
    class AplikacijaUI
    {

        //private static readonly string DataDir = "data";
        private static readonly string DrzaveDat = "Drzave.csv";
        private static readonly string SvPrvenstvo = "SvetskoPrvenstvo.csv";
        private static readonly char sep = Path.DirectorySeparatorChar;
        // private static string putanjaDataDirRelease = "data";

        private static string PodesiPutanju()
        {
            // preuzmi trenutnu putanju (lokaciju) gde se izvrsava .exe ove aplikacije
            DirectoryInfo dir = new DirectoryInfo(@".\..\..\data\");
            string putanja = dir.FullName;
            return putanja;


        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string putanjaDataDir = PodesiPutanju();

            DrzavaUI.UcitajDrzaveIzDatoteke(putanjaDataDir + DrzaveDat);

            SvetskoPrvenstvoUI.UcitajPrvenstvoIzDatoteke(putanjaDataDir + SvPrvenstvo);

            AplikacijaUI.PodesiIdBrojace();


            int odluka = -1;
            while (odluka != 0)
            {
                IspisiOsnovniMeni();
                Console.WriteLine("Opcija:");
                odluka = IOPomocnaKlasa.OcitajCeoBroj();
                switch (odluka)
                {
                    case 0:
                        Console.WriteLine("Izlaz iz programa");
                        break;
                    case 1:
                        DrzavaUI.MeniDrzavaUI();
                        break;
                    case 2:
                        SvetskoPrvenstvoUI.MeniSvetskoPrvenstvoUI();
                        break;
                    default:
                        Console.WriteLine("Nepostojeca komanda!\n\n");
                        break;
                }
            }

            DrzavaUI.SacuvajDrzaveUDatoteku(putanjaDataDir + DrzaveDat);
            SvetskoPrvenstvoUI.SacuvajPrvenstvoUDatoteku(putanjaDataDir + SvPrvenstvo);
            Console.WriteLine("Pritisnite bilo koji taster...");
            Console.ReadKey(true);

        }

        public static void IspisiOsnovniMeni()
        {
            Console.WriteLine("Svetska prvenstva - Osnovne opcije:");
            Console.WriteLine("\tOpcija broj 1 - Rad sa drzavama");
            Console.WriteLine("\tOpcija broj 2 - Rad sa svetskim prvenstvima");
            Console.WriteLine("\t\t ...");
            Console.WriteLine("\tOpcija broj 0 - IZLAZ IZ PROGRAMA");
        }

        private static void PodesiIdBrojace()
        {
            int max = -1;
            foreach (SvetskoPrvenstvo sp in SvetskoPrvenstvoUI.RecnikPrvenstva.Values)
                
            {
                if (sp.Id > max)
                {
                    max = sp.Id;
                }
            }
            SvetskoPrvenstvo.BrojacId = ++max;
            max = -1;
            foreach (Drzava dr in DrzavaUI.RecnikDrzave.Values)
            {
                if (dr.Id > max)
                {
                    max = dr.Id;
                }
            }
            Drzava.BrojacId = ++max;
        }
    }
}
