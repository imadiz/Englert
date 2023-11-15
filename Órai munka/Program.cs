using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Órai_munka
{
    internal class Program
    {
        public class Ember
        {
            public int kor;
            public int magassag;

            protected internal int Nap()
            {
                return this.kor * 365;
            }
            protected internal Ember(int kor, int magassag)
            {
                this.kor = kor;
                this.magassag = magassag;
            }
        }
        static void Main(string[] args)
        {
            Ember Egyik = new Ember(65, 300);
            Ember Hati = new Ember(80, 155);
            Ember Wombat = new Ember(45, 190);            

            Console.WriteLine($"Az egyik ember {Egyik.Nap()} napos.");
            Console.ReadKey();
        }
    }
}
