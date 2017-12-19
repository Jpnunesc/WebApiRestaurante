using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApiRestaurante.Models
{
    [Table("Restaurante")]
    public class Restaurante
    {
        [Key]
        public int RestauranteID { get; set; }
        public string NomeRestaurante { get; set; }

        public virtual ICollection<Restaurante> Restaurantes { get; set; }

    }
}