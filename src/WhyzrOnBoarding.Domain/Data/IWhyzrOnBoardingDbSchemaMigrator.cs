using System.Threading.Tasks;

namespace WhyzrOnBoarding.Data
{
    public interface IWhyzrOnBoardingDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
