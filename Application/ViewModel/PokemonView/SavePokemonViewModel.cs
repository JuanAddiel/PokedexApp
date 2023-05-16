using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.PokemonView
{
    public class SavePokemonViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int RegionId { get; set; }
        public int TipoId { get; set; }
        public string ImgUrl { get; set; }
    }
}
