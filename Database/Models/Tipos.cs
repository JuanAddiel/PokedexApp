using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Tipos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<Pokemon> Pokemon { get; set; }

    }
}
