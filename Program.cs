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
            int casi;
            int prove = 100;

            for (int i = 0; i < 366; i++)
            {
                casi = 0;
                for(int j = 0; j < prove; j++)
                {
                    persone.Clear();
                    CompilaLista(random, i, persone);
                    casi += ConfrontaCompleanni(persone);
                }
                percentuali.Add((double)casi / prove * 100);
            }

            for(int i = 0; i < percentuali.Count; i++)
            {
                Console.WriteLine("{0} persone : {1:F2} %", i, percentuali[i]);
            }
            Console.ReadKey();
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
            int cont = 0;
            foreach(Persona p in persone)
            {
                foreach (Persona p1 in persone)
                {
                    if(p.mese == p1.mese && p.giorno == p1.giorno)
                    {
                        cont++;
                    }
                }
            }
            if(cont > 1)
            {
                return 1;
            }
            return 0;
        }
    }
}
