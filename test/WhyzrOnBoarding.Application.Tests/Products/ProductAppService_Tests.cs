﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Volo.Abp.Application.Dtos;
using Shouldly;
using AutoMapper;
using Volo.Abp.Validation;

namespace WhyzrOnBoarding.Products
{
    public class ProductAppService_Tests: WhyzrOnBoardingApplicationTestBase
    {
        private readonly IProductAppService _productAppService;

        public ProductAppService_Tests()
        {
            _productAppService = GetRequiredService<IProductAppService>();
        }

        [Fact]
        public async Task Should_Get_List_Of_Products()
        {
            //Act
            var result = await _productAppService.GetListAsync(
                new PagedAndSortedResultRequestDto()
            );

            //Assert
            result.TotalCount.ShouldBeGreaterThan(0);
            result.Items.ShouldContain(b => b.Name == "Shose");
        }

        [Fact]
        public async Task Should_Get_Product()
        {
            //Act
            var prodcut = await _productAppService.CreateAsync(
                new CreateUpdateProductDto
                {
                    Name = "test get Product",
                    OptionA = "size"
                }
            );

            var result = await _productAppService.GetAsync(prodcut.Id);

            //Assert
            result.ShouldNotBe(null);
            result.Name.ShouldBe("test get Product");
            result.OptionA.ShouldBe("size");
            result.variants.Count.ShouldBeGreaterThan(0);
        }



        //create
        [Fact]
        public async Task Should_Create_A_Valid_Product_With_Empty_List_Variant()
        {
            //Act
            var result = await _productAppService.CreateAsync(
                new CreateUpdateProductDto
                {
                    Name = "test Product with empty variant",
                    OptionA = "size"
                }
            );

            //Assert
            result.Id.ShouldNotBe(Guid.Empty);
            result.Name.ShouldBe("test Product with empty variant");
            result.OptionA.ShouldBe("size");
            result.variants.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task Should_Create__Product_With_Variant()
        {
            List<CreateUpdateVariantDto> listVariants = new List<CreateUpdateVariantDto>();
            CreateUpdateVariantDto variantDto = new CreateUpdateVariantDto { Price = 100, ValueOPtionA = "red" };
            listVariants.Add(variantDto);
            //Act
            var result = await _productAppService.CreateAsync(
                new CreateUpdateProductDto
                {
                    Name = "New test Product",
                    OptionA = "color",
                    variants = listVariants
                }
            );

            //Assert
            result.Id.ShouldNotBe(Guid.Empty);
            result.Name.ShouldBe("New test Product");
            result.OptionA.ShouldBe("color");
            result.variants.Count.ShouldBeGreaterThan(0);
            result.variants.ShouldContain(c => c.Price == 100);
            result.variants.ShouldContain(c => c.ValueOPtionA == "red");
        }

        [Fact]
        public async Task Should_No_Create_Product_With_Empty_Name()
        {
            var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                await _productAppService.CreateAsync(
                new CreateUpdateProductDto
                {
                    Name = "Should_No_Create_Product_With_Empty_Name",
                    OptionA = "size"
                }
            );
            });
            exception.ValidationErrors
             .ShouldContain(err => err.MemberNames.Any(m => m == "Name"));
        }

