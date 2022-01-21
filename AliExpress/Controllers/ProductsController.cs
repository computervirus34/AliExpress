using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliExpress.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger<AliexpressProduct> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(
            ILogger<AliexpressProduct> logger,
            IUnitOfWork unitOfWork
            )
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        // GET: ProductsController
        public async Task<ActionResult> Index()
        {
            var products = await _unitOfWork.AliexpressProducts.All();
            return View(products);
        }

        // GET: OrdersProductController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _unitOfWork.AliexpressProducts.GetByID(id));
        }

        // GET: OrdersProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdersProductController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> AddNewProduct(AliexpressProduct product)
        {
            try
            {
                bool isSuccess = await _unitOfWork.AliexpressProducts.Add(product);
                
                if (isSuccess)
                {
                    await _unitOfWork.CompleteAsync();
                    return Json(new { status = true, message = "Product added successfully!" });
                }
                else
                {
                    return Json(new { status = false, message = "Please check fields value!" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });
            }
        }

        // GET: OrdersProductController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _unitOfWork.AliexpressProducts.GetByID(id));
        }

        // POST: OrdersProductController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateProduct(int id, AliexpressProduct product)
        {
            try
            {
                if (id != product.Id)
                    return Json(new { status = false, message = "Bad update request." });

                bool isSuccess = await _unitOfWork.AliexpressProducts.Update(product);
                if (isSuccess)
                {
                    await _unitOfWork.CompleteAsync();
                    return Json(new { status = true, message = "Product updated successfully!" });
                }

                return Json(new { status = false, message = "Product update failed!" });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });
            }
        }

        // GET: OrdersProductController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _unitOfWork.AliexpressProducts.GetByID(id));
        }

        // POST: OrdersProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(AliexpressProduct product)
        {
            try
            {
                var prod = await _unitOfWork.AliexpressProducts.GetByID(product.Id);

                if (prod == null)
                    return Json(new { status = false, message = "Product not found!" });

                bool isSuccess = await _unitOfWork.AliexpressProducts.Delete(product.Id);
                if (isSuccess)
                {
                    await _unitOfWork.CompleteAsync();
                    return Json(new { status = true, message = "Product deleted successfully!" });
                }

                return Json(new { status = false, message = "Product deleted failed!" });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });
            }
        }
    }
}
