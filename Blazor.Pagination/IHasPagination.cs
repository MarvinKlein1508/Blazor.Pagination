namespace Blazor.Pagination
{
    /// <summary>
    /// Provides default properties and methods to be used with the Pagination component.
    /// </summary>
    public interface IHasPagination
    {
        /// <summary>
        /// Gets or set the current page number.
        /// </summary>
        int Page { get; set; }
        /// <summary>
        /// Gets or set the total amount of items for the pagination.
        /// </summary>
        int TotalItems { get; set; }
        /// <summary>
        /// Loads the data for the current page.
        /// </summary>
        /// <param name="navigateToPage1"></param>
        /// <returns></returns>
        Task LoadAsync(bool navigateToPage1 = false);
    }
}
