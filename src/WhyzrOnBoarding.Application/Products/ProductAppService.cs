using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ExceptionHandling;
using Volo.Abp.Localization;
using WhyzrOnBoarding.Localization;
using WhyzrOnBoarding.Permissions;

namespace WhyzrOnBoarding.Products
{
    [Authorize(WhyzrOnBoardingPermissions.Products.Default)]
    public class ProductAppService : CrudAppService<
            Product,
            ProductDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateProductDto>, IProductAppService
    {

        private IRepository<Variant, Guid> _variantsRepository;
        private readonly IStringLocalizer<WhyzrOnBoardingResource> _localizer;
      
        public ProductAppService(IRepository<Product, Guid> productRepository,
            IRepository<Variant, Guid> variantsRepository, IStringLocalizer<WhyzrOnBoardingResource> localizer)
            : base(productRepository)
        {
            _variantsRepository = variantsRepository;
            _localizer = localizer;

            GetPolicyName = WhyzrOnBoardingPermissions.Products.Default;
            GetListPolicyName = WhyzrOnBoardingPermissions.Products.Default;
            CreatePolicyName = WhyzrOnBoardingPermissions.Products.Create;
            UpdatePolicyName = WhyzrOnBoardingPermissions.Products.Edit;
            DeletePolicyName = WhyzrOnBoardingPermissions.Products.Delete;
        }

        public override async Task<PagedResultDto<ProductDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var query = await CreateFilteredQueryAsync(input);
            var totalCount = await AsyncExecuter.CountAsync(query);

            //sort + pageging
            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);
            
            //get + map
            var resultList = await AsyncExecuter.ToListAsync(query);
            var productDtos = await MapToGetListOutputDtosAsync(resultList);
            
