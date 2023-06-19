using Ma.ShopsRUs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ma.ShopsRUs.Interfaces
{

    /// <summary>
    /// Discount repository
    /// </summary>
    public interface IDiscountRepository
    {
        /// <summary>
        /// Get all discounts
        /// </summary>
        /// <param name="trackChanges">Track Changes</param>
        /// <returns></returns>
        Task<IEnumerable<DiscountType>> GetAllDiscounts(bool trackChanges);

        /// <summary>
        /// Get discount percentage by type.
        /// </summary>
        /// <param name="type">employee, affiliate, customer vs.</param>
        /// <param name="trackChanges">Track Changes</param>
        /// <returns></returns>
        Task<DiscountType> GetDiscountPercentageByType(string type, bool trackChanges);

        /// <summary>
        /// Create discount
        /// </summary>
        /// <param name="discount"></param>
        void CreateDiscountType(DiscountType discount);
        string DiscountPercentage(DiscountType discount);
    }
}
