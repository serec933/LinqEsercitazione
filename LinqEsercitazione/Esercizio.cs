using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqEsercitazione
{
    public class Esercizio
    {
        public static List<Person> CreaListaPersone()
        {
            var PersonList = new List<Person>
            {
                new Person { ID = 1, Nome="Mario", Cognome="Rossi", Nazione="Italiana"},
                new Person { ID = 2, Nome="Francesca", Cognome="Bianchi", Nazione="Italiana"},
                new Person { ID = 3, Nome="Pietro", Cognome="Verdi", Nazione="Italiana"},
                new Person { ID = 4, Nome="Roberta", Cognome="Gialli", Nazione="Francese"}


            };
            return PersonList;
        }
        public static List<Veicoli> CreaListaVeicoli()
        { 
            var CarList = new List<Veicoli>
            {
                new Veicoli {ID= 1, Targa = "XYXYXY1", Colore ="Nero", Prezzo =5000, IDProprietario = 2, Peso = 1000},
                new Veicoli {ID= 2, Targa = "XYXYXY2", Colore ="Rosso", Prezzo =8000, IDProprietario = 4,Peso = 2000},
                new Veicoli {ID= 3, Targa = "XYXYXY3", Colore ="Rosso", Prezzo =6000, IDProprietario = 1, Peso = 1500},
                new Veicoli {ID= 4, Targa = "XYXYXY4", Colore ="Blu", Prezzo =9000, IDProprietario = 4, Peso = 1800},
                new Veicoli { ID=5, Targa="XYXYXY5", Colore= "Grigio", Prezzo=10000, IDProprietario=1,Peso=2000}
            };
            return CarList;


        }
        public static void NumeroMacchine()
        {
            var carList = CreaListaVeicoli();
            // Scrivere una query LINQ che conti il numero di macchine per colore

            var ContaPerColore = from c in carList
                              group c by (c.Colore) into groupList
                              select new { Colore = groupList.Key, Quantities = groupList.Count() };

            foreach (var item in ContaPerColore)
            {
                Console.WriteLine("{0} - {1}", item.Colore, item.Quantities);
            }

        }
        public static void QuanteMacchinePerPersona()
        {
            var carList = CreaListaVeicoli();
            var personList = CreaListaPersone();
            // Scrivere una query LINQ che restituisca Peso complessivo e Prezzo Medio dei Veicoli posseduti da ciascuna Persona
            var groupjoin1 =
                     from c in carList
                     group c by c.IDProprietario
                     into gr
                     select new
                     {
                         idProp = gr.Key,
                         prezzo = gr.Average(c => c.Prezzo),
                         peso = gr.Sum(c => c.Peso)
                     }
                     into gr1
                     join p in personList
                     on gr1.idProp equals p.ID
                     select new { p.ID, gr1.prezzo, gr1.peso };

            foreach (var item in groupjoin1)
            {
                Console.WriteLine($"La persona {item.ID} ha dei veicoli il cui prezzo medio è : {item.prezzo} e il peso totale è: {item.peso}");
            }

        }
       
    }
}
