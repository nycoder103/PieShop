using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> Categories
        {
            get
            {
                return new List<Category>
                {
                    new Category
                    {
                        CategoryId=1,
                        CategoryName ="Fruit Pies",
                        Description="All Fruity Pies"
                    },

                    new Category
                    {
                        CategoryId=2,
                        CategoryName ="Cheese Cakes",
                        Description="Cheesy All the Way"
                    },

                    new Category
                    {
                        CategoryId=3,
                        CategoryName ="Seasonal Pies",
                        Description="Get in the Mood for Seasonal"
                    }

                };
            }
        }
    }
}
