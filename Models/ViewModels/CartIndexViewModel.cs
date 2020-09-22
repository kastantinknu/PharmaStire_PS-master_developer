using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmaStire_PS.Models;

namespace PharmaStire_PS.Models.ViewModels
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
