namespace ITPerformance.GenericDto.Interfaces
{
    /// <summary>
    /// Defines a contract for objects that include a total count, typically used in paged results.
    /// </summary>
    public interface IHasTotalCount
    {
        /// <summary>
        /// Gets or sets the total number of items available (ignoring pagination).
        /// </summary>
        int TotalCount { get; set; }
    }
}
