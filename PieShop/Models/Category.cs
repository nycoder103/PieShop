using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{

    /// <summary>
    /// Used to group Pies by a given name
    /// </summary>
    public class Category
    {

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public List<Pie> Pies { get; set; }

    }
}
