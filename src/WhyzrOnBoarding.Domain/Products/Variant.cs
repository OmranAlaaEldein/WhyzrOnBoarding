using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace WhyzrOnBoarding.Products
{
    public class Variant: FullAuditedAggregateRoot<Guid>
    {

        public Variant()
        {

        }
        
        public void sentId(Guid id)
        {
            Id = id;
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

        [Range(0,int.MaxValue)]
        public int Price { set; get; }

        public Product product { set; get; }

    }
}
