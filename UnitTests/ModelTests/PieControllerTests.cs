using Microsoft.VisualStudio.TestTools.UnitTesting;
using PieShop.Controllers;
using PieShop.Models;
using PieShop.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class PieControllerTests
    {
        MockPieRepository mockPieRepo;
        MockCategoryRepository mockCategoryRepo;
        PieController pieController;


        [TestInitialize]
        public void Setup()
        {
            if (mockPieRepo == null)
            {
                mockPieRepo = new MockPieRepository();

                mockCategoryRepo = new MockCategoryRepository();

                pieController = new PieController(mockPieRepo, mockCategoryRepo);
            }
            
        }

        [TestMethod]
        public void PieController_Test_List_ReturnsCorrectCountOfPies()
        {
            var viewResult = pieController.List("Fruit Pies");

            var list = viewResult.ViewData.Model as PiesListViewModel;
            
            Assert.AreEqual(2, list.Pies.Count());
            
        }

        [TestMethod]
        public void PieController_Test_List_WithBlankCategory_ReturnsAllPies()
        {
            var viewResult = pieController.List(string.Empty);

            var list = viewResult.ViewData.Model as PiesListViewModel;

            Assert.AreEqual(4, list.Pies.Count());
            Assert.AreEqual("All Pies", list.CurrentCategory);
        }

        [TestMethod]
        public void PieController_Test_List_WithBlankCategory_HasCategorySetToAllPies()
        {
            var viewResult = pieController.List(string.Empty);

            var list = viewResult.ViewData.Model as PiesListViewModel;

            Assert.AreEqual("All Pies", list.CurrentCategory);
        }
    }
}
