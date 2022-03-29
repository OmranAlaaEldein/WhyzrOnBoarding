using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace WhyzrOnBoarding.Products
{
    public class Product: FullAuditedAggregateRoot<Guid>
    {
        internal Product()
        {

        }
        public void sentId(Guid id)
        {
            Id = id;
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

        public List<Variant> variants { set; get; }

    }
}
