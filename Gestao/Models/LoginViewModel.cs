using System.ComponentModel.DataAnnotations;

namespace Gestao.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "O e-mail e obrigatorio")]
    [EmailAddress(ErrorMessage = "Email invalido")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "A senha e obrigatoria")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Display(Name = "Lembrar-me")]
    public bool RememberMe { get; set; }
}
