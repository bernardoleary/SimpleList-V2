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
            if (User.Identity.IsAuthenticated)
            {
                _simpleListRepository = new SimpleListRepository();
                var simpleLists = _simpleListRepository.GetSimpleListsByUserName(User.Identity.Name);
                return View("Index", simpleLists);
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
        public ActionResult Create(SimpleListModel simpleListModel)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    _userRepository = new UserRepository();
                    var user = _userRepository.GetUserByUserName(User.Identity.Name);
                    var simpleList = new SimpleList.DataModel.SimpleList();
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
