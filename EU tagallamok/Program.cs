using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EU_tagallamok
{
    internal class Program
    {
        public class Tagallam
        {
            public string nev;
            public DateTime csatlakozas;

            protected internal Tagallam(string nev, DateTime csatlakozas)
            {
                this.nev = nev;
                this.csatlakozas = csatlakozas;
            }
        }
        static List<Tagallam> Osszes = new List<Tagallam>();
        static CultureInfo ci = CultureInfo.GetCultureInfo("hu-HU");
        static void Main(string[] args)
        {
            beolvasas();
            Console.ReadKey();
        }
        static void beolvasas()
        {
            foreach (string item in File.ReadAllLines("EUcsatlakozas.txt", Encoding.Default))
            {
                Osszes.Add(new Tagallam(item.Split(';')[0], Convert.ToDateTime(item.Split(';')[1])));
                Console.WriteLine($"Új tagállam: {Osszes.Last().nev} | {Osszes.Last().csatlakozas.ToString("yyyy-MM-dd",ci)}");
            }
        }
    }
}