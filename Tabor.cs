using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erdos_Barnabas_02_23
{
    internal class Tabor
    {
        public int KezdoHonap { get; set; }
        public int KezdoNap { get; set; }
        public int VegHonap { get; set; }
        public int VegNap { get; set; }
        public string Diakok { get; set; }
        public string Tema { get; set; }

        public Tabor(string line)
        {
            string[] temp = line.Split('\t');
            KezdoHonap = int.Parse(temp[0]);
            KezdoNap = int.Parse(temp[1]);
            VegHonap = int.Parse(temp[2]);
            VegNap = int.Parse(temp[3]);
            Diakok = temp[4];
            Tema = temp[5];
            
        }
    }
}
