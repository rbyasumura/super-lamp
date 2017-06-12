namespace Advance.Framework.Entities
{
    internal interface IVersionedEntity
    {
        int Version { get; set; }
        IVersionedEntity PreviousVersion { get; set; }
    }
}
