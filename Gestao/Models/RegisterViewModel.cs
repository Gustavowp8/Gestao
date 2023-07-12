using System.ComponentModel.DataAnnotations;

namespace Gestao.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "E-mail e obrigatorio")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Senha e obrigatorio")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("Password", ErrorMessage = "As não são identicas")]
        public string? ConfirmPassword { get; set; }
    }
}
