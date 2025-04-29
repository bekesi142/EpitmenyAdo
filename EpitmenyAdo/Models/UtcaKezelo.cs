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

            int A_AlapteruletTeljes = utcak.Where(x => x.Adosav == "A").Select(x=> x.HazAlapterulet).ToList().Sum();
            int B_AlapteruletTeljes = utcak.Where(x => x.Adosav == "B").Select(x => x.HazAlapterulet).ToList().Sum();
            int C_AlapteruletTeljes = utcak.Where(x => x.Adosav == "C").Select(x => x.HazAlapterulet).ToList().Sum();


            return $"Az A sávba {A_TelkekSzama} telek esik, az adó {Ado("A", A_AlapteruletTeljes)} Ft. \n" +
                $"A B sávba {B_TelkekSzama} telek esik, az adó {Ado("B", B_AlapteruletTeljes)} Ft. \n" +
                $"A C sávba {C_TelkekSzama} telek esik, az adó {Ado("C", C_AlapteruletTeljes)} Ft.";
            
        }

        public List<string> TobbsavbaSoroltUtcak()
        {

        }


    }
}
