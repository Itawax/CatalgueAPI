using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using WebAPI.Controllers;
using Newtonsoft.Json;

namespace WebAPI.Test
{
    [TestClass]
    internal class TestCatalogueController
    {
        [TestMethod]
        public void GetAllCatalogueItems()
        {
            List<CatalogueItem> dbData = GetTestProducts();

            HttpClient client = new HttpClient();
            var response = client.GetStringAsync("https://localhost:7070/api/CatalogueItems");

            List<CatalogueItem> responseData = JsonConvert.DeserializeObject<List<CatalogueItem>>(response.Result);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(dbData, responseData);
        }

        [TestMethod]
        public void GetCatalogueItemById(long id)
        {
            List<CatalogueItem> dbData = GetTestProducts();

            HttpClient client = new HttpClient();

            try
            {
                var response = client.GetStringAsync($"https://localhost:7070/api/CatalogueItems/{id}");
                CatalogueItem? item = dbData.FirstOrDefault(x => x.Id == id);

                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(item, JsonConvert.DeserializeObject<CatalogueItem>(response.Result));

            }
            catch
            {
                CatalogueItem? item = dbData.FirstOrDefault(x => x.Id == id);
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(dbData, null);
            }            

        }

        private List<CatalogueItem> GetTestProducts()
        {
            var _context = new CatalogueContext();
            List<CatalogueItem> cItems = _context.CatalogueItems.ToList();

            return cItems;
        }
    }
}
