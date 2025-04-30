using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace EpitmenyAdo.Models
{
    class UtcaKezelo
    {
        List<Utca> utcak = new();

        public void FileBeolvasas(string path)
        {
            File.ReadAllLines(path).Skip(1).ToList().ForEach(x => utcak.Add(new Utca(x)));
        }

        public int UtcaCount()
        {
            return utcak.Count();
        }

        public List<string> TulajdonosEpitmenyei(string bekeres)
        {
            List<string> bekertEmber_hazai = utcak.Where(x => x.TulajdonosAdoszama == bekeres).Select(x=>x.UtcaNeve + " utca " + x.Hazszam).ToList();
            return bekertEmber_hazai;
        }

        public int Ado(string adosav, int alapterulet)
        {
            
            switch (adosav)
            {
                case "A": return 800 * alapterulet;
                case "B": return 600 * alapterulet;
                case "C": return 100 * alapterulet;
                default: return 0;
            }
        }

        public int Ado(string utcanev, string hazszam)
        {
            // return utcak.Where(x => x.UtcaNeve == utcanev && x.Hazszam == hazszam).Select(x => x.FizetendoOsszeg).FirstOrDefault();
            return utcak.FirstOrDefault(x => x.UtcaNeve == utcanev && x.Hazszam == hazszam)?.FizetendoOsszeg ?? 0;
        }

        public string AdosavokAdatai()
        {
            int A_TelkekSzama = utcak.Where(x => x.Adosav == "A").Count();
            int B_TelkekSzama = utcak.Where(x => x.Adosav == "B").Count();
            int C_TelkekSzama = utcak.Where(x => x.Adosav == "C").Count();

            int A_TeljesAdo = utcak.Where(x => x.Adosav == "A").Select(x => x.FizetendoOsszeg).Sum();
            int B_TeljesAdo = utcak.Where(x => x.Adosav == "B").Select(x => x.FizetendoOsszeg).Sum();
            int C_TeljesAdo = utcak.Where(x => x.Adosav == "C").Select(x => x.FizetendoOsszeg).Sum();


            return $"Az A sávba {A_TelkekSzama} telek esik, az adó {A_TeljesAdo} Ft. \n" +
                $"A B sávba {B_TelkekSzama} telek esik, az adó {B_TeljesAdo} Ft. \n" +
                $"A C sávba {C_TelkekSzama} telek esik, az adó {C_TeljesAdo} Ft.";
            
        }

        public List<string> TobbsavbaSoroltUtcak()
        {
            return utcak.GroupBy(x => x.UtcaNeve).Where(x => x.GroupBy(y => y.Adosav).Count() > 1).Select(x=> x.Key).ToList();
            //return utcak.GroupBy(x => x.UtcaNeve).DistinctBy(x => x.Adosav);
        }

        public string LegtobbHazatTartalmazoUtca()
        {
            return utcak.GroupBy(x => x.UtcaNeve).OrderByDescending(x => x.Count()).First().Key;
        }

        public List<string> Utcak_HazSzama()
        {
            return utcak.GroupBy(x => x.UtcaNeve).Select(x => $"{x.Key} utca házainak száma: {x.Count()}").ToList();
        }


        /*
        7. Határozza meg a fizetendő adót tulajdonosonként! A tulajdonos adószámát és a fizetendő
        összeget írassa ki a mintának megfelelően a fizetendo.txt állományba! A fájlban
        minden tulajdonos adatai új sorban szerepeljenek, a tulajdonos adószámát egy szóközzel
        elválasztva kövesse az általa fizetendő adó teljes összege.
         */
        public List<string> FizetendoAdo_Tulajonkent()
        {
            return utcak.GroupBy(x => x.TulajdonosAdoszama).Select(x => $"{x.Key} Tulajdonos fizetendő adója összesen: {x.Sum(y => y.FizetendoOsszeg)}").ToList(); 
        }

    }
}
