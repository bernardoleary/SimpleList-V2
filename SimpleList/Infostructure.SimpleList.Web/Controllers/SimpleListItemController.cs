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
        private bool? _isAspnetAuthenticated = null;

        public ActionResult Index(int simpleListId)
        {
            // we return simple list with the simple list items populated if we're viwing the website
            // else we return just the simple list items
            _isAspnetAuthenticated = this.GetIsAspnetAuthenticated();
            if (_isAspnetAuthenticated.HasValue)
                return GetDataStructureToReturn(simpleListId, _isAspnetAuthenticated.Value);
            return View("Index");
        }

        public ActionResult Create(int simpleListId)
        {
            return View("Create", new SimpleListItemViewModel { SimpleListID = simpleListId });
        }

        [HttpPost]
        public ActionResult Create(int simpleListId, SimpleListItemViewModel simpleListItemModel)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    // create the objects and return the view model
                    var simpleListItem = new SimpleList.DataModel.Models.SimpleListItem();
                    simpleListItem.Description = simpleListItemModel.Description;
                    simpleListItem.SimpleListID = simpleListItemModel.SimpleListID;
                    _simpleListItemRepository = new SimpleListItemRepository();
                    _simpleListItemRepository.AddSimpleListItem(simpleListItem);
                    return RedirectToAction("Index", new { simpleListId = simpleListItemModel.SimpleListID });
                }
                else
                    return RedirectToAction("Index", "SimpleList");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int simpleListId, int simpleListItemId)
        {
            // we return simple list with the simple list items populated if we're viewing the website
            // else we return just the simple list items
            _isAspnetAuthenticated = this.GetIsAspnetAuthenticated();
            if (_isAspnetAuthenticated.HasValue)
            {
                // delete the simple list item
                _simpleListItemRepository = new SimpleListItemRepository();
                _simpleListItemRepository.DeleteSimpleListItem(simpleListItemId);
                return GetDataStructureToReturn(simpleListId, _isAspnetAuthenticated.Value);
            }
            else
                return View("Index");
        }

        public ActionResult ToggleDone(int simpleListId, int simpleListItemId)
        {
            // we return simple list with the simple list items populated if we're viwing the website
            // else we return just the simple list items
            _isAspnetAuthenticated = this.GetIsAspnetAuthenticated();
            if (_isAspnetAuthenticated.HasValue)
            {
                // set  the simple list item
                _simpleListItemRepository = new SimpleListItemRepository();
                _simpleListItemRepository.ToggleSimpleListItemDone(simpleListItemId);
                return GetDataStructureToReturn(simpleListId, _isAspnetAuthenticated.Value);
            }
            else
                return View("Index");
        }

        // this method returns an MVC view if we're in the ASP.NET UI, else a JSON structure
        private ActionResult GetDataStructureToReturn(int simpleListId, bool returnView)
        {
            if (returnView)
            {
                // get the simple list view model
                _simpleListRepository = new SimpleListRepository();
                var simpleList = _simpleListRepository.GetSimpleList(simpleListId);
                var mapper = new Models.Mapping.Mapper();
                var simpleListViewModels = mapper.SimpleListToSimpleListViewModel(simpleList, true);
                return View("Index", simpleList);
            }
            else
            {
                // get the JSON structure to return
                _simpleListItemRepository = new SimpleListItemRepository();
                var simpleListItems = _simpleListItemRepository.GetSimpleListItems(simpleListId);
                var mapper = new Models.Mapping.Mapper();
                var simpleListItemsViewModels = mapper.SimpleListItemsToSimpleListItemViewModels(simpleListItems);
                return Json(simpleListItemsViewModels, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
