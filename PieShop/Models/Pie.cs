using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public class Pie
    {
        /// <summary>
        /// The PieShop sells one or more Pies
        /// </summary>
        /// <remarks>
        /// Shortcut for creating properties: Type prop and press Tab twice
        /// Type Tab to move between fields
        /// Type Enter to move to next line
        /// </remarks>
        public int PieId { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public string AllergyInformation { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string ImageThumbnailUrl { get; set; }

        public bool IsPieOfTheWeek { get; set; }

        public bool InStock { get; set; }

        public int CategoryId { get; set; }

        //virtual for Entity Framework
        public virtual Category Category { get; set; }


    }
}
