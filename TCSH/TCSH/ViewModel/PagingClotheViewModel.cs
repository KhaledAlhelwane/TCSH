using TCSH.Models;

namespace TCSH.ViewModel
{
    public class PagingClotheViewModel
    {
        public List<Clothe>?Clothes { get; set; }
        /// Gets or sets CurrentPageIndex.
        public int CurrentPageIndex { get; set; }
        /// Gets or sets PageCount.
        public int PageCount { get; set; }
    }
}
