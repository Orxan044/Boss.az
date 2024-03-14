namespace Boss.az.BaseId;

abstract class BaseId
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
