using WhyzrOnBoarding.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace WhyzrOnBoarding.Permissions
{
    public class WhyzrOnBoardingPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(WhyzrOnBoardingPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(WhyzrOnBoardingPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<WhyzrOnBoardingResource>(name);
        }
    }
}
