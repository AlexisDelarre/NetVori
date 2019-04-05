using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetVori.Entite
{
    public class JVaisseau
    {
        public string Nom { get; set; }
        public double PoindDeVie { get; set; }
        public int PuissanceDeTir { get; set; }
        public int Bouclier { get; set; }
        public List<Technique> ListTechnique { get; set; }
    }
}
