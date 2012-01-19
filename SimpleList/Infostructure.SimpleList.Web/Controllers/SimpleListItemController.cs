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
    public class SimpleListItemController : Controller
    {
        public ActionResult Index(int simpleListId)
        {
            var service = new ApiService();
            return View(service.GetSimpleList(simpleListId));
        }

        public ActionResult Create(int simpleListId)
        {
            return View("Create", new SimpleListItemViewModel { SimpleListID = simpleListId });
        }

        [HttpPost]
        public ActionResult Create(SimpleListItemViewModel simpleListItemViewModel)
        {
            var service = new ApiService();
            service.CreateSimpleListItem(simpleListItemViewModel);
            return RedirectToAction("Index", new { simpleListId = simpleListItemViewModel.SimpleListID });
        }

        public ActionResult Delete(int simpleListId, int simpleListItemId)
        {
            var service = new ApiService();
            service.DeleteSimpleListItem(simpleListItemId);
            return View("Index", service.GetSimpleList(simpleListId));                
        }

        public ActionResult ToggleDone(int simpleListId, int simpleListItemId)
        {
            var service = new ApiService();
            service.ToggleDone(simpleListItemId);
            return View("Index", service.GetSimpleList(simpleListId));      
        }
    }
}
