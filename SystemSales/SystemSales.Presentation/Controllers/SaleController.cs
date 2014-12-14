using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SystemSales.Application.Contracts.Services;
using SystemSales.Application.TransferObjects;
using SystemSales.Presentation.Authorize;
using SystemSales.Presentation.Models;
using AutoMapper;
using Grid.Mvc.Ajax.GridExtensions;

namespace SystemSales.Presentation.Controllers
{
    [Authorize]
    public class SaleController : Controller
    {
        private readonly ISaleAppService _saleAppService;
        private readonly IManagerAppService _managerAppService;
        private readonly ICustomerAppService _customerAppService;
        private readonly IProductAppService _productAppService;

        public SaleController(ISaleAppService saleAppService, IManagerAppService managerAppService,
            ICustomerAppService customerAppService, IProductAppService productAppService)
        {
            _saleAppService = saleAppService;
            _managerAppService = managerAppService;
            _customerAppService = customerAppService;
            _productAppService = productAppService;
        }

        //
        // GET: /Sale/
        public ActionResult Index()
        {
            var sales = Mapper.Map<IEnumerable<SaleDto>, IEnumerable<SaleViewModel>>(_saleAppService.GetAll()).AsQueryable();
            var grid = (AjaxGrid<SaleViewModel>)new AjaxGridFactory().CreateAjaxGrid(sales, 1, false);
            return View(new SalesDataViewModel { SaleGrid = grid });
        }

        public JsonResult Grid(int? page)
        {
            var sales = Mapper.Map<IEnumerable<SaleDto>, IEnumerable<SaleViewModel>>(_saleAppService.GetAll()).AsQueryable();
            var grid = (AjaxGrid<SaleViewModel>)new AjaxGridFactory().CreateAjaxGrid(sales, page ?? 1, page.HasValue);
            return Json(new { Html = grid.ToJson("_SaleGrid", this), grid.HasItems }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Chart()
        {
            var saleGroups = from sale in _saleAppService.GetAll()
                             group sale by sale.Manager.Name into sGroup
                             select new { ManagerName = sGroup.Key, TotalSum = sGroup.Sum(x => x.Sum) };

            var chartModel = new ChartViewModel()
            {
                XValues = saleGroups.Select(x => x.ManagerName).ToArray(),
                YValues = saleGroups.Select(x => x.TotalSum).ToArray(),
                Width = 600,
                Height = 400,
                Title = "Sales",
                NameSeries = "Total Sum"
            };
            return View(chartModel);
        }

        //
        // GET: /Sale/Create
        [CustomAuthorize(Roles = "Admins")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Sale/Create
        [HttpPost]
        [CustomAuthorize(Roles = "Admins")]
        public ActionResult Create(SaleViewModel svm)
        {
            try
            {
                //Mapper.AssertConfigurationIsValid();
                // TODO: Add insert logic here
                svm.Date = System.DateTime.Now;
                var managerDtos = _managerAppService.SearchByName(svm.Manager.Name);
                if (managerDtos.Any())
                    svm.Manager.Id = managerDtos.First().Id;
                var customerDtos = _customerAppService.SearchByName(svm.Customer.Name);
                if (customerDtos.Any())
                    svm.Customer.Id = customerDtos.First().Id;
                var productDtos = _productAppService.SearchByName(svm.Product.Name);
                if (productDtos.Any())
                    svm.Product.Id = productDtos.First().Id;

                var saleDto = Mapper.Map<SaleViewModel, SaleDto>(svm);
                _saleAppService.Insert(saleDto);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Sale/Edit/5
        [CustomAuthorize(Roles = "Admins")]
        public ActionResult Edit(int id)
        {
            var saleDto = _saleAppService.GetById(id);
            var sale = Mapper.Map<SaleDto, SaleViewModel>(saleDto);
            return View(sale);
        }

        //
        // POST: /Sale/Edit/5
        [HttpPost]
        [CustomAuthorize(Roles = "Admins")]
        public ActionResult Edit(SaleViewModel svm)
        {
            try
            {
                // TODO: Add update logic here
                var saleDto = Mapper.Map<SaleViewModel, SaleDto>(svm);
                _saleAppService.Update(saleDto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Sale/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //
        // POST: /Sale/Delete/5
        [HttpPost]
        [CustomAuthorize(Roles = "Admins")]
        public ActionResult Delete(int id, int? page)
        {
            _saleAppService.Delete(id);
            return Grid(page ?? 1);
        }
    }
}
