﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YourCommunityWorkshopWebApi.Models;

namespace YourCommunityWorkshopWebApi.ViewModels
{
    public class CustomerRentalDetailsViewModel
    {
        public Rental Rental { get; set; }
        public string CustomerName { get; set; }
        public List<CustomerToolsViewModel> RentedTools { get; set; }
    }
}