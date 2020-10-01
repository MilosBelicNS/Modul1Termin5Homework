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
    class DrzavaUI
    {

        /** ATRIBUTI KLASE ****/
        public static Dictionary<int, Drzava> RecnikDrzave { get; set; }

        static DrzavaUI()
        {
            RecnikDrzave = new Dictionary<int, Drzava>();
        }

        /** MENI OPCJA ****/
        public static void MeniDrzavaUI()
        {
            int odluka = -1;
            while (odluka != 0)
            {
                IspisiOpcijeDrzave();
                Console.Write("Opcija:");
                odluka = IOPomocnaKlasa.OcitajCeoBroj();
                Console.Clear();
                switch (odluka)
                {
                    case 0:
                        Console.WriteLine("Izlaz");
                        break;
                    case 1:
                        UnosNovogDrzave();
                        break;
                    case 2:
                        IzmenaPodatakaODrzavi();
                        break;
                    case 3:
                        BrisanjePodatakaODrzavi();
                        break;
                    case 4:
                        IspisSvihDrzava();
                        break;
                    case 5:
                        SortirajDrzavePoNazivu();
                        break;
                    
                    default:
                        Console.WriteLine("Nepostojeca komanda!\n\n");
                        break;
                }
            }
        }

        public static void IspisiOpcijeDrzave()
        {
            Console.WriteLine("Rad sa drzavama - opcije:");
            Console.WriteLine("\tOpcija broj 1 - unos podataka o novoj drzavi");
            Console.WriteLine("\tOpcija broj 2 - izmena podataka o drzavi");
            Console.WriteLine("\tOpcija broj 3 - brisanje podataka o drzavi");
            Console.WriteLine("\tOpcija broj 4 - ispis podataka svih drzava");
            Console.WriteLine("\tOpcija broj 5 - ispis svih drzava sortiranih po nazivu");
            Console.WriteLine("\t\t ...");
            Console.WriteLine("\tOpcija broj 0 - POVRATAK NA GLAVNI MENI");
        }

        /** METODE ZA ISPIS drzave ****/
        // ispisi sve drzave
        public static void IspisSvihDrzava()
        {
            IspisSvihDrzava(RecnikDrzave.Values.ToList<Drzava>());
        }

        public static void IspisSvihDrzava(IList<Drzava> lista)
        {
            foreach (Drzava drzava in lista)
            {
                Console.WriteLine(drzava);
            }
        }




        /** METODE ZA PRETRAGU Drzave ****/
        // pronadji Drzave
        public static Drzava PronadjiDrzavuPoId()
        {
            Drzava retVal = null;
            Console.WriteLine("Unesi id drzave:");
            int id = IOPomocnaKlasa.OcitajCeoBroj();
            try
            {
                retVal = PronadjiDrzavuPoId(id);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Drzava sa id-om " + id + " ne postoji u evidenciji");
            }

            return retVal;
        }
        //pronadji drzavu
        public static Drzava PronadjiDrzavuPoNazivu()
        {
            Drzava retVal = null;
            Console.WriteLine("Unesi naziv drzave:");
            String dNaziv = IOPomocnaKlasa.OcitajTekst();
            retVal = PronadjiDrzavuPoNazivu(dNaziv);
            if (retVal == null)
                Console.WriteLine("Drzava sa imenom " + dNaziv + " ne postoji u evidenciji");
            return retVal;
        }

        //pronadji drzavu
        public static Drzava PronadjiDrzavuPoNazivu(String dNaziv)
        {
            Drzava retVal = null;
            foreach (Drzava drzava in RecnikDrzave.Values)
            {
                if (drzava.Naziv.Equals(dNaziv))
                {
                    retVal = drzava;
                    break;
                }
            }
            return retVal;
        }



        // pronadji drzavu
        public static Drzava PronadjiDrzavuPoId(int id)
        {
            try
            {
                return RecnikDrzave[id];
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Ne postoji vrednost u rečniku RecnikDrzave za dati ključ!");
                throw;
            }
        }

        public static void SortirajDrzavePoNazivu()
        {
            //kako mapa studenata ne može da se sortira tako 
            //sve studente moramo prebaciti u listu čiji elementi mogu da se sortiraju
            List<Drzava> sortiraneDrzave = RecnikDrzave.Values.ToList();
            Console.WriteLine("Drzave je moguće sortirati po nazivu\n\t1 - Rastuće\n\t2 - Opadajuće\nIzaberi opciju:");
            int sortOpcija = IOPomocnaKlasa.OcitajCeoBroj();
            switch (sortOpcija)
            {
                case 1:

                    foreach (var drzava in sortiraneDrzave.OrderBy(x => x.Naziv))
                    {
                        Console.WriteLine(drzava);
                    }
                    break;
                case 2:

                    foreach (var drzava in sortiraneDrzave.OrderByDescending(x => x.Naziv))
                    {
                        Console.WriteLine(drzava);
                    }
                    break;
                default:
                    break;
            }

        }
        public static void SortirajDrzavePoNazivu(IList<Drzava> lista)
        {
            foreach (Drzava drzava in lista)
            {
                Console.WriteLine(drzava);
            }
        }

        /** METODE ZA UNOS, IZMENU I BRISANJE drzave ****/
        // unos novog drzave
        public static void UnosNovogDrzave()
        {
            Console.WriteLine("Naziv:");
            string naziv = IOPomocnaKlasa.OcitajTekst();
            Console.WriteLine("Glavni grad:");
            string glavniGrad = IOPomocnaKlasa.OcitajTekst();

            if (!ProveraDaLiPostojiDrzava(naziv))
            { 
            Drzava drzava = new Drzava(naziv, glavniGrad);
            RecnikDrzave.Add(drzava.Id, drzava);
            }
            else Console.WriteLine("\nDrzava sa nazivom: " + naziv + " vec postoji!");

        }

        public static Drzava UnosNovogDrzave(string naziv, string glavniGrad)
        {
            //ID atribut ce se dodeliti automatski
            Drzava drzava = new Drzava(naziv, glavniGrad);
            RecnikDrzave.Add(drzava.Id,drzava);
            return drzava;
        }

        //izmena studenta
        public static void IzmenaPodatakaODrzavi()
        {
            Drzava drzava = PronadjiDrzavuPoId();
            if (drzava != null)
            {
                Console.WriteLine("Unesi naziv:");
                String drNaziv = IOPomocnaKlasa.OcitajTekst();
                Console.WriteLine("Unesi glavni grad:");
                String drGlavniGrad = IOPomocnaKlasa.OcitajTekst();
                if (!ProveraDaLiPostojiDrzava(drNaziv))
                {
                    drzava.Naziv = drNaziv;
                    drzava.GlavniGrad = drGlavniGrad;
                }
                else Console.WriteLine("Drzava sa nazivom " + drNaziv + " vec postoji u evidenciji.");

            }
        }

        //brisanje predmeta
        public static void BrisanjePodatakaODrzavi()
        {
            //neophodno redefinisati ToString metodu
            Drzava drzava = PronadjiDrzavuPoNazivu();
            if (drzava != null)
            {
                RecnikDrzave.Remove(drzava.Id);
             
                Console.WriteLine("Podaci obrisani iz evidencije");
            }
            else Console.WriteLine("Brisanje nije uspelo");
        }

        /** METODA ZA UCITAVANJE PODATAKA****/
        public static void UcitajDrzaveIzDatoteke(string nazivDatoteke)
        {
            if (File.Exists(nazivDatoteke))
            {
                using (StreamReader reader1 = File.OpenText(nazivDatoteke))
                {
                    string linija = "";
                    while ((linija = reader1.ReadLine()) != null)
                    {
                        Drzava drzava = Drzava.FromFileToObject(linija);
                        if (drzava == null)
                        {
                            //nedozvoljeno stanje
                            Environment.Exit(1);
                        }
                        RecnikDrzave.Add(drzava.Id, drzava);
                    }
                }
            }
            else
            {
                Console.WriteLine("Datoteka ne postoji ili putanja nije ispravna.");
            }

        }
        public static void SacuvajDrzaveUDatoteku(string nazivDatoteke)
        {
            if (File.Exists(nazivDatoteke))
            {
                using (StreamWriter writer = new StreamWriter(nazivDatoteke, false, Encoding.UTF8))
                {
                    foreach (Drzava d in RecnikDrzave.Values)
                    {
                        writer.WriteLine(d.ToFileString());
                    }
                }
            }
            else
            {
                Console.WriteLine("Datoteka ne postoji ili putanja nije ispravna.");
            }

        }

        public static bool ProveraDaLiPostojiDrzava(string naziv)
        {
            bool provera = false;
           foreach(KeyValuePair<int, Drzava> kvp in RecnikDrzave)
            {
                if(kvp.Value.Naziv == naziv)
                {
                    provera = true;
                }
            }
            return provera;
        }

    }
}
