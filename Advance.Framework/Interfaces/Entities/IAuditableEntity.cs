namespace Advance.Framework.Interfaces.Entities
{
    internal interface IAuditableEntity<T>
    {
        T CreatedBy { get; set; }
        T UpdatedBy { get; set; }
    }
}
