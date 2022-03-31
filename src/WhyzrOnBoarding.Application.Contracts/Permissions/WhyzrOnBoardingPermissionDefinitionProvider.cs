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
            
            var productsPermission = myGroup.AddPermission(WhyzrOnBoardingPermissions.Products.Default, L("Permission:Products"));
            productsPermission.AddChild(WhyzrOnBoardingPermissions.Products.Create, L("Permission:Products.Create"));
            productsPermission.AddChild(WhyzrOnBoardingPermissions.Products.Edit, L("Permission:Products.Edit"));
            productsPermission.AddChild(WhyzrOnBoardingPermissions.Products.Delete, L("Permission:Products.Delete"));

        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<WhyzrOnBoardingResource>(name);
        }
    }
}
