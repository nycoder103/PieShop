using Microsoft.VisualStudio.TestTools.UnitTesting;
using PieShop.Controllers;
using PieShop.Models;
using PieShop.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestCategory("Home Controller Tests")]
    [TestClass]
    public class HomeControllerTests
    {
        MockPieRepository mockPieRepo;
        HomeController homeController;


        [TestInitialize]
        public void Setup()
        {
            if (mockPieRepo == null)
            {
                mockPieRepo = new MockPieRepository();

                homeController = new HomeController(mockPieRepo);
            }
            
        }

        [TestMethod]
        public void HomeController_Test_List_ReturnsCorrectCountOfPies()
        {
            var viewResult = homeController.Index();

            var list = viewResult.ViewData.Model as HomeViewModel;
            
            Assert.AreEqual(2, list.PiesOfTheWeek.Count());
            
        }

        [TestMethod]
        public void HomeController_Test_List_ViewResultIsTypeOfHomeViewModel()
        {
            var viewResult = homeController.Index();

            var list = viewResult.ViewData.Model;

            Assert.IsInstanceOfType(list, typeof(HomeViewModel));
        }

    }
}
