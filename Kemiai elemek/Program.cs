using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kemiai_elemek
{
    internal class Program
    {
        class KemiaiElem
        {
            internal int Ev;
            internal string Nev;
            internal string Vegyjel;
            internal int Rendszam;
            internal string Felfedezo;
            public KemiaiElem(string ev, string nev, string vegyjel, int rendszam, string felfedezo)
            {
                if (!int.TryParse(ev, out Ev))
                {
                    Ev = 0;
                }

                this.Nev = nev;
                this.Vegyjel = vegyjel;
                this.Rendszam = rendszam;
                this.Felfedezo = felfedezo;
            }
        }
        static List<KemiaiElem> OsszesElem = new List<KemiaiElem>();
        static void Main(string[] args)
        {
            beolvasas();
            feladat3();
            feladat4();
            feladat5();//Nested: feladat6()
            feladat7();
            feladat8();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static void beolvasas()
        {
            foreach (string item in File.ReadAllLines("felfedezesek.csv", Encoding.Default).Skip(1))
            {
                string[] _temp = item.Trim().Split(';');
                OsszesElem.Add(new KemiaiElem(_temp[0], _temp[1], _temp[2], int.Parse(_temp[3]), _temp[4]));
            }
        }
        static void feladat3()
        {
            Console.WriteLine($"3.feladat: Az állományban {OsszesElem.Count} felfedezés található.");
        }
        static void feladat4()
        {
            Console.WriteLine($"4.feladat: Felfedezések száma az ókorban: {OsszesElem.Where(x=>x.Ev == 0).Count()}");
        }
        static void feladat5()
        {
            string input;
            while (true)
            {
                Console.Write($"5.feladat: Kérek egy vegyjelet: ");
                input = Console.ReadLine();
                if (input.Length < 3 && input.Length > 0)
                {
                    Regex onlyenglish = new Regex("^[a-zA-Z]*$", RegexOptions.Compiled);
                    if (onlyenglish.IsMatch(input))
                    {
                        feladat6(input);
                        break;
                    }
                }
            }
        }
        static void feladat6(string input)
        {
            Console.WriteLine("6.feladat: Keresés");
            if (OsszesElem.Any(x => x.Vegyjel.ToLower().Equals(input.ToLower())))
            {
                KemiaiElem hit = OsszesElem.Where(x => x.Vegyjel.ToLower().Equals(input.ToLower())).First();
                Console.Write($"\tAz elem vegyjele: {hit.Vegyjel}\n" +
                              $"\tAz elem neve: {hit.Nev}\n" +
                              $"\tRendszáma: {hit.Rendszam}\n" +
                              $"\tFelfedezés éve: ");
                if (hit.Ev == 0)
                    Console.Write($"Ókor");
                else
                    Console.Write(hit.Ev);
                Console.WriteLine($"\n\tFelfedező: {hit.Felfedezo}");

            }
            else
                Console.WriteLine("\tNincs ilyen vegyjel az állományban!");
        }
        static void feladat7()
        {
            OsszesElem.Sort((elem1, elem2) => elem1.Ev.CompareTo(elem2.Ev));
            int maxkulonbseg = 0;

            KemiaiElem olditem = null;

            foreach (KemiaiElem item in OsszesElem)
            {
                if (olditem != null)
                {
                    if (maxkulonbseg < (item.Ev - olditem.Ev) && !(olditem.Ev == 0))
                        maxkulonbseg = item.Ev - olditem.Ev;
                    olditem = item;
                }
                else
                {
                    olditem = OsszesElem[0];
                }
            }
            Console.WriteLine($"7.feladat: {maxkulonbseg} év volt a leghoszabb időszak két elem felfedezése között.");
        }
        static void feladat8()
        {
            Console.WriteLine("8.feladat: Statisztika");
            Dictionary<int, int> ev_felfedezes = new Dictionary<int, int>();

            foreach (KemiaiElem item in OsszesElem)
            {
                if (ev_felfedezes.ContainsKey(item.Ev))
                    ev_felfedezes[item.Ev]++;
                else
                    ev_felfedezes.Add(item.Ev, 1);
            }

            foreach (KeyValuePair<int, int> item in ev_felfedezes)
            {
                if (item.Value > 3 && item.Key != 0)
                    Console.WriteLine($"\t{item.Key}: {item.Value} db");
            }
        }
    }
}
