using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpitmenyAdo.Models
{
    class Utca
    {
        //38522 Aradi 1 C 180

        string tulajdonosAdoszama, utcaNeve, hazszam, adosav;
        int hazAlapterulet;

        public Utca(string sor)
        {
            var mezo = sor.Split(" ");
            tulajdonosAdoszama = mezo[0];
            utcaNeve = mezo[1];
            hazszam = mezo[2];
            adosav = mezo[3];
            HazAlapterulet = int.Parse(mezo[4]);
        }

        public Utca(string tulajdonosAdoszama, string utcaNeve, string hazszam, string adosav, int hazAlapterulet)
        {
            this.TulajdonosAdoszama = tulajdonosAdoszama;
            this.UtcaNeve = utcaNeve;
            this.Hazszam = hazszam;
            this.Adosav = adosav;
            this.HazAlapterulet = hazAlapterulet;
        }

        public string TulajdonosAdoszama { get => tulajdonosAdoszama; set => tulajdonosAdoszama = value; }
        public string UtcaNeve { get => utcaNeve; set => utcaNeve = value; }
        public string Hazszam { get => hazszam; set => hazszam = value; }
        public string Adosav { get => adosav; set => adosav = value; }
        public int HazAlapterulet { get => hazAlapterulet; set => hazAlapterulet = value; }
        public int FizetendoOsszeg
        {
            get
            {
                switch (adosav)
                {
                    case "A": return 800 * hazAlapterulet;
                    case "B": return 600 * hazAlapterulet;
                    case "C": return 100 * hazAlapterulet;
                    default: return 0;
                }
            }
        }
    }
}
