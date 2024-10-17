using System.ComponentModel.DataAnnotations;

namespace Contract.UsuariosModel.Request
{
    public class AuthenticationRequest
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Contrasenia { get; set; } = string.Empty;
    }
}
