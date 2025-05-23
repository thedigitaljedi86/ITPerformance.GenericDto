using ITPerformance.GenericDto.Interfaces;

namespace ITPerformance.GenericDto
{
    /// <summary>
    /// A data transfer object (DTO) that specifies pagination parameters for a request,
    /// including how many items to skip and the maximum number to return.
    /// Inherits from <see cref="LimitedResultRequestDto"/> and implements <see cref="IPagedResultRequest"/>.
    /// </summary>
    public class PagedResultRequestDto : LimitedResultRequestDto, IPagedResultRequest
    {
        /// <summary>
        /// Gets or sets the number of items to skip before beginning to return results.
        /// </summary>
        public virtual int SkipCount { get; set; }
    }
}
