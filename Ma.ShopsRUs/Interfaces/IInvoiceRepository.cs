using Ma.ShopsRUs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ma.ShopsRUs.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<Invoice> GetTotalInvoiceAmount(string billNumber, bool trackChanges);
        void GenerateInvoiceForCustomer(int userId, Invoice invoice);
    }
}
