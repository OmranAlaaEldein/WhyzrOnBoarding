namespace WhyzrOnBoarding.Permissions
{
    public static class WhyzrOnBoardingPermissions
    {
        public const string GroupName = "WhyzrOnBoarding";

        
        public static class Products
        {
            public const string Default = GroupName + ".Products";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
    }
}