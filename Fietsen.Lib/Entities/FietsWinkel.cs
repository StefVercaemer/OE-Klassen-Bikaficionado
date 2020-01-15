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

        public override string ToString()
        {
            return $"{Naam} ({Fietsen.Count})";
        }
    }
}
