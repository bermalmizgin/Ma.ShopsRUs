using Ma.ShopsRUs.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ma.ShopsRUs.Data.Configurations
{
    public class SeedInvoiceDetailsData : IEntityTypeConfiguration<InvoiceDetails>
    {
        public void Configure(EntityTypeBuilder<InvoiceDetails> builder)
        {
            builder.HasData
            (
                // First customer
                new InvoiceDetails
                {
                    // only loyal customer discount applied here
                    Id = 1,
                    InvoiceId = 1,
                    ProductId = 2,
                    ProductName = "Shoes",
                    ProductPrice = 20,
                    ProductQuantity = 2,
                    DerivedProductCost = 40,
                    DiscountPrice = 2,
                    TotalDerivedCost = 38
                },
                new InvoiceDetails
                {
                    // only price per $100 discount applied here (given that a percentage based discount
                    // has already been applied to this user
                    Id = 2,
                    InvoiceId = 1,
                    ProductId = 4,
                    ProductName = "T-Shirt",
                    ProductPrice = 482,
                    ProductQuantity = 1,
                    DerivedProductCost = 482,
                    DiscountPrice = 20,
                    TotalDerivedCost = 462
                },

                //Second customer (recently joined, and price less than $100)
                // no discount applied
                new InvoiceDetails
                {
                    Id = 3,
                    InvoiceId = 2,
                    ProductId = 40,
                    ProductName = "Glass",
                    ProductPrice = 50,
                    ProductQuantity = 5,
                    DerivedProductCost = 250,
                    DiscountPrice = 0,
                    TotalDerivedCost = 250
                },

                // Affiliate
                new InvoiceDetails
                {
                    // only affiliate discount applied here
                    Id = 4,
                    InvoiceId = 3,
                    ProductId = 3,
                    ProductName = "Glove",
                    ProductPrice = 50,
                    ProductQuantity = 5,
                    DerivedProductCost = 250,
                    DiscountPrice = 25,
                    TotalDerivedCost = 225
                },
               new InvoiceDetails
               {
                   // only price per $100 discount applied here (given that a percentage based discount
                   // has already been applied to this user
                   Id = 5,
                   InvoiceId = 3,
                   ProductId = 5,
                   ProductName = "Dress",
                   ProductPrice = 400,
                   ProductQuantity = 1,
                   DerivedProductCost = 400,
                   DiscountPrice = 20,
                   TotalDerivedCost = 380
               },
               new InvoiceDetails
               {
                   // no discount applied due to:
                   // this user has already had the affiliate discount applied
                   // and price is less than $100
                   Id = 6,
                   InvoiceId = 3,
                   ProductId = 15,
                   ProductName = "Watch",
                   ProductPrice = 77,
                   ProductQuantity = 5,
                   DerivedProductCost = 385,
                   DiscountPrice = 0,
                   TotalDerivedCost = 385
               },

                // Employee
                new InvoiceDetails
                {
                    // Both the percentage based discount and price based discount is 
                    // applied to this user
                    Id = 7,
                    InvoiceId = 4,
                    ProductId = 105,
                    ProductName = "T-Shirt",
                    ProductPrice = 200,
                    ProductQuantity = 5,
                    DerivedProductCost = 1000,
                    DiscountPrice = 80,
                    TotalDerivedCost = 920
                }
            );
        }
    }
}
