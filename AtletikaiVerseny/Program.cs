using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AtletikaiVerseny
{
    class Program
    {
        static List<atleta> Atletak = new List<atleta>();
        static void olv(string file)
        {
            StreamReader ol = new StreamReader(file);
            while (!ol.EndOfStream)
            {
                Atletak.Add(new atleta(ol.ReadLine()));
            }
            ol.Close();
        }
        static void nevugr()
        {
            foreach (var item in Atletak)
            {
                Console.WriteLine($"{item.VezNev,10} {item.KezNev,-10} \t {item.Ugras}");
            }
        }
        static void egye()
        {
            List<string> egyesület = new List<string>();
            foreach (var item in Atletak)
            {
                if (!egyesület.Contains(item.Egyesulet))
                {
                    egyesület.Add(item.Egyesulet);
                }
            }
            foreach (var item in egyesület)
            {
                Console.WriteLine(item);
            }
        }
        static void nagy()
        {
            int id = 0;
            for (int i = 1; i < Atletak.Count; i++)
            {
                if (Atletak[id].Ugras<Atletak[i].Ugras)
                {
                    id = i;
                }
            }
            Console.WriteLine($"{Atletak[id].Nev()}: {Atletak[id].Ugras} cm");

        }
        static int atl()
        {
            double atl = 0;
            foreach (var item in Atletak)
            {
                atl += item.Ugras;
            }
            atl = atl / Atletak.Count;
            int alatt = 0;
            foreach (var item in Atletak)
            {
                if (item.Ugras<atl)
                {
                    alatt++;
                }
            }
            return alatt;
        }
        static void ir()
        {
            StreamWriter ir = new StreamWriter("versenyzok.txt");
            foreach (var item in Atletak)
            {
                ir.WriteLine(item.Rajtszam + ";" + item.Nev());
            }
            ir.Close();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("1. feladat: adatok beolvasása\n");
            olv("tavol.csv");
            Console.WriteLine("2. feladat: Nevek és ugrások");
            nevugr();
            Console.WriteLine("\n3. feladat: Egyesületek:");
            egye();
            Console.WriteLine("\n4. feladat: Legnagyobb ugrás:");
            nagy();
            Console.WriteLine("\n5. feladat: Átlag alatt lévő ugrások száma: {0}",atl());
            Console.WriteLine("\n6. feladat: Adatok fájlba írása");
            ir();
            Console.ReadKey();
        }
    }
}
