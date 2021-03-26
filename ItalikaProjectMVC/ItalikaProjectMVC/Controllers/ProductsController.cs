using ItalikaProjectMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItalikaProjectMVC.Controllers
{
    public class ProductsController : Controller
    {
        private ItalikaAPI _Api;

        public ProductsController()
        {
            _Api = new ItalikaAPI();
        }

        public async  Task<IActionResult> Index()
        {
            string error = "";
            try
            {
                var lsProducts = await _Api.GetProducts();
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
           

            ViewBag.Products = "";
            ViewBag.message = TempData["error"] ?? error;
            return View();
        }

        public async Task<IActionResult> Create()
        {

            return View();
        }
        public async Task<IActionResult> CreatePost(Models.Product product)
        {
            

            var response = await _Api.CreateProduct(product);

            if (response == null)
            {
                TempData["error"] = "No se pudo crear";
            }


            return View();
        }
    }
}
