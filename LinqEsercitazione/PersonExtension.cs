using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqEsercitazione
{
    public static class PersonExtension
    {
        
        public static List<VeicoliRidotta> VeicoliPosseduti(this Person value, List<Veicoli> ElencoVeicoli)
        {
            int IDPersona = value.ID;
            var veicoliposseduti = (from e in ElencoVeicoli
                                   where (e.IDProprietario == IDPersona)
                                   select new VeicoliRidotta() { ID = e.ID, Prezzo = e.Prezzo, Targa = e.Targa }).ToList();

            //List<VeicoliRidotta> lista = new List<VeicoliRidotta>();
            //foreach (var item in veicoliposseduti)
            //{
            //    VeicoliRidotta v = new VeicoliRidotta() { ID= item.ID, Prezzo=item.Prezzo,Targa=item.Targa};
            //    lista.Add(v);
            //}

            return veicoliposseduti;

        }

        public static void VeicoliPossedutiStampa(this Person value, List<Veicoli> ElencoVeicoli)
        {
            int IDPersona = value.ID;
            var veicoliposseduti = from e in ElencoVeicoli
                                   where (e.IDProprietario == IDPersona)
                                   select new { ID = e.ID, Prezzo = e.Prezzo, Targa = e.Targa };
            Console.WriteLine("La persona " + IDPersona + " possiede i seguenti veicoli: ");
            foreach (var item in veicoliposseduti)
            {
                Console.WriteLine("ID veicolo: " +item.ID+ " Prezzo veicolo :" +item.Prezzo+ " Targa veicolo: "+ item.Targa);
            }

        }
        public static List<Veicoli> VeicoliPosseduti1(this Person value, List<Veicoli> ElencoVeicoli)
        {
            int IDPersona = value.ID;

            List<Veicoli> VeicoliPosseduti = new List<Veicoli>();

            foreach (var item in ElencoVeicoli)
            {
                if (item.IDProprietario == IDPersona)
                    VeicoliPosseduti.Add(item);
            }
            return VeicoliPosseduti;      
        }
    }
}
