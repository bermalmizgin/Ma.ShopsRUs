using AutoMapper;
using Ma.ShopsRUs.Controllers;
using Ma.ShopsRUs.Entities;
using Ma.ShopsRUs.Entities.DTOs;
using Ma.ShopsRUs.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ma.ShopsRUsTests.Controllers
{


    public class InvoiceControllerTests
    {
        private Mapper mapper;
        private InvoiceController controller;
        private Mock<IRepositoryManager> mockRepository;

        public InvoiceControllerTests()
        {
            // Mock Repo
            mockRepository = new Mock<IRepositoryManager>();

            // MapperConfiguration
            IConfigurationProvider configurationProvider = new MapperConfiguration((config) =>
            {
                config.CreateMap<Invoice, InvoiceDto>();
                config.CreateMap<CreateInvoiceDto, Invoice>();
                config.CreateMap<Invoice, CreateInvoiceDto>();
                config.CreateMap<InvoiceDto, Invoice>();
            });

            // Mapper
            mapper = new Mapper(configurationProvider);

            // Controller
            controller = new InvoiceController(mockRepository.Object, mapper);
        }

        [Fact]
        public async void GetInvoiceTest()
        {
            // Setup GetCustomerById
            mockRepository.Setup(a => a.Invoice.GetTotalInvoiceAmount("MARUS01", false)).ReturnsAsync(() => GetMockInvoices().FirstOrDefault());

            // Action
            IActionResult actionResult = await controller.GetInvoice("MARUS01");

            // Result
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var model = Assert.IsAssignableFrom<decimal>(okResult.Value);

            // Assert
            Assert.Equal(500, model);
        }

        [Fact]
        public async void GenerateInvoiceForACustomerTest()
        {
            Invoice invoice = GetMockInvoices().FirstOrDefault();


            // Setup GenerateInvoiceForACustomerTest
            mockRepository.Setup(a => a.Invoice.GenerateInvoiceForCustomer(1, invoice));

            // GetCustomerById
            mockRepository.Setup(a => a.User.GetCustomerById(1, false)).ReturnsAsync(() => new Users() { UserId = 1, UserType = "Customer" });

            // GetCustomerById
            mockRepository.Setup(a => a.Discount.GetAllDiscounts(false)).ReturnsAsync(() => new List<DiscountType>() { new DiscountType() { Id = 3, IsRatePercentage = true, Name = "Loyal Customer Discount", Rate = 5, Type = "Customer" } });

            // Create InvoiceDto
            CreateInvoiceDto invoiceDto = mapper.Map<CreateInvoiceDto>(invoice);

            // Action
            IActionResult actionResult = await controller.GenerateInvoiceForACustomer(1, invoiceDto);

            // Result
            var okResult = Assert.IsType<OkResult>(actionResult);

            // Assert
            Assert.NotNull(okResult);

        }

        #region Helper
        private IEnumerable<Invoice> GetMockInvoices()
        {
            IEnumerable<Invoice> mockUsers = new List<Invoice>()
            {
                new Invoice()
                {
                  DateCreated= new DateTime(2023,06,15),
                  InvoiceId= 1,
                  InvoiceNumber="MARUS01",
                  OrderId= 1,
                  Total=500,
                  UserId= 1,
                  InvoiceDetails = new List<InvoiceDetails>()
                  {
                    new InvoiceDetails()
                    {
                        Id = 1,
                        DerivedProductCost= 40,
                        DiscountPrice=20,
                        InvoiceId= 1,
                        ProductId= 1,
                        ProductName="Jean",
                        ProductPrice= 20,
                        ProductQuantity = 2,
                        TotalDerivedCost= 38
                    }
                  }
            }
            };
            return mockUsers;
        }
        #endregion

    }
}
