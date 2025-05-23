using ITPerformance.GenericDto.Interfaces;

namespace ITPerformance.GenericDto
{
    /// <summary>
    /// A data transfer object (DTO) that specifies a limit on the number of results to return.
    /// Implements <see cref="ILimitedResultRequest"/>.
    /// </summary>
    public class LimitedResultRequestDto : ILimitedResultRequest
    {
        /// <summary>
        /// Gets or sets the default maximum number of results to return if none is explicitly specified.
        /// </summary>
        public static int DefaultMaxCount { get; set; } = 10;

        /// <summary>
        /// Gets or sets the maximum number of results to return.
        /// Defaults to <see cref="DefaultMaxCount"/>.
        /// </summary>
        public virtual int MaxResultCount { get; set; } = DefaultMaxCount;
    }
}
