namespace ITPerformance.GenericDto.Interfaces
{
    /// <summary>
    /// Represents a request that limits the number of results returned.
    /// Inherits from <see cref="IResultRequest"/>.
    /// </summary>
    public interface ILimitedResultRequest : IResultRequest
    {
        /// <summary>
        /// Gets or sets the maximum number of results to return.
        /// </summary>
        int MaxResultCount { get; set; }
    }
}
