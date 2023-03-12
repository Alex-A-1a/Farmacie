using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacie
{
    public class Medicament
    {
        public string nume
        {
            set; get;
        }
        public string producator
        {
            set; get;
        }
        public int cod
        {
            set; get;
        }
        public int stoc
        {
            set; get;
        }
        public int pret
        {
            set; get;
        }
        public Natura natura
        {
            set; get;
        }
        public Eliberare mod_eliberare
        {
            get; set;
        }
        public DateTime dataActualizare = new DateTime();
        public Medicament()
        {
            nume = null;
            producator = null;
            cod = 0;
            pret = 0;
            stoc = 0;
        }
        public Medicament(string info)
        {
            string[] sir = info.Split(',');
            nume = sir[0];
            producator = sir[1];
            natura = (Natura)Enum.Parse(typeof(Natura), sir[2]);
            cod = int.Parse(sir[3]);
            pret = int.Parse(sir[4]);
            stoc = int.Parse(sir[5]);
            mod_eliberare = (Eliberare)Enum.Parse(typeof(Eliberare), sir[6]);
        }
        public Medicament(string den, string _producator, string _natura, int _cod, int _pret, int _stoc, string _el)
        {
            nume = den;
            producator = _producator;
            cod = _cod;
            natura = (Natura)Enum.Parse(typeof(Natura), _natura);
            pret = _pret;
            stoc = _stoc;
            mod_eliberare = (Eliberare)Enum.Parse(typeof(Eliberare), _el);
        }
        public string afisare()
        {
            return string.Format("{0, -5} {1, -10} {2, -15} {3, -10} {4, -10} {5, -10} {6, -10}", nume, producator, natura, cod, pret, stoc, mod_eliberare);
        }
        public void Add_Medicament()
        {
            try
            {
                using (StreamWriter swFisierText = new StreamWriter("medicamente.txt"))
                {

                    swFisierText.WriteLine(String.Format(nume.PadRight(10) + "," + producator.PadRight(10) + "," + Convert.ToString(natura) + "," + cod + "," + pret + "," + stoc + "," + mod_eliberare.ToString()));
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
        }
        ~Medicament()
        {

        }
        public Medicament(int nr)
        {
            Console.Write("Denumire produs: ");
            nume = Console.ReadLine();
            Console.Write("Producator: ");
            producator = Console.ReadLine();
            Console.Write("Codul produsului: ");
            cod = Int32.Parse(Console.ReadLine());
            Console.Write("Pret: ");
            pret = Int32.Parse(Console.ReadLine());
            Console.Write("Stocul este de: ");
            stoc = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Format:\n1. unguent\n2. sirop\n3. gel");
            natura = (Natura)Enum.Parse(typeof(Natura), Console.ReadLine());
            Console.WriteLine("Predat:\n1.Reteta\n2.Fara_reteta");
            mod_eliberare = (Eliberare)Enum.Parse(typeof(Eliberare), Console.ReadLine());
        }
    }
}