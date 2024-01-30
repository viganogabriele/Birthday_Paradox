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
            anno = random.Next(1, 2024);
            giorno = random.Next(1, DateTime.DaysInMonth(anno, mese) + 1);
        }
    }
}
