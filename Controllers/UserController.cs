using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace UserRegistration_Entity.Controllers
{
    public class UserController : Controller
    {
        protected UserEntityEntities userEntity = new UserEntityEntities();
        // GET: User
        public ActionResult Index()
        {
            /*UserEntityEntities userEntityEntities = new UserEntityEntities();
            var userlist = userEntityEntities.selectALL().ToList();*/
            return View();
        }

        [HttpPost]
        public ActionResult Index(User users)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("GetInfor",users);
            }
            return View(users);
        }

        public ActionResult GetInfor(User users)
        {

            string name = users.Name;
            string email = users.Email;
            string psw = users.Password;
            userEntity.addUser(name, email, psw);

            UserEntityEntities test = new UserEntityEntities();

            /*test.Users.Add(users);
            test.SaveChanges();*/

            var userlist = test.Users.ToList();
            //var userlist = test.selectALL().ToList();
            return View("GetInfor",userlist);

        }
    }
}