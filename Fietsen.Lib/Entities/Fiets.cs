using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fietsen.Lib.Entities
{
    public class Fiets
    {
        public string[] Merken { get; set; } = { "Bamboo", "Novy", "Trek" };

        public int AantalWielen { get; set; }

        public DateTime AankoopDatum { get; set; }
        public bool IsElektrisch { get; set; }
        public string Merk { get; set; }
        public float Snelheid { get; set; }

        public Fiets() : this("")
        {

        }

        public Fiets(string make, float speed = 0, int aantalWielen = 2,
            bool metBatterij = false, DateTime? aangekochtOp = null)
        {
            Merk = make;
            Snelheid = speed;
            AantalWielen = aantalWielen;
            IsElektrisch = metBatterij;
            if (aangekochtOp == null)
            {
                AankoopDatum = DateTime.Now;
            }
            else
            {
                AankoopDatum = (DateTime)aangekochtOp;
            }
        }

        public override string ToString()
        {
            return $"{Merk} {Snelheid}";
        }
    }
}
