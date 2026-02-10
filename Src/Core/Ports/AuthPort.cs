namespace Src.Core.Port.AuthPort;
public interface AuthPort{
    string generateAccessToken(string nameFull,string email,long id);
    string generateRefreshToken(string nameFull,string email,long id);

}