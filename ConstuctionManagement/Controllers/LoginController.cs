using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConstuctionManagement.Models;

namespace ConstuctionManagement.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(ConstuctionManagement.Models.tbl_user user)
        {
            using (ConstructionEntities1 db = new ConstructionEntities1())
            {
                var user_details = db.tbl_user.Where(x => x.username == user.username && x.password == user.password).FirstOrDefault();

                if (user_details == null)
                {
                    user.LoginErrorMessage = "Wrong Username or Password";
                    return View("Index", user);
                }
                else
                {
                    Session["UserID"] = user_details.user_id;
                    Session["UserName"] = user_details.username;
                    return RedirectToAction("Index", "Home");
                }

            }
        }

         public ActionResult LogOut()
            {
                int UserID = (int)Session["UserID"];
                Session.Abandon();
                return RedirectToAction("Index", "Login");

            }
        }
 

    }
