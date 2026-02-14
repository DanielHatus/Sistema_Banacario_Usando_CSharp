namespace Src.Infra.Persistence.Model;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Src.Core.Domain.Enums;

[Index(nameof(Email),IsUnique =true)]
public class UserPersist{
    public UserPersist(){}
    
    [Key]
    public long? Id{get;set;}
    public string FullName{get;set;}
    public string Email{get;set;}
    public string PasswordPayment{get;set;}
    public decimal BankStatement{get;set;}
    public Role Role{get;set;}
}