            return new PagedResultDto<ProductDto>(totalCount, productDtos);
        }

        public override async Task<ProductDto> GetAsync(Guid id)
        {
            //get product
            var queryable = await Repository.WithDetailsAsync(x => x.variants);
            var result = queryable.Where(x => x.Id == id).FirstOrDefault();
            
            if (result != null)
            {
                var productDto = await MapToGetOutputDtoAsync(result);
                return productDto;
            }
            else
            {
                throw new EntityNotFoundException(typeof(ProductDto), id);
            }
        }
        [Authorize(WhyzrOnBoardingPermissions.Products.Create)]
        public override async Task<ProductDto> CreateAsync(CreateUpdateProductDto input)
        {
            //validation 
            var errorList = ValidCreatedProduct(input);

            if (errorList.Count > 0)
            {
                ValidationException validationException = new ValidationException(ProductsConst.ProductsError.ErrorValidationException);
                validationException.Data.Add(ProductsConst.ProductsError.ErrorResultUpdateException, errorList);
                throw validationException;
            }

            //mapping + generat id
            var product = await MapToEntityAsync(input);
            product.sentId(GuidGenerator.Create());

            //add default variant 
            if (product.variants.IsNullOrEmpty())
            {
                Variant variant = new Variant();
                product.variants = new List<Variant>();
                product.variants.Add(variant);
            }

            //sent guid to new variant variant
            foreach (var item in product.variants)
            {
                item.sentId(GuidGenerator.Create());
            }

            //insert
            var result = await Repository.InsertAsync(product);

            var returnObj = await MapToGetOutputDtoAsync(result);
            return returnObj;
        }

        protected override Task MapToEntityAsync(CreateUpdateProductDto updateInput, Product entity)
        {
            //mapping properities product
            entity.Name = updateInput.Name;
            entity.Name1 = updateInput.Name1;
            entity.Name2 = updateInput.Name2;

            entity.Description = updateInput.Description;
            entity.Description1 = updateInput.Description1;
            entity.Description2 = updateInput.Description2;

            entity.OptionA = updateInput.OptionA;
            entity.OptionA1 = updateInput.OptionA1;
            entity.OptionA2 = updateInput.OptionA2;

            entity.OptionB = updateInput.OptionB;
            entity.OptionB1 = updateInput.OptionB1;
            entity.OptionB2 = updateInput.OptionB2;

            entity.OptionC = updateInput.OptionC;
            entity.OptionC1 = updateInput.OptionC1;
            entity.OptionC2 = updateInput.OptionC2;

            entity.OptionD = updateInput.OptionD;
            entity.OptionD1 = updateInput.OptionD1;
            entity.OptionD2 = updateInput.OptionD2;

            //mapping Variant : get list id of remove-edit Variant  
            var removeId = entity.variants.Select(x => x.Id).Except(updateInput.variants.Select(x => x.Id));
            var editId = entity.variants.Select(x => x.Id).Intersect(updateInput.variants.Select(x => x.Id));

            //remove Variant
            entity.variants.RemoveAll(x => x.Id.IsIn(removeId));

            //update Variant
            entity.variants.Where(x => x.Id.IsIn(editId)).ToList().ForEach(item =>
            {
                var newVariant = updateInput.variants.Where(b => b.Id == item.Id).FirstOrDefault();
                if (newVariant != null)
                {
                    item.Price = newVariant.Price;
                    item.Sku = newVariant.Sku;

                    item.ValueOPtionA = newVariant.ValueOPtionA;
                    item.ValueOPtionA1 = newVariant.ValueOPtionA1;
                    item.ValueOPtionA2 = newVariant.ValueOPtionA2;

                    item.ValueOPtionB = newVariant.ValueOPtionB;
                    item.ValueOPtionB1 = newVariant.ValueOPtionB1;
                    item.ValueOPtionB2 = newVariant.ValueOPtionB2;

                    item.ValueOPtionC = newVariant.ValueOPtionC;
                    item.ValueOPtionC1 = newVariant.ValueOPtionC1;
                    item.ValueOPtionC2 = newVariant.ValueOPtionC2;

                    item.ValueOPtionD = newVariant.ValueOPtionD;
                    item.ValueOPtionD1 = newVariant.ValueOPtionD1;
                    item.ValueOPtionD2 = newVariant.ValueOPtionD2;
                }
            } );

            //add Variant
            entity.variants.AddRange(
                updateInput.variants.Where(x => x.Id == Guid.Empty).Select(x =>
            {
                var variant = new Variant
                {
                    Price = x.Price,
                    Sku = x.Sku,

                    ValueOPtionA = x.ValueOPtionA,
                    ValueOPtionA1 = x.ValueOPtionA1,
                    ValueOPtionA2 = x.ValueOPtionA2,

                    ValueOPtionB = x.ValueOPtionB,
                    ValueOPtionB1 = x.ValueOPtionB1,
                    ValueOPtionB2 = x.ValueOPtionB2,

                    ValueOPtionC = x.ValueOPtionC,
                    ValueOPtionC1 = x.ValueOPtionC1,
                    ValueOPtionC2 = x.ValueOPtionC2,

                    ValueOPtionD = x.ValueOPtionD,
                    ValueOPtionD1 = x.ValueOPtionD1,
                    ValueOPtionD2 = x.ValueOPtionD2
                };
                variant.sentId(GuidGenerator.Create());
                return variant;
            }).ToList());

            //add default Variant if no item
            if (entity.variants.IsNullOrEmpty())
            {
                Variant DefaultVariant = new Variant();
                DefaultVariant.sentId(GuidGenerator.Create());
                entity.variants.Add(DefaultVariant);
            }
            return Task.CompletedTask;
        }

        [Authorize(WhyzrOnBoardingPermissions.Products.Edit)]
        public override async Task<ProductDto> UpdateAsync(Guid id, CreateUpdateProductDto input)
        {
            //validation
            var queryable = await Repository.WithDetailsAsync(x => x.variants);
            var product = queryable.Where(x => x.Id == id).FirstOrDefault();
            var errorList = ValidUpdateProduct(id, input, product);

            if (errorList.Count > 0)
            {
                //throw errors
                ValidationException validationException = new ValidationException(ProductsConst.ProductsError.ErrorValidationException);
                validationException.Data.Add(ProductsConst.ProductsError.ErrorResultUpdateException, errorList);
                throw validationException;
            }
            
            //map + update + mapDto
            await MapToEntityAsync(input, product);

            var result = await Repository.UpdateAsync(product);

            var returnObj = await MapToGetOutputDtoAsync(result);

            return returnObj;
        }

        [Authorize(WhyzrOnBoardingPermissions.Products.Delete)]
        public override async Task DeleteAsync(Guid id)
        {
            var result = await Repository.GetAsync(id);

            if (result == null)
            {
                throw new EntityNotFoundException(typeof(ProductDto), id);
            }
            await Repository.DeleteAsync(id);
        }

        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
            {
                return $"{nameof(Product.Name)}";
            }

            return $"{sorting}";
        }

        private List<ValidationResult> ValidCreatedProduct(CreateUpdateProductDto input)
        {
            List<ValidationResult> ListOfErrors = new List<ValidationResult>();
            
            //valid all variant
            if (!input.variants.IsNullOrEmpty())
            {
                foreach (var item in input.variants)
                {
                    var ValidVariant = ValidCreatedVariant(item);
                    ListOfErrors.AddRange(ValidVariant);
                }
            }
            return ListOfErrors;
        }

        private List<ValidationResult> ValidCreatedVariant(CreateUpdateVariantDto input)
        {
            List<ValidationResult> ListOfErrorsVariant = new List<ValidationResult>();
            
            //valid variant is new and id is empty
            if (input.Id != Guid.Empty)
            {
                ListOfErrorsVariant.Add(new ValidationResult(_localizer[ProductsConst.ProductsError.ErrorNewVariantShouldNotHaveId], new string[] { "Variant" + nameof(input.Id) }));
            }
            return ListOfErrorsVariant;
        }

        private List<ValidationResult> ValidUpdateProduct(Guid id, CreateUpdateProductDto input, Product product)
        {
            List<ValidationResult> ListOfErrors = new List<ValidationResult>();

            if (id == Guid.Empty)
            {
                ListOfErrors.Add(new ValidationResult(_localizer[ProductsConst.ProductsError.ErrorIdIsEmpty], new string[] { nameof(id) }));
                return ListOfErrors;
            }
            if (id != input.Id)
            {
                ListOfErrors.Add(new ValidationResult(_localizer[ProductsConst.ProductsError.ErrorIdSentNotEqualIdInput, id, input.Id], new string[] { nameof(id) }));
                return ListOfErrors;
            }

            if (product == null)
            {
                ListOfErrors.Add(new ValidationResult(_localizer[ProductsConst.ProductsError.ErrorProductNotFound, id], new string[] { nameof(product) }));
                return ListOfErrors;
            }
            //valid variant
            if (!input.variants.IsNullOrEmpty())
            {
                var oldVariantIds = product.variants.Select(x => x.Id).ToList();

                foreach (var item in input.variants)
                {
                    var ValidVariant = ValidUpdateVariant(item, oldVariantIds);
                    ListOfErrors.AddRange(ValidVariant);
                }
            }
            return ListOfErrors;
        }

        private List<ValidationResult> ValidUpdateVariant(CreateUpdateVariantDto input, List<Guid> oldVariantIds)
        {
            List<ValidationResult> ListOfErrorsVariant = new List<ValidationResult>();

            //valid if sent id not exist before 
            if (input.Id != Guid.Empty)
            {
                if (!input.Id.IsIn(oldVariantIds))
                {
                    ListOfErrorsVariant.Add(new ValidationResult(_localizer[ProductsConst.ProductsError.ErrorIdVariantIsNotExist, input.Id], new string[] { "Variant "+nameof(input.Id) }));
                }
            }
            return ListOfErrorsVariant;
        }
    }
}
