namespace Test.Helpers;

public class BaseQueryParameters
{
    private const int MaxPageSize = 1000000000;
    public int Page { get; set; } = 1;
    private int _pageSize = 40;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
    }

    //public int Type { get; set; }
}