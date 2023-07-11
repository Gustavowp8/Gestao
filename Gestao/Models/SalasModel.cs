using System.ComponentModel.DataAnnotations;

namespace Gestao.Models
{
    public class SalasModel
    {
        [Key]
        public int IdSala { get; set; }

        [Required, MaxLength(20)]
        public string Nome { get; set; }
    }
}
