using BnplV2.EnumTypes;
using BnplV2.Modules.BaseEntities;

namespace BnplV2.Modules.Messaging;

public class Sms: BaseEntity
{
    public required string Recipeint { get; set; }
    public required string Message { get; set; }
    public TransactionStatus Status { get; set; } = TransactionStatus.Successful;
}