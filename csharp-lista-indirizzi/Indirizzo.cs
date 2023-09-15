using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_lista_indirizzi
{
    public class Indirizzo
    {
        // ATTRIBUTI
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string Province { get; private set; }
        public int ZIP { get; private set; }

        // COSTRUTTORE
        public Indirizzo(string name, string surname, string street, string city, string province, int zip)
        {
            this.Name = name;
            this.Surname = surname;
            this.Street = street;
            this.City = city;
            this.Province = province;
            this.ZIP = zip;
        }

        // METODI
        public override string ToString()
        {
            return $"{this.Name} {this.Surname} abita a {this.Street}, {this.City}, {this.Province}, {this.ZIP};";
        }

        // METODI STATIC
        public static Indirizzo ParseFromLine(string line)
        {

            string[] stringSplits = line.Split(',');

            if (stringSplits.Length != 6)
            {
                throw new Exception($"L'indirizzo ({line}) non è leggibile!");
            }
            else
            {
                //definisco una variabile che ad ogni elemento valido aumenterà
                int counter = 0;

                for (int i = 0; i < stringSplits.Length; i++)
                {
                    stringSplits[i] = stringSplits[i].Trim();
                    if (stringSplits[i].Length > 0)
                    {
                        counter++;
                    }
                }

                if (counter == 6)
                {
                    string nome = stringSplits[0];
                    string cognome = stringSplits[1];
                    string via = stringSplits[2];
                    string citta = stringSplits[3];
                    string provincia = stringSplits[4];
                    int zip = int.Parse(stringSplits[5]);

                    Console.WriteLine($"Indirizzo di {nome} {cognome}: {via}, {citta}, {provincia}, {zip};");

                    Indirizzo nuovoIndirizzo = new Indirizzo(nome, cognome, via, citta, provincia, zip);
                    return nuovoIndirizzo;
                }
                else
                {
                    throw new Exception($"L'indirizzo ({line}) contiene valori non validi!");
                }
            }
        }

    }
}
