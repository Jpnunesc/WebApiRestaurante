using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiRestaurante.Models
{
    public class PratoDTO
    {
        public int PratoID { get; set; }
        public string NomePrato { get; set; }
        public decimal PrecoPrato { get; set; }

        public int RestauranteID { get; set; }
        public string NomeRestaurante { get; set; }
    }
}