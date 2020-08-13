using qa.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace qa.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class qaController : AbpController
    {
        protected qaController()
        {
            LocalizationResource = typeof(qaResource);
        }
    }
}