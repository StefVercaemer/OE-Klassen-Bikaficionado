using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fietsen.Lib.Entities
{
    public class Fiets
    {
        static Random random = new Random();

        public Guid Id { get; set; }

        public string[] Merken { get; set; } = { "Bamboo", "Novy", "Trek" };

        public int AantalWielen { get; set; }

        public DateTime AankoopDatum { get; set; }
        public bool IsElektrisch { get; set; }
        public string Merk { get; set; }

        private float snelheid;

        public float Snelheid
        {
            get { return snelheid; }
            set
            {
                if (value >= 0 && value <= 40)
                {
                    snelheid = value;

                }
                else
                {
                    throw new Exception("De snelheid moet tussen 0 en 40 zijn");
                }
            }
        }

        public Fiets() : this("")
        {
            //Snelheid: willekeurig tussen 0 en 40
        }

        public Fiets(string make, float speed = 0, int aantalWielen = 2,
            bool metBatterij = false, DateTime? aangekochtOp = null, Guid? id = null)
        {
            Merk = make;
            AantalWielen = aantalWielen;
            IsElektrisch = metBatterij;

            Snelheid = (speed == 0) ? Snelheid = random.Next(0, 41) : speed;

            AankoopDatum = (aangekochtOp == null) ? DateTime.Now : (DateTime)aangekochtOp;
            Id =  (id == null) ?  Guid.NewGuid() : (Guid)id;
        }

        public override string ToString()
        {
            return $"{Merk} {Snelheid}";
        }
    }
}
