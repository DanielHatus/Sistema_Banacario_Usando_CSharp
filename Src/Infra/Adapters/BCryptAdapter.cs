using System.Reflection.Metadata;
using Microsoft.AspNetCore.SignalR;

public class BCryptAdapter : IBCryptPort{

    public const int CostPassword=12; 
    public string HashPassword(string password){
        return BCrypt.Net.BCrypt.HashPassword(password,CostPassword);
    }

    public bool PasswordsIsMatch(string passwordRequest, string passwordHash){
        return BCrypt.Net.BCrypt.Verify(passwordRequest,passwordHash);
    }
}