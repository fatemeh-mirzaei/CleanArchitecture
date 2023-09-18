namespace Sample.Application.DTOs
{
    public class FilterUserDto : BasePaging
    {
        public string SearchBox { get; set; }
        public string FullName { get; set; }
        public DateTime? RegisterDate { get; set; }
        public List<GetUserDto> Users { get; set; }

        public FilterUserDto SetPaging(BasePaging paging)
        {
            this.PageId = paging.PageId;
            this.PageCount = paging.PageCount;
            this.StartPage = paging.StartPage;
            this.EndPage = paging.EndPage;
            this.PageSize = paging.PageSize;
            this.SkipEntity = paging.SkipEntity;
            this.ActivePage = paging.ActivePage;
            return this;
        }

        public FilterUserDto SetUser(List<GetUserDto> user)
        {
            this.Users = user;
            return this;
        }
    }
}
