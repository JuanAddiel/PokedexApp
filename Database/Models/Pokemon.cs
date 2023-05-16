using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
        public int TipoId { get; set; }
        public Tipos Tipos { get; set; }
        public string ImgUrl { get; set; }

    }
}
