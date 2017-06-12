namespace Advance.Framework.Interfaces.Entities
{
    internal interface IVersionedEntity
    {
        int Version { get; set; }
        IVersionedEntity PreviousVersion { get; set; }
    }
}
