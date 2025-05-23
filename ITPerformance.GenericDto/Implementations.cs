using ITPerformance.GenericDto.Interfaces;
using System;
using System.Linq;

namespace ITPerformance.GenericDto
{
    /// <summary>
    /// Provides a helper method to apply pagination logic to an IQueryable<T> based on a request object. 
    /// It checks the type of request and applies either full paging (Skip and Take) or limited result logic (Take only).
    /// </summary>
    public class PaginationHelper
    {
        /// <summary>
        /// Applies pagination to the input query based on the request type.
        /// </summary>
        /// <typeparam name="T">Type Constraint: T must be a class.</typeparam>
        /// <param name="query"></param>
        /// <param name="input"></param>
        /// <returns>
        /// If input implements IPagedResultRequest, it uses both Skip and Take.
        /// If input implements ILimitedResultRequest, it uses Take only.
        /// If neither, it returns the original query.
        /// </returns>
        public static IQueryable<T> ApplyPaging<T>(IQueryable<T> query, IResultRequest input) where T : class
        {
            if ((object)input is IPagedResultRequest pagedResultRequest)
            {
                return query.PageBy(pagedResultRequest);
            }

            if ((object)input is ILimitedResultRequest limitedResultRequest)
            {
                return query.Take(limitedResultRequest.MaxResultCount);
            }

            return query;
        }
    }

    /// <summary>
    /// Provides extension methods for applying pagination directly to IQueryable<T> instances.
    /// </summary>
    public static class PaginationExtentions
    {
        /// <summary>
        /// Applies pagination using values from a IPagedResultRequest object. 
        /// Internally calls the overload that accepts skipCount and maxResultCount.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="pagedResultRequest"></param>
        /// <returns></returns>
        public static IQueryable<T> PageBy<T>(this IQueryable<T> collection, IPagedResultRequest pagedResultRequest)
        {
            return collection.PageBy(pagedResultRequest.SkipCount, pagedResultRequest.MaxResultCount);
        }

        /// <summary>
        /// Skips a specified number of elements and takes a specified number from the collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="skipCount"></param>
        /// <param name="maxResultCount"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Throws ArgumentNullException if the input collection is null.</exception>
        public static IQueryable<T> PageBy<T>(this IQueryable<T> collection, int skipCount, int maxResultCount)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            return collection.Skip(skipCount).Take(maxResultCount);
        }
    }
}
