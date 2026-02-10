namespace Src.Core.Domain.Model.HistoryPaymentDomain;
using Src.Core.Domain.Model.UserDomain;

public class HistoryPaymentDomain{
    

    protected HistoryPaymentDomain(){}
    public UserDomain  Payer{get;}
    public UserDomain Payee{get;}

    public decimal Amount{get;}
    public DateOnly DayPayment{get;}
    public TimeOnly HourPayment{get;}

    private HistoryPaymentDomain(UserDomain payer,UserDomain payee,decimal amount){
        this.Payer=payer;
        this.Payee=payee;
        this.Amount=amount;
        this.DayPayment=DateOnly.FromDateTime(DateTime.Now);
        this.HourPayment=TimeOnly.FromDateTime(DateTime.Now);
    }

    public static HistoryPaymentDomain StoreDataPaymentFromSaveInDatabase(UserDomain payer,UserDomain payee,decimal amount){
        return new HistoryPaymentDomain(payer,payee,amount);
    }

}