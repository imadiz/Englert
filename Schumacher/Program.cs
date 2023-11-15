using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schumacher
{
    internal class Program
    {
        class Result
        {
            internal DateTime Date;
            internal string Name;
            internal int Pos;
            internal int FinishedLaps;
            internal int Points;
            internal string Team;
            internal string Status;
        }
        static List<Result> All_Results = new List<Result>();
        static void Main(string[] args)
        {
            feladat2();
            feladat3();
            feladat4();
            feladat5();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static void feladat2()
        {
            foreach (string item in File.ReadAllLines("schumacher.csv").Skip(1))
            {
                string[] spliced = item.Trim().Split(';');
                All_Results.Add(new Result
                {
                    Date = Convert.ToDateTime(spliced[0]),
                    Name = spliced[1],
                    Pos = Convert.ToInt32(spliced[2]),
                    FinishedLaps = Convert.ToInt32(spliced[3]),
                    Points = Convert.ToInt32(spliced[4]),
                    Team = spliced[5],
                    Status = spliced[6]
                });
            }
        }
        static void feladat3()
        {
            Console.WriteLine($"3.feladat: Az állomány {All_Results.Count}");
        }
        static void feladat4()
        {
            List<Result> hunprix = All_Results.Where(x => (x.Status.Equals("Finished") || x.Status.Contains("Lap"))//Ha a status egynelő "Finished"-el vagy tartalmazza a "Lap"-ot
                                                     && x.Name.Contains("Hungarian") && x.Pos != 0).ToList();//Ha az elért pozíció nem 0 és a Name tartalmazza a "Haungarian"-t
            Console.WriteLine("4.feladat helyezései");
            foreach (Result item in hunprix)
            {
                Console.WriteLine($"\t{item.Date:yyyy/MM/dd} | {item.Pos}. hely");
            }
        }
        static void feladat5()
        {
            Console.WriteLine("5.feladat: Hibastatisztika");

            Dictionary<string, int> failures = new Dictionary<string, int>();

            foreach (Result item in All_Results)
            {
                if (!(item.Status.Equals("Finished") || item.Status.Contains("Lap")))
                    if (failures.ContainsKey(item.Status))
                        failures[item.Status]++;
                    else
                        failures.Add(item.Status, 1);

            }

            foreach (KeyValuePair<string, int> item in failures)
            {
                if (item.Value > 2)
                {
                    Console.WriteLine($"\t{item.Key}: {item.Value}");
                }
            }
        }
    }
}
