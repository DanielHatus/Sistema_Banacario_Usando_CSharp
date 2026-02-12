namespace Src.Infra.Adapters;
using Src.Core.Ports;

public class AuthAdapter : IAuthPort
{
    public string generateAccessToken(string nameFull, string email, long id)
    {
        throw new NotImplementedException();
    }

    public string generateRefreshToken(string nameFull, string email, long id)
    {
        throw new NotImplementedException();
    }
}