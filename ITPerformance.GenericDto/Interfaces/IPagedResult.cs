using System.Collections.Generic;

namespace ITPerformance.GenericDto.Interfaces
{
    /// <summary>
    /// Represents a paged list of items along with the total count of all items available (before paging).
    /// Inherits from <see cref="IList{T}"/> and <see cref="IHasTotalCount"/>.
    /// </summary>
    /// <typeparam name="T">The type of items in the paged result.</typeparam>
    public interface IPagedResult<T> : IList<T>, IHasTotalCount
    {
    }
}
