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
    public class SimpleListController : Controller
    {
        private UserRepository _userRepository = null;
        private SimpleListRepository _simpleListRepository = null;

        public ActionResult Index()
        {
            string userName = Request.QueryString["userName"];
            string password = Request.QueryString["password"];

            // collect the simple list data
            _simpleListRepository = new SimpleListRepository();
            IEnumerable<SimpleList.DataModel.Models.SimpleList> simpleLists = null;
            if (User.Identity.IsAuthenticated)
                simpleLists = _simpleListRepository.GetSimpleLists(User.Identity.Name);
            else if (userName != null && password != null)
                simpleLists = _simpleListRepository.GetSimpleLists(userName, password);
            else
                return View("Index");
            var mapper = new Models.Mapping.Mapper();
            var simpleListViewModels = mapper.SimpleListsToSimpleListViewModels(simpleLists, false);

            // present the output
            if (User.Identity.IsAuthenticated)
                return View("Index", simpleListViewModels);
            else if (userName != null && password != null)
                return Json(simpleListViewModels, JsonRequestBehavior.AllowGet);
            else
                return View("Index");
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(SimpleListViewModel simpleListModel)
        {
            if (User.Identity.IsAuthenticated)
            {
                _userRepository = new UserRepository();
                var user = _userRepository.GetUser(User.Identity.Name);
                var simpleList = new SimpleList.DataModel.Models.SimpleList();
                simpleList.Name = simpleListModel.Name;
                simpleList.UserID = user.ID;
                simpleList.DateAdded = DateTime.Now;
                _simpleListRepository = new SimpleListRepository();
                _simpleListRepository.AddSimpleList(simpleList);
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Index");
        }
 
        public ActionResult Delete(int id)
        {
            return View();
        }

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
