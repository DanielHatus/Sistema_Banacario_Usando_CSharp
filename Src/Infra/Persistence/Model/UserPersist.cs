namespace Src.Infra.Persistence.Model;
using Src.Core.Domain.Enums;

public class UserPersist{
    protected UserPersist(){}
    public long Id{get;set;}
    public string FullName{get;set;}
    public string Email{get;set;}
    public string PasswordPayment{get;set;}
    public decimal BankStatement{get;set;}
    public Role role{get;set;}
}