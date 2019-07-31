using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using NetApp3.Models;
using NetApp3.Data;
using MongoDB.Bson;

namespace NetApp3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                new DbContext().Customers.InsertOneAsync(
                    new CustomerM()
                    {
                        First = "Afzal",
                        Last = "Virani"
                    }
                    );
                IMongoCollection<CustomerM> c = new DbContext().Customers;
                var d = c.Find(new BsonDocument()).ToListAsync().Result;
                return View(d);
            }
            catch (Exception e)
            {
                return View(new List<CustomerM>() {
                     new CustomerM()
                    {
                        First = "Afzal",
                        Last = "Virani"
                    }
                });
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
