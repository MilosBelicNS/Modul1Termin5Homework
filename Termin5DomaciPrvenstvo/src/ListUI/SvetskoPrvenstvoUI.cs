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
    class SvetskoPrvenstvoUI
    {
        /** ATRIBUTI KLASE ****/
        internal static List<SvetskoPrvenstvo> listaPrvenstava = new List<SvetskoPrvenstvo>();



        public static void MeniPrvenstvoUI()
        {
            int odluka = -1;
            while (odluka != 0)
            {
                IspisiOpcijePrvenstava();
                Console.Write("Opcija:");
                odluka = IOPomocnaKlasa.OcitajCeoBroj();
                Console.Clear();
                switch (odluka)
                {
                    case 0:
                        Console.WriteLine("Izlaz");
                        break;
                    case 1:
                        UnosNovogPrvenstva();
                        break;
                    case 2:
                        IzmenaPodatakaOPrvenstvu();
                        break;
                    case 3:
                        BrisanjePodatakaOPrvenstvu();
                        break;
                    case 4:
                        IspisSvihPrvenstava();
                        break;

                    case 5:
                        IspisiSvaPrvenstvaSortiranoPoNazivu();
                        break;
                    case 6:
                        IspisiPrvenstvoSortiranoPoGodiniOdrzavanja();
                        break;
                    case 7:
                        IspisiDrzaveOrganizatoreURasopnuGodina();
                        break;
                    default:
                        Console.WriteLine("Nepostojeca komanda!\n\n");
                        break;
                }
            }
        }


        /** METODE ZA ISPIS OPCIJA ****/
        //ispis teksta osnovnih opcija

        public static void IspisiOpcijePrvenstava()
        {
            Console.WriteLine("Rad sa drzavama - opcije:");
            Console.WriteLine("\tOpcija broj 1 - unos podataka o novom prvenstvu");
            Console.WriteLine("\tOpcija broj 2 - izmena podataka o prvenstvu");
            Console.WriteLine("\tOpcija broj 3 - brisanje podataka o prvenstvu");
            Console.WriteLine("\tOpcija broj 4 - ispis svih svetskih prvenstava");
            Console.WriteLine("\tOpcija broj 5 - ispis svih svetskih prvenstava sortiranih po nazivu");
            Console.WriteLine("\tOpcija broj 6 - ispis svih svetskih prvenstava sortiranih po godini odrzavanja");
            Console.WriteLine("\tOpcija broj 7 - pretraga drzava organizatora svetskih prvenstava po godini odrzavanja");
            Console.WriteLine("\t\t ...");
            Console.WriteLine("\tOpcija broj 0 - POVRATAK NA GLAVNI MENI");
        }

        /** METODE ZA ISPIS PRVENSTAVA ****/

        public static void IspisSvihPrvenstava()
        {
            for (int i = 0; i < listaPrvenstava.Count; i++)
            {

                Console.WriteLine(listaPrvenstava[i]);

            }
        }

        public static void IspisiSvaPrvenstvaSortiranoPoNazivu()
        {
            List<SvetskoPrvenstvo> sortedList = listaPrvenstava.OrderBy(x => x.Naziv).ToList();//zasto pisemo toList?

            for (int i = 0; i < sortedList.Count; i++)
            {

                Console.WriteLine(sortedList[i]);

            }
        }

        public static void IspisiPrvenstvoSortiranoPoGodiniOdrzavanja()
        {
            List<SvetskoPrvenstvo> sortedList = listaPrvenstava.OrderBy(x => x.GodinaOdrzavanja).ToList();//zasto pisemo toList?

            for (int i = 0; i < sortedList.Count; i++)
            {

                Console.WriteLine(sortedList[i]);

            }
        }


        public static void IspisiDrzaveOrganizatoreURasopnuGodina()
        {
            Console.WriteLine("Unesi pocetnu godinu:");
            int pocetnaGodina = IOPomocnaKlasa.OcitajCeoBroj();
            Console.WriteLine("Unesi zavrsnu godinu:");
            int zavrsnaGodina = IOPomocnaKlasa.OcitajCeoBroj();

            int counter;
            for (int i = 0; i < listaPrvenstava.Count; i++)
            {
                if (listaPrvenstava[i].GodinaOdrzavanja < pocetnaGodina) continue;
                if (listaPrvenstava[i].GodinaOdrzavanja > zavrsnaGodina) break;

                counter = 1;
                for (int j = i + 1; j < listaPrvenstava.Count; j++)
                {
                    if (listaPrvenstava[j].GodinaOdrzavanja < pocetnaGodina) continue;
                    if (listaPrvenstava[j].GodinaOdrzavanja > zavrsnaGodina) continue;

                    if (listaPrvenstava[i].DrzavaDomacin.Naziv == listaPrvenstava[j].DrzavaDomacin.Naziv)
                    {
                        counter++;
                    }
                }
                if (counter == 1)
                {
                    Console.WriteLine(listaPrvenstava[i].DrzavaDomacin);
                }
                else if (counter != 1)
                {
                    Console.WriteLine(listaPrvenstava[i].DrzavaDomacin + " " + counter);
                }

            }

        }


        /** METODE ZA PRETRAGU PRVENSTVO****/
        //pronadji PRVENSTVO

        public static SvetskoPrvenstvo PronadjiPrvenstvoPoId()
        {
            SvetskoPrvenstvo retVal = null;
            Console.WriteLine("Unesi id prvenstva:");
            int id = IOPomocnaKlasa.OcitajCeoBroj();
            retVal = PronadjiPrvenstvoPoId();
            if (retVal == null)
                Console.WriteLine("Drzava sa id: " + id + " ne postoji u evidenciji");
            return retVal;
        }

        //pronadji PRVENSTVO
        public static SvetskoPrvenstvo PronadjiPrvenstvoPoId(int id)
        {
            SvetskoPrvenstvo retVal = null;
            for (int i = 0; i < listaPrvenstava.Count; i++)
            {
                SvetskoPrvenstvo svetskoPrvenstvo = listaPrvenstava[i];
                if (svetskoPrvenstvo.Id == id)
                {
                    retVal = svetskoPrvenstvo;
                    break;
                }
            }
            return retVal;
        }

        //pronadji studenta
        public static SvetskoPrvenstvo PronadjiPrvenstvoPoNazivu()
        {
            SvetskoPrvenstvo retVal = null;
            Console.WriteLine("Unesi naziv prvenstva:");
            String svNaziv = IOPomocnaKlasa.OcitajTekst();
            retVal = PronadjiPrvenstvoPoNazivu(svNaziv);
            if (retVal == null)
                Console.WriteLine("Drzava sa imenom " + svNaziv + " ne postoji u evidenciji");
            return retVal;
        }

        //pronadji studenta
        public static SvetskoPrvenstvo PronadjiPrvenstvoPoNazivu(String svNaziv)
        {
            SvetskoPrvenstvo retVal = null;
            for (int i = 0; i < listaPrvenstava.Count; i++)
            {
                SvetskoPrvenstvo sv = listaPrvenstava[i];
                if (sv.Naziv.Equals(svNaziv))
                {
                    retVal = sv;
                    break;
                }
            }
            return retVal;
        }

        /** METODE ZA UNOS, IZMENU I BRISANJE prvenstva ****/
        // unos novog prvenstva
        public static void UnosNovogPrvenstva()
        {
            Console.WriteLine("Naziv:");
            string svNaziv = IOPomocnaKlasa.OcitajTekst();
            Console.WriteLine("Godina odrzavanja:");
            int svGodinaOdrzavanja = IOPomocnaKlasa.OcitajCeoBroj();
            Console.WriteLine("Drzava domacin:");
            string svDrzavaDomacin = IOPomocnaKlasa.OcitajTekst();
            Console.WriteLine("Glavni grad:");
            string svGlavniGrad = IOPomocnaKlasa.OcitajTekst();
            Drzava tempDrzava;
            SvetskoPrvenstvo tempSvetskoPrvenstvo;

            if (!ProveraPrvenstva(svNaziv))
            {        //ID CE SE DODELITI AUTOMATSKI
                tempDrzava = DrzavaUI.UnosNoveDrzave(svDrzavaDomacin, svGlavniGrad);
                tempSvetskoPrvenstvo = new SvetskoPrvenstvo(svNaziv, svGodinaOdrzavanja, tempDrzava);
                listaPrvenstava.Add(tempSvetskoPrvenstvo);
            }
            else 
            {
                tempDrzava = DrzavaUI.PronadjiDrzavuPoNazivu(svDrzavaDomacin);
                tempSvetskoPrvenstvo = new SvetskoPrvenstvo(svNaziv, svGodinaOdrzavanja, tempDrzava);
                listaPrvenstava.Add(tempSvetskoPrvenstvo);


            };


        }


        public static SvetskoPrvenstvo UnosNovogPrvenstva(string naziv, int godinaOdrzavanja, Drzava drzavaDomacin)
        {
            //ID atribut ce se dodeliti automatski
            SvetskoPrvenstvo svetskoPrvenstvo = new SvetskoPrvenstvo(naziv, godinaOdrzavanja, drzavaDomacin);
            listaPrvenstava.Add(svetskoPrvenstvo);
            return svetskoPrvenstvo;
        }



        // izmena prvenstva
        public static void IzmenaPodatakaOPrvenstvu()
        {
            SvetskoPrvenstvo svetskoPrvenstvo = PronadjiPrvenstvoPoNazivu();
            if (svetskoPrvenstvo != null)
            {
                Console.WriteLine("Unesi novi naziv :");
                String naziv = IOPomocnaKlasa.OcitajTekst();
                Console.WriteLine("Unesi godinu odrzavanja :");
                int svGodinaOdrzavanja = IOPomocnaKlasa.OcitajCeoBroj();
                Console.WriteLine("Unesi naziv drzave organizatora :");
                String svDrzavaDomacin = IOPomocnaKlasa.OcitajTekst();
                Console.WriteLine("Unesi glavni grad :");
                String svGlavniGrad = IOPomocnaKlasa.OcitajTekst();
                Drzava tempDrzava;
                if (!ProveraPrvenstva(naziv))
                {
                    tempDrzava = DrzavaUI.UnosNoveDrzave(svDrzavaDomacin, svGlavniGrad);
                    svetskoPrvenstvo.Naziv = naziv;
                    svetskoPrvenstvo.GodinaOdrzavanja = svGodinaOdrzavanja;
                    svetskoPrvenstvo.DrzavaDomacin = tempDrzava;
                }
                else Console.WriteLine("Svetsko prvenstvo sa nazivom " + naziv + " vec postoji u evidenciji.");


            }
        }

        //brisanje drzave
        public static void BrisanjePodatakaOPrvenstvu()
        {
            SvetskoPrvenstvo svetskoPrvenstvo = PronadjiPrvenstvoPoNazivu();
            if (svetskoPrvenstvo != null)
            {
                listaPrvenstava.Remove(svetskoPrvenstvo);

                Console.WriteLine("Podaci obrisani iz evidencije");
            }
        }

        /** METODA ZA UCITAVANJE PODATAKA****/
        public static void UcitajPrvenstvaIzDatoteke(string nazivDatoteke)
        {
            if (File.Exists(nazivDatoteke))
            {
                using (StreamReader reader1 = File.OpenText(nazivDatoteke))
                {
                    string linija = "";
                    while ((linija = reader1.ReadLine()) != null)
                    {
                        SvetskoPrvenstvo svetskoPrvenstvo = SvetskoPrvenstvo.FromFileToObject(linija);
                        if (svetskoPrvenstvo == null)
                        {
                            //nedozvoljeno stanje
                            Environment.Exit(1);
                        }
                        listaPrvenstava.Add(svetskoPrvenstvo);
                    }
                }
            }
            else
            {
                Console.WriteLine("Datoteka ne postoji ili putanja nije ispravna.");
            }

        }

        public static void SacuvajPrvenstvaUDatoteku(string nazivDatoteke)
        {
            if (File.Exists(nazivDatoteke))
            {
                using (StreamWriter writer = new StreamWriter(nazivDatoteke, false, Encoding.UTF8))
                {
                    foreach (SvetskoPrvenstvo svetskoPrvenstvo in listaPrvenstava)
                    {
                        writer.WriteLine(svetskoPrvenstvo.ToFileString());
                    }
                }
            }
            else
            {
                Console.WriteLine("Datoteka ne postoji ili putanja nije ispravna.");
            }

        }


        public static bool ProveraPrvenstva(string naziv)
        {
            bool provera = false;

            foreach(SvetskoPrvenstvo svetskoPrvenstvo in listaPrvenstava)
            {
                if(naziv == svetskoPrvenstvo.Naziv)
                {
                    provera = true;
                }
            }
            return provera;
        }
    }
}
