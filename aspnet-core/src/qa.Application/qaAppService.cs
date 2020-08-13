using System;
using System.Collections.Generic;
using System.Text;
using qa.Localization;
using Volo.Abp.Application.Services;

namespace qa
{
    /* Inherit your application services from this class.
     */
    public abstract class qaAppService : ApplicationService
    {
        protected qaAppService()
        {
            LocalizationResource = typeof(qaResource);
        }
    }
}
