using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infostructure.SimpleList.BusinessLogic.Repositories;
using Infostructure.SimpleList.DataModel;
using Infostructure.SimpleList.Web.Models;


namespace Infostructure.SimpleList.Web.Controllers
{
    public class SimpleListItemController : Controller
    {
        private SimpleListRepository _simpleListRepository = null;
        private SimpleListItemRepository _simpleListItemRepository = null;

        //
        // GET: /SimpleListItem/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Lists/{simpleListId}/ListItems

        public ActionResult Index(int simpleListId)
        {
            string userName = Request.QueryString["userName"];
            string password = Request.QueryString["password"];

            if (User.Identity.IsAuthenticated)
            {
                _simpleListRepository = new SimpleListRepository();
                var simpleList = _simpleListRepository.GetSimpleList(simpleListId);
                return View("Index", simpleList);
            }
            else if (userName != null && password != null)
            {
                _simpleListItemRepository = new SimpleListItemRepository();
                var simpleListItems = _simpleListItemRepository.GetSimpleListItems(simpleListId);
                var mapper = new Models.Mapping.Mapper();
                var simpleListItemsViewModels = mapper.SimpleListItemsToSimpleListItemViewModels(simpleListItems);
                return Json(simpleListItemsViewModels, JsonRequestBehavior.AllowGet);
            }
            else
                return View("Index");
        }

        //
        // GET: /Lists/{simpleListId}/ListItems/Create

        public ActionResult Create(int simpleListId)
        {
            return View("Create", new SimpleListItemViewModel { SimpleListID = simpleListId });
        }

        //
        // POST: /Lists/{simpleListId}/ListItems/Create

        [HttpPost]
        public ActionResult Create(int simpleListId, SimpleListItemViewModel simpleListItemModel)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    var simpleListItem = new SimpleList.DataModel.Models.SimpleListItem();
                    simpleListItem.Description = simpleListItemModel.Description;
                    simpleListItem.SimpleListID = simpleListItemModel.SimpleListID;
                    _simpleListItemRepository = new SimpleListItemRepository();
                    _simpleListItemRepository.AddSimpleListItem(simpleListItem);
                    return RedirectToAction("Index");
                }
                else
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Lists/{simpleListId}/ListItems/Edit/{simpleListItemId}

        public ActionResult Edit(int simpleListItemId)
        {
            _simpleListItemRepository = new SimpleListItemRepository();
            var simpleListItem = _simpleListItemRepository.GetSimpleListItem(simpleListItemId);
            return View("Edit", simpleListItem);
        }

        //
        // GET: /Lists/{simpleListId}/ListItems/Edit/{simpleListItemId}

        [HttpPost]
        public ActionResult EditListItem(int simpleListItemId, SimpleListItemViewModel collection)
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
        // GET: /SimpleListItem/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /SimpleListItem/Delete/5

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
