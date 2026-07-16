namespace Shared.Contracts.Common;

public sealed record PagedResult<T>(
    IReadOnlyList<T> Items,
    int Page,
    int PageSize,
    long TotalCount)
{
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    public bool HasPreviousPage => Page > 1;
    public bool HasNextPage => Page < TotalPages;
}

/// <summary>Standard paging/sorting/search request accepted by every list query in the system.</summary>
public record PagedQuery(
    int Page = 1,
    int PageSize = 20,
    string? SearchTerm = null,
    string? SortBy = null,
    bool SortDescending = false);