using qa.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace qa.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class qaPageModel : AbpPageModel
    {
        protected qaPageModel()
        {
            LocalizationResourceType = typeof(qaResource);
        }
    }
}