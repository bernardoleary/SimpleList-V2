using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infostructure.SimpleList.BusinessLogic.Repositories;
using Infostructure.SimpleList.DataModel;
using Infostructure.SimpleList.Web.Models;
using Infostructure.SimpleList.Web.Services;

namespace Infostructure.SimpleList.Web.Controllers
{
    public class SimpleListController : Controller
    {
        public ActionResult Index()
        {
            var service = new ApiService();
            return View(service.GetSimpleLists(false));
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(SimpleListViewModel simpleListViewModel)
        {
            var service = new ApiService();
            service.CreateSimpleList(simpleListViewModel);
            return RedirectToAction("Index");
        }
 
        public ActionResult Delete(int simpleListId)
        {
            return View();
        }
    }
}
