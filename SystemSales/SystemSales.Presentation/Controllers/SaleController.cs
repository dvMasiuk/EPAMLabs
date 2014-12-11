using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SystemSales.Application.Contracts.Services;
using SystemSales.Application.TransferObjects;
using SystemSales.Presentation.Models;
using AutoMapper;
using Grid.Mvc.Ajax.GridExtensions;

namespace SystemSales.Presentation.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISaleAppService _saleAppService;

        public SaleController(ISaleAppService saleAppService)
        {
            _saleAppService = saleAppService;
        }

        //
        // GET: /Sale/
        public ActionResult Index()
        {
            var sales = Mapper.Map<IEnumerable<SaleDto>, IEnumerable<SaleModel>>(_saleAppService.GetAll()).AsQueryable();
            var grid = (AjaxGrid<SaleModel>)new AjaxGridFactory().CreateAjaxGrid(sales, 1, false);
            return View(new SaleDataViewModel { SaleGrid = grid });
        }

        //
        // GET: /Sale/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Sale/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Sale/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Sale/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Sale/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Sale/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Sale/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
