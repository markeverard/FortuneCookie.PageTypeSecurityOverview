namespace FortuneCookie.PageTypeSecurityOverview.Models
{
    public class PageTypeSecurityModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public bool IsAvailable { get; set; }
        public string[] AccessControlList { get; set; }
        public string[] AllowablePageTypeNames { get; set; }

        public string AvailableCssName { get { return IsAvailable ? "available" : "unavailable"; }}
    }
}