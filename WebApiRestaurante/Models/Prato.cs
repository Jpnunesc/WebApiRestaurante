using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApiRestaurante.Models
{
    [Table("Prato")]
    public class Prato
    {

        [Key]
        public int PratoID { get; set; }
        public string NomePrato { get; set; }
        public decimal PrecoPrato { get; set; }

        public int RestauranteID { get; set; }

        [ForeignKey("RestauranteID")]
        public Restaurante Restaurante { get; set; }
    }
}