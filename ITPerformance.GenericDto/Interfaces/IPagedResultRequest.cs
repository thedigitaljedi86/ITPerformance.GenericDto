namespace ITPerformance.GenericDto.Interfaces
{
    /// <summary>
    /// Represents a request for a paged result, including how many items to skip and the maximum number to return.
    /// Inherits from <see cref="ILimitedResultRequest"/>.
    /// </summary>
    public interface IPagedResultRequest : ILimitedResultRequest
    {
        /// <summary>
        /// Gets or sets the number of items to skip before beginning to return results.
        /// </summary>
        int SkipCount { get; set; }
    }
}
