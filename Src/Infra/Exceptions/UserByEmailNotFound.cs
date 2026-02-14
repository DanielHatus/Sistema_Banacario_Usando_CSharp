public class UserByEmailNotFound : InfraBaseException{
    
    public UserByEmailNotFound(string message,int statusCode):base(message,statusCode){}
}