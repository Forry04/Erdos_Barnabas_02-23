namespace Erdos_Barnabas_02_23
{
    internal class Program
    {
        static List<Tabor> Taborok = new();
        static void Main(string[] args)
        {
             using StreamReader streamReader = new StreamReader("taborok.txt");

            while (!streamReader.EndOfStream)
            {

                Taborok.Add(new(streamReader.ReadLine()));
            }

            Console.WriteLine($"{Sorszam(6,16)}");
           
            //2. feladat
            Console.WriteLine("2.feladat");
            Console.WriteLine($"Az adatsorok száma: {Taborok.Count}");
                 
            Console.WriteLine($"Az először rögzített tábor témája: {Taborok.First().Tema}");
            Console.WriteLine($"Az utoljára rögzített tábor témája: {Taborok.Last().Tema}");

            //3. feladat
            Console.WriteLine("3. feladat");

            var fel3 = Taborok.Where(x => x.Tema == "zenei").ToList();
            if (fel3.Count>0)
            {
                
                foreach (var item in fel3)
                {
                    Console.WriteLine($"Zenei tábor kezdődik {item.KezdoHonap}. hó {item.KezdoNap}. napján.");
                }

            }
            else
            {
                Console.WriteLine("Nem volt zenei tábor");
            }

            //4. feladat
            Console.WriteLine("4. feladat");

            var fel4 = Taborok.OrderByDescending(x => x.Diakok.Length).ToList();
            Console.WriteLine("Legnépszerűbbek");
            for (int i = 0; i < fel4.Count(); i++)
            {
                if (fel4[0].Diakok.Length == fel4[i].Diakok.Length)
                {
                    Console.WriteLine($"{fel4[i].KezdoHonap} {fel4[i].KezdoNap} {fel4[i].Tema}");
                }
            }

            //6.feladat
            Console.WriteLine("6. Feladat");
            Console.Write("Hó: ");
            int honap = int.Parse(Console.ReadLine());
            Console.Write("Nap: ");
            int nap = int.Parse(Console.ReadLine());
            DateTime dt = new DateTime(2023, honap, nap);
            var fel6 = Taborok.Where(x => new DateTime(2023,x.KezdoHonap,x.KezdoNap) <= dt && dt <= new DateTime(2023, x.VegHonap, x.VegNap));
            Console.WriteLine($"Ekkor éppen {fel6.Count()} tábor tart.");

            //7. feladat
            Console.WriteLine("7. feladat");
            Console.Write("Adja meg egy tanuló betűjelét: ");
            string tanulo = Console.ReadLine();
            var fel7 = Taborok.Where(x => x.Diakok.Contains(tanulo.ToUpper())).OrderBy(k=> new DateTime(2023, k.KezdoHonap, k.KezdoNap)).ToList();

            using StreamWriter sw = new StreamWriter("egytanulo.txt");
            foreach (var item in fel7)
            {
                sw.WriteLine($"{item.KezdoHonap}.{item.KezdoNap}-{item.VegHonap}.{item.VegNap}. {item.Tema}");
            }
            sw.Close();
           

            bool mehet = true;
            for (int i = 0; i < fel7.Count-1; i++)
            {
                if (Sorszam(fel7[i].VegHonap, fel7[i].VegNap) > Sorszam(fel7[i + 1].KezdoHonap, fel7[i + 1].KezdoNap))
                {
                    mehet = false;
                    break;
                }
            }

            Console.WriteLine(mehet? "El mehet mindegyik táborba.": "Nem mehet el mindegyik táborba.");

            Console.ReadLine();



        }
        //5. feladat
        public static int Sorszam(int honap, int nap)
        {
            int juniusNapok = 30;
            int juliusNapok = 31;

            if (honap == 6)
            {
                return nap-15;
            }
            else if (honap == 7)
            {
                return juniusNapok + nap-15;
            }
            else if (honap == 8)
            {
                return juniusNapok + juliusNapok + nap - 15;
            }
            else
            {
                return 0;
            }
        }

    }
}