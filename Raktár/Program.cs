using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Raktár
{
    class Program
    {
        static List<Termek> termekek = new List<Termek>();
        static List<Megrendeles> rendelesek = new List<Megrendeles>();
        static void BeolvasRaktar()
        {
            StreamReader raktar = new StreamReader("raktar.csv");
            while (!raktar.EndOfStream)
            {
                string[] sor = raktar.ReadLine().Split(';');
                termekek.Add(new Termek(sor[0], sor[1], int.Parse(sor[2]), int.Parse(sor[3]))); 
            }
            raktar.Close();
        }
        static void BeolvasRendeles()
        {
            StreamReader rendeles = new StreamReader("rendeles.csv");
            while (!rendeles.EndOfStream)
            {
                string sor = rendeles.ReadLine();
                string[] adat = sor.Split(';');
                if (adat[0] == "M")
                {
                    rendelesek.Add(new Megrendeles(adat[1], adat[2], adat[3]));
                }
                else
                {
                    //rendelesek[rendelesek.Count - 1].termekek.Add(sor);
                    rendelesek[rendelesek.Count - 1].TetelHozzaad(adat[2], Convert.ToInt32(adat[3]));
                }
            }
            rendeles.Close();
        }
        static void Main(string[] args)
        {
            BeolvasRaktar();
            BeolvasRendeles();
            foreach (var t in termekek)
            {

                Console.WriteLine(t.Nev);
            }
            foreach (var r in rendelesek)
            {
                Console.WriteLine(r.Email);
            }
            Console.ReadKey();
        }
    }
}
