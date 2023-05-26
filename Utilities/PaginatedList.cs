namespace Utilities
{
    public class PaginatedList<TEntity>
    {
        public PaginatedList(List<TEntity> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Items = items;
            Count = count;
        }

        public List<TEntity> Items { get; } = new List<TEntity>();

        public int PageIndex { get; }

        public int TotalPages { get; }

        public int Count { get; }

        public int PageSize { get; }

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;
    }
}
