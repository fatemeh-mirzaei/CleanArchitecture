namespace Sample.Application.DTOs
{
    public class BasePaging
    {
        public BasePaging()
        {
            PageSize = 5;

        }

        public int PageId { get; set; }

        public int PageCount { get; set; }

        public int ActivePage { get; set; }

        public int StartPage { get; set; }

        public int EndPage { get; set; }

        public int PageSize { get; set; }

        public int SkipEntity { get; set; }
    }
}
