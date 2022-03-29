using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.ExceptionHandling;

namespace WhyzrOnBoarding.Products
{
    public interface IProductAppService : ICrudAppService<
            ProductDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateProductDto>
    {

    }
}
