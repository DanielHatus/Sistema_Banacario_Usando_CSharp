public class UserByIdNotFound:InfraBaseException{
    public UserByIdNotFound(string message,int statusCode):base(message,statusCode){}
}