using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            int prove = 200;
            string percorsoFile = "C:\\Users\\gabri\\OneDrive\\Desktop\\Percentuali.txt";

            // Pulizia file
            IniziaFile(percorsoFile);

            // Programma
            for (int i = 0; i <= 366; i++)
            {
                casi = 0;
                for(int j = 0; j < prove; j++) // Esegui il numero specificato di prove per il numero di persone attuale
                {
                    persone.Clear();
                    CompilaLista(random, i, persone);
                    casi += ConfrontaCompleanni(persone);
                }
                percentuali.Add((double)casi / (double)prove * 100);
            }

            // Output a schermo
            for(int i = 0; i < percentuali.Count; i++)
            {
                Console.WriteLine("{0} persone : {1:F2} %", i, percentuali[i]);
            }

            // Compilazione file
            CompilaFile(percorsoFile, percentuali);
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
            for (int i = 0; i < persone.Count; i++)
            {
                for (int j = i + 1; j < persone.Count; j++)
                {
                    if (persone[i].mese == persone[j].mese && persone[i].giorno == persone[j].giorno)
                    {
                        return 1; // Se trova una coppia restituisce 1
                    }
                }
            }
            return 0; // Se non trova coppie restituisce 0
        }
        static void IniziaFile(string percorsoFile)
        {
            if (File.Exists(percorsoFile) == true)
            {
                File.Delete(percorsoFile);
            }
            File.AppendAllText(percorsoFile,
            string.Format("Persone\tPercentuali\r\n"));
        }
        static void CompilaFile(string percorsoFile, List <double> percentuali)
        {
            for (int i = 0; i < percentuali.Count; i++)
            {
                File.AppendAllText(percorsoFile,
                string.Format("{0}\t{1}\r\n", i, percentuali[i]));
            }
        }
    }
}
