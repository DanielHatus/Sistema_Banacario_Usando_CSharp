namespace Src.Core.Domain.Vo.BankStatementVo;
using Src.Core.Exceptions.DomainException;

public class BankStatementVo{
    public decimal Statement{get;}
    public static BankStatementVo InitCreditsBonusFromCreateAccount(){
        return new BankStatementVo(1000);
    }

public static BankStatementVo ReceivedBankStatementByDatabase(decimal actBankStatement){
    return new BankStatementVo(actBankStatement);     
}
    private BankStatementVo(decimal bankStatement){
        this.Statement=bankStatement;
    }

    public BankStatementVo EffectPayment(decimal amount){
        if (amount <= 0 || amount > this.Statement){
            throw new DomainException("o valor do pagamento não pode ser menor ou igual a 0, ou maior que seu extrator atual.",400);
        }
        return new BankStatementVo(this.Statement-amount);
    }

    public BankStatementVo ReceivedPayment(decimal amount){
       return new BankStatementVo(this.Statement+amount);
    }
}