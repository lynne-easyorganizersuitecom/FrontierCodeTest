using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc_5_Empty_Template1.Models
{
    public class AccountModel
    {
        public AccountModel()
        {
            
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        [DisplayFormat(DataFormatString = "{0:(###) ###-####}")]
        public string PhoneNumber { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal AmountDue { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime? PaymentDueDate { get; set; }

        public int AccountStatusId { get; set; }

    }
}