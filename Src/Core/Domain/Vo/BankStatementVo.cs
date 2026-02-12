namespace Src.Core.Domain.Vo;
using Src.Core.Exceptions;

public class BankStatementVo{
    public decimal Statement{get;private set;}
    public static BankStatementVo InitCreditsBonusFromCreateAccount(){
        return new BankStatementVo(1000);
    }

public static BankStatementVo ReceivedBankStatementByDatabase(decimal actBankStatement){
    return new BankStatementVo(actBankStatement);     
}
    private BankStatementVo(decimal bankStatement){
        this.Statement=bankStatement;
    }

    public void EffectPayment(decimal amount){
        if (amount <= 0 || amount > this.Statement){
            throw new DomainException("o valor do pagamento não pode ser menor ou igual a 0, ou maior que seu extrator atual.",400);
        }
       this.Statement-=amount;
    }

    public void ReceivedPayment(decimal amount){
       this.Statement+=amount;
    }
}