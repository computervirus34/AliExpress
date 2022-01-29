using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliExpress.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ILogger<AliexpressOrder> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public OrdersController(
            ILogger<AliexpressOrder> logger,
            IUnitOfWork unitOfWork
            )
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        // GET: OrdersController
        public async Task<ActionResult> Index()
        {
            if (HttpContext.Session.GetString("login") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View(await _unitOfWork.AliexpressOrders.All());
        }

        // GET: OrdersProductController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (HttpContext.Session.GetString("login") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View(await _unitOfWork.AliexpressOrders.GetByID(id));
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

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> AddNewOrder(AliexpressOrder order)
        {
            try
            {
                bool isSuccess = await _unitOfWork.AliexpressOrders.Add(order);
                if (isSuccess)
                    await _unitOfWork.CompleteAsync();

                if (isSuccess)
                {
                    return Json(new { status = true, message = "Orders added successfully!" });
                }
                else
                {
                    return Json(new { status = false, message = "Orders check fields value!" });
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
            if (HttpContext.Session.GetString("login") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View(await _unitOfWork.AliexpressOrders.GetByID(id));
        }

        // POST: OrdersProductController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateOrders(int id, AliexpressOrder order)
        {
            try
            {
                if (id != order.Id)
                    return Json(new { status = false, message = "Bad update request." });

                bool isSuccess = await _unitOfWork.AliexpressOrders.Update(order);
                if (isSuccess)
                {
                    await _unitOfWork.CompleteAsync();
                    return Json(new { status = true, message = "Order updated successfully!" });
                }

                return Json(new { status = false, message = "Order update failed!" });
            }
            catch (Exception ex)
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
            return View(await _unitOfWork.AliexpressOrders.GetByID(id));
        }

        // POST: OrdersProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(AliexpressOrder order)
        {
            try
            {
                var ord = await _unitOfWork.AliexpressOrders.GetByID(order.Id);

                if (ord == null)
                    return Json(new { status = false, message = "Order not found!" });

                bool isSuccess = await _unitOfWork.AliexpressProducts.Delete(order.Id);
                if (isSuccess)
                {
                    await _unitOfWork.CompleteAsync();
                    return Json(new { status = true, message = "Order deleted successfully!" });
                }

                return Json(new { status = false, message = "Order deleted failed!" });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });
            }
        }
    }
}
