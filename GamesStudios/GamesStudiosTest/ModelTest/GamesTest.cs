using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using GamesStudios.Models;
using GamesStudios.Helpers;
namespace GamesStudiosTest.ModelTest
{
    [TestClass]
    public class GamesTest
    {
    

        [TestMethod]
        public void WrongURLTest()
        {
            var game = new Game()
            {
                DownloadLink = "xd"
            };
            var result = TestModelHelper.Validate(game);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("The URL is not Valid", result[0].ErrorMessage);
        }

    }
}
