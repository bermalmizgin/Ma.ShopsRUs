using AutoMapper;
using Ma.ShopsRUs.Entities;
using Ma.ShopsRUs.Entities.DTOs;
using Ma.ShopsRUs.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ma.ShopsRUs.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public CustomerController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            IEnumerable<Users> customers = await _repository.User.GetAllCustomers(trackChanges: false);
            var customerDto = _mapper.Map<IEnumerable<CustomerUsersDto>>(customers);
            return Ok(customerDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomers([FromBody] CreateCustomerUserDto userDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userEntity = _mapper.Map<Users>(userDto);
            _repository.User.CreateUser(userEntity, userType: "Customer");
            await _repository.SaveAsync();

            var customerToReturn = _mapper.Map<CustomerUsersDto>(userEntity);
            return CreatedAtRoute("CustomerId", new { Id = customerToReturn.UserId }, customerToReturn);
        }

        [HttpGet("{Id:int}", Name = "CustomerId")]
        public async Task<IActionResult> GetCustomerById(int Id)
        {
            var customer = await _repository.User.GetCustomerById(Id, trackChanges: false);
            if (customer == null) return NotFound();
            var customerDto = _mapper.Map<CustomerUsersDto>(customer);
            return Ok(customerDto);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetCustomerByName(string name)
        {
            var customer = await _repository.User.GetCustomersByName(name.Trim().ToLower(), trackChanges: false);
            if (customer == null) return NotFound();
            var customerDto = _mapper.Map<CustomerUsersDto>(customer);
            return Ok(customerDto);
        }
    }
}
