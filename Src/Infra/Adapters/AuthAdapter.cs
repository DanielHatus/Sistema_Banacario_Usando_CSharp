using Src.Core.Port.AuthPort;

public class AuthAdapter : AuthPort
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