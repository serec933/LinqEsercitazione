using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqEsercitazione
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Per ogni colore sono disponibli il seguente numero di veicoli:");
            Esercizio.NumeroMacchine();
            Console.WriteLine("-----");
            Console.WriteLine("Persona, prezzo medio e peso complessivo: ");
            Esercizio.QuanteMacchinePerPersona();

            Console.WriteLine("--------");
            Console.WriteLine("TEST EXTENSION METHODS");
            Person p = new Person { ID = 1, Nome = "ffff", Cognome = "ggggg", Nazione = "ggg" };
            var veicoli = Esercizio.CreaListaVeicoli();
            List<VeicoliRidotta> vvv = p.VeicoliPosseduti(veicoli);
            Console.WriteLine("La persona " + p.ID + " possiede i seguenti veicoli: ");
            foreach (var item in vvv)
            {
                Console.WriteLine("ID veicolo: " + item.ID + " Prezzo veicolo :" + item.Prezzo + " Targa veicolo: " + item.Targa);
            }
            Console.ReadKey();

        }
    }
}
