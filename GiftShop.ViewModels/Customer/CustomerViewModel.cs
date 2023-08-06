﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftShop.Web.ViewModels.Customer
{
    public class CustomerViewModel
    {
        public string UserId { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;

        public string DeliveryCompanyName { get; set; } = null!;    

    }
}