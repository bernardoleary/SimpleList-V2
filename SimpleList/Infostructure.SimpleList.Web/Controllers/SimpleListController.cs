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

        //
        // GET: /SimpleList/

        public ActionResult Index()
        {
            string userName = Request.QueryString["userName"];
            string password = Request.QueryString["password"];

            if (User.Identity.IsAuthenticated)
            {
                _simpleListRepository = new SimpleListRepository();
                var simpleLists = _simpleListRepository.GetSimpleLists(User.Identity.Name);
                return View("Index", simpleLists);
            }
            else if (userName != null && password != null)
            {
                _simpleListRepository = new SimpleListRepository();
                var simpleLists = _simpleListRepository.GetSimpleLists(userName, password);
                var simpleListsDto = AutoMapper.Mapper.Map<IEnumerable<DataModel.Models.SimpleList>, IEnumerable<Models.SimpleListViewModel>>(simpleLists);
                return Json(simpleListsDto, JsonRequestBehavior.AllowGet);
            }
            else
                return View("Index");
        }

        //
        // GET: /SimpleList/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Lists/Create

        public ActionResult Create()
        {
            return View("Create");
        }

        //
        // POST: /Lists/Create

        [HttpPost]
        public ActionResult Create(SimpleListViewModel simpleListModel)
        {
            try
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
            catch
            {
                return View();
            }
        }

        //
        // GET: /SimpleList/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /SimpleList/Delete/5

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
