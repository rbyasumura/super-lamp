namespace Advance.Framework.Interfaces.Entities
{
    public interface IAuditableEntity<T>
    {
        T CreatedBy { get; set; }
        T UpdatedBy { get; set; }
    }
}
