using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.TagHelpers
{
    public class EmailTagHelper: TagHelper
    {
        public string Address { get; set; }

        public string Content { get; set; }
    }
}
