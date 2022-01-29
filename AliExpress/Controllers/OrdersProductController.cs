using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliExpress.Controllers
{
    public class OrdersProductController : Controller
    {
        private readonly ILogger<AliexpressOrdersProduct> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public OrdersProductController(
            ILogger<AliexpressOrdersProduct> logger,
            IUnitOfWork unitOfWork
            )
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        // GET: OrdersProductController
        public async Task<ActionResult> Index()
        {
            if (HttpContext.Session.GetString("login") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View(await _unitOfWork.AliexpressOrdersProducts.All());
        }

        // GET: OrdersProductController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (HttpContext.Session.GetString("login") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View(await _unitOfWork.AliexpressOrdersProducts.GetByID(id));
        }

        // GET: OrdersProductController/Create
        public ActionResult Create()
        {
            if (HttpContext.Session.GetString("login") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        // POST: OrdersProductController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> AddNewOrdersProduct(AliexpressOrdersProduct orderProduct)
        {
            try
            {
                bool isSuccess = await _unitOfWork.AliexpressOrdersProducts.Add(orderProduct);
                if (isSuccess)
                    await _unitOfWork.CompleteAsync();

                if (isSuccess)
                {
                    return Json(new { status = true, message = "Order Product added successfully!" });
                }
                else
                {
                    return Json(new { status = false, message = "Please check fields value!" });
                }
                //return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return Json(new { status = false, message = ex.Message });
            }
        }

        // GET: OrdersProductController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (HttpContext.Session.GetString("login") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View(await _unitOfWork.AliexpressOrdersProducts.GetByID(id));
        }

        // POST: OrdersProductController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateOrdersProduct(int id, AliexpressOrdersProduct orderProduct)
        {
            try
            {
                if (id != orderProduct.Id)
                    return Json(new { status = false, message = "Bad update request." });

                bool isSuccess = await _unitOfWork.AliexpressOrdersProducts.Update(orderProduct);
                if (isSuccess)
                {
                    await _unitOfWork.CompleteAsync();
                    return Json(new { status = true, message = "Order Product updated successfully!" });
                }

                return Json(new { status = false, message = "Orders product update failed!" });
            }
            catch(Exception ex)
            {
                return Json(new { status = false, message = ex.Message });
            }
        }

        // GET: OrdersProductController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (HttpContext.Session.GetString("login") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View(await _unitOfWork.AliexpressOrdersProducts.GetByID(id));
        }

        // POST: OrdersProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(AliexpressOrdersProduct ordersProduct)
        {
            try
            {
                var ordersProcut = await _unitOfWork.AliexpressOrdersProducts.GetByID(ordersProduct.Id);

                if (ordersProcut == null)
                    return Json(new { status = false, message = "Orders product not found!" });

                bool isSuccess = await _unitOfWork.AliexpressOrdersProducts.Delete(ordersProduct.Id);
                if (isSuccess)
                {
                    await _unitOfWork.CompleteAsync();
                    return Json(new { status = true, message = "Order Product deleted successfully!" });
                }

                return Json(new { status = false, message = "Orders product deleted failed!" });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });
            }
        }
    }
}
