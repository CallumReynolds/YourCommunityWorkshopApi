using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YourCommunityWorkshopWebApi.ViewModels
{
    public class CustomerToolsViewModel
    {
        public int RentalId { get; set; }
        public int RentalToolId { get; set; }    
        public string ToolName { get; set; }
    }
}