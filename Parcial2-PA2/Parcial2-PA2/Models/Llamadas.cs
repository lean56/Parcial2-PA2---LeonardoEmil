using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial2_PA2.Models
{
    public class Llamadas
    {
        [Key]
        public int LlamadaId { get; set; }
        [Required(ErrorMessage ="Debes Agregar una Descripcion")]
        public string Descripcion { get; set; }
    
        [ForeignKey("LlamadaDetalleId")]
        public List<LlamadaDetalles> Detalles { get; set; }
        public Llamadas()
        {
            LlamadaId = 0;
            Descripcion = string.Empty;
            Detalles = new List<LlamadaDetalles>();
        }
                    
    }
}
