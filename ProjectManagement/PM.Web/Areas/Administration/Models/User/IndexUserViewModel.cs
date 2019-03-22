using PagedList;

namespace PM.Web.Administration.User
{
    public class IndexUserViewModel
    {
        public IPagedList<UserPreviewViewModel> Users { get; set; }
    }
}
