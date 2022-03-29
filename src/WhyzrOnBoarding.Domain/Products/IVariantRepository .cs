using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace WhyzrOnBoarding.Products
{
    public interface IVariantRepository : IRepository<Variant, Guid>
    {

    }
}
