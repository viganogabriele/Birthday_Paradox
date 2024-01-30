using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatiStessoGiorno
{
    internal class Persona
    {
        public Persona() { }
        public int mese;
        public int giorno;
        public int anno;
        public void GeneraDataNascita(Random random) 
        {
            mese = random.Next(1, 13);
            giorno = random.Next(1, 32);
            anno = random.Next(0, 2024);
            if(giorno <= DateTime.DaysInMonth(anno, mese))
            {
                giorno = random.Next(1, 32);
            }
        }
    }
}
