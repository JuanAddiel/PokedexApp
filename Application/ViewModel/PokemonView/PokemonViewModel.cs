using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.PokemonView
{
    public class PokemonViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ImgUrl { get; set; }
    }
}
