using Application.Interfaces;
using Contract.UsuariosModel.Helpers;
using Contract.UsuariosModel.Request;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.ThirdPartyServices;

public class AuthenticationService : IAuthenticationService
{
    private readonly IMedicoRepository _medicoRepository;
    private readonly AutenticacionServiceOptions _options;

    public AuthenticationService(IMedicoRepository medicoRepository, IOptions<AutenticacionServiceOptions> options)
    {
        _medicoRepository = medicoRepository;
        _options = options.Value;
    }

    private Medico? ValidateUser(AuthenticationRequest authenticationRequest)
    {
        if (string.IsNullOrEmpty(authenticationRequest.Email) || string.IsNullOrEmpty(authenticationRequest.Contrasenia))
            return null;

        var medicos = _medicoRepository.GetMedicos();

        var user = medicos.FirstOrDefault(x => x.Email.Equals(authenticationRequest.Email) && x.Contrasenia.Equals(authenticationRequest.Contrasenia));

        return user;
    }

    public string Autenticar(AuthenticationRequest authenticationRequest)
    {
        var user = ValidateUser(authenticationRequest);

        if (user == null)
        {
            throw new Exception("User authentication failed");
        }

        var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.SecretForKey));

        var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

        var claimsForToken = new List<Claim>();
        claimsForToken.Add(new Claim("sub", user.Id.ToString()));
        claimsForToken.Add(new Claim("given_name", user.Nombre));
        claimsForToken.Add(new Claim("family_name", user.Apellido));

        var jwtSecurityToken = new JwtSecurityToken(
            _options.Issuer,
            _options.Audience,
            claimsForToken,
            DateTime.UtcNow,
            DateTime.UtcNow.AddHours(1),
            credentials);

        var tokenToReturn = new JwtSecurityTokenHandler()
            .WriteToken(jwtSecurityToken);

        return tokenToReturn.ToString();
    }
}