using BnplV2.EnumTypes;

namespace BnplV2.Modules.BaseEntities;

public class BaseTransaction: BaseEntity
{
    public required string TransactionId { get; set; }
    public string? TransactionExtId { get; set; }
    public TransactionStatus TransactionStatus { get; set; }
    public TransactionType TransactionType { get; set; }
    public TransactionNature TransactionNature { get; set; }
    public required double Amount { get; set; }
}