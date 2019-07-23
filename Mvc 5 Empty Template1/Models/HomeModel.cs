using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc_5_Empty_Template1.Models
{
    public class HomeModel
    {
        public HomeModel()
        {
            
        }

        public IList<AccountModel> ActiveAccounts { get; set; }

        public IList<AccountModel> InactiveAccounts { get; set; }

        public IList<AccountModel> OverdueAccounts { get; set; }

    }
}