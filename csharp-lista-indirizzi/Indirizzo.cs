using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_lista_indirizzi
{
    public class Indirizzo
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string Province { get; private set; }
        public int ZIP { get; private set; }

        public Indirizzo(string name, string surname, string street, string city, string province, int zip)
        {
            this.Name = name;
            this.Surname = surname;
            this.Street = street;
            this.City = city;
            this.Province = province;
            this.ZIP = zip;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Surname} abita a {this.Street}, {this.City}, {this.Province}, {this.ZIP};";
        }
    }
}
