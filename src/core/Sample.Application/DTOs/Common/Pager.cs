namespace Sample.Application.DTOs
{
    public class Pager
    {
        public static BasePaging Build(int pageCount, int pageNumber, int pageSize)
        {
            if (pageNumber <= 1) pageNumber = 1;


            return new BasePaging
            {
                ActivePage = pageNumber,
                PageCount = pageCount,
                PageId = pageNumber,
                PageSize = pageSize,
                SkipEntity = (pageNumber - 1) * pageSize,
                StartPage = pageNumber - 3 <= 0 ? 1 : pageNumber - 3,
                EndPage = pageNumber + 3 > pageCount ? pageCount : pageNumber + 3
            };
        }
    }
}
