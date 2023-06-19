using AutoMapper;
using Ma.ShopsRUs.Entities;
using Ma.ShopsRUs.Entities.DTOs;
using Ma.ShopsRUs.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ma.ShopsRUs.Controllers
{
    [Route("api/invoices")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public InvoiceController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{billNumber}")]
        public async Task<IActionResult> GetInvoice(string billNumber)
        {
            if (billNumber == null) return BadRequest();
            var invoice = await _repository.Invoice.GetTotalInvoiceAmount(billNumber, trackChanges: false);
            if (invoice == null) return NotFound();
            var invoiceDto = _mapper.Map<InvoiceDto>(invoice);
            return Ok(invoiceDto.Total);
        }

        [HttpPost]
        public async Task<IActionResult> GenerateInvoiceForACustomer(int userId, [FromBody] CreateInvoiceDto invoiceDto)
        {
            decimal invoiceSubtotal = 0;
            var user = await _repository.User.GetCustomerById(userId, false);
            if (user == null) return NotFound();

            invoiceSubtotal = await ApplyDiscount(invoiceDto, invoiceSubtotal, user);
            var invoiceEntity = _mapper.Map<Invoice>(invoiceDto);
            invoiceEntity.Total = invoiceSubtotal;
            _repository.Invoice.GenerateInvoiceForCustomer(userId, invoiceEntity);
            await _repository.SaveAsync();
            return Ok();
        }

        private async Task<decimal> ApplyDiscount(CreateInvoiceDto invoiceDto, decimal invoiceSubtotal, Users user)
        {
            var discounts = await _repository.Discount.GetAllDiscounts(false);
            foreach (var discount in discounts)
            {
                if (discount.Equals(user.UserType) && discount.IsRatePercentage)
                {
                    var discountValue = invoiceDto.OrderTotal * (discount.Rate / 100);
                    invoiceSubtotal = invoiceDto.OrderTotal - discountValue;
                }

                foreach (var detail in invoiceDto.InvoiceDetails)
                {
                    if (detail.DerivedProductCost >= 100 && !discount.IsRatePercentage)
                    {
                        invoiceSubtotal -= discount.Rate;
                    }
                }
            }

            return invoiceSubtotal;
        }
    }
}
