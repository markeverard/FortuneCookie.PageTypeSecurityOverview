using System.Collections.Generic;

namespace FortuneCookie.PageTypeSecurityOverview.Models
{
    public class OverviewPageViewModel
    {
        public string EditPageTypeUrl { get; set; }
        public List<PageTypeSecurityModel> PageTypeModels { get; set; }
    }
}