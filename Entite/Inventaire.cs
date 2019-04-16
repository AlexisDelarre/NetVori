using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetVori.Entite
{
    public class Inventaire
    {
        public List<Technique> Inventary { get; set; }

        public Inventaire()
        {
            if (Inventary == null)
                Inventary = new List<Technique>();
        }

        public bool AddCompetence(Technique tech)
        {
            if (Inventary.Count >= 6)
                return false;
            else
            {
                Inventary.Add(tech);
                return true;
            }
        }

        public bool DeleteCompetence(Technique tech)
        {
            if(Inventary[0].Nom == tech.Nom)
            {
                Inventary.Remove(Inventary[0]);
            }
            if (Inventary[1].Nom == tech.Nom)
            {
                Inventary.Remove(Inventary[1]);
            }
            if (Inventary[2].Nom == tech.Nom)
            {
                Inventary.Remove(Inventary[2]);
            }
            if (Inventary[3].Nom == tech.Nom)
            {
                Inventary.Remove(Inventary[3]);
            }
            if (Inventary[4].Nom == tech.Nom)
            {
                Inventary.Remove(Inventary[4]);
            }
            if (Inventary[5].Nom == tech.Nom)
            {
                Inventary.Remove(Inventary[5]);
            }
            return true;
        }

    }
}
