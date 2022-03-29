using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace WhyzrOnBoarding.Products
{
    public class VariantDto: AuditedEntityDto<Guid>
    {
        public VariantDto()
        {
        }
        public Guid ProductId { set; get; }

        public string ValueOPtionA { set; get; }
        public string ValueOPtionA1 { set; get; }
        public string ValueOPtionA2 { set; get; }

        public string ValueOPtionB { set; get; }
        public string ValueOPtionB1 { set; get; }
        public string ValueOPtionB2 { set; get; }

        public string ValueOPtionC { set; get; }
        public string ValueOPtionC1 { set; get; }
        public string ValueOPtionC2 { set; get; }

        public string ValueOPtionD { set; get; }
        public string ValueOPtionD1 { set; get; }
        public string ValueOPtionD2 { set; get; }

        public string Sku { set; get; }
        public int Price { set; get; }

        public ProductDto productDto { set; get; }
    }
}
