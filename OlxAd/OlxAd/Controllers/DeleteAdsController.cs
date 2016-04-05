using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OlxAd.Models;
using OlxAd.DataAccessLayer;
using PagedList;
namespace OlxAd.Controllers
{
    public class DeleteAdsController : Controller
    {
        //
        // GET: /DeleteAds/       
      

        [HttpPost]
        public ActionResult DeleteAds_Post(int id)
        {
            bool result;

          //  IEnumerable<InsertAds> ads = null;
            if (ModelState.IsValid)
            {
              result= new DBData().DeleteDataforADS(id);
               // ads = new DBData().MyAds(Convert.ToInt32(Session["UserNo"]));
                if (result)
                {
                    TempData["Status"] = "Data Deleted Successfully!";

                }
                else
                {
                    TempData["Status"] = "Data cannot be deleted!";

                }



            }
          

            return View("Deleted");
        }      

    }
}
