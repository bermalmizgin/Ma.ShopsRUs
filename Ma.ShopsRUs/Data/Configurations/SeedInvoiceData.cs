using Ma.ShopsRUs.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ma.ShopsRUs.Data.Configurations
{
    public class SeedInvoiceData : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasData
            (
                new Invoice
                {
                    InvoiceId = 1,
                    OrderId = 1,
                    InvoiceNumber = "SRU001",
                    UserId = 1, // customer
                    Total = 500,
                },
                new Invoice
                {
                    InvoiceId = 2,
                    OrderId = 2,
                    InvoiceNumber = "SRU002",
                    UserId = 2, // customer
                    Total = 1500,
                },
                new Invoice
                {
                    InvoiceId = 3,
                    OrderId = 3,
                    InvoiceNumber = "SRU003",
                    UserId = 3, // affiliate
                    Total = 990,
                },
                new Invoice
                {
                    InvoiceId = 4,
                    OrderId = 4,
                    InvoiceNumber = "SRU004",
                    UserId = 4, // employee
                    Total = 920,
                }
            );
        }
    }
}
