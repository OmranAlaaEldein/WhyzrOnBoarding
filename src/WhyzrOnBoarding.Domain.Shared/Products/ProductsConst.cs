using System;
using System.Collections.Generic;
using System.Text;

namespace WhyzrOnBoarding.Products
{
    public static class ProductsConst
    {
        public const int MaxNameLength = 128;
        public const int MaxVariantnLength = 128;
        public const int DefaultPrice = 100;
        public const string DefaultSku = "0000";

        public static class ProductsError
        {
            public const string ErrorIdVariantIsNotExist = "IdVariantIsNotExist";
            public const string ErrorIdSentNotEqualIdInput = "IdSentNotEqualIdInput";
            public const string ErrorIdIsEmpty = "IdIsEmpty";
            public const string ErrorProductNotFound = "ProductNotFound";
            public const string ErrorNewVariantShouldNotHaveId = "NewVariantShouldNotHaveId";
            public const string ErrorResultUpdateException = "ResultUpdateException";
            public const string ErrorResultCreateException = "ResultCreateException";
            public const string ErrorValidationException = "ValidationException"; 

        }
    }
}
