using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetVori.Entite
{
    public class Technique
    {
        public string Nom { get; set; }
        public int Degat { get; set; }
        public int Precision { get; set; }
        
        public Technique(string nom, int degat)
        {
            Nom = nom;
            Degat = degat;
        }
    }
}
