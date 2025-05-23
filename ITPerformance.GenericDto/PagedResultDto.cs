using ITPerformance.GenericDto.Interfaces;
using System.Collections.Generic;

namespace ITPerformance.GenericDto
{
    /// <summary>
    /// A data transfer object (DTO) that represents a paged result set with a total item count.
    /// Inherits from <see cref="List{T}"/> and implements <see cref="IPagedResult{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of items in the result set.</typeparam>
    public class PagedResultDto<T> : List<T>, IPagedResult<T>
    {
        /// <summary>
        /// Gets or sets the total number of items available (before paging).
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedResultDto{T}"/> class.
        /// </summary>
        public PagedResultDto()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedResultDto{T}"/> class with a total count and a list of items.
        /// </summary>
        /// <param name="totalCount">The total number of items available.</param>
        /// <param name="items">The list of items on the current page.</param>
        public PagedResultDto(int totalCount, IReadOnlyList<T> items)
            : base(items)
        {
            TotalCount = totalCount;
        }
    }

}
