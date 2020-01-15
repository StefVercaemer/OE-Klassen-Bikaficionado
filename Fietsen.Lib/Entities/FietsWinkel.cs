using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fietsen.Lib.Entities
{
    public class FietsWinkel
    {
        
        public string Naam { get; set; }

        public List<Fiets> Fietsen { get; set; }

        public FietsWinkel(string naam, bool metTestData = true)
        {
            if (metTestData) MaakTestData();
            else Fietsen = new List<Fiets>();

            Naam = naam;
        }

        void MaakTestData()
        {
            Fietsen = new List<Fiets>
            {
                new Fiets("Trek", 20.5F, 2),
                new Fiets("Bamboo", 0, 3, true),
                new Fiets("Orbea", 10)
            };
        }

        public bool SlaOp(Fiets opTeSlaan)
        {
            bool isGelukt = true;
            if (!IsBestaandeFiets(opTeSlaan))
            {
                Fietsen.Add(opTeSlaan);
            }
            else
            {
                int index = GeefIndexVanFiets(opTeSlaan);
                Fietsen[index] = opTeSlaan;
            }

            return isGelukt;
        }

        int GeefIndexVanFiets(Fiets fiets)
        {
            int index = -1;
            for (int i = 0; i < Fietsen.Count; i++)
            {
                if (Fietsen[i].Id == fiets.Id)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        bool IsBestaandeFiets(Fiets fiets)
        {
            bool bestaat = false;
            foreach (Fiets velo in Fietsen)
            {
                if (velo.Id == fiets.Id)
                {
                    bestaat = true;
                    break;
                }
            }
            return bestaat;
        }

        public void Verwijder(Fiets teVerwijderen)
        {
            Fietsen.Remove(teVerwijderen);
        }

        public bool VoegVeloToe(Fiets toeTeVoegen)
        {
            bool isGelukt = true;
            foreach (Fiets velo in Fietsen)
            {
                if (velo.Id == toeTeVoegen.Id)
                {
                    isGelukt = false;
                    break;
                }
            }
            if (isGelukt) Fietsen.Add(toeTeVoegen);

            return isGelukt;
        }

        bool VoegFietsToe(Fiets toeTeVoegen)
        {
            bool isGelukt = false;
            if (!Fietsen.Contains(toeTeVoegen))
            {
                Fietsen.Add(toeTeVoegen);
            }
            return isGelukt;
        }

        public override string ToString()
        {
            return $"{Naam} ({Fietsen.Count})";
        }
    }
}
