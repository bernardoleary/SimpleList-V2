using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infostructure.SimpleList.BusinessLogic.Repositories;
using Infostructure.SimpleList.DataModel;
using Infostructure.SimpleList.Web.Models;
using Infostructure.SimpleList.Web.Services;
using Infostructure.SimpleList.Web.Models.Mapping;

namespace Infostructure.SimpleList.Web.Controllers
{
    public class UserController : Controller
    {
        public ActionResult LogIn()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public void Register(UserViewModel userViewModel)
        {
            var userRepository = new UserRepository();
            var mapper = new Mapper();
            userRepository.AddUser(mapper.UserViewModelToUser(userViewModel));
            // show a jQuery popup to confirm user registered
        }

        public ActionResult ChangePassword()
        {
            return View("ChangePassword");
        }

        [HttpPost]
        public void ChangePassword(string userName, string oldPassword, string newPassword)
        {
            var userRepository = new UserRepository();
            userRepository.UpdatePassword(userName, oldPassword, newPassword);
            // show a jQuery popup to confirm password changed
        }

        public ActionResult ForgotPassword()
        {
            return View("ForgotPassword");
        }

        [HttpPost]
        public void ForgotPassword(string userName)
        {
            // update the password
            // email the user
            // show a jQuery popup to confirm email sent
        }

        public ActionResult UpdateDetails(int userId)
        {
            var userRepository = new UserRepository();
            var mapper = new Mapper();
            return View("UpdateDetails", mapper.UserToUserViewModel(userRepository.GetUser(userId)));
        }

        [HttpPost]
        public void UpdateDetails(UserViewModel userViewModel)
        {
            var userRepository = new UserRepository();
            var mapper = new Mapper();
            userRepository.UpdateUser(mapper.UserViewModelToUser(userViewModel));
            // show a jQuery popup to confirm details updated
        }
    }
}
