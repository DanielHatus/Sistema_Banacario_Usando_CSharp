public interface IBCryptPort{
    string HashPassword(string password);
    bool PasswordsIsMatch(string passwordRequest,string passwordHash);
}