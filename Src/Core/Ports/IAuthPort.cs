namespace Src.Core.Ports;
public interface IAuthPort{
    string generateAccessToken(string nameFull,string email,long id);
    string generateRefreshToken(string nameFull,string email,long id);

}