using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pasticceria.Data.Entity
{
    public class Ingrediente
    {
        public int ID { get; set; }
        public int IDDolce { get; set; }
        public string Nome { get; set; }
        public int Qta { get; set; }
        public string UnitaMisura { get; set; }
        [NotMapped]
        public bool IsCancelled { get; set; }
    }
}
