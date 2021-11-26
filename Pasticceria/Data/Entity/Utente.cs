using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pasticceria.Data.Entity
{
    public class Utente
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string eMail { get; set; }
        public string Password { get; set; }
    }
}
