using EpitmenyAdo.Models;
using System;


// 2022 május (emelt informatika) - Építményadó
namespace EpitmenyAdo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            UtcaKezelo kezelo = new UtcaKezelo();
            kezelo.FileBeolvasas("utca.txt");
            Console.WriteLine("2. feladat:  Amintában szereplő elemek száma:  " + kezelo.UtcaCount());
            /*
            Console.Write("3. felladat: Egy adószám:    ");
            string bekeres = Console.ReadLine();
            foreach (string item in kezelo.TulajdonosEpitmenyei(bekeres))
            {
                Console.WriteLine(item);
            }
            */

            Console.WriteLine("5. feladat \n" + kezelo.AdosavokAdatai());
            Console.WriteLine("6. feladat:   Több sávba sorolt utcák:  \n" + string.Join("\n", kezelo.TobbsavbaSoroltUtcak()));
            Console.WriteLine("+feladatok");
            Console.WriteLine(string.Join("\n", kezelo.Utcak_HazSzama()));
            Console.WriteLine(string.Join("\n", kezelo.FizetendoAdo_Tulajonkent()));

        }
    }
}