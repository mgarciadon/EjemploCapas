using Contract.UsuariosModel.Request;

namespace Application.Interfaces;

public interface IAuthenticationService
{
    string Autenticar(AuthenticationRequest authenticationRequest);
}
