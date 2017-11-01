using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PieShop.Controllers;
using PieShop.Models;
using PieShop.ViewModels;
using System.Linq;

namespace UnitTests
{
    [TestCategory("Shopping Cart Tests")]
    [TestClass]
    public class ShoppingCartTests
    {
        ShoppingCart shoppingCart;

        [TestInitialize]
        public void Setup()
        {
            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart(new AppDbContext(new DbContextOptions<AppDbContext>()));

            }
        }
    }
}