using qa.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace qa.Permissions
{
    public class qaPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(qaPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(qaPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<qaResource>(name);
        }
    }
}
