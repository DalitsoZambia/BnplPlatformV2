namespace BnplV2.Modules.BaseEntities;
/// <summary>
/// Base Entity
/// All Entities that go to the database will inherit from this class
/// </summary>
public class BaseEntity
{
    public int Id { get; set; }
    public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedDate { get; set; } = DateTimeOffset.UtcNow;
}

public class BaseEntityResponse
{
    public int Id { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset UpdatedDate { get; set; }
}