        //Update
        [Fact]
        public async Task Should_Update_Product()
        {
            //Act
            var product = await _productAppService.CreateAsync(
                new CreateUpdateProductDto
                {
                    Name = "create Product",
                    OptionA = "size"
                }
            );

            var result = await _productAppService.UpdateAsync(
                product.Id,
                new CreateUpdateProductDto
                {
                    Id = product.Id,
                    Name = "update Product",
                    OptionA = "model"
                }
            );
            //Assert
            result.Name.ShouldBe("update Product");
            result.OptionA.ShouldBe("model");
            result.variants.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task Should_No_Update_Product_With_Empty_Name()
        {
            var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                var product = await _productAppService.CreateAsync(
              new CreateUpdateProductDto
              {
                  Name = "Should_No_Update_Product_With_Empty_Name",
                  OptionA = "size"
              }
          );

                var result = await _productAppService.UpdateAsync(
                    product.Id,
                    new CreateUpdateProductDto
                    {
                        Id = product.Id,
                        Name = "",
                        OptionA = "model"
                    }
                );
              
            });
            exception.ValidationErrors
                .ShouldContain(err => err.MemberNames.Any(m => m == "Name"));
        }

        [Fact]
        public async Task Should_No_Update_Product_With_Id_Empty()
        {
            var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                var product = await _productAppService.CreateAsync(
              new CreateUpdateProductDto
              {
                  Name = "Should_No_Update_Product_With_Id_Empty",
                  OptionA = "size"
              }
          );

                var result = await _productAppService.UpdateAsync(
                    product.Id,
                    new CreateUpdateProductDto
                    {
                        Id =Guid.Empty,
                        Name = "",
                        OptionA = "model"
                    }
                );

            });
            exception.ValidationErrors
                .ShouldContain(err => err.MemberNames.Any(m => m == "Id"));

        }

        [Fact]
        public async Task Should_Update_Product_With_Id_Not_Exist()
        {
            var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                var product = await _productAppService.CreateAsync(
          new CreateUpdateProductDto
          {
              Name = "Should_Update_Product_With_Id_Not_Exist",
              OptionA = "size"
          }
      );

            var result = await _productAppService.UpdateAsync(
                Guid.NewGuid(),
                new CreateUpdateProductDto
                {
                    Id = product.Id,
                    Name = "",
                    OptionA = "model"
                }
            );

        });
            exception.ValidationErrors
                .ShouldContain(err => err.MemberNames.Any(m => m == "Id"));

        }


        
        [Fact]
        public async Task Should_Update_Product_With_new_Variant()
        {
            //Act
            var product = await _productAppService.CreateAsync(
                new CreateUpdateProductDto
                {
                    Name = "Should_Update_Product_With_new_Variant",
                    OptionA = "color"
                }
            );

            //variant
            var existVarinat = product.variants.FirstOrDefault();
            List<CreateUpdateVariantDto> listVariants = new List<CreateUpdateVariantDto>();
            CreateUpdateVariantDto variantDto = new CreateUpdateVariantDto { Price = 250, ValueOPtionA = "brown" };
            CreateUpdateVariantDto variantDto2 = new CreateUpdateVariantDto { Id = existVarinat.Id, Price = existVarinat.Price, ValueOPtionA = existVarinat.ValueOPtionA };
            listVariants.Add(variantDto);
            listVariants.Add(variantDto2);

            var result = await _productAppService.UpdateAsync(
                product.Id,
                new CreateUpdateProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    OptionA = product.OptionA,
                    variants = listVariants
                }
            );
            //Assert
            result.Id.ShouldNotBe(Guid.Empty);
            result.Name.ShouldBe("test update Product with add variant");
            result.OptionA.ShouldBe("color");
            result.variants.Count.ShouldBeGreaterThan(1);
            result.variants.ShouldContain(c => c.Price == 250);
            result.variants.ShouldContain(c => c.ValueOPtionA == "brown");
        }


        [Fact]
        public async Task Should_Update_Product_With_Update_Variant()
        {

        }


        [Fact]
        public async Task Should_Update_Product_With_Removr_Variant()
        {

        }

        [Fact]
        public async Task Should_Update_Product_With_Crud_Variant()
        {

        }

        [Fact]
        public async Task Should_Update_Product_With_Error_Id__Variant()
        {

        }

        /////Delete
        [Fact]
        public async Task Should_Delete_Product()
        {
            //Act
            var product = await _productAppService.CreateAsync(
                new CreateUpdateProductDto
                {
                    Name = "Delete Product",
                    OptionA = "size"
                }
            );

            await _productAppService.DeleteAsync(product.Id);
            
            var result = await _productAppService.GetAsync(product.Id);

            //Assert
            result.ShouldBe(null);
        }

    }
}
