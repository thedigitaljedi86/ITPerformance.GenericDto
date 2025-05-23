namespace ITPerformance.GenericDto.Interfaces
{
    /// <summary>
    /// Represents a generic Data Transfer Object (DTO) that includes an identifier.
    /// </summary>
    /// <typeparam name="TKey">The type of the identifier.</typeparam>
    public interface IEntityDto<TKey>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the entity.
        /// </summary>
        TKey Id { get; set; }
    }
}