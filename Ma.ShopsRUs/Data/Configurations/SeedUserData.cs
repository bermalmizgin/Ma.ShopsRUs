using Ma.ShopsRUs.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ma.ShopsRUs.Data.Configurations
{
    public class SeedUserData : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasData
            (
                new
                {
                    UserId = 1,
                    DateCreated = new DateTime(2020, 3, 2, 9, 23, 30, 356, DateTimeKind.Local).AddTicks(7550),
                    Email = "omay@gmail.com",
                    FirstName = "Omay",
                    LastName = "Lahoya",
                    MiddleName = "",
                    PhoneNumber = "0123456789",
                    UserType = "Customer"
                },
                new
                {
                    UserId = 2,
                    DateCreated = new DateTime(2023, 6, 6, 9, 23, 58, 310, DateTimeKind.Local).AddTicks(7655),
                    Email = "lahoya@email.com",
                    FirstName = "Lahoya",
                    LastName = "Bermal",
                    MiddleName = "",
                    PhoneNumber = "012345678910",
                    UserType = "Customer"
                },
                new
                {
                    UserId = 3,
                    DateCreated = new DateTime(2023, 4, 14, 9, 15, 44, 487, DateTimeKind.Local).AddTicks(7663),
                    Email = "mizgin@email.com",
                    FirstName = "Mizgin",
                    LastName = "Aydeniz",
                    MiddleName = "L.",
                    PhoneNumber = "0123456789",
                    UserType = "Affiliate"
                },
                new
                {
                    UserId = 4,
                    DateCreated = new DateTime(2018, 3, 12, 9, 23, 33, 422, DateTimeKind.Local).AddTicks(7667),
                    Email = "sedat@email.com",
                    FirstName = "Sedat",
                    LastName = "Aydeniz",
                    PhoneNumber = "0123456789",
                    UserType = "Employee"
                },
                new
                {
                    UserId = 5,
                    DateCreated = new DateTime(2022, 3, 4, 9, 23, 45, 120, DateTimeKind.Local).AddTicks(7670),
                    Email = "doguhan@email.com",
                    FirstName = "Doguhan",
                    LastName = "Aydeniz",
                    PhoneNumber = "0123456789",
                    UserType = "Employee"
                }
            );
        }
    }
}
