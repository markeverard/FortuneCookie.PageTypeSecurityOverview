using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.DataAbstraction;
using EPiServer.PlugIn;
using FortuneCookie.PageTypeSecurityOverview.Models;

namespace FortuneCookie.PageTypeSecurityOverview.Controllers
{
    [GuiPlugIn(Area = PlugInArea.AdminMenu, 
        Url = "/modules/FortuneCookie.PageTypeSecurityOverview/Overview/", 
        DisplayName = "Page Type Security Overview")]
    public class OverviewController : Controller
    {
        public ActionResult Index()
        {
            var pageTypeModels = GetPageTypeSecurityModels();
            var editPageTypeUrl = UriSupport.AbsoluteUrlFromUIBySettings("Admin/EditPageType.aspx");
            var model = new OverviewPageViewModel { PageTypeModels = pageTypeModels, EditPageTypeUrl = editPageTypeUrl };
            return View(model);
        }

        private static List<PageTypeSecurityModel> GetPageTypeSecurityModels()
        {
            var pageTypeModels = PageType.List()
                .OrderBy(pageType => pageType.Name)
                .Select(p => new PageTypeSecurityModel()
                                 {
                                     AccessControlList = p.ACL.Select(a => a.Value.Name).ToArray(),
                                     AllowablePageTypeNames = p.AllowedPageTypeNames,
                                     Id = p.ID,
                                     Name = p.Name,
                                     IsAvailable = p.IsAvailable
                                 })
                .ToList();

            return pageTypeModels;
        }
    }
}
