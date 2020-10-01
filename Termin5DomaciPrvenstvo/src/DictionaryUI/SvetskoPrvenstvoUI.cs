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
    class SvetskoPrvenstvoUI
    {
        /** ATRIBUTI KLASE ****/
        public static Dictionary<int, SvetskoPrvenstvo> RecnikPrvenstva { get; set; }

        static SvetskoPrvenstvoUI()
        {
            RecnikPrvenstva = new Dictionary<int, SvetskoPrvenstvo>();
        }

        /** MENI OPCJA ****/
        public static void MeniSvetskoPrvenstvoUI()
        {
            int odluka = -1;
            while (odluka != 0)
            {
                IspisiOpcijePrvenstva();
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
                        SortirajPrvenstvaPoNazivu();
                        break;
                    case 6:
                        SortirajPrvenstvaPoGodini();
                        break;


                    default:
                        Console.WriteLine("Nepostojeca komanda!\n\n");
                        break;
                }
            }
        }


        public static void IspisiOpcijePrvenstva()
        {
            Console.WriteLine("Rad sa prvenstvima - opcije:");
            Console.WriteLine("\tOpcija broj 1 - unos podataka o novom prvenstvu");
            Console.WriteLine("\tOpcija broj 2 - izmena podataka o prvenstvu");
            Console.WriteLine("\tOpcija broj 3 - brisanje podataka o prvenstvu");
            Console.WriteLine("\tOpcija broj 4 - ispis svih prvenstava");
            Console.WriteLine("\tOpcija broj 5 - ispis svih prvenstava sortiranih po nazivu");
            Console.WriteLine("\tOpcija broj 6 - ispis svih prvenstava sortiranih po godijni odrzavanja");
            Console.WriteLine("\tOpcija broj 7 - pretraga prvenstava po godini odrzavanja");
            Console.WriteLine("\t\t ...");
            Console.WriteLine("\tOpcija broj 0 - POVRATAK NA GLAVNI MENI");
        }

        /** METODE ZA ISPIS drzave ****/
        // ispisi sve drzave
        public static void IspisSvihPrvenstava()
        {
            IspisSvihPrvenstava(RecnikPrvenstva.Values.ToList<SvetskoPrvenstvo>());
        }

        public static void IspisSvihPrvenstava(IList<SvetskoPrvenstvo> lista)
        {
            foreach (SvetskoPrvenstvo svetskoPrvenstvo in lista)
            {
                Console.WriteLine(svetskoPrvenstvo);
            }
        }

        /** METODA ZA SORTIRANJE PREDMETA****/
        //public static IList<SvetskoPrvenstvo> SortirajPrvenstvaPoNazivu()
        //{
        //    //kako mapa studenata ne može da se sortira tako 
        //    //sve studente moramo prebaciti u listu čiji elementi mogu da se sortiraju
        //    List<SvetskoPrvenstvo> sortiranaPrvenstva = RecnikPrvenstva.Values.ToList();
        //    Console.WriteLine("Drzave je moguće sortirati po nazivu\n\t1 - Rastuće\n\t2 - Opadajuće\nIzaberi opciju:");
        //    int sortOpcija = IOPomocnaKlasa.OcitajCeoBroj();
        //    switch (sortOpcija)
        //    {
        //        case 1:
        //            sortiranaPrvenstva.OrderBy(x => x.Naziv);
        //            break;
        //        case 2:
        //            sortiranaPrvenstva.OrderByDescending(x => x.Naziv);
        //            break;
        //        default:
        //            break;
        //    }
        //    return sortiranaPrvenstva;
        //}

        public static void SortirajPrvenstvaPoNazivu()
        {
            //kako mapa studenata ne može da se sortira tako 
            //sve studente moramo prebaciti u listu čiji elementi mogu da se sortiraju
            List<SvetskoPrvenstvo> sortiranaPrvenstva = RecnikPrvenstva.Values.ToList();
            Console.WriteLine("Drzave je moguće sortirati po nazivu\n\t1 - Rastuće\n\t2 - Opadajuće\nIzaberi opciju:");
            int sortOpcija = IOPomocnaKlasa.OcitajCeoBroj();
            switch (sortOpcija)
            {
                case 1:

                    foreach(var prvenstvo in sortiranaPrvenstva.OrderBy(x => x.Naziv))
                    {
                        Console.WriteLine(prvenstvo);
                    }
                    break;
                case 2:
                    
                    foreach (var prvenstvo in sortiranaPrvenstva.OrderByDescending(x => x.Naziv))
                    {
                        Console.WriteLine(prvenstvo);
                    }
                    break;
                default:
                    break;
            }
            
        }

        //public static void IspisiDrzaveOrganizatoreURasopnuGodina()
        //{
        //    Console.WriteLine("Unesi pocetnu godinu:");
        //    int pocetnaGodina = IOPomocnaKlasa.OcitajCeoBroj();
        //    Console.WriteLine("Unesi zavrsnu godinu:");
        //    int zavrsnaGodina = IOPomocnaKlasa.OcitajCeoBroj();

        //    int counter;
        //    for (int i = 0; i < RecnikPrvenstva.Count; i++)
        //    {
        //        if (RecnikPrvenstva[i].GodinaOdrzavanja < pocetnaGodina) continue;
        //        if (RecnikPrvenstva[i].GodinaOdrzavanja > zavrsnaGodina) break;

        //        counter = 1;
        //        for (int j = i + 1; j < RecnikPrvenstva.Count; j++)
        //        {
        //            if (RecnikPrvenstva[j].GodinaOdrzavanja < pocetnaGodina) continue;
        //            if (RecnikPrvenstva[j].GodinaOdrzavanja > zavrsnaGodina) continue;

        //            if (RecnikPrvenstva[i].DrzavaDomacin.Naziv == RecnikPrvenstva[j].DrzavaDomacin.Naziv)
        //            {
        //                counter++;
        //            }
        //        }s
        //        if (counter == 1)
        //        {
        //            Console.WriteLine(RecnikPrvenstva[i].DrzavaDomacin);
        //        }
        //        else if (counter != 1)
        //        {
        //            Console.WriteLine(RecnikPrvenstva[i].DrzavaDomacin + " " + counter);
                

        //    }

        //}

        public static void SortirajPrvenstvaPoGodini()
        {
            //kako mapa studenata ne može da se sortira tako 
            //sve studente moramo prebaciti u listu čiji elementi mogu da se sortiraju
            List<SvetskoPrvenstvo> sortiranaPrvenstva = RecnikPrvenstva.Values.ToList();
            Console.WriteLine("Drzave je moguće sortirati po godini\n\t1 - Rastuće\n\t2 - Opadajuće\nIzaberi opciju:");
            int sortOpcija = IOPomocnaKlasa.OcitajCeoBroj();
            switch (sortOpcija)
            {
                case 1:
                   foreach(var prvenstvo in sortiranaPrvenstva.OrderBy(x => x.GodinaOdrzavanja))
                    {
                        Console.WriteLine(prvenstvo);
                    }
                    break;
                case 2:
                    foreach (var prvenstvo in sortiranaPrvenstva.OrderByDescending(x => x.GodinaOdrzavanja))
                    {
                        Console.WriteLine(prvenstvo);
                    }
                    break;
                default:
                    break;
            }
          
        }

        /** METODE ZA PRETRAGU Prvenstva ****/
        // pronadji Prvenstva
        public static SvetskoPrvenstvo PronadjiPrvenstvoPoId()
        {
            SvetskoPrvenstvo retVal = null;
            Console.WriteLine("Unesi id prvenstva:");
            int id = IOPomocnaKlasa.OcitajCeoBroj();
            try
            {
                retVal = PronadjiPrvenstvoPoId(id);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Drzava sa id-om " + id + " ne postoji u evidenciji");
            }

            return retVal;
        }

        // pronadji drzavu
        public static SvetskoPrvenstvo PronadjiPrvenstvoPoId(int id)
        {
            try
            {
                return RecnikPrvenstva[id];
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Ne postoji vrednost u rečniku RecnikDrzave za dati ključ!");
                throw;
            }
        }

        //pronadji drzavu
        public static SvetskoPrvenstvo PronadjiPrvenstvoPoNazivu()
        {
            SvetskoPrvenstvo retVal = null;
            Console.WriteLine("Unesi naziv prvenstva:");
            String dNaziv = IOPomocnaKlasa.OcitajTekst();
            retVal = PronadjiPrvenstvoPoNazivu(dNaziv);
            if (retVal == null)
                Console.WriteLine("Drzava sa imenom " + dNaziv + " ne postoji u evidenciji");
            return retVal;
        }

        //pronadji drzavu
        public static SvetskoPrvenstvo PronadjiPrvenstvoPoNazivu(String dNaziv)
        {
            SvetskoPrvenstvo retVal = null;
            foreach (SvetskoPrvenstvo svetskoPrvenstvo in RecnikPrvenstva.Values)
            {
                if (svetskoPrvenstvo.Naziv.Equals(dNaziv))
                {
                    retVal = svetskoPrvenstvo;
                    break;
                }
            }
            return retVal;
        }


        /** METODE ZA UNOS, IZMENU I BRISANJE drzave ****/
        // unos novog drzave
        public static void UnosNovogPrvenstva()
        {
            Console.WriteLine("Naziv:");
            string pNaziv = IOPomocnaKlasa.OcitajTekst();
            Console.WriteLine("Godina:");
            int pGodina = IOPomocnaKlasa.OcitajCeoBroj();
            Console.WriteLine("Drzava domacin:");
            string pDrzavaDomacin = IOPomocnaKlasa.OcitajTekst();
            Console.WriteLine("Glavni grad:");
            string pGlavniGrad = IOPomocnaKlasa.OcitajTekst();
            Drzava drzava;
            SvetskoPrvenstvo svetskoPrvenstvo;

            if (!ProveraDaLiPostojiPrvenstvo(pNaziv))
            {
                drzava = DrzavaUI.UnosNovogDrzave(pDrzavaDomacin, pGlavniGrad);
                svetskoPrvenstvo = new SvetskoPrvenstvo(pNaziv, pGodina, drzava);
                RecnikPrvenstva.Add(svetskoPrvenstvo.Id, svetskoPrvenstvo);
            }
            else
            {
                drzava = DrzavaUI.PronadjiDrzavuPoNazivu(pDrzavaDomacin);
                svetskoPrvenstvo = new SvetskoPrvenstvo(pNaziv, pGodina, drzava);
                RecnikPrvenstva.Add(svetskoPrvenstvo.Id,svetskoPrvenstvo);


            };
        }

        public static SvetskoPrvenstvo UnosNovogPrvenstva(string naziv, int godina, Drzava drzava)
        {
            //ID atribut ce se dodeliti automatski
            SvetskoPrvenstvo svetskoPrvenstvo = new SvetskoPrvenstvo(naziv, godina, drzava);
            RecnikPrvenstva.Add(svetskoPrvenstvo.Id,svetskoPrvenstvo);
            return svetskoPrvenstvo;
        }


        public static void IzmenaPodatakaOPrvenstvu()
        {
            SvetskoPrvenstvo svetskoPrvenstvo = PronadjiPrvenstvoPoId();
            if (svetskoPrvenstvo != null)
            {
                Console.WriteLine("Unesi naziv:");
                String svNaziv = IOPomocnaKlasa.OcitajTekst();
                Console.WriteLine("Unesi godinu:");
                int svGodina = IOPomocnaKlasa.OcitajCeoBroj();
                Console.WriteLine("Unesi drzavu organizatora:");
                String svDrzavaNaziv = IOPomocnaKlasa.OcitajTekst();
                Console.WriteLine("Unesi glavni grad:");
                String svGlavniGrad = IOPomocnaKlasa.OcitajTekst();
                Drzava drzava;
                if (!ProveraDaLiPostojiPrvenstvo(svNaziv))
                {

                    drzava = DrzavaUI.UnosNovogDrzave(svDrzavaNaziv, svGlavniGrad);
                    svetskoPrvenstvo.Naziv = svNaziv;
                    svetskoPrvenstvo.GodinaOdrzavanja = svGodina;
                    svetskoPrvenstvo.DrzavaDomacin = drzava;
                    
                 }
                else Console.WriteLine("Svetsko prvenstvo sa nazivom " + svNaziv + " vec postoji u evidenciji.");

            }
        }

        public static void BrisanjePodatakaOPrvenstvu()
        {
            //neophodno redefinisati ToString metodu
            SvetskoPrvenstvo svetskoPrvenstvo = PronadjiPrvenstvoPoId();
            if (svetskoPrvenstvo != null)
            {
                RecnikPrvenstva.Remove(svetskoPrvenstvo.Id);

                Console.WriteLine("Podaci obrisani iz evidencije");
            }
            else Console.WriteLine("Brisanje nije uspelo");
        }


        /** METODA ZA UCITAVANJE PODATAKA****/
        public static void UcitajPrvenstvoIzDatoteke(string nazivDatoteke)
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
                        RecnikPrvenstva.Add(svetskoPrvenstvo.Id, svetskoPrvenstvo);
                    }
                }
            }
            else
            {
                Console.WriteLine("Datoteka ne postoji ili putanja nije ispravna.");
            }

        }

        public static void SacuvajPrvenstvoUDatoteku(string nazivDatoteke)
        {
            if (File.Exists(nazivDatoteke))
            {
                using (StreamWriter writer = new StreamWriter(nazivDatoteke, false, Encoding.UTF8))
                {
                    foreach (SvetskoPrvenstvo s in RecnikPrvenstva.Values)
                    {
                        writer.WriteLine(s.ToFileString());
                    }
                }
            }
            else
            {
                Console.WriteLine("Datoteka ne postoji ili putanja nije ispravna.");
            }

        }

        public static bool ProveraDaLiPostojiPrvenstvo(string naziv)
        {
            bool provera = false;
            foreach (KeyValuePair<int, SvetskoPrvenstvo> kvp in RecnikPrvenstva)
            {
                if (kvp.Value.Naziv == naziv)
                {
                    provera = true;
                }
            }
            return provera;
        }





    }
}
