using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatiStessoGiorno
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            List <Persona> persone = new List <Persona>();
            List <double> percentuali = new List <double>();
            int casi = 0;
            int prove = 100;

            for (int i = 0; i < 366; i++)
            {
                casi = 0;
                for(int j = 0; j < prove; j++)
                {
                    CompilaLista(random, i, persone);
                    casi += ConfrontaCompleanni(persone);
                }
                percentuali[i] = casi / prove;
            }
        }
        static void CompilaLista(Random random, int nPersone, List <Persona> persone)
        {
            for(int i = 0; i < nPersone; i++)
            {
                Persona p = new Persona();
                p.GeneraDataNascita(random);
                persone.Add(p);
            }
        }
        static int ConfrontaCompleanni(List <Persona> persone)
        {
            return 0;
        }
    }
}
