namespace Allup.ViewModels;
public class PaginatedList<T> : List<T>
{
    public PaginatedList (IQueryable<T> query, int currentPage, int totalPage, int pageItemCount)
    {
        CurrentPage = currentPage;
        TotalPage = totalPage;
        HasPrev = CurrentPage > 1;
        HasNext = CurrentPage < TotalPage;
        Start = CurrentPage - (int)Math.Floor((decimal)(pageItemCount - 1) / 2);
        End = CurrentPage + (int)Math.Ceiling((decimal)(pageItemCount - 1) / 2);

        if (TotalPage > pageItemCount)
        {
            if (Start <= 0)
            {
                Start = 1;
                End = pageItemCount;
            }
            if (End > TotalPage)
            {
                Start = TotalPage - (pageItemCount - 1);
                End = TotalPage;
            }
        }

        this.AddRange(query);
    }

    public int CurrentPage { get; }
    public int TotalPage { get; }
    public bool HasPrev { get; }
    public bool HasNext { get; }
    public int Start { get; }
    public int End { get; }


    public static PaginatedList<T> Create(IQueryable<T> query, int currentPage, int elementCount, int pageItemCount)
    {
        int totalPage = (int)Math.Ceiling((decimal)query.Count() / elementCount);
        query = query.Skip((currentPage - 1) * elementCount).Take(elementCount);

        return new PaginatedList<T>(query, currentPage, totalPage, pageItemCount);
    }
}