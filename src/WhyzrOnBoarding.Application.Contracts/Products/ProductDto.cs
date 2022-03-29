using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;


namespace WhyzrOnBoarding.Products
{
    public class ProductDto : AuditedEntityDto<Guid>
    {
        public ProductDto() { 
        }
        public string Name { set; get; }
        public string Name1 { set; get; }
        public string Name2 { set; get; }

        public string Description { set; get; }
        public string Description1 { set; get; }
        public string Description2 { set; get; }

        public string OptionA { set; get; }
        public string OptionA1 { set; get; }
        public string OptionA2 { set; get; }

        public string OptionB { set; get; }
        public string OptionB1 { set; get; }
        public string OptionB2 { set; get; }

        public string OptionC { set; get; }
        public string OptionC1 { set; get; }
        public string OptionC2 { set; get; }

        public string OptionD { set; get; }
        public string OptionD1 { set; get; }
        public string OptionD2 { set; get; }
        public List<VariantDto> variants { set; get; } 
    }
}
