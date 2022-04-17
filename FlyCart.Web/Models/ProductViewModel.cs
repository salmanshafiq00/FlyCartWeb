using FlyCart.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FlyCart.Web.Models
{
    public class ProductViewModel
    {
       public Product Products { get; set; }
        public ProductOption ProductOptions { get; set; }
    }
}