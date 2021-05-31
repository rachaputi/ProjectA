using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportManagementSystem.Models;
using TransportManagementSystem.ViewModels;

namespace TransportManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Login(AccountViewModel avm)
        {
            if(avm.account.UserName.Equals("Srikanth") && avm.account.Password.Equals("Srikanth@99"))
            {
                //Session["username"] = avm.account.UserName;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                @ViewBag.Message = "Invalid Login Details";
                return View("Index");
            }
           
        }
        public ActionResult Logout()
        {

            return RedirectToAction("Index");
        }

    }
}
