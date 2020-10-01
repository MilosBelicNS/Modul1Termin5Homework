using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termin5DomaciPrvenstvo.src.Model;
using Termin5DomaciPrvenstvo.src.Utils;

namespace Termin5DomaciPrvenstvo.src.UI
{
    class DrzavaUI
    {

        /** ATRIBUTI KLASE ****/
        internal static List<Drzava> listaDrzava = new List<Drzava>();

        public static void MeniDrzavaUI()
        {
            int odluka = -1;
            while (odluka != 0)
            {
                IspisiOpcijeDrzava();
                Console.Write("Opcija:");
                odluka = IOPomocnaKlasa.OcitajCeoBroj();
                Console.Clear();
                switch (odluka)
                {
                    case 0:
                        Console.WriteLine("Izlaz");
                        break;
                    case 1:
                        UnosNoveDrzave();
                        break;
                    case 2:
                        IzmenaPodatakaODrzavi();
                        break;
                    case 3:
                        BrisanjePodatakaODrzavi();
                        break;
                    case 4:
                        IspisiSveDrzave();
                        break;
                    
                    case 5:
                        IspisiSveDrzaveSortiranoPoNazivu();
                        break;
                    default:
                        Console.WriteLine("Nepostojeca komanda!\n\n");
                        break;
                }
            }
        }

        /** METODE ZA ISPIS OPCIJA ****/
        //ispis teksta osnovnih opcija

        public static void IspisiOpcijeDrzava()
        {
            Console.WriteLine("Rad sa drzavama - opcije:");
            Console.WriteLine("\tOpcija broj 1 - unos podataka o novoj drzavi");
            Console.WriteLine("\tOpcija broj 2 - izmena podataka o drzavi");
            Console.WriteLine("\tOpcija broj 3 - brisanje podataka o drzavi");
            Console.WriteLine("\tOpcija broj 4 - ispis svih drzava");
            Console.WriteLine("\tOpcija broj 5 - ispis svih drzava sortiranih po nazivu");
            Console.WriteLine("\t\t ...");
            Console.WriteLine("\tOpcija broj 0 - POVRATAK NA GLAVNI MENI");
        }

        /** METODE ZA ISPIS Drzava ****/
       
        public static void IspisiSveDrzave()
        {
            for (int i = 0; i < listaDrzava.Count; i++)
            {

                Console.WriteLine(listaDrzava[i]);

            }
        }

        public static void IspisiSveDrzaveSortiranoPoNazivu()
        {
            List<Drzava> sortedList = listaDrzava.OrderBy(x => x.Naziv).ToList();//zasto pisemo toList?

            for (int i = 0; i < sortedList.Count; i++)
            {

                Console.WriteLine(sortedList[i]);

            }
        }


        /** METODE ZA PRETRAGU DRZAVA****/
        //pronadji drzavu

        public static Drzava PronadjiDrzavuPoId()
        {
            Drzava retVal = null;
            Console.WriteLine("Unesi id drzave:");
            int id = IOPomocnaKlasa.OcitajCeoBroj();
            retVal = PronadjiDrzavuPoId();
            if (retVal == null)
                Console.WriteLine("Drzava sa id: " + id + " ne postoji u evidenciji");
            return retVal;
        }

        //pronadji studenta
        public static Drzava PronadjiDrzavuPoId(int id)
        {
            Drzava retVal = null;
            for (int i = 0; i < listaDrzava.Count; i++)
            {
                Drzava dr = listaDrzava[i];
                if (dr.Id == id)
                {
                    retVal = dr;
                    break;
                }
            }
            return retVal;
        }

        //pronadji studenta
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

        //pronadji studenta
        public static Drzava PronadjiDrzavuPoNazivu(String dNaziv)
        {
            Drzava retVal = null;
            for (int i=0; i < listaDrzava.Count; i++)
            {
                Drzava dr = listaDrzava[i];
                if (dr.Naziv.Equals(dNaziv))
                {
                    retVal = dr;
                    break;
                }
            }
            return retVal;
        }



        /** METODE ZA UNOS, IZMENU I BRISANJE PREDMETA ****/
        // unos novog predmeta
        public static void UnosNoveDrzave()
        {
            Console.WriteLine("Naziv:");
            string naziv = IOPomocnaKlasa.OcitajTekst();
            Console.WriteLine("Glavni grad:");
            string grad = IOPomocnaKlasa.OcitajTekst();
            if (!ProveraDaLiDrzavaPostoji(naziv))
            {        //ID CE SE DODELITI AUTOMATSKI
                Drzava drzava = new Drzava(naziv, grad);

                listaDrzava.Add(drzava);
            }
            else Console.WriteLine("\nDrzava sa nazivom: " + naziv + " vec postoji!");

            
        }


        public static Drzava UnosNoveDrzave(string naziv, string glavniGrad)
        {
            //ID atribut ce se dodeliti automatski
            Drzava drzava = new Drzava(naziv, glavniGrad);
            listaDrzava.Add(drzava);
            return drzava;
        }



        // izmena predmeta
        public static void IzmenaPodatakaODrzavi()
        {
            Drzava drzava = PronadjiDrzavuPoNazivu();
            if (drzava != null)
            {
                Console.WriteLine("Unesi novi naziv :");
                string naziv = IOPomocnaKlasa.OcitajTekst();
                if(!ProveraDaLiDrzavaPostoji(naziv))
                { 
                drzava.Naziv = naziv;
                }
                else Console.WriteLine("Drzava sa nazivom " + naziv + " vec postoji u evidenciji.");


            }
        }

        //brisanje drzave
        public static void BrisanjePodatakaODrzavi()
        {
            Drzava drzava = PronadjiDrzavuPoNazivu();
            if (drzava != null)
            {
               listaDrzava.Remove(drzava);
              
                Console.WriteLine("Podaci obrisani iz evidencije");
            }
        }


        public static bool ProveraDaLiDrzavaPostoji(string naziv)
        {
            bool provera = false;

            foreach (Drzava drzava in listaDrzava)
            {
                if (drzava.Naziv == naziv)
                {
                    provera = true;
                }
               
            }
            return provera;
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
                        listaDrzava.Add(drzava);
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
                    foreach (Drzava drzava in listaDrzava)
                    {
                        writer.WriteLine(drzava.ToFileString());
                    }
                }
            }
            else
            {
                Console.WriteLine("Datoteka ne postoji ili putanja nije ispravna.");
            }

        }



    }
}
