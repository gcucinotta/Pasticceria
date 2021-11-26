using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pasticceria.Data.Entity
{
    public class Dolce
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public DateTime DataVendita { get; set; }
        public int Qta { get; set; }
        public decimal Prezzo { get; set; }
        public bool IsVetrina { get; set; }
        [NotMapped]
        public List<Data.Entity.Ingrediente> Ingredienti { get; set; }
        public int IDUtente { get; set; }
    }
}
