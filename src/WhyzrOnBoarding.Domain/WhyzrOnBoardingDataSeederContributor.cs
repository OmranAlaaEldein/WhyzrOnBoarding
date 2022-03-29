using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using WhyzrOnBoarding.Products;

namespace WhyzrOnBoarding
{
    public class WhyzrOnBoardingDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Product, Guid> _productRepository;
        private readonly IRepository<Variant, Guid> _variantRepository;

        public WhyzrOnBoardingDataSeederContributor(
            IRepository<Product, Guid> ProductRepository,
            IRepository<Variant, Guid> VariantRepository)
        {
            _productRepository = ProductRepository;
            _variantRepository = VariantRepository;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _productRepository.GetCountAsync() > 0)
            {
                return;
            }
            // add Product TShirt with their Variant
            var TShirt = await _productRepository.InsertAsync(
                new Product
                {
                    Name= "TShirt",
                    Name1="قميص",
                    
                    Description= "TShirt to wear", 
                    Description1="قمصان للبس",
                    
                    OptionA="color",
                    OptionA1 = "لون",

                    OptionB = "size",
                    OptionB1 = "حجم"
                }, autoSave: true
                );

            await _variantRepository.InsertAsync(
                new Variant
                {
                    ProductId = TShirt.Id,
                    
                    ValueOPtionA="red",
                    ValueOPtionA1 = "أحمر",

                    ValueOPtionB = "baby",
                    ValueOPtionB1 = "ولادي",

                    Sku="WE3Q",
                    Price=122
                },
                autoSave: true
            );

            await _variantRepository.InsertAsync(
                new Variant
                {
                    ProductId = TShirt.Id,

                    ValueOPtionA = "red",
                    ValueOPtionA1 = "أحمر",

                    ValueOPtionB = "man",
                    ValueOPtionB1 = "رجالي",

                    Sku = "WE3S4",
                    Price = 150
                },
                autoSave: true
            );
            await _variantRepository.InsertAsync(
                new Variant
                {
                    ProductId = TShirt.Id, // SET THE AUTHOR

                    ValueOPtionA = "yallow",
                    ValueOPtionA1 = "أصفر",

                    ValueOPtionB = "baby",
                    ValueOPtionB1 = "ولادي",

                    Sku = "WE3W",
                    Price = 122
                },
                autoSave: true
            );
            await _variantRepository.InsertAsync(
                new Variant
                {
                    ProductId = TShirt.Id, // SET THE AUTHOR

                    ValueOPtionA = "yallow",
                    ValueOPtionA1 = "أصفر",

                    ValueOPtionB = "man",
                    ValueOPtionB1 = "رجالي",

                    Sku = "WE3A",
                    Price = 150
                },
                autoSave: true
            );


            // add Product Shose with their Variant
            var Shose = await _productRepository.InsertAsync(
                new Product
                {
                    Name = "Shose",
                    Name1 = "حذاء",

                    Description = "to wear in feet",
                    Description1 = "للبس في القدم",

                    OptionA = "color",
                    OptionA1 = "لون",

                }, autoSave: true
                );

            await _variantRepository.InsertAsync(
                new Variant
                {
                    ProductId = Shose.Id, // SET THE AUTHOR

                    ValueOPtionA = "black",
                    ValueOPtionA1 = "أسود",
                    
                    Sku = "E3A",
                    Price = 100
                },
                autoSave: true
            );

            await _variantRepository.InsertAsync(
                new Variant
                {
                    ProductId = Shose.Id, // SET THE AUTHOR

                    ValueOPtionA = "brown",
                    ValueOPtionA1 = "بني",

                    Sku = "E3B",
                    Price = 100
                },
                autoSave: true
            );

        }
    }
}
