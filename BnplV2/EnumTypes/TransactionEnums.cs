namespace BnplV2.EnumTypes;

public enum TransactionStatus
{
    Pending,
    Successful,
    Failed
}

public enum TransactionType
{
    LoanDisbursement,
    LoanRepayment,
}

public enum TransactionNature
{
    MobileMoney,
    BankTransfer,
    Cash
}