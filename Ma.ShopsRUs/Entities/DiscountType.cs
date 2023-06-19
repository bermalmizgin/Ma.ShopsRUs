using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ma.ShopsRUs.Entities
{
    public class DiscountType
    {
        /// <summary>
        /// Unique (auto)
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Discount name. etc: 
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Discount type. etc: employee, affiliate, customer vs.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Type { get; set; }

        /// <summary>
        /// Discount rate. 
        /// If the user is an employee of the store, he gets a 30% discount
        /// If the user is an affiliate of the store, he gets a 10% discount
        /// If the user has been a customer for over 2 years, he gets a 5% discount.
        /// For every $100 on the bill, there would be a $ 5 discount(e.g. for $ 990, you get $ 45 as a discount).
        /// The percentage based discounts do not apply on groceries.
        /// A user can get only one of the percentage based discounts on a bill.
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(19, 2)")]
        public decimal Rate { get; set; }

        /// <summary>
        /// True  : Rate value percentage (10%)
        /// False : Rate value amount (10$)
        /// </summary>
        public bool IsRatePercentage { get; set; }

    }
}
