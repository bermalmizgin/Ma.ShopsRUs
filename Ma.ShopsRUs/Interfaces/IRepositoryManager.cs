using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ma.ShopsRUs.Interfaces
{
    public interface IRepositoryManager
    {
        IDiscountRepository Discount { get; }
        IInvoiceRepository Invoice { get; }
        IUserRepository User { get; }

        Task SaveAsync();
    }
}
