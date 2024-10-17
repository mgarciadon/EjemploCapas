namespace Contract.UsuariosModel.Helpers;

public class AutenticacionServiceOptions
{
    public const string AutenticacionService = "AutenticacionService";

    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string SecretForKey { get; set; }
}
