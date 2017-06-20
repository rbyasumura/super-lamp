namespace Advance.Framework.Interfaces.Repositories
{
    public interface IPropertyValues
    {
        object this[string propertyName] { get; set; }

        object ToObject();
    }
}
