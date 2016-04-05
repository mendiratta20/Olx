using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OlxAd.Models;
using OlxAd.DataAccessLayer;

namespace OlxAd.Controllers
{    
    
    public class RegistrationController : Controller
    {
        //
        // GET: /Registration/
        public  string userName;
        public  int UserNo;

        public ActionResult Home()
        {
            return View();
        }
        [HttpGet]
        [ActionName("Register")]
        public ActionResult Registration_Get()
        {
            Registration Reg = new Registration( );
            return View("Register", Reg);
        }

        [HttpPost]
        [ActionName("Register")]
        public ActionResult Registration_post(Registration Reg)
        {
            bool result;
            try
            {

                if (ModelState.IsValid)
                {


                    result = new DBData().InsertData(Reg);
                    if (result == true)
                    {
                        TempData["Status"] = "Data Inserted Successfully!";
                       
                    }
                    else
                    {
                        TempData["Status"] = "User Already Exists! Try with differnt User";
                    }

                    return View("Register", Reg);
                    //RedirectToAction("Login");//redirect to home page
                }
                else
                return View("Register", Reg);

            }
            catch
            {
                return View();
            }



        }

        public ActionResult Login()
        {

            return View();     
        }


        [HttpPost, ActionName("Login")]
        public ActionResult Login_Post(Users user)
        {
            bool result;
          //  string username;
           
            try
            {             

                result = new DBData().Validate(user);
                
               
                if (result == true)
                {
                    ViewBag.isVisible = 0;
                    
                    Session["UserName"] = user.Name;
                  
                     Session["UserNo"] = new DBData().FetchUserNo(Session["UserName"].ToString());
                    return View("Home");
                }
                else
                {
                    ViewBag.isVisible = 1;
                    return View("Login");
                }
            }
            catch
            {
                ViewBag.isVisible = 1;
                return View();
            }
        }





    }
}
