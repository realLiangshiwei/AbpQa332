using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace qa.Web
{
    [Dependency(ReplaceServices = true)]
    public class qaBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "qa";
    }
}
