using AutoMapper;
using Ma.ShopsRUs.Entities;
using Ma.ShopsRUs.Entities.DTOs;
using Ma.ShopsRUs.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Ma.ShopsRUs.Controllers.Tests
{
    public class CustomerControllerTests
    {
        private CustomerController controller;
        private Mock<IRepositoryManager> mockRepository;

        public CustomerControllerTests()
        {
            // Mock Repo
           mockRepository = new Mock<IRepositoryManager>();



            // MapperConfiguration
            IConfigurationProvider configurationProvider = new MapperConfiguration((config) => {
                config.CreateMap<Users, CustomerUsersDto>();
                config.CreateMap<CreateCustomerUserDto, Users>();
                config.CreateMap<CustomerUsersDto, Users>();
            });
            
            // Mapper
            IMapper mapper = new Mapper(configurationProvider);

            // Controller
            controller = new CustomerController(mockRepository.Object, mapper);
        }
  

        [Fact]
        public async void GetCustomersTest()
        {

            // Setup GetAllCustomers
            mockRepository.Setup(a => a.User.GetAllCustomers(false)).ReturnsAsync(() => GetMockUsers());

            // Action
            IActionResult actionResult = await controller.GetCustomers();

            // Result
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var model = Assert.IsAssignableFrom<IEnumerable<CustomerUsersDto>>(okResult.Value);

            // Assert
            Assert.Equal(model.Count(), GetMockUsers().Count());
        }

        [Fact]
        public async void GetCustomerByIdTest()
        {
            // Setup GetCustomerById
            mockRepository.Setup(a => a.User.GetCustomerById(1, false)).ReturnsAsync(() => GetMockUsers().FirstOrDefault());



            // Action
            IActionResult actionResult = await controller.GetCustomerById(1);

            // Result
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var model = Assert.IsAssignableFrom<CustomerUsersDto>(okResult.Value);

            // Assert
            Assert.Equal(1, model.UserId);
        }

        [Fact]
        public async void GetCustomerByIdTest_NotFound()
        {

            // Setup GetCustomerByName
            mockRepository.Setup(a => a.User.GetCustomersByName("omay", false)).ReturnsAsync(() => GetMockUsers().FirstOrDefault(a => a.FirstName == "Omay"));

            // Action
            var result = await controller.GetCustomerById(2);

            // Result
            var notFoundResult = Assert.IsType<NotFoundResult>(result);

            // Assert
            Assert.NotNull(notFoundResult);
        }

        [Fact()]
        public async void GetCustomerByNameTest()
        {
            // Setup GetCustomerByName
            mockRepository.Setup(a => a.User.GetCustomersByName("omay", false)).ReturnsAsync(() => GetMockUsers().FirstOrDefault(a => a.FirstName == "Omay"));

            // Action
            IActionResult actionResult = await controller.GetCustomerByName("Omay");

            // Results
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var model = Assert.IsAssignableFrom<CustomerUsersDto>(okResult.Value);
            
            // Assert
            Assert.Equal("Omay  Lahoya", model.FullName);
        }

        [Fact()]
        public async void GetCustomerByNameTest_NotFound()
        {
            // Setup GetCustomerByName
            mockRepository.Setup(a => a.User.GetCustomersByName("omay", false)).ReturnsAsync(() => GetMockUsers().FirstOrDefault(a => a.FirstName == "Omay"));

            // Action
            IActionResult actionResult = await controller.GetCustomerByName("Mizgin");

            // Result
            var notFoundResult = Assert.IsType<NotFoundResult>(actionResult);

            // Assert
            Assert.NotNull(notFoundResult);
        }

        [Fact()]
        public async void CreateCustomersTest()
        {
            // Setup CreateCustomers

            //Users Dto
            CreateCustomerUserDto userDto = new CreateCustomerUserDto();
            userDto.FirstName = "Doğuhan";
            userDto.LastName = "Aydeniz";
            userDto.Email = "doguhan@gmail.com";
            userDto.Address = "Adres";
            userDto.PhoneNumber = "1234567890";
            

            // Action
            IActionResult actionResult = await controller.CreateCustomers(userDto);
            

            // Result
            var okResult = Assert.IsType<CreatedAtRouteResult>(actionResult);

            // Assert
            Assert.Equal(okResult.RouteValues?.FirstOrDefault().Value, 0);
            Assert.NotNull(okResult);
        }

        #region Helper
        private IEnumerable<Users> GetMockUsers()
        {
            IEnumerable<Users> mockUsers = new List<Users>()
            {
                new Users()
                {
                    UserId= 1,
                    UserType="Customer",
                    FirstName = "Omay",
                    LastName = "Lahoya"
                },
                new Users()
                {
                    UserId= 2,
                    UserType="Affilate"
                },

            };
            return mockUsers;
        }
        #endregion

    }
}