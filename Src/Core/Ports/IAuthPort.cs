namespace Src.Core.Ports;
public interface IAuthPort{
    string GenerateAccessToken(string nameFull,string email,long? id);
    string GenerateRefreshToken(string nameFull,string email,long? id);

}